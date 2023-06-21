Imports System.Runtime.InteropServices

Public Class OperatingSystem
    <StructLayout(LayoutKind.Sequential)>
    Private Structure SYSTEMTIME
        Public wYear As Short
        Public wMonth As Short
        Public wDayOfWeek As Short
        Public wDay As Short
        Public wHour As Short
        Public wMinute As Short
        Public wSecond As Short
        Public wMilliseconds As Short
    End Structure

    Private Declare Function SetSystemTime Lib "kernel32" (ByRef lpSystemTime As SYSTEMTIME) As Boolean

    Public Shared Sub SetDateTime(ByVal dUTCDateTime As Date)
        Dim lpSystemTime As SYSTEMTIME

        With lpSystemTime
            .wYear = dUTCDateTime.Year
            .wMonth = dUTCDateTime.Month
            .wDay = dUTCDateTime.Day
            .wHour = dUTCDateTime.Hour
            .wMinute = dUTCDateTime.Minute
            .wSecond = dUTCDateTime.Second
        End With

        Dim bRet As Boolean = SetSystemTime(lpSystemTime)

        If Not bRet Then
            Throw New Exception("No se puede setear la fecha y hora del sistema")
        End If
    End Sub

End Class
