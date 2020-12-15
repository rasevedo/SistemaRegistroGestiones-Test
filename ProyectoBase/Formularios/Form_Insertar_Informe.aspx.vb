Imports CapAccesoDatosSiReGe
Imports CapLogicaSiReGe
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class Form_Insertar_Informe
    Inherits System.Web.UI.Page

    Dim con As SqlConnection = New SqlConnection("Data Source=localhost;Initial Catalog=SiReGe;Integrated Security=True")


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For i As Integer = 0 To txtavanceInforme.Items.Count - 1
            txtavanceInforme.Items(i).Attributes.Add("onclick", "OnlyOneCheckList(this)")
        Next
    End Sub


    'La funcion de este boton se encarga revisar que todos los textboxes y dropdownlists esten rellenos para insertar en la base de datos. Aunque solo fuerza 3 textboxes como obligados para insertar'
    'Devuelve: No devulve, pero insertar datos a la base de datos en la tabla Informe'
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim dts As New Entidad_Informe
        Dim func As New Datos_Informe
        If txttituloInforme.Text <> "" And txtfechaAprobacion.Text <> "" Then
            Try
                dts._tituloInforme = txttituloInforme.Text
                dts._idEmpleados = idEmpleados.Text
                dts._tituloInforme = txttipoInforme.Text
                dts._numeroOficio = txtnumeroOficio.Text
                dts._tipoInforme = txttipoInforme.Text
                dts._fechaAprobacion = txtfechaAprobacion.Text
                dts._fechaCulminacion = txtfechaCulminacion.Text
                dts._fechaTraslado = txtfechaTraslado.Text
                dts._avanceInforme = txtavanceInforme.Text
                If func.insertarInforme(dts) Then
                    Insert_checklist()
                    txtavanceInforme.ClearSelection()
                    Response.Write("<script language=javascript>alert('El elemento se ha agregado')</script>")
                    GestionLimpiar()
                Else
                    Response.Write("<script language=javascript>alert('Faltan espacio para rellenar')</script>")
                    '  MsgBox("Fracaso")
                End If
            Catch ex As Exception
                Response.Write("<script language=javascript>alert('Hubo un problema en agregar el elemento')</script>")
                ' MsgBox(ex.Message)
            End Try
        Else
            Response.Write("<script language=javascript>alert('Faltan elementos que agregar')</script>")
            ' MsgBox("Falta datos")
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("Informe.aspx")
    End Sub

#Region "LimpiarFormulario"
    'Funcion que se utiliza para limpiar todos los textboxes de la pagina'
    'Devulve: Hace vacio todos los textboxes'
    Sub GestionLimpiar()
        txttituloInforme.Text = String.Empty
        txtnumeroOficio.Text = String.Empty
        txtfechaAprobacion.Text = String.Empty
        txtfechaCulminacion.Text = String.Empty
        txtfechaTraslado.Text = String.Empty
    End Sub
#End Region

#Region "InsertarAvance"
    'Funcion que revisa cuales avances estan chekeados y los inserta a la base de datos'
    'Devuelve: Valor seleccionado con check'
    Public Sub Insert_checklist()
        Dim str As String = ""
        For i As Integer = 0 To txtavanceInforme.Items.Count - 1
            If txtavanceInforme.Items(i).Selected Then
                If str = "" Then
                    str = txtavanceInforme.Items(i).Text
                Else
                    str += "," & txtavanceInforme.Items(i).Text
                End If
            End If
        Next
        Dim cmd As SqlCommand = New SqlCommand("Insert into Informe(avanceInforme) values('" & str & "')", con)
        cmd.ExecuteNonQuery()
    End Sub
#End Region






End Class