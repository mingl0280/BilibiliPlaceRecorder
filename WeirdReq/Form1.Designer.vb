'  This Source Code Form Is subject To the terms Of the Mozilla Public
'  License, v. 2.0. If a copy of the MPL was Not distributed with this
'  file, You can obtain one at http: //mozilla.org/MPL/2.0/.

'If it Is Not possible Or desirable To put the notice In a particular
'file, then You may include the notice in a location (such as a LICENSE
'file in a relevant directory) where a recipient would be likely to look
'For such a notice.
Imports Gecko
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub



    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.gWebBrowser = New Gecko.GeckoWebBrowser()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'gWebBrowser
        '
        Me.gWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gWebBrowser.FrameEventsPropagateToMainWindow = False
        Me.gWebBrowser.Location = New System.Drawing.Point(0, 0)
        Me.gWebBrowser.Name = "gWebBrowser"
        Me.gWebBrowser.Size = New System.Drawing.Size(1853, 1023)
        Me.gWebBrowser.TabIndex = 0
        Me.gWebBrowser.UseHttpActivityObserver = False
        '
        'Timer1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1853, 1023)
        Me.Controls.Add(Me.gWebBrowser)
        Me.Name = "Form1"
        Me.Text = "Bilibili Place Recorder"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gWebBrowser As GeckoWebBrowser
    Friend WithEvents Timer1 As Timer
End Class
