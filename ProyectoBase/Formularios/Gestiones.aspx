<%@ Page Title="Gestiones" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master"  CodeBehind="Gestiones.aspx.vb" Inherits="CapPresentacionSiReGe.Gestiones" EnableEventValidation="false"%>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style type="text/css">
        .auto-style2 {
            position: relative;
            width: 1142px;
            -ms-flex: 0 0 100%;
            flex: 0 0 100%;
            max-width: 100%;
            left: 0px;
            top: 10px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style3 {
            width: 1023px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">  
    <link href="Estilo.css" rel="stylesheet" />
   <meta charset="utf-8"/>
    <div class="row">

        <div class="auto-style2">
            <header class="panel-heading">
                <div class="col-md-5 col-md-offset-3">
                    <h1 class="auto-style3">Sistema de Gestiones</h1>
                </div>
            </header>
        </div>

        <div class="panel-body">

                            <div class="row">
                                 <div class="col-md-2 col-md-offset--1">
                                    <div class="form-group">
                                        <asp:Button Text="Nuevo" ID="btnAgregar"  Width="170px" runat="server" OnClick="Button1_Click" />
                                    </div>
                                </div>
                                <div class="col-md-2 col-md-offset-0">
                                    <div class="form-group">
                                        <asp:Button Text="Borrar" ID="btnBorrar"  Width="170px" runat="server" OnClientClick="javascript:return Confirmationbox();" OnClick="Button3_Click" />
                                    </div>
                                </div>

                             

                                <div class="col-md-2 col-md-offset-0">
                                    <div class="form-group">
                                        <asp:Button Text="Exportar" ID="btnExportar"  Width="170px" runat="server" OnClick="Button2_Click" />
                                    </div>
                                </div>                             
                                <div class="col-md-2 col-md-offset-0">
                                    <div class="form-group">
                                        <asp:Button Text="Volver" ID="btnVolver"  Width="170px" runat="server" OnClick="Button4_Click" />
                                    </div>
                                </div>    
                             </div> 

                            <div class="row">
                                 <div class="col-md-4 col-md-offset--1">
                                    <div class="form-group">
                                        Tipo de Gestión:
                                        <asp:DropDownList ID="Search" runat="server">
                                             <asp:ListItem>Atención presencial</asp:ListItem>
                                            <asp:ListItem>Vía telefonica</asp:ListItem>
                                            <asp:ListItem>Correo Electrónico</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnSearch" runat="server" Width="125px" Text="Buscar" OnClick="btnsearch_Click"/>
                                    </div>
                                </div>                                
                            </div> 

                   
                   <div id="grdCharges" runat="server" style="width: 1145px; overflow: auto; height: 450px;" >
                       
                       <asp:GridView ID="GridViewGestiones" runat="server" CellPadding="10" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="2px" AutoGenerateColumns="False" DataKeyNames="idGestiones"  AllowPaging="True" AllowSorting="True" CellSpacing="10" HorizontalAlign="Center" Width="50%" >
                           <Columns>
                               <asp:buttonfield buttontype="Button" commandname="Select" text="Detalle"/>
                               <asp:HyperLinkField Text="Modificar" DataNavigateUrlFields="idGestiones" DataNavigateUrlFormatString="Modificar_Gestiones.aspx?idGestiones={0}" />
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" onclick="GridCheckOne(this)"></asp:CheckBox>
                                    </ItemTemplate>
                               </asp:TemplateField>                                                            
                               <asp:BoundField DataField="idGestiones" HeaderText="Codigo de Gestión"    >
                                   <HeaderStyle HorizontalAlign="Center" />
                               </asp:BoundField>
                               <asp:BoundField DataField="tipoGestiones" HeaderText="Tipo de Gestión"  >
                                   <ControlStyle Width="200px"></ControlStyle>

                                   <HeaderStyle Width="200px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="cedulaUsuario" HeaderText="Cedula del Usuario"  >
                                   <ControlStyle Width="200px"></ControlStyle>

                                   <HeaderStyle Width="200px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="nombreUsuario" HeaderText="Nombre del Usuario"  >
                                   <ControlStyle Width="200px"></ControlStyle>

                                   <HeaderStyle Width="200px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="fechaIngreso" HeaderText="Fecha de Ingreso"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="confidencialidadGestiones" HeaderText="Confidencialidad"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="fuenteGeneradora" HeaderText="Fuente Generadora"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="tipoServicio" HeaderText="Tipo de servicio"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="nombreEmpleados" HeaderText="Funcionario que Tramita"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="direccionRegional" HeaderText="Dirección Regional de Educación"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="supervicionGestiones" HeaderText="Supervisión"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="nombreCentroEducativo" HeaderText="Nombre del Centro Educativo"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="descripcionUnidad" HeaderText="Descripción Unidad"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="descripcionDespacho" HeaderText="Descripción Despacho" HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="descripcionDireccion" HeaderText="Descripción Dirección"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="descripcionDepartamento" HeaderText="Descripción Departamento" HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="numeroOficio" HeaderText="Numero de Oficio"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="tipoDimension" HeaderText="Dimensión"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="letraDimension" HeaderText="Letra Dimensión" HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="descripcionTipoDimension" HeaderText="Detalle Dimensión"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="tipoUsuario" HeaderText="Tipo de Usuario" HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="detalleGestiones" HeaderText="Detalle de Gestiones"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>                                 
                               <asp:BoundField DataField="respuestaGestiones" HeaderText="Respuesta de Gestiones" HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="categoriaGestiones" HeaderText="Categoria de Gestiones"  HeaderStyle-Width="120px">
<HeaderStyle Width="120px"></HeaderStyle>
                               </asp:BoundField>
                           </Columns>

                           
                            <FooterStyle BackColor="#00A0E3" ForeColor="White" />
                            <PagerStyle BackColor="#00A0e3" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" Width="200px" Wrap="True" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#00A0e3" ForeColor="White" HorizontalAlign="Center" Width="150px" Wrap="False" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                       </asp:GridView>

                      
                       <asp:SqlDataSource runat="server" ID="SqlDataSourceGrid" ConnectionString='<%$ ConnectionStrings:SiReGeConnectionString %>' SelectCommand="mostrarGestiones" SelectCommandType="StoredProcedure" ></asp:SqlDataSource>
                     
                      <script type = "text/javascript">
                        function checkAll(objRef) {
                            var GridView = objRef.parentNode.parentNode.parentNode;
                            var inputList = GridView.getElementsByTagName("input");
                            for (var i=0;i<inputList.length;i++) {
                                //Get the Cell To find out ColumnIndex
                                var row = inputList[i].parentNode.parentNode;
                                if(inputList[i].type == "checkbox"  && objRef != inputList[i]) {
                                    if (objRef.checked) {
                                        //If the header checkbox is checked check all checkboxes and highlight all rows
                                        inputList[i].checked=true;
                                    }
                                    else {
                                        //If the header checkbox is checked uncheck all checkboxes and change rowcolor back to original
                                        if(row.rowIndex % 2 == 0) {           
                                        }                           
                                        inputList[i].checked=false;
                                    }
                                }
                            }
                        }
                      </script> 

                        <asp:LinkButton Text="" ID = "lnkFake" runat="server" />
                        <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="lnkFake"
                        CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                        </asp:ModalPopupExtender>

                       <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none" ScrollBars="Vertical" Height="590px" >
                           <div class="header">
                               Detalles de la Gestión
                           </div>
                           <div class="body">
                               <table border="0">
                                   <tr>
                                       <td> 
                                           
                                       </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Codigo de Gestión"></asp:Label>
                                           <asp:TextBox ID="txtId_Gestiones" runat="server" Enabled="false" style="text-align: center"/>
                                        </td>
                                       <td> 
                                           
                                       </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Tipo de Gestión: </b>
                                            <asp:TextBox ID="txtTipo_Gestiones" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                        <td>
                                            <b>Cédula del Usuario: </b>
                                            <asp:TextBox ID="txtCedulaUsuario" runat="server" Enabled="false" style="text-align: center"/>
                                        </td>
                                        <td>
                                            <b>Nombre del Usuario: </b>
                                            <asp:TextBox ID="txtNombreUsuario" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Fecha de Ingreso: </b>
                                            <asp:TextBox ID="txtFechaIngreso" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                        <td>
                                            <b>Confidencialidad: </b>
                                            <asp:TextBox ID="txtConfidencialida" runat="server" Enabled="false" style="text-align: center"/>
                                        </td> 
                                        <td>
                                            <b>Supervisión: </b>
                                            <asp:TextBox ID="txtSupervision" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                    </tr>
                                </table>

                               <table border="0">
                                   <tr>
                                       <td>
                                            <b>Fuente Generadora: </b>
                                            <asp:TextBox ID="txtFuenteGeneradora" runat="server" Enabled="false" size="100" style="text-align: center" />
                                        </td>
                                   </tr>
                                    <tr>
                                        <td>
                                            <b>Tipo de Servicio: </b>
                                            <asp:TextBox ID="txtTipoServicio" runat="server" Enabled="false" size="100" style="text-align: center" />
                                        </td> 
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Funcionario que tramita: </b>
                                            <asp:TextBox ID="txtempleado" runat="server" Enabled="false" size="100" style="text-align: center" />
                                        </td> 
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Dirección Regional de Educación: </b>
                                            <asp:TextBox ID="txtRegional" runat="server" Enabled="false" size="100" style="text-align: center" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Nombre del Centro Educativo: </b>
                                            <asp:TextBox ID="txtCE" runat="server" Enabled="false" size="100" style="text-align: center" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Descripción de Unidad: </b>
                                            <asp:TextBox ID="txtUnidad" runat="server" Enabled="false" size="100" style="text-align: center" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Descripción de Despacho: </b>
                                            <asp:TextBox ID="txtDespacho" runat="server" Enabled="false" size="100" style="text-align: center" />
                                        </td>
                                    </tr>
                                   <tr>

                                        <td>
                                            <b>Descripción de Dirección: </b>
                                            <asp:TextBox ID="txtDireccion" runat="server" Enabled="false" size="100" style="text-align: center" />
                                        </td>
                                    </tr>
                                   <tr>
                                        <td>
                                            <b>Descripción de Departamento: </b>
                                            <asp:TextBox ID="txtDepartamento" runat="server" Enabled="false" size="100" style="text-align: center" />
                                        </td>
                                    </tr>
                                   <tr>
                                        <td>
                                            <b>Dimensión: </b>
                                            <asp:TextBox ID="txtDimension" runat="server" Enabled="false"  size="100" style="text-align: center"/>
                                        </td>
                                    </tr>
                                   <tr>
                                       <td>
                                            <b>Letra de Dimensión: </b>
                                             <asp:TextBox ID="txtLetraDim" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                    </tr>
                                   <tr>
                                        <td>
                                            <b>Detalle de la Dimensión: </b>
                                            <asp:label ID="lblDetalleDim" runat="server" backcolor="#f8f8f8" borderwidth="1px" />
                                        </td>
                                    </tr>
                                   </table>

                               <table border="0">
                                   <tr>
                                        <td>
                                            <b>Número de Oficio: </b>
                                            <asp:TextBox ID="txtNumOficio" runat="server" Enabled="false" style="text-align: center"/>
                                        </td>
                                        <td>
                                            
                                        </td>
                                       <td>
                                           <b>Tipo de Usuario: </b>
                                           <asp:TextBox ID="txtTipoUsuario" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                    </tr>
                                   <tr>
                                        <td>
                                             <b>Categoria de la Gestión: </b>
                                            <asp:TextBox ID="txtCategoria_Gestion" runat="server" Enabled="false" style="text-align: center" />                                       
                                        </td>
                                    </tr>
                                   </table>

                                  <table border="0">
                                   <tr>
                                       <td> 
                                           
                                       </td>
                                        <td>
                                             <b>Detalle de la Gestión: </b>
                                             <asp:Label ID="lblDetalleGestion" runat="server" backcolor="#f8f8f8" borderwidth="1px"  />                                        
                                        </td>
                                       <td> 
                                           
                                       </td>
                                    </tr>
                                   <tr>   
                                       <td> 
                                           
                                       </td>
                                        <td>
                                            <b>Respuesta de la Gestión: </b>
                                            <asp:Label ID="lblRespuesta_Gestion" runat="server" backcolor="#f8f8f8" borderwidth="1px" />
                                        </td>  
                                       <td> 
                                           
                                       </td>
                                    </tr>                                
                               </table> 

                           </div>
                           
                           <div class="footer" style="float: right">
                               <asp:Button ID="btnClose" runat="server" Text="Cerrar" CssClass="button"/>
                           </div>
                       </asp:Panel>

                   </div>
                </div>                                              
    </div>         
</asp:Content>
