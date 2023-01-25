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
    'Informacion de Socios
    Public Const GetSocios As String = Direc + "GetSocios"
    Public Const CreateSocio As String = Direc + "CreateSocio"
    Public Const UpdateSocio As String = Direc + "UpdateSocio"
    Public Const DeleteSocio As String = Direc + "DeleteSocio"
    'Informacion de Cliente
    Public Const GetCliente As String = Direc + "GetClientes"
    Public Const GetClienteId As String = Direc + "GetCliente"
    Public Const CreateCliente As String = Direc + "CreateCliente"
    Public Const UpdateCliente As String = Direc + "UpdateCliente"
    Public Const DeleteCliente As String = Direc + "DeleteCliente"
    'Informacion de Bancos
    Public Const GetBancos As String = Direc + "GetBancos"
    Public Const GetBancoId As String = Direc + "GetBanco"
    Public Const CreateBanco As String = Direc + "CreateBanco"
    Public Const UpdateBanco As String = Direc + "UpdateBanco"
    Public Const DeleteBanco As String = Direc + "DeleteBanco"
    Public Const GetAccountType As String = Direc + "GetAccountType"
    Public Const GetAccount As String = Direc + "GetAccount"
End Class
