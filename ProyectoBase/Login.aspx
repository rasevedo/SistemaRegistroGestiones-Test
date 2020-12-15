<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="CapPresentacionSiReGe.Login" %>

<%@ Register Assembly="LoginControl" Namespace="LoginControl.Logeo" TagPrefix="cc1" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="Contenido/Estilos.css" />
    <link rel="shortcut icon" href="/Contenido/Imagenes/MEP.ico" type="image/x-icon" />
    <title></title>
       <script type="text/javascript">
           // constants to define the title of the alert and button text.
           var ALERT_TITLE = "Sistema Registro de Gestiones";
           var ALERT_BUTTON_TEXT = "Ok";

           // over-ride the alert method only if this a newer browser.
           // Older browser will see standard alerts
           if (document.getElementById) {
               window.alert = function (txt) {
                   createCustomAlert(txt);
               }
           }
           function createCustomAlert(txt) {
               // shortcut reference to the document object
               d = document;

               // if the modalContainer object already exists in the DOM, bail out.
               if (d.getElementById("modalContainer")) return;

               // create the modalContainer div as a child of the BODY element
               mObj = d.getElementsByTagName("body")[0].appendChild(d.createElement("div"));
               mObj.id = "modalContainer";
               // make sure its as tall as it needs to be to overlay all the content on the page
               mObj.style.height = document.documentElement.scrollHeight + "px";

               // create the DIV that will be the alert 
               alertObj = mObj.appendChild(d.createElement("div"));
               alertObj.id = "alertBox";
               // MSIE doesnt treat position:fixed correctly, so this compensates for positioning the alert
               //if (d.all && !window.opera) alertObj.style.top = document.documentElement.clientHeight / 3 + "px";
               // center the alert box
               alertObj.style.left = (d.documentElement.scrollWidth - alertObj.offsetWidth) / 2 + "px";

               // create an H1 element as the title bar
               h1 = alertObj.appendChild(d.createElement("h1"));
               h1.appendChild(d.createTextNode(ALERT_TITLE));

               // create a paragraph element to contain the txt argument
               msg = alertObj.appendChild(d.createElement("p"));
               msg.innerHTML = txt;

               // create an anchor element to use as the confirmation button.
               btn = alertObj.appendChild(d.createElement("a"));
               btn.id = "closeBtn";
               btn.appendChild(d.createTextNode(ALERT_BUTTON_TEXT));
               btn.href = "#";
               // set up the onclick event to remove the alert when the anchor is clicked
               btn.onclick = function () { removeCustomAlert(); return false; }
           }

           // removes the custom alert from the DOM
           function removeCustomAlert() {
               document.getElementsByTagName("body")[0].removeChild(document.getElementById("modalContainer"));
           }

    </script>
</head>
<body id="fondo">
    <form id="form1" runat="server">
        <div id="pagina" >
            <div  id="encabezado" > </div>
              <div id="EncabezadoSistema">
            <br />
                  Sistema Registro de Gestiones
            </div> 
            <div id="separador"></div>
            <div id="ContenedorPrincipal" style="text-align:center" > 
                <br />
                <br />
                <cc1:LoginMEP ID="LoginMEP1" runat="server" />
                <br />
                <asp:Label ID="lblRecordatorio" runat="server" Font-Bold="true" 
                    ForeColor="#00a0e3">Recuerde ingresar con el Usuario y la Contraseña de Windows</asp:Label>
                <p></p>
            </div>
            <div id="piepagina">
                <table id="tablapiepagina">
                    <tr>
                        <td style="text-align:center; width:350px;"><asp:Label ID="lblVersion" runat="server" Text="Versión del Sistema:"></asp:Label></td>
                        <td style="text-align:center; width:650px;"> © 2018, Ministerio de Educación Pública de Costa Rica. Todos los derechos reservados.</td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

