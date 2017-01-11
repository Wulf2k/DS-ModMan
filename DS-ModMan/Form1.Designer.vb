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
        Me.SuspendLayout()
        '
        'lblVer
        '
        Me.lblVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVer.AutoSize = True
        Me.lblVer.Location = New System.Drawing.Point(568, 467)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(76, 13)
        Me.lblVer.TabIndex = 12
        Me.lblVer.Text = "2016.12.03.22"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBrowse.Location = New System.Drawing.Point(576, 9)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(68, 24)
        Me.btnBrowse.TabIndex = 47
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtEXEfile
        '
        Me.txtEXEfile.AllowDrop = True
        Me.txtEXEfile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEXEfile.Location = New System.Drawing.Point(63, 12)
        Me.txtEXEfile.Name = "txtEXEfile"
        Me.txtEXEfile.ReadOnly = True
        Me.txtEXEfile.Size = New System.Drawing.Size(507, 20)
        Me.txtEXEfile.TabIndex = 45
        Me.txtEXEfile.Text = "Drag 'n Drop DARKSOULS.exe here"
        Me.txtEXEfile.WordWrap = False
        '
        'lblGAFile
        '
        Me.lblGAFile.AutoSize = True
        Me.lblGAFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGAFile.Location = New System.Drawing.Point(7, 15)
        Me.lblGAFile.Name = "lblGAFile"
        Me.lblGAFile.Size = New System.Drawing.Size(50, 13)
        Me.lblGAFile.TabIndex = 46
        Me.lblGAFile.Text = "EXE File:"
        '
        'frmModMan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 489)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtEXEfile)
        Me.Controls.Add(Me.lblGAFile)
        Me.Controls.Add(Me.lblVer)
        Me.Name = "frmModMan"
        Me.Text = "Wulf's Dark Souls Mod Manager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblVer As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtEXEfile As TextBox
    Friend WithEvents lblGAFile As Label
End Class
