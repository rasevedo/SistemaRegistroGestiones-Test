Imports CapAccesoDatosSiReGe
Imports CapLogicaSiReGe
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO


Public Class Modificar_Informe
    Inherits System.Web.UI.Page

    Dim con As SqlConnection = New SqlConnection("Data Source=localhost;Initial Catalog=SiReGe;Integrated Security=True")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.GetInforme()
        End If
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.ModificarInforme()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Informe.aspx")
    End Sub

    Private ReadOnly Property id As Integer
        Get
            Return If(Not String.IsNullOrEmpty(Request.QueryString("idInforme")), Integer.Parse(Request.QueryString("idInforme")), 0)
        End Get
    End Property

    Private Sub ModificarInforme()
        Try
            Dim dts As New Entidad_Informe 'instanciamos a la clase atributos de la tabla trabajador
            Dim func As New Datos_Informe 'instanciamos a la clase funciones de la tabla trabajador
            dts._idInforme = txtidInforme.Text
            dts._tituloInforme = txttituloInforme.Text
            dts._idEmpleados = idEmpleados.Text
            dts._tituloInforme = txttipoInforme.Text
            dts._numeroOficio = txtnumeroOficio.Text
            dts._tipoInforme = txttipoInforme.Text
            dts._fechaAprobacion = txtfechaAprobacion.Text
            dts._fechaCulminacion = txtfechaCulminacion.Text
            dts._fechaTraslado = txtfechaTraslado.Text
            dts._avanceInforme = txtavanceInforme.Text
            If func.modificarInforme(dts) Then
                Response.Write("<script language=javascript>alert('El elemento se ha agregado')</script>")
                ' MsgBox("Exito")
                Response.Redirect(Request.Url.AbsoluteUri, False)
                Response.Redirect("~Informe.aspx")
            Else
                Response.Write("<script language=javascript>alert('Faltan espacio para rellenar')</script>")
                ' MsgBox("Fracaso")
            End If
        Catch ex As Exception
            'Response.Write("<script language=javascript>alert('Hubo un problema en agregar el elemento. Porfavor rellenar de nuevo los espacios de fechas y dimensiones')</script>")
            'MsgBox(ex.Message)
        End Try
    End Sub

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


    Private Sub GetInforme()

        Dim cmd As SqlCommand = New SqlCommand("SELECT I.idInforme, I.tituloInforme, E.nombreEmpleados, I.tipoInforme, I.numeroOficio, I.fechaAprobacion, I.fechaCulminacion, I.fechaTraslado, I.avanceInforme 
                                                FROM Informe I join Empleados as E on I.idEmpleados = E.idEmpleados  
                                                WHERE idInforme=@idInforme", con)
        cmd.Parameters.AddWithValue("@idInforme", id)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        da.Fill(dt)
        For Each dr As DataRow In dt.Rows
            Me.txtidInforme.Text = dr("idInforme").ToString()
            Me.txttituloInforme.Text = dr("tituloInforme").ToString()
            '' Me.idEmpleados.Text = dr("idEmpleados").ToString()
            Me.txttipoInforme.Text = dr("tipoInforme").ToString()
            Me.txtnumeroOficio.Text = dr("numeroOficio").ToString()
            Me.txttipoInforme.Text = dr("tipoInforme").ToString()
            Me.txtfechaAprobacion.Text = dr("tipoInforme").ToString()
            Me.txtfechaCulminacion.Text = dr("fechaCulminacion").ToString()
            Me.txtfechaTraslado.Text = dr("fechaTraslado").ToString()
        Next
    End Sub



End Class