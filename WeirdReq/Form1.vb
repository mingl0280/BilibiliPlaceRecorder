'  This Source Code Form Is subject To the terms Of the Mozilla Public
'  License, v. 2.0. If a copy of the MPL was Not distributed with this
'  file, You can obtain one at http: //mozilla.org/MPL/2.0/.

'If it Is Not possible Or desirable To put the notice In a particular
'file, then You may include the notice in a location (such as a LICENSE
'file in a relevant directory) where a recipient would be likely to look
'For such a notice.
Imports Gecko.DOM
Imports Gecko.Events
Imports System.IO
Imports System.Drawing.Imaging
Imports Gecko

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gWebBrowser.Navigate("http://live.bilibili.com/pages/1702/pixel-drawing")
    End Sub

    Dim refCounter As Integer = 0

    Private Sub gWebBrowser_DocumentCompleted(sender As Object, e As GeckoDocumentCompletedEventArgs) Handles gWebBrowser.DocumentCompleted
        Timer1.Interval = 10 * 1000
        If Not Directory.Exists("CanvasSnippets") Then
            Directory.CreateDirectory("CanvasSnippets")
        End If
        Timer1.Start()
        Timer1_Tick(New Object, New EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim obj As GeckoCanvasElement = gWebBrowser.Document.GetElementById("drawing-canvas")
        Dim DataStr As String = obj.ToDataURL("image/png")
        Dim ImageBytes() As Byte = Convert.FromBase64String(DataStr.Substring("data:image/png;base64,".Length))
        Dim Image As Image = Image.FromStream(New MemoryStream(ImageBytes))
        Image.Save("CanvasSnippets\" + getNowTimestamp() + ".png", ImageFormat.Png)
        refCounter = refCounter + 1
        If refCounter Mod 100 = 0 Then
            gWebBrowser.Reload()
        End If
    End Sub

    Private Function getNowTimestamp() As String
        Return Convert.ToInt64(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds()).ToString()
    End Function

    Private Sub SetTimerHandler(sender As Object, e As EventArgs)
        Dim inp = InputBox("Set current interval in seconds:", "Set timer interval", (Timer1.Interval / 1000).ToString)
        If (inp = "") Then
            Return
        End If
        Dim vinp = CInt(inp) * 1000
        If (vinp <> Timer1.Interval) Then
            Timer1.Interval = vinp
        End If
    End Sub

    Private Sub gWebBrowser_ShowContextMenu(sender As Object, e As GeckoContextMenuEventArgs) Handles gWebBrowser.ShowContextMenu
        e.ContextMenu.MenuItems.Add(New MenuItem("Set Timer Interval", New EventHandler(AddressOf SetTimerHandler)))
    End Sub
End Class
