<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModMan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtEXEfile = New System.Windows.Forms.TextBox()
        Me.lblGAFile = New System.Windows.Forms.Label()
        Me.lblEXEtype = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbModList = New System.Windows.Forms.ListBox()
        Me.btnLaunch = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'lblVer
        '
        Me.lblVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblVer.AutoSize = true
        Me.lblVer.Location = New System.Drawing.Point(432, 335)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(76, 13)
        Me.lblVer.TabIndex = 12
        Me.lblVer.Text = "2017.01.20.12"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBrowse.Location = New System.Drawing.Point(440, 9)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(68, 24)
        Me.btnBrowse.TabIndex = 47
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = true
        '
        'txtEXEfile
        '
        Me.txtEXEfile.AllowDrop = true
        Me.txtEXEfile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtEXEfile.Location = New System.Drawing.Point(63, 12)
        Me.txtEXEfile.Name = "txtEXEfile"
        Me.txtEXEfile.ReadOnly = true
        Me.txtEXEfile.Size = New System.Drawing.Size(371, 20)
        Me.txtEXEfile.TabIndex = 45
        Me.txtEXEfile.Text = "Drag 'n Drop DARKSOULS.exe here"
        Me.txtEXEfile.WordWrap = false
        '
        'lblGAFile
        '
        Me.lblGAFile.AutoSize = true
        Me.lblGAFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGAFile.Location = New System.Drawing.Point(7, 15)
        Me.lblGAFile.Name = "lblGAFile"
        Me.lblGAFile.Size = New System.Drawing.Size(50, 13)
        Me.lblGAFile.TabIndex = 46
        Me.lblGAFile.Text = "EXE File:"
        '
        'lblEXEtype
        '
        Me.lblEXEtype.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.lblEXEtype.AutoSize = true
        Me.lblEXEtype.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEXEtype.Location = New System.Drawing.Point(7, 335)
        Me.lblEXEtype.Name = "lblEXEtype"
        Me.lblEXEtype.Size = New System.Drawing.Size(88, 13)
        Me.lblEXEtype.TabIndex = 48
        Me.lblEXEtype.Text = "No EXE selected"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = true
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(219, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Mods found:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbModList
        '
        Me.lbModList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lbModList.FormattingEnabled = true
        Me.lbModList.Location = New System.Drawing.Point(162, 79)
        Me.lbModList.Name = "lbModList"
        Me.lbModList.Size = New System.Drawing.Size(181, 225)
        Me.lbModList.TabIndex = 50
        '
        'btnLaunch
        '
        Me.btnLaunch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnLaunch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLaunch.Location = New System.Drawing.Point(197, 326)
        Me.btnLaunch.Name = "btnLaunch"
        Me.btnLaunch.Size = New System.Drawing.Size(88, 24)
        Me.btnLaunch.TabIndex = 51
        Me.btnLaunch.Text = "Launch Mod"
        Me.btnLaunch.UseVisualStyleBackColor = true
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(162, 38)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(181, 23)
        Me.btnUpdate.TabIndex = 79
        Me.btnUpdate.Text = "Update Mod Manager"
        Me.btnUpdate.UseVisualStyleBackColor = true
        Me.btnUpdate.Visible = false
        '
        'frmModMan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 357)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnLaunch)
        Me.Controls.Add(Me.lbModList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblEXEtype)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtEXEfile)
        Me.Controls.Add(Me.lblGAFile)
        Me.Controls.Add(Me.lblVer)
        Me.Name = "frmModMan"
        Me.Text = "Wulf's Dark Souls Mod Manager"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents lblVer As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtEXEfile As TextBox
    Friend WithEvents lblGAFile As Label
    Friend WithEvents lblEXEtype As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lbModList As ListBox
    Friend WithEvents btnLaunch As Button
    Friend WithEvents btnUpdate As Button
End Class
