Public Class ApiConstants



    Private Const Direc As String = "http://localhost:3000/api/v1/"
    Public Const LoginIn As String = Direc + "loginIn"
    Public Const RegisterLogin As String = Direc + "RegisterLogin"
    Public Const RegisterLogout As String = Direc + "RegisterLogout"

    'Informacion de Online
    Public Const ServiceOn As String = Direc + "ServiceOn"
    'Informacion de ventas
    Public Const SalesDateInfo As String = Direc + "SalesDateInfo"
    'Informacion de tasas
    Public Const GetTasas As String = Direc + "GetTasas"
    Public Const CreateTasa As String = Direc + "CreateTasa"
    Public Const UpdateTasa As String = Direc + "UpdateTasa"
    Public Const DeleteTasa As String = Direc + "DeleteTasa"
End Class
