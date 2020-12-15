Public Class Sitio
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Usuario") IsNot Nothing Then
                lblNombreUsuario.Text = CStr(Session("NombreUsuario"))
                lblNombreUsuario.Visible = True
                lblUsuario.Text = CStr(Session("Usuario"))
            Else
                Session.Clear()
                Response.Redirect(ResolveUrl("~/Login.aspx"))
            End If
            Menu()
        End If
    End Sub

    Private Sub Menu()
        Try
            Dim ds_Datos As DataSet
            ds_Datos = capLogica.GenerarMenu(Convert.ToString(Session("Perfil")))
            XDS_Menu.Data = ds_Datos.GetXml
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub MenuPrincipal_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MenuPrincipal.MenuItemClick
        Select Case e.Item.Value
            Case "Salir"
                Response.Expires = 0
                Response.Cookies.Clear()
                Session.Abandon()
                Session.Clear()
                Response.Redirect(ResolveUrl("~/Login.aspx"))
        End Select
    End Sub

End Class