Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System
Imports System.Diagnostics
Imports System.Security.Principal
Imports System.Drawing.Printing

Public Class UserUtilities
    <DllImport("user32.dll", SetLastError:=True)> Private Shared Function LockWorkStation() As <MarshalAs(UnmanagedType.Bool)> Boolean

    End Function
    Declare Function AddPrinterConnection Lib "winspool.drv" Alias "AddPrinterConnectionA" (ByVal pName As String) As Integer
    Declare Function DeletePrinterConnection Lib "winspool.drv" Alias "DeletePrinterConnectionA" (ByVal pName As String) As Long
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean
    Declare Function GetDefaultPrinter Lib "winspool.drv" Alias "GetDefaultPrinterA" (ByVal pszBuffer() As String, ByVal pcchBuffer As Integer) As Boolean

    Dim retrycounter As Integer = 5

    Private Sub UserUtilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each arg As String In My.Application.CommandLineArgs
            If arg.Equals(My.Resources.LOCK) Then
                LockWorkStation()
            ElseIf arg.StartsWith(My.Resources.MSG) Then
                Dim userbox As New MessageForm
                userbox.UserMessageBox.Text = arg.Substring(10)
                userbox.ShowDialog()
            ElseIf arg.StartsWith(My.Resources.GPUPDATE) Then
                GPUpdate()
            ElseIf arg.StartsWith(My.Resources.PRINTER) Then
                Dim pinfo As New printerInfo
                Dim parg() As String = arg.Substring(10).Split(",")
                pinfo.name = parg(0)
                pinfo.connection = parg(1)
                If parg(2).Equals(My.Resources.PRINTERDEFAULT) Then
                    pinfo.isDefault = True
                Else
                    pinfo.isDefault = False
                End If
                addPrinter(pinfo)

            End If
        Next
        Application.Exit()
    End Sub

    Private Sub GPUpdate()
        Try
            Dim refresher As Process = New Process()
            refresher.StartInfo.Arguments = "/target:user /wait:-1"
            refresher.StartInfo.FileName = "c:\windows\system32\gpupdate.exe"
            refresher.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            refresher.Start()
            refresher.WaitForExit()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddPrinter(ByRef printer As printerInfo)
        Dim ret As Integer = 0
        ret = AddPrinterConnection(printer.connection)
        If ret = 0 Then
            Threading.Thread.Sleep(10000)
            retrycounter = retrycounter - 1
            If retrycounter > 0 Then
                AddPrinter(printer)
            Else

            End If
        Else
            retrycounter = 5
        End If

        If printer.isDefault Then
            SetDefaultPrinter(printer.connection)
        End If

    End Sub
End Class

Public Structure PrinterInfo
    Dim name As String
    Dim connection As String
    Dim isDefault As Boolean
End Structure