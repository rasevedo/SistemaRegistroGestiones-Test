Imports CapAccesoDatosSiReGe
Imports CapLogicaSiReGe
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports AjaxControlToolkit
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.IO

Public Class Gestiones
    Inherits System.Web.UI.Page

    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Mostrar()
        End If
    End Sub

#Region "Mostrar Tabla"
    Sub Mostrar()
        Try
            Dim func As New Datos_Gestiones
            dt = func.mostrarGestiones
            If dt.Rows.Count <> 0 Then
                GridViewGestiones.DataSource = dt
                GridViewGestiones.DataBind()
            Else
                GridViewGestiones.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    'Boton dirige a la inserción de formularios
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Response.Redirect("Form_Insertar_Gestiones.aspx")
    End Sub

    'Toda la informacion detro de este buton funcionan para la exportacion de datos
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        PrepareGridViewForExport(GridViewGestiones)
        ExportGridView()
    End Sub


    Sub Reporte()
#Region "Mostrar Tabla"
        'Dim dsGestiones As New GestionesReport()
        For Each row As GridViewRow In GridViewGestiones.Rows
            If TryCast(row.FindControl("chkSelect"), CheckBox).Checked Then
                Dim idGestiones As String = row.Cells(1).Text
                Dim tipoGestiones As String = row.Cells(2).Text
                Dim cedulaUsuario As String = row.Cells(3).Text
                Dim nombreUsuario As String = row.Cells(4).Text
                Dim fechaIngreso As String = row.Cells(5).Text
                Dim confidencialidadGestiones As String = row.Cells(6).Text
                Dim fuenteGeneradora As String = row.Cells(7).Text
                Dim tipoServicio As String = row.Cells(8).Text
                Dim nombreEmpleados As String = row.Cells(9).Text
                Dim direccionRegional As String = row.Cells(10).Text
                Dim supervicionGestiones As String = row.Cells(11).Text
                Dim nombreCentroEducativo As String = row.Cells(12).Text
                Dim descripcionUnidad As String = row.Cells(13).Text
                Dim descripcionDespacho As String = row.Cells(14).Text
                Dim descripcionDireccion As String = row.Cells(15).Text
                Dim descripcionDepartamento As String = row.Cells(16).Text
                Dim numeroOficio As String = row.Cells(17).Text
                Dim tipoDimension As String = row.Cells(18).Text
                Dim letraDimension As String = row.Cells(19).Text
                Dim descripcionTipoDimension As String = row.Cells(20).Text
                Dim tipoUsuario As String = row.Cells(21).Text
                Dim detalleGestiones As String = row.Cells(22).Text
                Dim respuestaGestiones As String = row.Cells(23).Text
                Dim categoriaGestiones As String = row.Cells(24).Text
             '   dsGestiones.Tables(0).Rows.Add(row.Cells(1).Text, row.Cells(2).Text, row.Cells(3).Text, row.Cells(4).Text, row.Cells(5).Text, row.Cells(6).Text, row.Cells(7).Text, row.Cells(8).Text, row.Cells(9).Text, row.Cells(10).Text, row.Cells(11).Text, row.Cells(12).Text, row.Cells(13).Text, row.Cells(14).Text, row.Cells(15).Text, row.Cells(16).Text, row.Cells(17).Text, row.Cells(18).Text, row.Cells(19).Text, row.Cells(20).Text, row.Cells(21).Text, row.Cells(22).Text, row.Cells(23).Text, row.Cells(24).Text)
            End If
        Next
#End Region
    End Sub

    'Esta funcion ayuda a una vez extraido los datos a exportar estos son guardados en un archivo de excel
    'Devuelve: Crea un archivo de excel con las filas marcadas con check.
#Region "Exportar Gridview a Excel"
    Private Sub ExportGridView()
        Dim attachment As String = "attachment; filename=Gestiones.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        Dim sw As StringWriter = New StringWriter()
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()
        GridViewGestiones.Parent.Controls.Add(frm)
        frm.Attributes("runat") = "server"
        frm.Controls.Add(GridViewGestiones)
        frm.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

    'La unica funcion de este es evitar un error que se crea al querer exportar'
    'NO DEVUELVE'
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub

    'Si la opción dentro de la tabla es distinto a un checkbox, dropdownlist o linkbutton este sera preparado para tambien ser exportado'
    'NO DEVUELVE'
    Private Sub PrepareGridViewForExport(ByVal gv As Control)
        Dim lb As LinkButton = New LinkButton()
        Dim l As Literal = New Literal()
        Dim name As String = String.Empty
        For i As Integer = 0 To gv.Controls.Count - 1
            If gv.Controls(i).[GetType]() = GetType(LinkButton) Then
                l.Text = (TryCast(gv.Controls(i), LinkButton)).Text
                gv.Controls.Remove(gv.Controls(i))
                gv.Controls.AddAt(i, l)
            ElseIf gv.Controls(i).[GetType]() = GetType(DropDownList) Then
                l.Text = (TryCast(gv.Controls(i), DropDownList)).SelectedItem.Text
                gv.Controls.Remove(gv.Controls(i))
                gv.Controls.AddAt(i, l)
            ElseIf gv.Controls(i).[GetType]() = GetType(CheckBox) Then
                l.Text = If((TryCast(gv.Controls(i), CheckBox)).Checked, "True", "False")
                gv.Controls.Remove(gv.Controls(i))
                gv.Controls.AddAt(i, l)
            End If
            If gv.Controls(i).HasControls() Then
                PrepareGridViewForExport(gv.Controls(i))
            End If
        Next
    End Sub
