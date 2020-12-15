Imports System.Data.SqlClient
Imports CapAccesoDatosSiReGe

Public Class Datos_AvanceCasos

    Inherits conexion
    Dim cmd As New SqlCommand
    Public Function insertarAvancesCasos(ByVal dts As Entidad_AvanceCasos) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("insertarAvanceCasos")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@idCasos", dts._idCasos)
            cmd.Parameters.AddWithValue("@detalleAvance", dts._detalleAvance)
            cmd.Parameters.AddWithValue("@fechaAvance", Convert.ToDateTime(dts._fechaAvance))
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


    Public Function mostrarAvanceCasos() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrarAvancesCasos")
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

End Class
