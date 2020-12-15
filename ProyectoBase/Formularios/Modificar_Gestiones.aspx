<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Modificar_Gestiones.aspx.vb" Inherits="CapPresentacionSiReGe.Modificar_Gestiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">                
            <div class="row">
                <div class="col-lg-12">                    
                        <header class="panel-heading">
                            <div class="col-md-5 col-md-offset-4">
                                <h1>Modificar Gestion</h1>
                            </div>
                        </header>
                        <div class="panel-body">

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Codigo de Gestión" runat="server" />
                                        <asp:TextBox ID="txtidGestiones" runat="server" Enabled="false" CssClass="form-control input-sm"  />
                                    </div>
                                </div>                            
                            </div>


                            <div class="row">                               
                                <div class="col-md-3 col-md-offset-5">
                                    <div class="form-group">
                                        <asp:Label Text="Tipo de Gestión*" runat="server" />
                                        <br />
                                        <br />
                                        <asp:RadioButtonList ID="RadioButtonList1"  runat="server" RepeatLayout="Flow" >
                                            <asp:ListItem>Atención presencial</asp:ListItem>
                                            <asp:ListItem>Vía telefonica</asp:ListItem>
                                            <asp:ListItem>Correo Electrónico</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                    </div>
                                </div>                              
                            </div>


                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Cédula del Usuario" runat="server" />
                                        <asp:TextBox ID="txtcedulaUsuario" runat="server" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Nombre del Usuario" runat="server" />
                                        <asp:TextBox ID="txtnombreUsuario" runat="server" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1" >
                                    <div class="form-group">
                                        <asp:Label Text="Fecha de Ingreso*" runat="server"/>
                                        <asp:TextBox ID="txtfechaIngreso" runat="server" TextMode="Date" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Funcionario que tramita*" runat="server"/>                                       
                                        <asp:DropDownList ID="idEmpleados" runat="server" CssClass="form-control input-sm" DataSourceID="SqlDataSource1" DataTextField="nombreEmpleados" DataValueField="idEmpleados"  />
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SiReGeConnectionString %>" SelectCommand="SELECT [idEmpleados], [nombreEmpleados] FROM [Empleados]"></asp:SqlDataSource>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Confidencialidad" runat="server" />
                                        <asp:DropDownList ID="txtConfidencialidad" runat="server" CssClass="form-control input-sm" >
                                            <asp:ListItem Text="-Seleccione-" Value=" "></asp:ListItem>
                                            <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        </asp:DropDownList>                                                                                   
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Fuente Generadora*" runat="server" />
                                        <asp:DropDownList ID="txtfuenteGeneradora" runat="server" CssClass="form-control input-sm" >
                                            <asp:ListItem Text="-Seleccione-" Value=" "></asp:ListItem>
                                            <asp:ListItem Text="Solicitud de un usuario" Value="Solicitud de un usuario"></asp:ListItem>
                                            <asp:ListItem Text="Solicitud del Jerarca de la Administración Activa" Value="Solicitud del Jerarca de la Administración Activa"></asp:ListItem>
                                            <asp:ListItem Text="Solicitud de algún titular de una Dirección del sector académico o administrativo" Value="Solicitud de algún titular de una Dirección del sector académico o administrativo"></asp:ListItem>
                                        </asp:DropDownList>                                                                                   
                                    </div>
                                </div>
                            </div>

                            <div class="row">                                
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Tipo de servicio*" runat="server" />
                                        <asp:DropDownList ID="txttipoServicio" runat="server" CssClass="form-control input-sm" >
                                            <asp:ListItem Text="-Seleccione-" Value=" "></asp:ListItem>
                                            <asp:ListItem Text="Evacuación de Consultas" Value="Evacuación de Consultas"></asp:ListItem>
                                            <asp:ListItem Text="Denuncias e inconformidades" Value="Denuncias e inconformidades"></asp:ListItem>
                                            <asp:ListItem Text="Investigaciones integrales de gestión del servicio" Value="Investigaciones integrales de gestión del servicio"></asp:ListItem>
                                            <asp:ListItem Text="Asesoramiento y acompañamiento en instrucción" Value="Asesoramiento y acompañamiento en instrucción"></asp:ListItem>
                                            <asp:ListItem Text="Elaboración de instrumentos y mecanismos de referencia para la evaluación global del servicio" Value="Elaboración de instrumentos y mecanismos de referencia para la evaluación global del servicio"></asp:ListItem>
                                        </asp:DropDownList>                                                                                   
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Dirección Regional de Educación" runat="server" />
                                        <asp:DropDownList ID="txtdireccionRegionalEducacion" runat="server" CssClass="form-control input-sm" >
                                            <asp:ListItem Text="-Seleccione-" Value=" "></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN AGUIRRE" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN AGUIRRE"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE ALAJUELA" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE ALAJUELA"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE CAÑAS" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE CAÑAS"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE CARTAGO" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE CARTAGO"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE COTO" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE COTO"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE DESAMPARADOS" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE DESAMPARADOS"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE GUÁPILES" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE GUÁPILES"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE HEREDIA" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE HEREDIA"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE LIBERIA" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE LIBERIA"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE LIMÓN" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE LIMÓN"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE NICOYA" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE NICOYA"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE OCCIDENTE" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE OCCIDENTE"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE PÉREZ ZELEDÓN" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE PÉREZ ZELEDÓN"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE PUNTARENAS" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE PUNTARENAS"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE PURISCAL" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE PURISCAL"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE SAN CARLOS" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE SAN CARLOS"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE SANTA CRUZ" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE SANTA CRUZ"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE SARAPIQUÍ" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE SARAPIQUÍ"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN DE TURRIALBA" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN DE TURRIALBA"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN GRANDE DE TÉRRABA" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN GRANDE DE TÉRRABA"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN NORTE-NORTE" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN NORTE-NORTE"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN SAN JOSÉ NORTE" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN SAN JOSÉ NORTE"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN SAN JOSÉ OESTE" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN SAN JOSÉ OESTE"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL SAN JOSÉ CENTRAL" Value="DIRECCIÓN REGIONAL SAN JOSÉ CENTRAL"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN LOS SANTOS" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN LOS SANTOS"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN PENINSULAR" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN PENINSULAR"></asp:ListItem>
                                            <asp:ListItem Text="DIRECCIÓN REGIONAL DE EDUCACIÓN SULÁ" Value="DIRECCIÓN REGIONAL DE EDUCACIÓN SULÁ"></asp:ListItem>
                                        </asp:DropDownList>                                                                                   
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Supervisión " runat="server" />
                                        <asp:DropDownList ID="txtSupervision" runat="server" CssClass="form-control input-sm" >
                                            <asp:ListItem Text="-Seleccione-" Value=" "></asp:ListItem>
                                            <asp:ListItem Text="Circuito 1" Value="Circuito 1"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 2" Value="Circuito 2"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 3" Value="Circuito 3"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 4" Value="Circuito 4"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 5" Value="Circuito 5"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 6" Value="Circuito 6"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 7" Value="Circuito 7"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 8" Value="Circuito 8"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 9" Value="Circuito 9"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 10" Value="Circuito 10"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 11" Value="Circuito 11"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 12" Value="Circuito 12"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 13" Value="Circuito 13"></asp:ListItem>
                                            <asp:ListItem Text="Circuito 14" Value="Circuito 14"></asp:ListItem>
                                        </asp:DropDownList>                                                                                   
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Nombre del Centro Educativo" runat="server" />
                                        <asp:TextBox ID="txtnombreCE" runat="server" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Descripción Unidad" runat="server" />
                                        <asp:DropDownList ID="DD1" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="DD1_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="descripcionUnidad" DataValueField="idUnidad"></asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:SiReGeConnectionString %>' SelectCommand="SELECT [idUnidad], [descripcionUnidad] FROM [Unidad]"></asp:SqlDataSource>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1" >
                                    <div class="form-group">
                                        <asp:Label Text="Número de Oficio " runat="server"/>
                                        <asp:TextBox ID="txtnumeroOficio" runat="server"  Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Descripción Despacho" runat="server" />                                      
                                        <asp:TextBox ID="txtDespacho" runat="server" Enabled="false" CssClass="form-control input-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Descripción Dirección" runat="server" />
                                        <asp:TextBox ID="txtDireccion" runat="server" Enabled="false" CssClass="form-control input-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1" >
                                    <div class="form-group">
                                        <asp:Label Text="Descripción Departamento" runat="server"/>
                                        <asp:TextBox ID="txtDepartamento" runat="server" Enabled="false" CssClass="form-control input-sm"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Dimensión*" runat="server" />
                                        <asp:DropDownList ID="DDL_Dimension1" runat="server" CssClass="form-control input-sm" DataSourceID="SqlDataSource3" DataTextField="tipoDimension" DataValueField="tipoDimension"></asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:SiReGeConnectionString %>' SelectCommand="SELECT        tipoDimension
