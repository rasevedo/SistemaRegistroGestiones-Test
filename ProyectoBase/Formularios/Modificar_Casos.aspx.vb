Imports CapAccesoDatosSiReGe
Imports CapLogicaSiReGe
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class Modificar_Casos
    Inherits System.Web.UI.Page

    Dim con As SqlConnection = New SqlConnection("Data Source=localhost;Initial Catalog=SiReGe;Integrated Security=True")

    Private dt As DataTable = New DataTable()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.GetCaso()


            AvancePanel.Visible = False
            Me.MostrarAvanceGridview()
            Me.FiltrarPorCaso()
        End If
    End Sub

    Protected Sub DD1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim strConnString As String = ConfigurationManager _
             .ConnectionStrings("SiReGeConnectionString").ConnectionString
        Dim strQuery As String = "select descripcionDespacho, descripcionDireccion, descripcionDepartamento from Unidad where" _
                           & " idUnidad = @idUnidad"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.Parameters.AddWithValue("@idUnidad", DD1.SelectedItem.Value)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        Try
            con.Open()
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            While sdr.Read()
                txtDespacho.Text = sdr(0).ToString()
                txtDireccion.Text = sdr(1).ToString()
                txtDepartamento.Text = sdr(2).ToString()
            End While
        Catch ex As Exception
            MsgBox(ex.Message + "entra por aca y se muere")
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub

    Protected Sub DDL_Dimension2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim strConnString As String = ConfigurationManager _
             .ConnectionStrings("SiReGeConnectionString").ConnectionString
        Dim strQuery As String = "select descripcionLetraDimension from Dimensiones where" _
                           & " idDimension = @idDimension"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.Parameters.AddWithValue("@idDimension", DDL_Dimension2.SelectedItem.Value)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        Try
            con.Open()
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            While sdr.Read()
                txtTipoDetalleLetraDimension.Text = sdr(0).ToString
            End While
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub



    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Me.ModificarCaso()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        Response.Redirect("Casos.aspx")
    End Sub

    Private ReadOnly Property id As Integer
        Get
            Return If(Not String.IsNullOrEmpty(Request.QueryString("idCasos")), Integer.Parse(Request.QueryString("idCasos")), 0)
        End Get
    End Property

    Private Sub ModificarCaso()
        Try
            Dim dts As New Entidad_Casos 'instanciamos a la clase atributos de la tabla trabajador
            Dim func As New Datos_Casos 'instanciamos a la clase funciones de la tabla trabajador

            dts._idCasos = txtidCasos.Text
            dts._numeroCasos = txtnumeroCaso.Text
            dts._estadoCasos = txtestadoCaso.Text
            dts._fechaCasos = txtfechaCaso.Text
            dts._cedulaDenuncianteCasos = txtcedulaUsuario.Text
            dts._nombreDenuncianteCasos = txtnombreUsuario.Text
            dts._idEmpleados = idEmpleados.Text
            dts._nombreCentroEducativo = txtnombreCE.Text
            dts._idUnidad = DD1.Text
            dts._numeroOficio = txtnumeroOficio.Text
            dts._fechaOficio = txtfechaOficio.Text
            dts._idDimension = DDL_Dimension2.Text
            dts._condicionCasos = txtcondicionCaso.Text
            dts._detalleInconformidadCasos = txtasunto.Text
            dts._respuestaCasos = txtrespuesta.Text
            dts._valoracionAdmisibilidad = txtvaloracionAdmisibilidad.Text
            dts._veredictoValoracionIngreso = txtveredictoValoracion.Text
            dts._trazabilidadCasos = txttrazabilidadCaso.Text
            dts._fechaRespuestaCasos = txtfechaRespuestaCasos.Text
            dts._fechaCerradoCasos = txtfechaCerradoCasos.Text
            If func.modificarCasos(dts) Then
                Response.Write("<script language=javascript>alert('El elemento se ha agregado')</script>")
                'MsgBox("Exito")
                Response.Redirect(Request.Url.AbsoluteUri, False)
                Response.Redirect("~Casos.aspx")
            Else
                Response.Write("<script language=javascript>alert('Faltan espacio para rellenar')</script>")
                ' MsgBox("Fracaso")
            End If
        Catch ex As Exception
            ' Response.Write("<script language=javascript>alert('Hubo un problema en agregar el elemento. Porfavor rellenar de nuevo los espacios de fechas y dimensiones')</script>")
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetCaso()

        Dim cmd As SqlCommand = New SqlCommand("SELECT C.idCasos, C.numeroCasos, C.estadoCasos, C.fechaCasos, C.cedulaDenuncianteCasos, C.nombreDenucianteCasos, E.nombreEmpleados, C.nombreCentroEducativo,
                                                       U.descripcionUnidad, U.descripcionDespacho, U.descripcionDireccion, U.descripcionDepartamento, C.numeroOficio, C.fechaOficio,
	                                                   D.tipoDimension, D.letraDimension, D.descripcionTipoDimension, C.condicionCasos, C.detalleInconformidadCasos, C.respuestaCasos, C.valoracionAdmisibilidad,
	                                                   C.veredictoValoracionIngreso, C.trazabilidadCasos, C.fechaRespuestaCasos, C.fechaCerradoCasos 
	     	   
	 
	                                            FROM casos C join Empleados as E on C.idEmpleados = E.idEmpleados				 
				                                             join Unidad as U on C.idUnidad = U.idUnidad				 
				                                             join Dimensiones as D on C.idDimension = D.idDimension  
                                                
                                                WHERE idCasos=@idCasos", con)
        cmd.Parameters.AddWithValue("@idCasos", id)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        da.Fill(dt)
        For Each dr As DataRow In dt.Rows

            Me.txtidCasos.Text = dr("idCasos").ToString()
            Me.txtnumeroCaso.Text = dr("numeroCasos").ToString()
            Me.txtestadoCaso.Text = dr("estadoCasos").ToString()
            Me.txtfechaCaso.Text = dr("fechaCasos").ToString()
            Me.txtcedulaUsuario.Text = dr("cedulaDenuncianteCasos").ToString()
            Me.txtnombreUsuario.Text = dr("nombreDenucianteCasos").ToString()
            ' Me.idEmpleados.Text = dr("idEmpleados").ToString()
            Me.txtnombreCE.Text = dr("nombreCentroEducativo").ToString()
            ' Me.DD1.Text = dr("idUnidad").ToString()
            Me.txtnumeroOficio.Text = dr("numeroOficio").ToString()
            Me.txtfechaOficio.Text = dr("fechaOficio").ToString()
            ' Me.DDL_Dimension3.Text = dr("idDimension").ToString()
            Me.txtcondicionCaso.Text = dr("condicionCasos").ToString()
            Me.txtasunto.Text = dr("detalleInconformidadCasos").ToString()
            Me.txtrespuesta.Text = dr("respuestaCasos").ToString()
            Me.txtvaloracionAdmisibilidad.Text = dr("valoracionAdmisibilidad").ToString()
            Me.txtveredictoValoracion.Text = dr("veredictoValoracionIngreso").ToString()
            Me.txttrazabilidadCaso.Text = dr("trazabilidadCasos").ToString()
            Me.txtfechaRespuestaCasos.Text = dr("fechaRespuestaCasos").ToString()
            Me.txtfechaCerradoCasos.Text = dr("fechaCerradoCasos").ToString()
        Next
    End Sub

    Protected Sub btnAgregarAvance_Click(sender As Object, e As EventArgs) Handles btnAgregarAvance.Click
        AvancePanel.Visible = True

    End Sub

    Protected Sub btnInsertarAvance_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInsertarAvance.Click
        'validamos que todos los datos esten ingresados
        Dim dts As New Entidad_AvanceCasos 'instanciamos a la clase atributos de la tabla trabajador
        Dim func As New Datos_AvanceCasos 'instanciamos a la clase funciones de la tabla trabajador        
        Try
            'enviamos los datos
            dts._idCasos = txtidCasos.Text
            dts._detalleAvance = txtDetalleAvance.Text
            dts._fechaAvance = txtFechaAvance.Text
            If func.insertarAvancesCasos(dts) Then
                'MsgBox("Exito")
            Else
                'MsgBox("Fracaso")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Sub MostrarAvanceGridview()
        Try
            Dim func As New Datos_AvanceCasos
            dt = func.mostrarAvanceCasos
            If dt.Rows.Count <> 0 Then
                Dim dView As DataView = New DataView(dt)
                GridviewAvance.DataSource = dt
                GridviewAvance.DataBind()
            Else
                GridviewAvance.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub FiltrarPorCaso()
        Dim strConnString As String = ConfigurationManager _
             .ConnectionStrings("SiReGeConnectionString").ConnectionString

        Dim con As New SqlConnection(strConnString)
        con.Open()

        Dim cmd As SqlCommand = New SqlCommand("SELECT ac.idAvanceCasos, c.idCasos, ac.detalleAvance, ac.fechaAvance
 
	                                            FROM AvanceCasos ac join Casos as c on ac.idCasos = c.idCasos

                                                WHERE c.idCasos='" & txtidCasos.Text & "'", con)

        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        con.Close()
        GridviewAvance.DataSource = ds
        GridviewAvance.DataBind()
    End Sub


End Class