#End Region

    'La funcion dentro del boton revisa antes de borrar cuales filas estan marcadas con un check'
    'Devuelve: Elimina la fila o filas seleccionadas'
#Region "Borrar"
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            Dim func As New Datos_Gestiones
            Dim dts As New Entidad_Gestiones
            For Each gvrow As GridViewRow In GridViewGestiones.Rows
                Dim chkdelete As CheckBox = DirectCast(gvrow.FindControl("chkSelect"), CheckBox)
                If chkdelete.Checked Then
                    Dim gesid As Integer = Convert.ToInt32(GridViewGestiones.DataKeys(gvrow.RowIndex).Value)
                    dts._idGestiones = gesid
                    If func.borrarGestiones(dts) Then
                        Response.Write("<script language=javascript>alert('El elemento ha sido eliminado de forma exitosa')</script>")
                        'MsgBox("El elemento ha sido eliminado de forma exitosa")
                    Else
                        Response.Write("<script language=javascript>alert('No se ha eliminado el elemento.')</script>")
                        'MsgBox("No se ha eliminado el elemento.")
                    End If
                End If
            Next
            Mostrar()
        Catch ex As Exception
            Response.Write("<script language=javascript>alert('Hubo un problema en eliminar el elemento')</script>")
            'MsgBox("Hubo un problema en eliminar el elmento" + ex.Message)
        End Try
    End Sub
#End Region

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("~/MenuPrincipal.aspx")
    End Sub


    'Funcion para la creacion del reporte aunque su funcionamiento esta incompleto debido a que no se logro implementar el reportviewer de forma correcta'
    'NO DEVUELVE'
#Region "SeleccionarFilas"
    Protected Sub GridViewGestiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewGestiones.SelectedIndexChanged
        txtId_Gestiones.Text = GridViewGestiones.SelectedRow.Cells(3).Text
        txtTipo_Gestiones.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(4).Text)
        txtCedulaUsuario.Text = GridViewGestiones.SelectedRow.Cells(5).Text
        txtNombreUsuario.Text = GridViewGestiones.SelectedRow.Cells(6).Text
        txtFechaIngreso.Text = GridViewGestiones.SelectedRow.Cells(7).Text
        txtConfidencialida.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(8).Text)
        txtFuenteGeneradora.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(9).Text)
        txtTipoServicio.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(10).Text)
        txtempleado.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(11).Text)
        txtRegional.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(12).Text)
        txtSupervision.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(13).Text)
        txtCE.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(14).Text)
        txtUnidad.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(15).Text)
        txtDespacho.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(16).Text)
        txtDireccion.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(17).Text)
        txtDepartamento.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(18).Text)
        txtNumOficio.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(19).Text)
        txtDimension.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(20).Text)
        txtLetraDim.Text = GridViewGestiones.SelectedRow.Cells(21).Text
        lblDetalleDim.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(22).Text)
        txtTipoUsuario.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(23).Text)
        lblDetalleGestion.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(24).Text)
        lblRespuesta_Gestion.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(25).Text)
        txtCategoria_Gestion.Text = Page.Server.HtmlDecode(GridViewGestiones.SelectedRow.Cells(26).Text)
        mpe.Show()
    End Sub
#End Region

    'Boton con la funcion de filtrar datos en la tabla gridview por medio de tipoGestion seleccionado en el dropdownlist'
    'Devuelve: Gridview filtrado'
    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim strConnString As String = ConfigurationManager _
             .ConnectionStrings("SiReGeConnectionString").ConnectionString

        Dim con As New SqlConnection(strConnString)
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("SELECT G.idGestiones, G.tipoGestiones, G.cedulaUsuario, G.nombreUsuario, G.fechaIngreso, G.confidencialidadGestiones, G.fuenteGeneradora ,G.tipoServicio, E.nombreEmpleados,
           G.direccionRegional, G.supervicionGestiones, G.nombreCentroEducativo, U.descripcionUnidad, U.descripcionDespacho, U.descripcionDireccion, U.descripcionDepartamento,
	       G.numeroOficio, D.tipoDimension, D.letraDimension, D.descripcionTipoDimension, G.tipoUsuario, G.detalleGestiones, G.respuestaGestiones, G.categoriaGestiones
    
            FROM Gestiones G join Empleados as E on G.idEmpleados = E.idEmpleados
	                             join Unidad as U on G.idUnidad = U.idUnidad
					             join Dimensiones as D on G.idDimension = D.idDimension 

           WHERE tipoGestiones='" & Search.Text & "'", con)

        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        con.Close()
        GridViewGestiones.DataSource = ds
        GridViewGestiones.DataBind()
    End Sub

End Class
