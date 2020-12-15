Public Class WSIntegra2

    Dim _Integra2 As New Integra2.WebIntegra

    Function ObtieneDatosFuncionarioXCed(ByVal str_Cedula As String) As DataTable
        Return _Integra2.ObtieneDatosFuncionarioXCed(str_Cedula)
    End Function

    Function ConsultaNombramientosActivosxFuncionario(ByVal str_Cedula As String) As DataTable
        Return _Integra2.ConsultaNombramientosActivosxFuncionario(str_Cedula)
    End Function

    Public Function WSObtieneDatosCentroEducativoCodigoPresupuestario(ByVal str_Codigo As String) As DataTable
        Dim str_Sql As String
        str_Sql = "WHERE CODIGO_PRESUPUESTRIO='" + str_Codigo + "'"
        Return _Integra2.EjecutaV_CENTROS_EDUCATIVOS(str_Sql)
    End Function

End Class
