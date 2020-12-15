Public Class Logica

    ''' <summary>
    ''' Genera un parametro SQL con el valor y el formato requerido
    ''' </summary>
    ''' <param name="pName">Nombre del Parametro</param>
    ''' <param name="pValue">Variable que contiene el valor del parametro</param>
    ''' <returns>Retorna el parametro con el nombre y el tipo de valor asignados</returns>
    ''' <remarks></remarks>
    Public Function NuevoParametroSQL(ByVal pName As String, ByVal pValue As Object) As SqlClient.SqlParameter
        Dim temp As New SqlClient.SqlParameter
        temp.IsNullable = True
        Dim vValue As New Object

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
                temp.SqlDbType = SqlDbType.Decimal
            Case TypeOf pValue Is Double
                vValue = If(pValue = Double.MinValue, System.DBNull.Value, pValue)
                temp.SqlDbType = SqlDbType.Float
            Case TypeOf pValue Is DateTime
                vValue = If(pValue = Date.MinValue, System.DBNull.Value, pValue)
                temp.SqlDbType = SqlDbType.DateTime
            Case TypeOf pValue Is Date
                vValue = If(pValue = Date.MinValue, System.DBNull.Value, pValue)
                temp.SqlDbType = SqlDbType.Date
        End Select

        temp.Value = vValue
        temp.ParameterName = pName

        Return temp
    End Function

    ''' <summary>
    ''' Genera un parametro ODBC con el valor y el formato requerido
    ''' </summary>
    ''' <param name="pName">Nombre del Parametro</param>
    ''' <param name="pValue">Variable que contiene el valor del parametro</param>
    ''' <returns>Retorna el parametro con el nombre y el tipo de valor asignados</returns>
    ''' <remarks></remarks>
    Public Function NuevoParametroODBC(ByVal pName As String, ByVal pValue As Object) As Odbc.OdbcParameter
        Dim temp As New Odbc.OdbcParameter
        temp.IsNullable = True
        Dim vValue As New Object

        Select Case True
            Case TypeOf pValue Is Integer
                vValue = If(pValue = Integer.MinValue, System.DBNull.Value, pValue)
                temp.OdbcType = Odbc.OdbcType.Int
            Case TypeOf pValue Is Long
                vValue = If(pValue = Long.MinValue, System.DBNull.Value, pValue)
                temp.OdbcType = Odbc.OdbcType.BigInt
            Case TypeOf pValue Is String AndAlso Len(pValue) <= 5000
                vValue = If(pValue = String.Empty, System.DBNull.Value, pValue)
                temp.OdbcType = Odbc.OdbcType.VarChar
            Case TypeOf pValue Is String AndAlso Len(pValue) > 5000
                vValue = If(pValue = String.Empty, System.DBNull.Value, pValue)
                temp.OdbcType = Odbc.OdbcType.Text
            Case TypeOf pValue Is Decimal
                vValue = If(pValue = Decimal.MinValue, System.DBNull.Value, pValue)
                temp.OdbcType = Odbc.OdbcType.Decimal
            Case TypeOf pValue Is Double
                vValue = If(pValue = Double.MinValue, System.DBNull.Value, pValue)
                temp.OdbcType = Odbc.OdbcType.Double
            Case TypeOf pValue Is DateTime
                vValue = If(pValue = Date.MinValue, System.DBNull.Value, pValue)
                temp.OdbcType = Odbc.OdbcType.DateTime
            Case TypeOf pValue Is Date
                vValue = If(pValue = Date.MinValue, System.DBNull.Value, pValue)
                temp.OdbcType = Odbc.OdbcType.Date
        End Select

        temp.Value = vValue
        temp.ParameterName = pName

        Return temp
    End Function


End Class
