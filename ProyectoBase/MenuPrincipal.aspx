<%@ Page Title="MenuPrincipal" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master"  CodeBehind="MenuPrincipal.aspx.vb" Inherits="CapPresentacionSiReGe.MenuPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="row"> 
        <div class="col-lg-12">
            
                <header class="panel-heading">
                    <div class="col-md-5 col-md-offset-4">
                        <h1></h1>
                    </div>
                </header>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-3 col-md-offset-1">
                            <div class="form-group">                              
                                <asp:ImageButton ID="ImgBtnGestion" runat="server" ImageUrl="~/Contenido/Imagenes/Atencion de Gestiones del Servicio_OFF.png"  OnClick="ImgBtnGestion_Click"/>
                            </div>
                            <div>
                                <asp:Label Text="Atención de Gestiones del Servicio" runat="server" CssClass="centrar" />
                            </div>
                        </div>
                            <div class="col-md-3 col-md-offset-1">
                                <div class="form-group">              
                                    <asp:ImageButton ID="ImgBtnDAU" runat="server" ImageURL="~/Contenido/Imagenes/DAU_OFF.png"  OnClick="ImgBtnDAU_Click"/>
                                </div>
                                <div>
                                    <asp:Label Text="Departamento de Atención al Usuario" runat="server" CssClass="centrar" />
                                </div>
                            </div> 
                            <div class="col-md-3 col-md-offset-1">
                                <div class="form-group">                                   
                                    <asp:ImageButton ID="ImgBtnDMC" runat="server" ImageURL="~/Contenido/Imagenes/DMC_OFF.png"  OnClick="ImgBtnDMC_Click"/>
                                </div>
                                <div>
                                    <asp:Label Text="Departamento de Mejora Continua" runat="server" CssClass="centrar" />
                                </div>
                            </div>                       
                     </div>
                </div>
             
        </div>
    </div>                     
</asp:Content>

