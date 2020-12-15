Imports System.Data.SqlClient
Imports CapAccesoDatosSiReGe

Public Class Datos_Gestiones

    Inherits conexion
    Dim cmd As New SqlCommand

    Public Function insertarGestiones(ByVal dts As Entidad_Gestiones) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("insertarGestiones")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@idEmpleados", dts._idEmpleados)
            cmd.Parameters.AddWithValue("@tipoGestiones", dts._tipoGestiones)
            cmd.Parameters.AddWithValue("@cedulaUsuario", dts._cedulaUsuario)
            cmd.Parameters.AddWithValue("@nombreUsuario", dts._nombreUsuario)
            cmd.Parameters.AddWithValue("@tipoUsuario", dts._tipoUsuario)
            cmd.Parameters.AddWithValue("@fechaIngreso", Convert.ToDateTime(dts._fechaIngreso))
            cmd.Parameters.AddWithValue("@confidencialidadGestiones", dts._confidencialidadGestiones)
            cmd.Parameters.AddWithValue("@fuenteGeneradora", dts._fuenteGeneradora)
            cmd.Parameters.AddWithValue("@tipoServicio", dts._tipoServicio)
            cmd.Parameters.AddWithValue("@direccionRegional", dts._direccionRegional)
            cmd.Parameters.AddWithValue("@supervicionGestiones", dts._supervicionGestiones)
            cmd.Parameters.AddWithValue("@nombreCentroEducativo", dts._nombreCentroEducativo)
            cmd.Parameters.AddWithValue("@idUnidad", dts._idUnidad)
            cmd.Parameters.AddWithValue("@idDimension", dts._idDimension)
            cmd.Parameters.AddWithValue("@numeroOficio", dts._numeroOficio)
            cmd.Parameters.AddWithValue("@detalleGestiones", dts._detalleGestiones)
            cmd.Parameters.AddWithValue("@categoriaGestiones", dts._categoriaGestiones)
            cmd.Parameters.AddWithValue("@respuestaGestiones", dts._respuestaGestiones)
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

    Public Function mostrarGestiones() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrarGestiones")
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

    Public Function borrarGestiones(ByVal dts As Entidad_Gestiones) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("eliminarGestiones")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@idGestiones", dts._idGestiones)
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

    Public Function modificarGestiones(ByVal dts As Entidad_Gestiones) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("modificarGestiones")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@idGestiones", dts._idGestiones)
            cmd.Parameters.AddWithValue("@idEmpleados", dts._idEmpleados)
            cmd.Parameters.AddWithValue("@tipoGestiones", dts._tipoGestiones)
            cmd.Parameters.AddWithValue("@cedulaUsuario", dts._cedulaUsuario)
            cmd.Parameters.AddWithValue("@nombreUsuario", dts._nombreUsuario)
            cmd.Parameters.AddWithValue("@tipoUsuario", dts._tipoUsuario)
            cmd.Parameters.AddWithValue("@fechaIngreso", Convert.ToDateTime(dts._fechaIngreso))
            cmd.Parameters.AddWithValue("@confidencialidadGestiones", dts._confidencialidadGestiones)
            cmd.Parameters.AddWithValue("@fuenteGeneradora", dts._fuenteGeneradora)
            cmd.Parameters.AddWithValue("@tipoServicio", dts._tipoServicio)
            cmd.Parameters.AddWithValue("@direccionRegional", dts._direccionRegional)
            cmd.Parameters.AddWithValue("@supervicionGestiones", dts._supervicionGestiones)
            cmd.Parameters.AddWithValue("@nombreCentroEducativo", dts._nombreCentroEducativo)
            cmd.Parameters.AddWithValue("@idUnidad", dts._idUnidad)
            cmd.Parameters.AddWithValue("@idDimension", dts._idDimension)
            cmd.Parameters.AddWithValue("@numeroOficio", dts._numeroOficio)
            cmd.Parameters.AddWithValue("@detalleGestiones", dts._detalleGestiones)
            cmd.Parameters.AddWithValue("@categoriaGestiones", dts._categoriaGestiones)
            cmd.Parameters.AddWithValue("@respuestaGestiones", dts._respuestaGestiones)
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
