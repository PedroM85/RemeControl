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
    Public Const GetTasaCliente As String = Direc + "GetTasaCliente"
    Public Const GetTasaMayo As String = Direc + "GetTasaMayo"
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
    'Informacion de Cambios
    Public Const GetCambios As String = Direc + "GetCambio"
    Public Const GetStatus As String = Direc + "GetStatus"
    Public Const CreateCambio As String = Direc + "CreateCambio"
    Public Const UpdateCambio As String = Direc + "UpdateCambio"
    Public Const DeleteCambio As String = Direc + "DeleteCambio"
    'Informacion de dashboard
    Public Const GetCambiosDiarios As String = Direc + "PostDashboard"
    Public Const GetTotalInfo As String = Direc + "TotalInfo"
    'Informacion de Gasto
    Public Const Pong As String = Direc + "pong"
    'Informacion BancoSocio
    Public Const GetBancoSocio As String = Direc + "GetBancoSo"
    Public Const GetBancoSoType As String = Direc + "GetBancoSoType"
    Public Const CreateBancoSo As String = Direc + "CreateBancoSo"
    Public Const UpdateBancoSo As String = Direc + "UpdateBancoSo"
    Public Const DeleteBancoSocio As String = Direc + "DeleteBancoSo"
End Class
