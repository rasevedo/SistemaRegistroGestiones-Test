Imports System.Data.SqlClient
Imports CapAccesoDatosSiReGe

Public Class Datos_Usuario

    Inherits conexion
    Dim cmd As New SqlCommand

    Public Function validarUsuario(ByVal dts As Entidad_Usuario) As DataTable
        conectado()
        cmd = New SqlCommand("IniciarSesion")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cnn
        cmd.Parameters.AddWithValue("@Usuario", dts._users)
        cmd.Parameters.AddWithValue("@Contrasena", dts._passwords)
        If cmd.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function

End Class