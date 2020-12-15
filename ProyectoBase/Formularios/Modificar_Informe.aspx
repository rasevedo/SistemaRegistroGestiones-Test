<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Modificar_Informe.aspx.vb" Inherits="CapPresentacionSiReGe.Modificar_Informe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">               
            <div class="row">
                <div class="col-lg-12">                    
                        <header class="panel-heading">
                            <div class="col-md-5 col-md-offset-4">
                                <h1>Modificar Informe</h1>
                            </div>
                        </header>
                        <div class="panel-body">

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Codigo del Informe" runat="server" />
                                        <asp:TextBox ID="txtidInforme" runat="server" Enabled="false" CssClass="form-control input-sm"  />
                                    </div>
                                </div>                            
                            </div>

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
                                            <asp:ListItem Text="Informe" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Estudio" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Capacitación" Value="3"></asp:ListItem>
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
                            
                            <div class="row">                                
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Avance" runat="server"/>                              
                                        <asp:CheckBoxList ID="txtavanceInforme" runat="server"  >
                                            <asp:ListItem> 1&#176; etapa</asp:ListItem>
                                            <asp:ListItem> 2&#176; etapa</asp:ListItem>
                                            <asp:ListItem> 3&#176; etapa</asp:ListItem>
                                            <asp:ListItem> 4&#176; etapa</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                </div>                                                          
                            </div> 
                            
                            <div class="row">
                                 <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" CssClass="btn btn-primary" Width="170px" OnClick="btnUpdate_Click" />
                                    </div>
                                </div>
                                <div class="col-md-2 col-md-offset-6">
                                    <div class="form-group">
                                        <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnCancel_Click" />
                                    </div>
                                </div>                               
                             </div>
                           
                         </div>                                         
                </div>
            </div>                           
</asp:Content>
