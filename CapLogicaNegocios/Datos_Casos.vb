Imports System.Data.SqlClient
Imports CapAccesoDatosSiReGe

Public Class Datos_Casos

    Inherits conexion
    Dim cmd As New SqlCommand
    Public Function insertarCasos(ByVal dts As Entidad_Casos) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("insertarCasos")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@numeroCasos", dts._numeroCasos)
            cmd.Parameters.AddWithValue("@estadoCasos", dts._estadoCasos)
            cmd.Parameters.AddWithValue("@fechaCasos", Convert.ToDateTime(dts._fechaCasos))
            cmd.Parameters.AddWithValue("@cedulaDenuncianteCasos", dts._cedulaDenuncianteCasos)
            cmd.Parameters.AddWithValue("@nombreDenucianteCasos", dts._nombreCentroEducativo)
            cmd.Parameters.AddWithValue("@idEmpleados", dts._idEmpleados)
            cmd.Parameters.AddWithValue("@nombreCentroEducativo", dts._nombreCentroEducativo)
            cmd.Parameters.AddWithValue("@idUnidad", dts._idUnidad)
            cmd.Parameters.AddWithValue("@numeroOficio", dts._numeroOficio)
            cmd.Parameters.AddWithValue("@fechaOficio", Convert.ToDateTime(dts._fechaOficio))
            cmd.Parameters.AddWithValue("@idDimension", dts._idDimension)
            cmd.Parameters.AddWithValue("@condicionCasos", dts._condicionCasos)
            cmd.Parameters.AddWithValue("@detalleInconformidadCasos", dts._detalleInconformidadCasos)
            cmd.Parameters.AddWithValue("@respuestaCasos", dts._respuestaCasos)
            cmd.Parameters.AddWithValue("@valoracionAdmisibilidad", dts._valoracionAdmisibilidad)
            cmd.Parameters.AddWithValue("@veredictoValoracionIngreso", dts._veredictoValoracionIngreso)
            cmd.Parameters.AddWithValue("@trazabilidadCasos", dts._trazabilidadCasos)
            cmd.Parameters.AddWithValue("@fechaRespuestaCasos", Convert.ToDateTime(dts._fechaRespuestaCasos))
            cmd.Parameters.AddWithValue("@fechaCerradoCasos", Convert.ToDateTime(dts._fechaCerradoCasos))
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

    Public Function mostrarCasos() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrarCasos")
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

    Public Function borrarCasos(ByVal dts As Entidad_Casos) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("eliminarCasos")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@idCasos", dts._idCasos)
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

    Public Function modificarCasos(ByVal dts As Entidad_Casos) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("modificarCasos")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@idCasos", dts._idCasos)
            cmd.Parameters.AddWithValue("@numeroCasos", dts._numeroCasos)
            cmd.Parameters.AddWithValue("@estadoCasos", dts._estadoCasos)
            cmd.Parameters.AddWithValue("@fechaCasos", Convert.ToDateTime(dts._fechaCasos))
            cmd.Parameters.AddWithValue("@cedulaDenuncianteCasos", dts._cedulaDenuncianteCasos)
            cmd.Parameters.AddWithValue("@nombreDenucianteCasos", dts._nombreCentroEducativo)
            cmd.Parameters.AddWithValue("@idEmpleados", dts._idEmpleados)
            cmd.Parameters.AddWithValue("@nombreCentroEducativo", dts._nombreCentroEducativo)
            cmd.Parameters.AddWithValue("@idUnidad", dts._idUnidad)
            cmd.Parameters.AddWithValue("@numeroOficio", dts._numeroOficio)
            cmd.Parameters.AddWithValue("@fechaOficio", Convert.ToDateTime(dts._fechaOficio))
            cmd.Parameters.AddWithValue("@idDimension", dts._idDimension)
            cmd.Parameters.AddWithValue("@condicionCasos", dts._condicionCasos)
            cmd.Parameters.AddWithValue("@detalleInconformidadCasos", dts._detalleInconformidadCasos)
            cmd.Parameters.AddWithValue("@respuestaCasos", dts._respuestaCasos)
            cmd.Parameters.AddWithValue("@valoracionAdmisibilidad", dts._valoracionAdmisibilidad)
            cmd.Parameters.AddWithValue("@veredictoValoracionIngreso", dts._veredictoValoracionIngreso)
            cmd.Parameters.AddWithValue("@trazabilidadCasos", dts._trazabilidadCasos)
            cmd.Parameters.AddWithValue("@fechaRespuestaCasos", Convert.ToDateTime(dts._fechaRespuestaCasos))
            cmd.Parameters.AddWithValue("@fechaCerradoCasos", Convert.ToDateTime(dts._fechaCerradoCasos))
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
