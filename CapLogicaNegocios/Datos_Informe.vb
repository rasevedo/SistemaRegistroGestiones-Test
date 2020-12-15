Imports System.Data.SqlClient
Imports CapAccesoDatosSiReGe

Public Class Datos_Informe

    Inherits conexion
    Dim cmd As New SqlCommand

    Public Function insertarInforme(ByVal dts As Entidad_Informe) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("insertarInforme")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@tituloInforme", dts._tituloInforme)
            cmd.Parameters.AddWithValue("@idEmpleados", dts._idEmpleados)
            cmd.Parameters.AddWithValue("@tipoInforme", dts._tipoInforme)
            cmd.Parameters.AddWithValue("@numeroOficio", dts._numeroOficio)
            cmd.Parameters.AddWithValue("@fechaAprobacion", dts._fechaAprobacion)
            cmd.Parameters.AddWithValue("@fechaCulminacion", dts._fechaCulminacion)
            cmd.Parameters.AddWithValue("@fechaTraslado", dts._fechaTraslado)
            cmd.Parameters.AddWithValue("@avanceInforme", dts._avanceInforme)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrarInforme() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrarInforme")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function borrarInforme(ByVal dts As Entidad_Informe) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("eliminarInforme")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@idInforme", dts._idInforme)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function modificarInforme(ByVal dts As Entidad_Informe) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("modificarInforme")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@idInforme", dts._idInforme)
            cmd.Parameters.AddWithValue("@tituloInforme", dts._tituloInforme)
            cmd.Parameters.AddWithValue("@idEmpleados", dts._idEmpleados)
            cmd.Parameters.AddWithValue("@tipoInforme", dts._tipoInforme)
            cmd.Parameters.AddWithValue("@numeroOficio", dts._numeroOficio)
            cmd.Parameters.AddWithValue("@fechaAprobacion", dts._fechaAprobacion)
            cmd.Parameters.AddWithValue("@fechaCulminacion", dts._fechaCulminacion)
            cmd.Parameters.AddWithValue("@fechaTraslado", dts._fechaTraslado)
            cmd.Parameters.AddWithValue("@avanceInforme", dts._avanceInforme)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function




End Class

