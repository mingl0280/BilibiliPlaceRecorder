Imports Gecko.DOM
Imports Gecko.Events
Imports System.IO
Imports System.Drawing.Imaging

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

End Class
