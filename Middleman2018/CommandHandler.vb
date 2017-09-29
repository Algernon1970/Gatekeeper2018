Public Class CommandHandler

    Public Function GetVersion() As String
        Return "Version 2018.1"
    End Function

    Public Function Test(ByVal cmdline As String) As String
        Return "Test got " & cmdline
    End Function

End Class
