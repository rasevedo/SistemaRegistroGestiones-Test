<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Form_Insertar_Informe.aspx.vb" Inherits="CapPresentacionSiReGe.Form_Insertar_Informe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">            
            <div class="row">
                <div class="col-lg-12">                    
                        <header class="panel-heading">
                            <div class="col-md-5 col-md-offset-4">
                                <h1>Insertar Informe</h1>
                            </div>
                        </header>
                        <div class="panel-body">

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Título del Informe" runat="server" />
                                        <asp:TextBox ID="txttituloInforme" runat="server" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Funcionario que tramita*" runat="server"/>                                       
                                        <asp:DropDownList ID="idEmpleados" runat="server" CssClass="form-control input-sm" DataSourceID="SqlDataSource1" DataTextField="nombreEmpleados" DataValueField="idEmpleados"  />
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SiReGeConnectionString %>" SelectCommand="SELECT [idEmpleados], [nombreEmpleados] FROM [Empleados]"></asp:SqlDataSource>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1" >
                                    <div class="form-group">
                                        <asp:Label Text="Tipo de Informe " runat="server"/>
                                        <asp:DropDownList ID="txttipoInforme" runat="server" CssClass="form-control input-sm" >
                                            <asp:ListItem Text="Informe" Value="Informe"></asp:ListItem>
                                            <asp:ListItem Text="Estudio" Value="Estudio"></asp:ListItem>
                                            <asp:ListItem Text="Capacitación" Value="Capacitación"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Número de oficio " runat="server"/>
                                        <asp:TextBox ID="txtnumeroOficio" runat="server"  Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Fecha de Aprobación" runat="server"/>
                                        <asp:TextBox ID="txtfechaAprobacion" runat="server" TextMode="Date" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>                              
                            </div>

                            <div class="row">                                
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Fecha de Culminación" runat="server"/>
                                        <asp:TextBox ID="txtfechaCulminacion" runat="server" TextMode="Date" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>                            
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Fecha de Traslado" runat="server"/>
                                        <asp:TextBox ID="txtfechaTraslado" runat="server" TextMode="Date" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>
                            </div>   

                            <script type="text/javascript">
                                function OnlyOneCheckList(chk) {
                                    var chkList = chk.parentNode.parentNode.parentNode;
                                    var chks = chkList.getElementsByTagName("input");
                                    for (var i = 0; i < chks.length; i++) {
                                        if (chks[i] != chk && chk.checked) {
                                            chks[i].checked = false;
                                        }
                                    }
                                }
                            </script>


                            <div class="row">                                
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Avance" runat="server"/>                              
                                        <asp:CheckBoxList ID="txtavanceInforme" runat="server"  >
                                            <asp:ListItem Text="1° etapa" Value="1"  />
                                            <asp:ListItem Text="2° etapa" Value="2"  />
                                            <asp:ListItem Text="3° etapa" Value="3"  />
                                            <asp:ListItem Text="4° etapa" Value="4"  />
                                        </asp:CheckBoxList>
                                    </div>
                                </div>                                                          
                            </div> 
                                                                                                            
                            <div class="row">
                                 <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="Button1_Click" />
                                    </div>
                                </div>
                                <div class="col-md-2 col-md-offset-6">
                                    <div class="form-group">
                                        <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="Button2_Click" />
                                    </div>
                                </div>                               
                             </div>
                           
                         </div>                                         
                </div>
            </div>                           
</asp:Content>

