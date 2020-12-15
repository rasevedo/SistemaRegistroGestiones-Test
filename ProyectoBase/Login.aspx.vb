Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblVersion.Text += Space(1) + System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString
            Dim dsInfoUsuario As DataSet
            Dim intAplicacion As Integer
            'Consecutivo que genera el Sistema de Control de Accesos y Seguridad
            intAplicacion = 0
            dsInfoUsuario = CType(LoginMEP1.VerificarLogeo(intAplicacion, Nothing), DataSet)
            If dsInfoUsuario IsNot Nothing Then
                If dsInfoUsuario.Tables("tblUsuario").Rows.Count > 0 Then
                    Session("NombreUsuario") = dsInfoUsuario.Tables("tblUsuario").Rows(0).Item("Nombre")
                    Session("CedulaUsuario") = dsInfoUsuario.Tables("tblUsuario").Rows(0).Item("Cedula")
                    Session("Usuario") = dsInfoUsuario.Tables("tblUsuario").Rows(0).Item("Usuario")
                    If dsInfoUsuario.Tables("tblPermisos").Rows.Count > 0 Then
                        Session("Perfil") = dsInfoUsuario.Tables("tblPermisos").Rows(0).Item("vchIdPerfil")

                        If dsInfoUsuario.Tables("tblPermisos").Rows(0).Item("dti_Ult_logeo") Is DBNull.Value Then
                            LoginMEP1.IncluyeLogeo(CStr(Session("Usuario")), intAplicacion)
                            Response.Redirect(ResolveUrl("~MenuPrincipal.aspx"))
                        Else
                            If DateDiff(DateInterval.Day, CDate(dsInfoUsuario.Tables("tblPermisos").Rows(0).Item("dti_Ult_logeo")), CDate(Now.ToShortDateString)) > 30 Then
                                Mensajes("Lleva más de un Mes de Inactividad, comuníquese con el Administrador del Sistema para que le habilite el acceso.")
                            Else
                                LoginMEP1.ActualizaLogeo(CStr(Session("Usuario")), intAplicacion)
                                Response.Redirect(ResolveUrl("~MenuPrincipal.aspx"))
                            End If
                        End If
                    Else
                        Mensajes(CStr(Session("NombreUsuario")) + " | No tiene permisos para esta aplicación")
                    End If
                Else
                    Mensajes("El usuario no existe o se encuentra bloqueado. Consulte a un administrador de la red")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Mensajes(ByVal str_CuerpoMensaje As String)
        Dim str_Mensaje As String
        str_Mensaje = "<script language=JavaScript>"
        str_Mensaje = str_Mensaje + "alert(""" & str_CuerpoMensaje & """);"
        str_Mensaje = str_Mensaje + "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", str_Mensaje)
        End If
    End Sub

End Class