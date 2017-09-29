Imports System.Net
Imports System.Text
Imports System.IO

Public Class Webserver
    Const listenerPrefix As String = "http://*:1701/"
    Dim listener As HttpListener

    Public Sub StartServer()
        listener = New HttpListener
        listener.Prefixes.Add(listenerPrefix)
        listener.Start()
        listener.BeginGetContext(AddressOf RequestWait, Nothing)
    End Sub

    Public Sub StopServer()
        listener.Stop()
    End Sub

    Private Sub RequestWait(ByVal ar As IAsyncResult)
        If Not listener.IsListening Then
            listener.BeginGetContext(AddressOf RequestWait, Nothing)
        End If

        Dim formattedResponse As String = ""
        Dim c As HttpListenerContext = listener.EndGetContext(ar)
        listener.BeginGetContext(AddressOf RequestWait, Nothing)

        Respond(c, HandleCommands(c))
    End Sub

    Private Sub Respond(ByRef c As HttpListenerContext, ByVal response As String)
        Dim buffer() As Byte = Encoding.Unicode.GetBytes(response)

        c.Response.ContentLength64 = buffer.Length
        Dim output As System.IO.Stream = c.Response.OutputStream
        output.Write(buffer, 0, buffer.Length)
        output.Flush()
        output.Close()
    End Sub

    Private Function HandleCommands(ByRef c As HttpListenerContext)
        Dim cmd As String = c.Request.QueryString("command")
        Dim params As String = c.Request.QueryString("cmdlines")
        Try
            If IsNothing(params) Then
                Return CStr(CallByName(New CommandHandler, cmd, Microsoft.VisualBasic.CallType.Method))
            Else
                Return CStr(CallByName(New CommandHandler, cmd, Microsoft.VisualBasic.CallType.Method, params))
            End If

        Catch ex As Exception
            Return "Failed to call " & cmd
        End Try
    End Function

End Class

