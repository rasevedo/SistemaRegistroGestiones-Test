Public Class Funciones

    Public Function CrearParametro(ByVal pName As String, ByVal pValue As Object, Optional ByVal retorno As Boolean = False) As SqlClient.SqlParameter
        Dim temp As New SqlClient.SqlParameter
        temp.IsNullable = True
        Dim vValue As New Object

        If retorno Then
            temp.ParameterName = pName
            temp.Direction = ParameterDirection.ReturnValue
            temp.SqlDbType = SqlDbType.VarChar
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

    Public Function DevolverStringFormatoLcase(ByVal str_Cadena As String) As String
        DevolverStringFormatoLcase = String.Empty
        Dim bandera As Boolean = False
        Dim a As Integer

        If str_Cadena.Trim.Length > 1 Then
            DevolverStringFormatoLcase = str_Cadena.Substring(0, 1).ToUpper

            For i As Integer = 1 To str_Cadena.Trim.Length - 1
                If str_Cadena.Substring(i, 1) = Space(1) Then
                    bandera = True
                    a = i
                End If

                If bandera Then
                    If a <> i Then
                        DevolverStringFormatoLcase += str_Cadena.Substring(i, 1).ToUpper
                        bandera = False
                    Else
                        DevolverStringFormatoLcase += Space(1)
                    End If
                Else
                    DevolverStringFormatoLcase += str_Cadena.Substring(i, 1).ToLower
                End If
            Next
        Else
            DevolverStringFormatoLcase = str_Cadena.Trim.ToUpper
        End If
    End Function

    Public Function Menu(str_Perfil As String) As DataSet
        Dim a As New ArrayList
        a.Add(CrearParametro("Perfil", str_Perfil))
        Return _Datos.DevuelveProcedimientoAlmacenadoConParametros("palGenerarMenu", a, BaseDatos.NombreBaseDatos)
    End Function

    Public Function ObtenerDescripcionPerfil(str_Perfil As String) As DataSet
        Dim a As New ArrayList
        a.Add(CrearParametro("Perfil", str_Perfil))
        Return _Datos.DevuelveProcedimientoAlmacenadoConParametros("palObtenerDescripcionPerfil", a, BaseDatos.NombreBaseDatos)
    End Function

    Public Function DevolverConsultasSQL(str_SQL As String) As DataSet
        Return _Datos.DevolverConsultasSQL(str_SQL, BaseDatos.NombreBaseDatos)
    End Function


End Class
