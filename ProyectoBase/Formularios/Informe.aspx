<%@ Page Title="Informe" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Informe.aspx.vb" Inherits="CapPresentacionSiReGe.Informe" EnableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">  
<link href="Estilo.css" rel="stylesheet" />
   
    <div class="row">

        <div class="col-lg-12" style="left: 0px; top: 20px; width: 1438px">
            <header class="panel-heading">
                <div class="col-md-5 col-md-offset-3">
                    <h1>Sistema de Informes</h1>
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
                                        <asp:Button Text="Borrar" ID="btnBorrar"  Width="170px" runat="server" OnClick="Button3_Click" />
                                    </div>
                                </div>
                                <div>
                                    <div class="col-md-2 col-md-offset-0">
                                        <asp:Button Text="Exportar" ID="btnExportar"  Width="170px" runat="server" OnClick="Button2_Click" />
                                    </div>
                                </div>                                
                                <div class="col-md-2 col-md-offset-0">
                                    <div class="form-group">
                                        <asp:Button Text="Volver" ID="btnVolver"  Width="170px" runat="server" OnClick="Button4_Click" />
                                    </div>
                                </div>    
                             </div> 

                           

                
                   <div id="grdCharges" runat="server"  style="width: 1145px; overflow: auto; height: 450px">

                       <asp:GridView ID="GridViewInforme" runat="server" CellPadding="10" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="2px" AutoGenerateColumns="False" DataKeyNames="idInforme" AllowPaging="True" AllowSorting="True" CellSpacing="10" HorizontalAlign="Center">
                           <Columns>
                               <asp:buttonfield buttontype="Button" commandname="Select" text="Detalle"/>
                               <asp:HyperLinkField Text="Modificar" DataNavigateUrlFields="idInforme" DataNavigateUrlFormatString="Modificar_Informe.aspx?idInforme={0}" />
                               <asp:TemplateField>
                                   <HeaderTemplate>
                                        <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" onclick="GridCheckOne(this)"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                               <asp:BoundField DataField="idInforme" HeaderText="Codigo del Informe" ReadOnly="True" InsertVisible="False" ></asp:BoundField>
                               <asp:BoundField DataField="tituloInforme" HeaderText="Título del Informe" ></asp:BoundField>
                               <asp:BoundField DataField="nombreEmpleados" HeaderText="Funcionario que Tramita" ></asp:BoundField>
                               <asp:BoundField DataField="tipoInforme" HeaderText="Tipo de Informe" ></asp:BoundField>
                               <asp:BoundField DataField="numeroOficio" HeaderText="Número del Oficio" ></asp:BoundField>
                               <asp:BoundField DataField="fechaAprobacion" HeaderText="Fecha de Aprobación" ></asp:BoundField>
                               <asp:BoundField DataField="fechaCulminacion" HeaderText="Fecha de Culminación" ></asp:BoundField>
                               <asp:BoundField DataField="fechaTraslado" HeaderText="Fecha de Traslado" ></asp:BoundField>
                               <asp:BoundField DataField="avanceInforme" HeaderText="Avance" ></asp:BoundField>
                           </Columns>



                            <RowStyle Width="250px" BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Wrap="True" />
                            <FooterStyle BackColor="#00A0E3" ForeColor="White" />
                            <PagerStyle BackColor="#00A0e3" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#00A0e3" ForeColor="White" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                            

                       </asp:GridView>

                       <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:SiReGeConnectionString %>' SelectCommand="mostrarInforme" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                  
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

                       <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none" ScrollBars="Vertical" Height="430px" >
                           <div class="header">
                               Detalles del Informe
                           </div>
                           <div class="body">
                               <table border="0">
                                   <tr>
                                       <td> 
                                           
                                       </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Codigo de Informe"></asp:Label>
                                           <asp:TextBox ID="txtId_Informe" runat="server" Enabled="false" style="text-align: center"/>
                                        </td>
                                       <td> 
                                           
                                       </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Título del Informe: </b>
                                            <asp:TextBox ID="txtTitulo_Informe" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                        <td>
                                            <b>Nombre del funcionario: </b>
                                            <asp:TextBox ID="txtEmpleado_Informe" runat="server" Enabled="false" style="text-align: center"/>
                                        </td>
                                        <td>
                                            <b>Tipo de Informe: </b>
                                            <asp:TextBox ID="txtTipo_Informe" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Número de Oficio: </b>
                                            <asp:TextBox ID="txtNumOficio_Informe" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                        <td>
                                            
                                        </td> 
                                        <td>
                                            
                                        </td>
                                    </tr>
                                   <tr>
                                        <td>
                                            <b>Fecha de Aprobación: </b>
                                            <asp:TextBox ID="txtFechaAprobacion" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                        <td>
                                            <b>Fecha de Culminación: </b>
                                            <asp:TextBox ID="txtFechaCulminacion" runat="server" Enabled="false" style="text-align: center" />
                                        </td> 
                                        <td>
                                            <b>Fecha de Traslado: </b>
                                            <asp:TextBox ID="txtFechaTraslado" runat="server" Enabled="false" style="text-align: center" />
                                        </td>
                                    </tr>
                                   <tr>
                                        <td>
                                            <b>Avance: </b>
                                            <asp:TextBox ID="txtAvance_Informe" runat="server" Enabled="false" style="text-align: center" size="30"/>
                                        </td>
                                        <td>
                                           
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
