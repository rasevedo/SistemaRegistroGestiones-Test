Imports CapAccesoDatosSiReGe
Imports CapLogicaSiReGe
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class Modificar_Gestiones
    Inherits System.Web.UI.Page

    Dim con As SqlConnection = New SqlConnection("Data Source=localhost;Initial Catalog=SiReGe;Integrated Security=True")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.GetGestion()

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
            Throw ex
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


    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.ModificarGestion()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Gestiones.aspx")
    End Sub

    Private ReadOnly Property id As Integer
        Get
            Return If(Not String.IsNullOrEmpty(Request.QueryString("idGestiones")), Integer.Parse(Request.QueryString("idGestiones")), 0)
        End Get
    End Property

    Private Sub ModificarGestion()
        Try
            Dim dts As New Entidad_Gestiones 'instanciamos a la clase atributos de la tabla trabajador
            Dim func As New Datos_Gestiones 'instanciamos a la clase funciones de la tabla trabajador
            dts._idGestiones = txtidGestiones.Text
            dts._idEmpleados = idEmpleados.Text
            dts._tipoGestiones = RadioButtonList1.Text
            dts._cedulaUsuario = txtcedulaUsuario.Text
            dts._nombreUsuario = txtnombreUsuario.Text
            dts._tipoUsuario = txtTipoUsuario.Text
            dts._fechaIngreso = txtfechaIngreso.Text
            dts._confidencialidadGestiones = txtConfidencialidad.Text
            dts._fuenteGeneradora = txtfuenteGeneradora.Text
            dts._tipoServicio = txttipoServicio.Text
            dts._direccionRegional = txtdireccionRegionalEducacion.Text
            dts._supervicionGestiones = txtSupervision.Text
            dts._nombreCentroEducativo = txtnombreCE.Text
            dts._idUnidad = DD1.Text
            dts._numeroOficio = txtnumeroOficio.Text
            dts._idDimension = DDL_Dimension2.Text
            dts._tipoUsuario = txtTipoUsuario.Text
            dts._categoriaGestiones = txtCategoria.Text
            dts._detalleGestiones = txtasunto.Text
            dts._respuestaGestiones = txtrespuesta.Text
            If func.modificarGestiones(dts) Then
                Response.Write("<script language=javascript>alert('El elemento se ha agregado')</script>")
                '  MsgBox("Exito")
                Response.Redirect(Request.Url.AbsoluteUri, False)
                Response.Redirect("~/Gestiones.aspx")
            Else
                Response.Write("<script language=javascript>alert('Faltan espacio para rellenar')</script>")
                ' MsgBox("Fracaso")
            End If
        Catch ex As Exception
            'Response.Write("<script language=javascript>alert('Hubo un problema en agregar el elemento. Porfavor rellenar de nuevo los espacios de fechas y dimensiones')</script>")
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetGestion()

        Dim cmd As SqlCommand = New SqlCommand("SELECT G.idGestiones, G.tipoGestiones, G.cedulaUsuario, G.nombreUsuario, G.fechaIngreso, G.confidencialidadGestiones, G.fuenteGeneradora ,G.tipoServicio, E.nombreEmpleados,
                                                       G.direccionRegional, G.supervicionGestiones, G.nombreCentroEducativo, U.descripcionUnidad, U.descripcionDespacho, U.descripcionDireccion, U.descripcionDepartamento,
	                                                   G.numeroOficio, D.tipoDimension, D.letraDimension, D.descripcionTipoDimension, G.tipoUsuario, G.detalleGestiones, G.respuestaGestiones, G.categoriaGestiones
                                                FROM Gestiones G join Empleados as E on G.idEmpleados = E.idEmpleados
	                                                             join Unidad as U on G.idUnidad = U.idUnidad
					                                             join Dimensiones as D on G.idDimension = D.idDimension  
                                                WHERE idGestiones=@idGestiones", con)
        cmd.Parameters.AddWithValue("@idGestiones", id)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        da.Fill(dt)
        For Each dr As DataRow In dt.Rows
            Me.txtidGestiones.Text = dr("idGestiones").ToString()
            'Me.idEmpleados.Text = dr("idEmpleados").ToString()
            Me.RadioButtonList1.Text = dr("tipoGestiones").ToString()
            Me.txtcedulaUsuario.Text = dr("cedulaUsuario").ToString()
            Me.txtnombreUsuario.Text = dr("nombreUsuario").ToString()
            Me.txtTipoUsuario.Text = dr("tipoUsuario").ToString()
            Me.txtfechaIngreso.Text = dr("fechaIngreso").ToString()
            Me.txtConfidencialidad.Text = dr("confidencialidadGestiones").ToString()
            Me.txtfuenteGeneradora.Text = dr("fuenteGeneradora").ToString()
            Me.txttipoServicio.Text = dr("tipoServicio").ToString()
            Me.txtdireccionRegionalEducacion.Text = dr("direccionRegional").ToString()
            Me.txtSupervision.Text = dr("supervicionGestiones").ToString()
            Me.txtnombreCE.Text = dr("nombreCentroEducativo").ToString()
            ' Me.DD1.Text = dr("idUnidad").ToString()
            Me.txtnumeroOficio.Text = dr("numeroOficio").ToString()
            ' Me.DDL_Dimension3.Text = dr("idDimension").ToString()
            Me.txtCategoria.Text = dr("categoriaGestiones").ToString()
            Me.txtasunto.Text = dr("detalleGestiones").ToString()
            Me.txtrespuesta.Text = dr("respuestaGestiones").ToString()
        Next
    End Sub


End Class