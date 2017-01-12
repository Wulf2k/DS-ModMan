Imports System.IO
Imports System.IO.Compression
Imports System.Reflection
Imports System.Threading


Public Class frmModMan

    Shared Version As String
    Shared VersionCheckUrl As String = "http://wulf2k.ca/souls/DS-ModMan-ver.txt"

    Shared WithEvents maxProgSnapTimer As System.Timers.Timer
    Public Const RelDarkSoulsDir = "Dark Souls Prepare to Die Edition\DATA"
    Public Const SteamGames_Library = "SteamLibrary\steamapps\common"
    Public Const SteamGames_Main = "Program Files (x86)\Steam\steamapps\common"

    Shared bigEndian = False
    Shared dataPath As String = ""
    Shared progressSnapInterval = 1000
    Shared realCurrentProgress As Integer = 0
    Shared realCurrentProgressMax As Integer = 0

    Dim exelocs As Hashtable
    Dim dbglocs As Hashtable = New Hashtable
    Dim nalocs As Hashtable = New Hashtable
    Dim jplocs As Hashtable = New Hashtable

    Public fs As FileStream
    Public modName As String = ""

    Private Async Sub updatecheck()
        Try
            Dim client As New Net.WebClient()
            Dim content As String = Await client.DownloadStringTaskAsync(VersionCheckUrl)

            Dim lines() As String = content.Split({vbCrLf, vbLf}, StringSplitOptions.None)
            Dim latestVersion = lines(0)
            Dim latestUrl = lines(1)

            If latestVersion > Version.Replace(".", "") Then
                btnUpdate.Tag = latestUrl
                btnUpdate.Visible = True
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub frmModMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Version = lblVer.Text

        Dim oldFileArg As String = Nothing
        For Each arg In Environment.GetCommandLineArgs().Skip(1)
            If arg.StartsWith("--old-file=") Then
                oldFileArg = arg.Substring("--old-file=".Length)
            Else
                MsgBox("Unknown command line arguments")
                oldFileArg = Nothing
                Exit For
            End If
        Next
        If oldFileArg IsNot Nothing Then
            If oldFileArg.EndsWith(".old") Then
                Dim t = New Thread(
                    Sub()
                    Try
                        'Give the old version time to shut down
                        Thread.Sleep(1000)
                        File.Delete(oldFileArg)
                    Catch ex As Exception
                        Me.Invoke(Function() MsgBox("Deleting old version failed: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation))
                    End Try
                End Sub)
                t.Start()
            Else
                MsgBox("Deleting old version failed: Invalid filename ", MsgBoxStyle.Exclamation)
            End If
        End If


        updatecheck()


        InitExeLocs()
        ScanForDarkSoulsDataDir()
        

    End Sub

    Sub InitExeLocs
        nalocs.Add("interroot/val", &HD65C3C)
        nalocs.Add("msb/val", &HD66318)
        nalocs.Add("msb/lookup", &HD907F0)
        nalocs.Add("ffx/name", &HD66BD8)
        nalocs.Add("ffx/val", &HD66BE0)
    End Sub

    Public Sub ScanForDarkSoulsDataDir()

        Dim installDirList = New List(Of String)

        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
        Dim foundMainInstallDir = False
        For Each d In allDrives
            'If we haven't already found a main Steam install, check for that.
            'Otherwise, only check for SteamLibrary on this drive.
            If Not foundMainInstallDir Then
                Dim potentialMainSteamInstall = Path.Combine(d.Name, SteamGames_Main)
                If Directory.Exists(potentialMainSteamInstall) Then
                    'This is likely the main steam installation folder.
                    foundMainInstallDir = True
                    installDirList.Add(potentialMainSteamInstall)
                End If
            End If

            Dim possibleSteamLibDir = Path.Combine(d.Name, SteamGames_Library)
            If Directory.Exists(possibleSteamLibDir) Then
                installDirList.Add(possibleSteamLibDir)
            End If
        Next
        For Each d In installDirList
            Dim possibleDarkSoulsPath = Path.Combine(d, RelDarkSoulsDir)
            Dim exepath = possibleDarkSoulsPath & "\DarkSouls.exe"

            If File.Exists(exepath) Then
                dataPath = possibleDarkSoulsPath
                txtEXEfile.Text = exepath
                checkEXE()
            End If
        Next

    End Sub
    Private Sub txt_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtEXEfile.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub
    Private Sub txt_Drop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtEXEfile.DragDrop
        Dim file() As String = e.Data.GetData(DataFormats.FileDrop)
        txtEXEfile.Text = file(0)

        checkEXE()
    End Sub
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim dlg = New OpenFileDialog()
        Dim dlgResult = DialogResult.Cancel
        Dim fileName = ""

        dlg.CheckFileExists = True
        dlg.CheckPathExists = True
        dlg.Multiselect = False
        dlg.InitialDirectory = Environment.CurrentDirectory
        dlg.Filter = "Executable files (*.exe)|*.exe"
        dlg.SupportMultiDottedExtensions = True
        dlg.Title = "Select Dark Souls EXE"
        dlg.ValidateNames = True
        dlg.AddExtension = True
        dlg.AutoUpgradeEnabled = True
        dlg.FileName = "DARKSOULS.exe"

        dlgResult = dlg.ShowDialog()

        fileName = dlg.FileName

        txtEXEfile.Text = fileName

        checkEXE()
    End Sub
    Sub checkEXE()
        fs = New IO.FileStream(txtEXEfile.Text, IO.FileMode.Open)
        Dim checkVal As Int32

        checkVal = RInt32(&H80)

        Select Case checkVal
            Case &HCE9634B4
                lblEXEtype.text = "Debug EXE selected (Unsupported)"
                exelocs = dbglocs
            Case &HFC293654
                lblEXEtype.text = "NA Release EXE selected"
                exelocs = nalocs
            Case Else
                lblEXEtype.text = "Unknown EXE selected"
        End Select

        fs.Close()

        If lblEXEtype.text = "NA Release EXE selected" Then
            'Create steam_appid.txt so that EXEs can be launched manually
            If Not File.Exists(dataPath & "\steam_appid.txt") Then
                fs = New IO.FileStream(dataPath & "\steam_appid.txt", IO.FileMode.Create)
                fs.Write(System.Text.Encoding.ASCII.GetBytes("211420"), 0, 6)
                fs.Close
            End If
            LoadMods()
        End If

    End Sub

    Sub LoadMods()
        'Create mods folder, if absent
        If Not Directory.Exists(dataPath & "\mods") Then
            Directory.CreateDirectory(dataPath & "\mods")
        End If

        lbModList.Items.Clear
        
        For each d In Directory.GetDirectories(dataPath & "\mods")
            Dim str() as String
            str = d.Split("\")
            
            lbModList.items.add(str(str.Count - 1))
        Next
        If lbModList.Items.Count > 0 Then
            lbModList.SelectedIndex = 0
        End If

    End Sub
    Function RInt32(ByVal loc As Integer) As int32
        Dim tmpInt32 As Int32 = 0
        Dim byt = New Byte() {0, 0, 0, 0}

        fs.Position = loc

        fs.Read(byt, 0, 4)

        If bigEndian Then byt.Reverse

        tmpInt32 = BitConverter.ToInt32(byt, 0)

        Return tmpInt32
    End Function
    Sub WInt32(byval loc As Integer, byval val As Int32)
        fs.Position = loc
        
        Dim byt() as Byte
        byt = BitConverter.GetBytes(val)

        If bigEndian Then byt = byt.Reverse

        fs.Write(byt, 0, 4)
    End Sub
    Sub WUniStrN(byval loc As Integer, byval str As String)
        Dim byt() as byte
        byt = System.Text.Encoding.Unicode.GetBytes(str)
        ReDim Preserve byt(byt.Length)

        fs.Position = loc
        fs.Write(byt,0,byt.length)
    End Sub

    Private Sub btnLaunch_Click(sender As Object, e As EventArgs) Handles btnLaunch.Click
  

        Directory.SetCurrentDirectory(dataPath)

        Dim modInfoPath As String
        modName = lbModList.SelectedItem.ToString
        modInfoPath = dataPath & "\mods\" & modname & "\modinfo.txt"


        If modName = "" Then
            MsgBox("No mod selected.")
            Return
        End If

        If modName.Length > 16 Then
            MsgBox("Mod name must be less than 17 characters.")
            Return
        End If


        Try
            If File.Exists(dataPath & "\darksouls.mod.exe") Then
                File.Delete(dataPath & "\darksouls.mod.exe")
            End If

            File.Copy(dataPath & "\darksouls.exe", dataPath & "\DARKSOULS.mod.exe")
        Catch ex As Exception
            
        End Try
        
        If File.exists(modInfoPath) Then
            Dim modCmds() as String
            modCmds = File.ReadAllLines(modInfoPath)
            
            For each cmd In modCmds
                If cmd.Split(",")(0) = "redirect" Then
                    Try
                        Redirect(cmd.Split(",")(1))
                    Catch ex As Exception
                        MsgBox("Error applying redirect." & Environment.NewLine & ex.Message)
                    End Try
                    
                End If
            Next

            Process.Start(dataPath & "\DARKSOULS.mod.exe")


        Else
            MsgBox("modinfo.txt for " & modName & " not present.")
            Return
        End If
    End Sub

    Sub Redirect(byval redir As string)
        fs = New IO.FileStream(dataPath & "\DARKSOULS.mod.exe", FileMode.Open)

        Select Case redir.ToLower
            Case "msb"
                WUniStrN(exelocs("interroot/val"), "mods/" & modName)
                WUniStrN(exelocs("msb/val"), "mod:/msb")
                WUniStrN(exelocs("msb/lookup"), "msb:/%s.msb")
                WUniStrN(exelocs("ffx/name"), "mod")
                WUniStrN(exelocs("ffx/val"), "interroot:/")
        End Select

        fs.Close
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim updateWindow As New UpdateWindow(sender.tag)
        updateWindow.ShowDialog()
        If updateWindow.WasSuccessful Then
            Process.Start(updateWindow.NewAssembly, """--old-file=" & updateWindow.OldAssembly & """")
            Me.Close()
        End If
    End Sub
End Class
