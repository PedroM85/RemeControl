
Public Class ApiConstants




    Public Const LoginIn As String = "loginIn"
    Public Const RegisterLogin As String = "RegisterLogin"
    Public Const RegisterLogout As String = "RegisterLogout"

    'Informacion de Online
    Public Const ServiceOn As String = "ServiceOn"

#Region "Informacion de ventas in Openning.controller"

    Public Const PostSalesDateInfo As String = "PostSalesDateInfo"

    Public Const PostSessionPerSaleDate As String = "PostSessionPerSalesDate"

    Public Const PostOpenSalesDate As String = "PostOpenSalesDate"

    Public Const PostCloseSession As String = "PostCloseSession"

    Public Const PostSessionInfo As String = "PostSessionInfo"

    Public Const GetIsOpenning As String = "isopen"

#End Region
#Region "Informacion SalesSession in Salessession.controller"

    Public Const CreateOpenSalesDate As String = "PostOpenSalesDate"

    Public Const CreateCloseSalesDate As String = "PostCloseSalesDate"

    Public Const PostSessionPaymentType As String = "PostPaymentTypePerSession"

    Public Const GetCounter As String = "GetCounter"

#End Region
    'Informacion de tasas
    Public Const GetTasas As String = "GetTasas"
    Public Const PostTasaCliente As String = "PostTasaCliente"
    Public Const GetTasaMayo As String = "GetTasaMayo"
    Public Const CreateTasa As String = "CreateTasa"
    Public Const UpdateTasa As String = "UpdateTasa"
    Public Const DeleteTasa As String = "DeleteTasa"
    'Informacion de Socios
    Public Const GetSocios As String = "GetSocios"
    Public Const CreateSocio As String = "CreateSocio"
    Public Const UpdateSocio As String = "UpdateSocio"
    Public Const DeleteSocio As String = "DeleteSocio"
    'Informacion de Cliente
    Public Const GetCliente As String = "GetClientes"
    Public Const GetClienteId As String = "GetCliente"
    Public Const CreateCliente As String = "CreateCliente"
    Public Const UpdateCliente As String = "UpdateCliente"
    Public Const DeleteCliente As String = "DeleteCliente"
    'Informacion de Bancos
    Public Const GetBancos As String = "GetBancos"
    Public Const GetBancoId As String = "GetBanco"
    Public Const CreateBanco As String = "CreateBanco"
    Public Const UpdateBanco As String = "UpdateBanco"
    Public Const DeleteBanco As String = "DeleteBanco"
    Public Const GetAccountType As String = "GetAccountType"
    Public Const GetAccount As String = "GetAccount"
    'Informacion de Cambios
    Public Const GetCambios As String = "GetCambio"
    Public Const GetStatus As String = "GetStatus"
    Public Const CreateCambio As String = "CreateCambio"
    Public Const UpdateCambio As String = "UpdateCambio"
    Public Const DeleteCambio As String = "DeleteCambio"
    'Informacion de dashboard
    Public Const GetCambiosDiarios As String = "PostDashboard"
    Public Const GetTotalInfo As String = "TotalInfo"
    'Informacion de Gasto
    Public Const GetGasto As String = "GetGasto"
    Public Const CreateGasto As String = "CreateGasto"
    Public Const UpdateGasto As String = "UpdateGasto"
    Public Const DeleteGasto As String = "DeleteGasto"
    'Informacion BancoSocio
    Public Const GetBancoSocio As String = "GetBancoSo"
    Public Const GetBancoSoType As String = "GetBancoSoType"
    Public Const CreateBancoSo As String = "CreateBancoSo"
    Public Const UpdateBancoSo As String = "UpdateBancoSo"
    Public Const DeleteBancoSocio As String = "DeleteBancoSo"


End Class
