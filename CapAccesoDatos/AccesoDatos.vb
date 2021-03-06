﻿Imports System.Configuration
Imports System.Data.SqlClient

Public Class AccesoDatos

    Dim ConexionSQLServer As New SqlClient.SqlConnection

    Public Sub EstablecerCadenaConexion(ByVal int_Conexion As Integer)
        Select Case int_Conexion
            Case 1 'Cadena de conexion a la base de datos
                ConexionSQLServer.ConnectionString = ConfigurationManager.ConnectionStrings("Cnn_NombreConexion").ConnectionString
        End Select
    End Sub

    Public Function EjecutaConsultaSQL(ByVal str_Sql As String, ByVal int_Conexion As Integer) As Boolean

        EstablecerCadenaConexion(int_Conexion)

        Dim SqlCmd As New SqlClient.SqlCommand

        Try
            ConexionSQLServer.Open()
            With SqlCmd
                .Connection = ConexionSQLServer
                .CommandType = CommandType.Text
                .CommandText = str_Sql
                .CommandTimeout = 100000
            End With

            SqlCmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            SqlCmd.Dispose()
            ConexionSQLServer.Close()
            ConexionSQLServer.Dispose()
        End Try

    End Function

    Public Function EjecutaConsulta(ByVal str_Sql As String, ByVal int_Conexion As Integer) As DataSet
        EstablecerCadenaConexion(int_Conexion)

        Dim SqlCmd As New SqlClient.SqlCommand
        Dim SqlDA As New SqlClient.SqlDataAdapter
        Dim SqlDS As New DataSet

        Try
            ConexionSQLServer.Open()

            With SqlCmd
                .Connection = ConexionSQLServer
                .CommandType = CommandType.Text
                .CommandText = str_Sql
                .CommandTimeout = 100000
            End With

            SqlDA.SelectCommand = SqlCmd
            SqlDA.Fill(SqlDS)
            Return SqlDS
        Catch ex As Exception
            Return Nothing
        Finally
            SqlDS.Dispose()
            SqlDS = Nothing
            SqlDA.Dispose()
            SqlDA = Nothing
            SqlCmd.Dispose()
            SqlCmd = Nothing
            ConexionSQLServer.Close()
            ConexionSQLServer.Dispose()
        End Try
    End Function

    Public Function Consultas(ByVal str_Sql As String, ByVal int_Conexion As Integer) As DataSet
        EstablecerCadenaConexion(int_Conexion)

        Dim SqlCmd As New SqlClient.SqlCommand
        Dim SqlDA As New SqlClient.SqlDataAdapter
        Dim SqlDS As New DataSet

        Try
            ConexionSQLServer.Open()

            With SqlCmd
                .Connection = ConexionSQLServer
                .CommandType = CommandType.Text
                .CommandText = str_Sql
                .CommandTimeout = 100000
            End With

            SqlDA.SelectCommand = SqlCmd
            SqlDA.Fill(SqlDS, "resultado")
            Return SqlDS
        Catch ex As Exception
            Return Nothing
        Finally
            SqlDS.Dispose()
            SqlDS = Nothing
            SqlDA.Dispose()
            SqlDA = Nothing
            SqlCmd.Dispose()
            SqlCmd = Nothing
            ConexionSQLServer.Close()
            ConexionSQLServer.Dispose()
        End Try
    End Function

    Public Function DevolverConsultasSQL(ByVal str_Sql As String, ByVal int_Conexion As Integer) As DataSet

        EstablecerCadenaConexion(int_Conexion)

        Dim SqlCmd As New SqlClient.SqlCommand

        Dim SqlDA As New SqlClient.SqlDataAdapter
        Dim SqlDS As New DataSet

        Try
            ConexionSQLServer.Open()

            With SqlCmd
                .Connection = ConexionSQLServer
                .CommandType = CommandType.Text
                .CommandText = str_Sql
                .CommandTimeout = 100000
            End With

            SqlDA.SelectCommand = SqlCmd
            SqlDA.Fill(SqlDS, "resultado")
            Return SqlDS
        Catch ex As Exception
            Return Nothing
        Finally
            SqlDS.Dispose()
            SqlDS = Nothing
            SqlDA.Dispose()
            SqlDA = Nothing
            SqlCmd.Dispose()
            SqlCmd = Nothing
            ConexionSQLServer.Close()
            ConexionSQLServer.Dispose()
        End Try
    End Function

    Public Function EjecutaProcedimientoAlmacenadoRetorno(ByVal str_Procedimiento As String, ByVal pParametros As ArrayList, ByVal int_Conexion As Integer) As Integer

        EstablecerCadenaConexion(int_Conexion)

        Dim SqlCmd As New SqlClient.SqlCommand


        Try
            ConexionSQLServer.Open()

            With SqlCmd
                .Connection = ConexionSQLServer
                .CommandType = CommandType.StoredProcedure
                .CommandText = str_Procedimiento
                .CommandTimeout = 100000
            End With

            For Each vParam As SqlClient.SqlParameter In pParametros
                SqlCmd.Parameters.Add(vParam)

            Next

            SqlCmd.ExecuteScalar()
            Return SqlCmd.Parameters("RETURN_VALUE").Value

        Catch ex As Exception
            Return Nothing
        Finally
            SqlCmd.Dispose()
            SqlCmd = Nothing
            ConexionSQLServer.Close()
        End Try

    End Function

    Public Function EjecutaProcedimientoAlmacenadoSinParametros(ByVal str_Procedimiento As String, ByVal int_Conexion As Integer) As Boolean
        EstablecerCadenaConexion(int_Conexion)

        Dim SqlCmd As New SqlClient.SqlCommand
        Try
            ConexionSQLServer.Open()
            SqlCmd.Connection = ConexionSQLServer
            SqlCmd.CommandText = str_Procedimiento
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandTimeout = 1000

            SqlCmd.ExecuteScalar()
            Return True
        Catch ex As Exception
            Return False
        Finally
            SqlCmd.Dispose()
            ConexionSQLServer.Close()
            ConexionSQLServer.Dispose()
        End Try
    End Function

    Public Function EjecutaProcedimientoAlmacenado(ByVal str_Procedimiento As String, ByVal pParametros As ArrayList, ByVal int_Conexion As Integer) As Boolean
        EstablecerCadenaConexion(int_Conexion)

        Dim SqlCmd As New SqlClient.SqlCommand
        Try
            ConexionSQLServer.Open()
            SqlCmd.Connection = ConexionSQLServer
            SqlCmd.CommandText = str_Procedimiento
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandTimeout = 1000

            For Each vParam As SqlClient.SqlParameter In pParametros
                SqlCmd.Parameters.Add(vParam)
            Next

            SqlCmd.ExecuteScalar()
            Return True
        Catch ex As Exception
            Return False
        Finally
            SqlCmd.Dispose()
            ConexionSQLServer.Close()
            ConexionSQLServer.Dispose()
        End Try
    End Function

    Public Function DevuelveProcedimientoAlmacenadoConParametros(ByVal str_Procedimiento As String, ByVal pParametros As ArrayList, ByVal int_Conexion As Integer) As DataSet
        EstablecerCadenaConexion(int_Conexion)

        Dim SqlCmd As New SqlClient.SqlCommand
        Dim SqlDA As New SqlClient.SqlDataAdapter
        Dim SqlDS As New DataSet

        Try
            ConexionSQLServer.Open()
            SqlCmd.Connection = ConexionSQLServer
            SqlCmd.CommandText = str_Procedimiento
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandTimeout = 1000

            For Each vParam As SqlClient.SqlParameter In pParametros
                SqlCmd.Parameters.Add(vParam)
            Next

            SqlDA.SelectCommand = SqlCmd
            SqlDA.Fill(SqlDS, "resultado")
            Return SqlDS
        Catch ex As Exception
            Return Nothing
        Finally
            SqlCmd.Dispose()
            ConexionSQLServer.Close()
            ConexionSQLServer.Dispose()
        End Try
    End Function

    Public Function DevuelveProcedimientoAlmacenadoSinParametros(ByVal str_Procedimiento As String, ByVal int_Conexion As Integer) As DataSet
        EstablecerCadenaConexion(int_Conexion)

        Dim SqlCmd As New SqlClient.SqlCommand
        Dim SqlDA As New SqlClient.SqlDataAdapter
        Dim SqlDS As New DataSet

        Try
            ConexionSQLServer.Open()
            SqlCmd.Connection = ConexionSQLServer
            SqlCmd.CommandText = str_Procedimiento
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandTimeout = 1000

            SqlDA.SelectCommand = SqlCmd
            SqlDA.Fill(SqlDS, "resultado")
            Return SqlDS
        Catch ex As Exception
            Return Nothing
        Finally
            SqlCmd.Dispose()
            ConexionSQLServer.Close()
            ConexionSQLServer.Dispose()
        End Try
    End Function



End Class








