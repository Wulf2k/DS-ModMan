Imports System.IO
Imports System.IO.Compression
Imports System.Reflection

Public Class frmModMan

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
    Dim rlslocs As Hashtable = New Hashtable
    Dim jplocs As Hashtable = New Hashtable



    Private Sub frmModMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScanForDarkSoulsDataDir()




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

            If File.Exists(possibleDarkSoulsPath) Then
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
    End Sub

    Sub checkEXE()
        Dim fs = New IO.FileStream(txtEXEfile.Text, IO.FileMode.Open)
        Dim checkVal As Int32

        checkVal = RInt32(fs, &H80)

        Select Case checkVal
            Case &HCE9634B4
                MsgBox("Debug")
            Case &HFC293654
                MsgBox("NA Release")
            Case Else
                MsgBox("Unknown")
        End Select

        fs.Close()
    End Sub

    Function RInt32(fs As Stream, ByVal loc As Integer)
        Dim tmpInt32 As Integer = 0
        Dim byt = New Byte() {0, 0, 0, 0}

        fs.Position = loc

        fs.Read(byt, 0, 4)

        If bigEndian Then byt.Reverse

        tmpInt32 = BitConverter.ToInt32(byt, 0)

        Return tmpInt32
    End Function

End Class
