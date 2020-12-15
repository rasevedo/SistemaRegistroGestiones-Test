Imports CapAccesoDatosSiReGe
Imports CapLogicaSiReGe
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class Form_Insertar_Gestiones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

#Region "Seleccionar Unidad"
    'Funcion que se utiliza para la elección de Unidad con dropdownlist de cascada con 3 textboxes ya que lo unico que se requiere es solo idUnidad por lo tanto se utiliza el espacio de Unidad como el responsable'
    'Devuelve:El idUnidad a insertar en la tabla Gestiones'
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
#End Region

#Region "Seleccionar letraDimension"
    'Funcion que se utiliza para la elección de Dimensiones con dropdownlist de cascada con 1 textboxes ya que lo unico que se requiere es solo idDimension por lo tanto se utiliza el espacio de letra como el responsable ya que es elegido por tipoDimension'
    'Devuelve:El idDimension a insertar en la tabla Gestiones'
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
#End Region

    'La funcion de este boton se encarga revisar que todos los textboxes y dropdownlists esten rellenos para insertar en la base de datos. Aunque solo fuerza 3 textboxes como obligados para insertar'
    'Devuelve: No devulve, pero insertar datos a la base de datos en la tabla Gestiones'
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim dts As New Entidad_Gestiones
        Dim func As New Datos_Gestiones
        If idEmpleados.Text <> "" Then
            Try
                dts._tipoGestiones = RadioButtonList1.Text
                dts._cedulaUsuario = txtcedulaUsuario.Text
                dts._nombreUsuario = txtnombreUsuario.Text
                dts._fechaIngreso = Convert.ToDateTime(txtfechaIngreso.Text)
                dts._idEmpleados = idEmpleados.Text
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
                If func.insertarGestiones(dts) Then
                    Response.Write("<script language=javascript>alert('El elemento se ha agregado')</script>")
                    GestionLimpiar()
                Else
                    Response.Write("<script language=javascript>alert('Faltan espacios para rellenar')</script>")
                    ' MsgBox("Faltan espacios que rellenar")
                End If
            Catch ex As Exception
                Response.Write("<script language=javascript>alert('Hubo un problema en agregar el elemento')</script>")
                ' MsgBox("Hubo un problema en agregar el elemento" + ex.Message)
            End Try
        Else
            Response.Write("<script language=javascript>alert('Faltan elementos que agregar')</script>")
            'MsgBox("Faltan datos que agregar")
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("Gestiones.aspx")
    End Sub

#Region "LimpiarFormulario"
    'Funcion que se utiliza para limpiar todos los textboxes de la pagina'
    'Devulve: Hace vacio todos los textboxes'
    Sub GestionLimpiar()
        txtcedulaUsuario.Text = String.Empty
        txtnombreUsuario.Text = String.Empty
        txtfechaIngreso.Text = String.Empty
        txtConfidencialidad.Text = String.Empty
        txtfuenteGeneradora.Text = String.Empty
        txttipoServicio.Text = String.Empty
        txtdireccionRegionalEducacion.Text = String.Empty
        txtSupervision.Text = String.Empty
        txtnombreCE.Text = String.Empty
        txtnumeroOficio.Text = String.Empty
        txtTipoUsuario.Text = String.Empty
        txtCategoria.Text = String.Empty
        txtasunto.Text = String.Empty
        txtrespuesta.Text = String.Empty
    End Sub
#End Region



End Class