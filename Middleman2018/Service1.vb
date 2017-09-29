Public Class Service1
    Dim ws As New Webserver()
    Protected Overrides Sub OnStart(ByVal args() As String)
        ws.StartServer()
    End Sub

    Protected Overrides Sub OnStop()
        ws.StopServer()
    End Sub

End Class
