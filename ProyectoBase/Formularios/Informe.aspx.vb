Imports CapAccesoDatosSiReGe
Imports CapLogicaSiReGe
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.IO
Imports System.Reflection



Public Class Informe
    Inherits System.Web.UI.Page

    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Mostrar()
    End Sub

#Region "Mostrar Tabla"
    Sub Mostrar()
        Try
            Dim func As New Datos_Informe
            dt = func.mostrarInforme
            If dt.Rows.Count <> 0 Then
                GridViewInforme.DataSource = dt
                GridViewInforme.DataBind()
            Else
                GridViewInforme.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Response.Redirect("Form_Insertar_Informe.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        PrepareGridViewForExport(GridViewInforme)
        ExportGridView()
    End Sub




    'Esta funcion ayuda a una vez extraido los datos a exportar estos son guardados en un archivo de excel
    'Devuelve: Crea un archivo de excel con las filas marcadas con check.
#Region "Exportar a Excel"
    Private Sub ExportGridView()
        Dim attachment As String = "attachment; filename=Informes.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        Dim sw As StringWriter = New StringWriter()
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()
        GridViewInforme.Parent.Controls.Add(frm)
        frm.Attributes("runat") = "server"
        frm.Controls.Add(GridViewInforme)
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
            Dim func As New Datos_Informe
            Dim dts As New Entidad_Informe
            For Each gvrow As GridViewRow In GridViewInforme.Rows
                Dim chkdelete As CheckBox = DirectCast(gvrow.FindControl("chkSelect"), CheckBox)
                If chkdelete.Checked Then
                    Dim gesid As Integer = Convert.ToInt32(GridViewInforme.DataKeys(gvrow.RowIndex).Value)
                    dts._idInforme = gesid
                    If func.borrarInforme(dts) Then
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

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("~/MenuPrincipal.aspx")
    End Sub

    'Funcion para la creacion del reporte aunque su funcionamiento esta incompleto debido a que no se logro implementar el reportviewer de forma correcta'
    'NO DEVUELVE'
#Region "SeleccionarFilas"
    Protected Sub GridViewInforme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewInforme.SelectedIndexChanged
        txtId_Informe.Text = GridViewInforme.SelectedRow.Cells(3).Text
        txtTitulo_Informe.Text = GridViewInforme.SelectedRow.Cells(4).Text
        txtEmpleado_Informe.Text = GridViewInforme.SelectedRow.Cells(5).Text
        txtTipo_Informe.Text = GridViewInforme.SelectedRow.Cells(6).Text
        txtNumOficio_Informe.Text = GridViewInforme.SelectedRow.Cells(7).Text
        txtFechaAprobacion.Text = GridViewInforme.SelectedRow.Cells(8).Text
        txtFechaCulminacion.Text = GridViewInforme.SelectedRow.Cells(9).Text
        txtFechaTraslado.Text = GridViewInforme.SelectedRow.Cells(10).Text
        txtAvance_Informe.Text = Page.Server.HtmlDecode(GridViewInforme.SelectedRow.Cells(11).Text)
        mpe.Show()
    End Sub
#End Region

End Class