FROM            Dimensiones
GROUP BY tipoDimension"></asp:SqlDataSource>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                   <div class="form-group">
                                        <asp:Label Text="Letra Dimensión*" runat="server" />
                                        <asp:DropDownList ID="DDL_Dimension2" runat="server" CssClass="form-control input-sm" DataSourceID="SqlDataSource4" DataTextField="letraDimension" DataValueField="idDimension" AutoPostBack="True" OnSelectedIndexChanged="DDL_Dimension2_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:SiReGeConnectionString %>' SelectCommand="SELECT [idDimension], [letraDimension] FROM [Dimensiones] WHERE ([tipoDimension] = @tipoDimension)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="DDL_Dimension1" PropertyName="SelectedValue" Name="tipoDimension" Type="String"></asp:ControlParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                       
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1" >
                                    <div class="form-group">
                                        <asp:Label Text="Detalle Dimensión*" runat="server"/>
                                       <asp:TextBox ID="txtTipoDetalleLetraDimension" runat="server" Enabled="false" CssClass="form-control input-sm" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Tipo de Usuario*" runat="server"  />
                                        <asp:DropDownList ID="txtTipoUsuario" runat="server" CssClass="form-control input-sm">                            
                                            <asp:ListItem Text="-Seleccione-" Value=" "></asp:ListItem>
                                            <asp:ListItem Text="Externo" Value="Externo"></asp:ListItem>
                                            <asp:ListItem Text="Interno" Value="Interno"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Categoría" runat="server" />
                                        <asp:DropDownList ID="txtCategoria" runat="server" CssClass="form-control input-sm"> 
                                            <asp:ListItem Text="-Seleccione-" Value=" "></asp:ListItem>
                                            <asp:ListItem Text="Redireccionar a dependencia" Value="Redireccionar a dependencia"></asp:ListItem>
                                            <asp:ListItem Text="Asignación casos DAT" Value="Asignación casos DAT"></asp:ListItem>
                                            <asp:ListItem Text="Prensa y Drh comunicaciones" Value="Prensa y Drh comunicaciones"></asp:ListItem>
                                            <asp:ListItem Text="Mejora Continua" Value="Mejora Continua"></asp:ListItem>
                                            <asp:ListItem Text="Espera información" Value="Espera información"></asp:ListItem>
                                            <asp:ListItem Text="Dirección de la CS" Value="Dirección de la CS"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>                                
                            </div>

                            <div class="row">
                                <div class="col-lg-12 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Detalle*" runat="server" />                                       
                                        <asp:TextBox runat="server" ID="txtasunto" TextMode="Multiline" CssClass="form-control input-lg"  Name="S1" Rows="5" Cols="12" />
                                    </div>
                                </div>
                            </div>                           
                            <div class="row">                              
                                <div class="col-md-12 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Respuesta" runat="server"/>
                                        <asp:TextBox runat="server" ID="txtrespuesta" TextMode="Multiline" Enabled="true" CssClass="form-control input-lg" Name="S2" Rows="5" Cols="12" />                                        
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
