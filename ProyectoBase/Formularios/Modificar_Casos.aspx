<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Modificar_Casos.aspx.vb" Inherits="CapPresentacionSiReGe.Modificar_Casos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">                
            <div class="row">
                <div class="col-lg-12">                    
                        <header class="panel-heading">
                            <div class="col-md-5 col-md-offset-4">
                                <h1>Modificar Caso</h1>
                            </div>
                        </header>
                        <div class="panel-body">

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Codigo de Caso" runat="server" />
                                        <asp:TextBox ID="txtidCasos" runat="server" Enabled="false" CssClass="form-control input-sm"  />
                                    </div>
                                </div>                            
                            </div>

                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Número de Caso" runat="server" />
                                        <asp:TextBox ID="txtnumeroCaso" runat="server" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Estado del Caso" runat="server" />
                                        <asp:DropDownList ID="txtestadoCaso" runat="server" CssClass="form-control input-sm" >
                                            <asp:ListItem Text=" " Value="0"></asp:ListItem>
                                            <asp:ListItem Text="ABIERTO" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="CERRADO" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1" >
                                    <div class="form-group">
                                        <asp:Label Text="Fecha de Caso*" runat="server"/>
                                        <asp:TextBox ID="txtfechaCaso" runat="server" TextMode="Date" Enabled="true" CssClass="form-control input-sm"  />
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
                                        <asp:Label Text="Funcionario que Tramita" runat="server"/>                                       
                                        <asp:DropDownList ID="idEmpleados" runat="server" CssClass="form-control input-sm" DataSourceID="SqlDataSource1" DataTextField="nombreEmpleados" DataValueField="idEmpleados"  />
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SiReGeConnectionString %>" SelectCommand="SELECT [idEmpleados], [nombreEmpleados] FROM [Empleados]"></asp:SqlDataSource>
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
                                        <asp:Label Text="Número de Oficio" runat="server"/>
                                        <asp:TextBox ID="txtnumeroOficio" runat="server"  Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Fecha de Oficio" runat="server"/>
                                        <asp:TextBox ID="txtfechaOficio" runat="server" TextMode="Date" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>
                            </div>
                        
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Condición del Caso" runat="server"  />
                                        <asp:DropDownList ID="txtcondicionCaso" runat="server" CssClass="form-control input-sm">                            
                                            <asp:ListItem Text="EXTERNO " Value="1"></asp:ListItem>
                                            <asp:ListItem Text="INTERNO " Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Descripción Unidad" runat="server" />
                                        <asp:DropDownList ID="DD1" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="DD1_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="descripcionUnidad" DataValueField="idUnidad"></asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:SiReGeConnectionString %>' SelectCommand="SELECT [idUnidad], [descripcionUnidad] FROM [Unidad]"></asp:SqlDataSource>
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
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:SiReGeConnectionString %>' SelectCommand="SELECT  tipoDimension FROM Dimensiones GROUP BY tipoDimension"></asp:SqlDataSource>
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
                                        <asp:Label Text="Valoración de Admisibilidad" runat="server"  />
                                        <asp:DropDownList ID="txtvaloracionAdmisibilidad" runat="server" CssClass="form-control input-sm">                            
                                            <asp:ListItem Text="Poca complejidad" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Mediana complejidad" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Alta complejidad" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Veredicto de la Valoración de Ingreso" runat="server" />
                                        <asp:DropDownList ID="txtveredictoValoracion" runat="server" CssClass="form-control input-sm">                            
                                            <asp:ListItem Text="Desestimación" Value="Desestimación"></asp:ListItem>
                                            <asp:ListItem Text="Traslado a otras instancias administrativas o jurisdiccionales" Value="Traslado a otras instancias administrativas o jurisdiccionales"></asp:ListItem>
                                            <asp:ListItem Text="Aceptación condicionada a la ampliación de datos" Value="Aceptación condicionada a la ampliación de datos"></asp:ListItem>
                                            <asp:ListItem Text="Inicio de una investigación" Value="Inicio de una investigación"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Trazabilidad " runat="server" />
                                        <asp:DropDownList ID="txttrazabilidadCaso" runat="server" CssClass="form-control input-sm">                            
                                            <asp:ListItem Text="Despacho Ministerial" Value="Despacho Ministerial"></asp:ListItem>
                                            <asp:ListItem Text="Viceministerio" Value="Viceministerio"></asp:ListItem>
                                            <asp:ListItem Text="Dirección" Value="Dirección"></asp:ListItem>
                                            <asp:ListItem Text="Departamento" Value="Departamento"></asp:ListItem>
                                            <asp:ListItem Text="Unidad" Value="Unidad"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-lg-12 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Detalle de Inconformidad" runat="server" />                                       
                                        <asp:TextBox runat="server" ID="txtasunto" TextMode="Multiline" CssClass="form-control input-lg"  Name="S1" Rows="5" Cols="12" />
                                    </div>
                                </div>
                            </div>                           
                            <div class="row">                              
                                <div class="col-md-12 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Respuesta del Caso" runat="server"/>
                                        <asp:TextBox runat="server" ID="txtrespuesta" TextMode="Multiline" Enabled="true" CssClass="form-control input-lg" Name="S2" Rows="5" Cols="12" />                                        
                                    </div>
                                </div>
                            </div>  
                            
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Fecha de Respuesta" runat="server"/>
                                        <asp:TextBox ID="txtfechaRespuestaCasos" runat="server" TextMode="Date" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Fecha de Cierre" runat="server"/>
                                        <asp:TextBox ID="txtfechaCerradoCasos" runat="server" TextMode="Date" Enabled="true" CssClass="form-control input-sm"  />
                                    </div>
                                </div>                                
                            </div>

                            <div class="row">
                                 <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                         <asp:Button ID="btnAgregarAvance" runat="server" CssClass="btn btn-primary" Width="170px" Text="Agregar Avance" OnClick="btnAgregarAvance_Click" />
                                    </div>
                                </div>
                                                             
                             </div>

                            
                            <asp:UpdatePanel ID="AvancePanel" runat="server">
                                <ContentTemplate>


                                    <div class="row">
                                    <div class="col-md-3 col-md-offset-1" >
                                            <div class="form-group">
                                                <asp:Label Text="Fecha del Avance" runat="server"/>
                                                <asp:TextBox ID="txtFechaAvance" runat="server" TextMode="Date" Enabled="true" CssClass="form-control input-sm"  />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 col-md-offset-1">
                                            <div class="form-group">
                                                <asp:Label Text="Detalle del Avance" runat="server" />
                                                <asp:TextBox runat="server" ID="txtDetalleAvance" TextMode="Multiline" Enabled="true" CssClass="form-control input-lg" Rows="2" Cols="12" />
                                            </div>
                                        </div>                                       
                                    </div> 
                                    
                                    <div class="row">
                                        <div class="col-md-3 col-md-offset-1">
                                            <div class="form-group">                                                
                                                <asp:Button ID="btnInsertarAvance" runat="server" Text="Insertar Avance" CssClass="btn btn-primary" Width="170px" OnClick="btnInsertarAvance_Click" />
                                            </div>
                                        </div>                                                                      
                                    </div>

                                    <asp:GridView ID="GridviewAvance" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" DataKeyNames="idAvanceCasos,idCasos" >
                                        <Columns>
                                            <asp:BoundField DataField="idAvanceCasos" HeaderText="Codigo de Avance(General)" ReadOnly="True" InsertVisible="False" SortExpression="idAvanceCasos" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="idCasos" HeaderText="Codigo de Caso" SortExpression="idCasos" InsertVisible="False" ReadOnly="True" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="detalleAvance" HeaderText="Detalle del Avance" SortExpression="detalleAvance"></asp:BoundField>
                                            <asp:BoundField DataField="fechaAvance" HeaderText="Fecha del Avance" SortExpression="fechaAvance"></asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                        <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>
                                        <RowStyle ForeColor="#000066"></RowStyle>
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                        <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                                        <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                                        <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                                        <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                                    </asp:GridView>

                                    </div>
                                </div>
                            </div>
                          
                                <asp:SqlDataSource runat="server" ID="SqlDataSource6" ConnectionString='<%$ ConnectionStrings:SiReGeConnectionString %>' SelectCommand="mostrarAvancesCasos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </ContentTemplate>
                          </asp:UpdatePanel>

                            
                            
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


