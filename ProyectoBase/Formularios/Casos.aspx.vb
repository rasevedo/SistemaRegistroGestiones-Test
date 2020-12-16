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

Public Class Casos
    Inherits System.Web.UI.Page

    Dim dt As New DataTable

    Dim MyConnString As String = ConfigurationManager.ConnectionStrings("SiReGeConnectionString").ConnectionString
    Dim con As SqlConnection = Nothing
    Dim cmd As SqlCommand = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Mostrar()
        End If
    End Sub

#Region "Mostrar Tabla"
    Sub Mostrar()
        Try
            Dim func As New Datos_Casos
            dt = func.mostrarCasos
            If dt.Rows.Count <> 0 Then
                GridViewCasos.DataSource = dt
                GridViewCasos.DataBind()
            Else
                GridViewCasos.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    'Boton dirige a la inserción de formularios
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Response.Redirect("Form_Insertar_Casos.aspx")
    End Sub

    'Toda la informacion detro de este buton funcionan para la exportacion de datos
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        PrepareGridViewForExport(GridViewCasos)
        ExportGridView()
    End Sub

    Protected Sub ExportarWord_Click(sender As Object, e As EventArgs) Handles btnExportarWord.Click
        ExportaWord()
    End Sub

    Protected Sub ExportaWord()
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.word"
        Response.ContentEncoding = System.Text.Encoding.UTF8
        Response.AddHeader("Content-Disposition", "attachment;filename=Casos.doc")
        Response.Charset = ""
        EnableViewState = False
        Dim table As New Table()
        Dim row As New TableRow()
        row.Cells.Add(New TableCell())
        row.Cells(0).Controls.Add(pnlPopup)
        table.Rows.Add(row)
        Dim oStringWriter As New System.IO.StringWriter()
        Dim oHtmlTextWriter As New System.Web.UI.HtmlTextWriter(oStringWriter)
        table.RenderControl(oHtmlTextWriter)
        Response.Write(oStringWriter.ToString())
        Response.[End]()
    End Sub



    'Esta funcion ayuda a una vez extraido los datos a exportar estos son guardados en un archivo de excel
    'Devuelve: Crea un archivo de excel con las filas marcadas con check.
#Region "Exportar a Excel"
    Private Sub ExportGridView()
        Dim attachment As String = "attachment; filename=Casos.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        Dim sw As StringWriter = New StringWriter()
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()
        GridViewCasos.Parent.Controls.Add(frm)
        frm.Attributes("runat") = "server"
        frm.Controls.Add(GridViewCasos)
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

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        'La funcion dentro del boton revisa antes de borrar cuales filas estan marcadas con un check'
        'Devuelve: Elimina la fila o filas seleccionadas'
        Try
            Dim func As New Datos_Casos
            Dim dts As New Entidad_Casos
            For Each gvrow As GridViewRow In GridViewCasos.Rows
                Dim chkdelete As CheckBox = DirectCast(gvrow.FindControl("chkSelect"), CheckBox)
                If chkdelete.Checked Then
                    Dim gesid As Integer = Convert.ToInt32(GridViewCasos.DataKeys(gvrow.RowIndex).Value)
                    dts._idCasos = gesid
                    If func.borrarCasos(dts) Then
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
            ' MsgBox("Hubo un problema en eliminar el elmento" + ex.Message)
        End Try
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("~/MenuPrincipal.aspx")
    End Sub

    'Funcion para la creacion del reporte aunque su funcionamiento esta incompleto debido a que no se logro implementar el reportviewer de forma correcta'
    'NO DEVUELVE'
#Region "SeleccionarFilas"
    Protected Sub GridViewCasos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewCasos.SelectedIndexChanged
        txtId_Caso.Text = GridViewCasos.SelectedRow.Cells(3).Text
        txtNumCaso.Text = GridViewCasos.SelectedRow.Cells(4).Text
        txtEstadoCaso.Text = GridViewCasos.SelectedRow.Cells(5).Text
        txtFechaCaso.Text = GridViewCasos.SelectedRow.Cells(6).Text
        txtCedulaUsuario.Text = GridViewCasos.SelectedRow.Cells(7).Text
        txtNombreUsuario.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(8).Text)
        txtempleado.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(9).Text)
        txtCE.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(10).Text)
        txtUnidad.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(11).Text)
        txtDespacho.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(12).Text)
        txtDireccion.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(13).Text)
        txtDepartamento.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(14).Text)
        txtNumOficio.Text = GridViewCasos.SelectedRow.Cells(15).Text
        txtFechaOficio.Text = GridViewCasos.SelectedRow.Cells(16).Text
        txtDimension.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(17).Text)
        txtLetraDim.Text = GridViewCasos.SelectedRow.Cells(18).Text
        lblDetalleDim.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(19).Text)
        txtCondicionCaso.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(20).Text)
        lblDetalleInconformidad.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(21).Text)
        lblRespuesta_Caso.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(22).Text)
        txtValoracionAdmisibilidad.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(23).Text)
        txtVeredicto.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(24).Text)
        txtTrazabilidad.Text = Page.Server.HtmlDecode(GridViewCasos.SelectedRow.Cells(25).Text)
        txtFechaRespuesta.Text = GridViewCasos.SelectedRow.Cells(26).Text
        txtFechaCerrado.Text = GridViewCasos.SelectedRow.Cells(27).Text
        mpe.Show()
    End Sub
#End Region





End Class