Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblVersion.Text = "Versión del Sistema:" + Space(1) + System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString

        If Not Page.IsPostBack Then
            If Session("Usuario") IsNot Nothing Then
                lblNombreUsuario.Text = CStr(Session("NombreUsuario"))
                lblNombreUsuario.Visible = True
                lblUsuario.Text = CStr(Session("Usuario"))
                lblPerfil.Text = "Perfil: " + Session("Perfil")
            Else
                Session.Clear()
                Response.Redirect(ResolveUrl("~/Login.aspx"))
            End If
            Menu()
            DescripcionPerfil()
        End If

    End Sub

    Private Sub Mensajes(ByVal str_CuerpoMensaje As String)
        Dim str_Mensaje As String
        str_Mensaje = "<script language=JavaScript>"
        str_Mensaje = "alert(""" & str_CuerpoMensaje & """);"
        str_Mensaje = str_Mensaje + "</script>"
        ScriptManager.RegisterClientScriptBlock(Me, GetType(MasterPage), "", str_Mensaje, True)
    End Sub

    Private Sub DescripcionPerfil()
        Dim dt_Datos As DataTable
        dt_Datos = _Funciones.ObtenerDescripcionPerfil(Convert.ToString(Session("Perfil"))).Tables("resultado")
        lblDescripcion.Text = dt_Datos.Rows(0).Item("vchDescripcion")
        dt_Datos.Dispose()
    End Sub

   Private Sub Menu()
        Try
            Dim ds_Datos As DataSet
            Dim Menu As New Menu
            ds_Datos = _Funciones.Menu(Convert.ToString(Session("Perfil")))

            Dim dtRow As DataRow() = ds_Datos.Tables("resultado").Select("intIDPadreItem IS NULL")

            Dim Inicio As New MenuItem
            Inicio.Text = "Inicio"
            Inicio.Value = "0"
            Inicio.NavigateUrl = String.Empty
            Menu1.Items.Add(Inicio)

            Dim MenuPrincipal As New MenuItem
            MenuPrincipal.Text = "Menú Principal"
            MenuPrincipal.Value = "1"
            MenuPrincipal.NavigateUrl = String.Empty
            Menu1.Items.Add(MenuPrincipal)

            For Each row As DataRow In dtRow
                Dim A As New MenuItem
                A.Text = row("vchDescripcion")
                A.Value = Convert.ToString(row("intIDItem"))
                A.NavigateUrl = If(row("vchURL") Is DBNull.Value, String.Empty, row("vchURL"))
                Menu1.Items.Add(A)
            Next

            Dim Salir As New MenuItem
            Salir.Text = "Salir"
            Salir.Value = "100"
            Salir.NavigateUrl = String.Empty
            Menu1.Items.Add(Salir)

            For Each item As MenuItem In Menu1.Items
                SubMenus(ds_Datos, item.Value, item.ValuePath)
            Next

            Menu1.Visible = True

            lblPerfil.Text = "Perfil: " + Session("Perfil")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SubMenus(ds_Datos As DataSet, str_ID_Parent As String, str_Path As String)
        For Each row As DataRow In ds_Datos.Tables(0).Select("intIDPadreItem=" + str_ID_Parent)
            Dim A As New MenuItem
            A.Text = row("vchDescripcion")
            A.Value = row("intIDItem").ToString
            A.NavigateUrl = If(row("vchURL") Is DBNull.Value, String.Empty, row("vchURL"))
            Menu1.FindItem(str_Path).ChildItems.Add(A)
            SubMenus(ds_Datos, A.Value, A.ValuePath)
        Next
    End Sub

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
        Select Case e.Item.Text
            Case "Inicio"
                Response.Redirect(ResolveUrl("~/Formularios/Inicio.aspx"))
            Case "Salir"
                Response.Expires = 0
                Response.Cookies.Clear()
                Session.Abandon()
                Session.Clear()
                Response.Redirect(ResolveUrl("~/Login.aspx"))
        End Select
    End Sub

End Class