Module VariablesGlobales

    Public ConexionSQLServer As New SqlClient.SqlConnection

    Public _Funciones As New CapLogicaSiReGe.Funciones

    Public _WSIntegra2 As New CapLogicaSiReGe.Integra2.WebIntegra
    Public _WSSigrh As New CapLogicaSiReGe.SIGRH.WebSigrh

    Enum BaseDatos
        NombreBaseDatos = 1
    End Enum

End Module
