Public Class Funciones

    Dim _Datos As New Acceso_Datos

    Public Function CrearParametro(ByVal pName As String, ByVal pValue As Object, Optional ByVal retorno As Boolean = False) As SqlClient.SqlParameter
        Dim temp As New SqlClient.SqlParameter
        temp.IsNullable = True
        Dim vValue As New Object

        If retorno Then
            temp.ParameterName = pName
            temp.Direction = ParameterDirection.ReturnValue
            temp.SqlDbType = SqlDbType.Int
        Else
            Select Case True
                Case TypeOf pValue Is Integer
                    vValue = If(pValue = Integer.MinValue, System.DBNull.Value, pValue)
                    temp.SqlDbType = SqlDbType.Int
                Case TypeOf pValue Is Long
                    vValue = If(pValue = Long.MinValue, System.DBNull.Value, pValue)
                    temp.SqlDbType = SqlDbType.BigInt
                Case TypeOf pValue Is String AndAlso Len(pValue) <= 5000
                    vValue = If(pValue = String.Empty, System.DBNull.Value, pValue)
                    temp.SqlDbType = SqlDbType.VarChar
                Case TypeOf pValue Is String AndAlso Len(pValue) > 5000
                    vValue = If(pValue = String.Empty, System.DBNull.Value, pValue)
                    temp.SqlDbType = SqlDbType.Text
                Case TypeOf pValue Is Decimal
                    vValue = If(pValue = Decimal.MinValue, System.DBNull.Value, pValue)
                Case TypeOf pValue Is Double
                    vValue = If(pValue = Double.MinValue, System.DBNull.Value, pValue)
                Case TypeOf pValue Is Date
                    vValue = If(pValue = Date.MinValue, System.DBNull.Value, pValue)
                    temp.SqlDbType = SqlDbType.Date
            End Select
            temp.Value = vValue
            temp.ParameterName = pName
        End If

        Return temp
    End Function

    Public Function Menu(str_Perfil As String) As DataSet
        Dim str_Sql As String
        str_Sql = "SELECT A.* FROM tbl_Menu A INNER JOIN tbl_Perfiles_Menu B ON A.int_id_item = B.int_id_item AND B.vch_cod_perfil = '" + str_Perfil + "'"
        Menu = _Datos.Consultas(str_Sql, BaseDatos.NombreBaseDatos)
    End Function

End Class
