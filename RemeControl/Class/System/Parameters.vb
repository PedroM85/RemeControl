Imports RemeControl.MgrFramework

Public Class Parameters

    Public Sub New()
        MyBase.New

    End Sub

    Public Function WebDirec(Value As Int32)
        Dim Direc As String
        If Value = 0 Then
            Direc = "https://unelca.com/api/v1/"
        Else
            Direc = "http://localhost:3000/api/v1/"
        End If
        Return Direc
    End Function
    Public Function GetUrl(Value As Int32) As String
        Return WebDirec(Value)
    End Function

End Class
