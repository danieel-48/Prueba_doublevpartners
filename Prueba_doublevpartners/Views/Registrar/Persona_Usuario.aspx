<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Persona_Usuario.aspx.cs" Inherits="Prueba_doublevpartners.Views.Registrar.Persona_Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Persona y Usuario</title>
    <link href="~/Registrar.css" type="text/css" rel="stylesheet"/>
    <style>
        .login-page {
            display: flex; 
        }

        .form {
            width: 55%; 
            margin: 0 7.5%; 
            display: inline-block; 
            vertical-align: top;
        }
    </style>
</head>
<body>
    <form id="formRegistroPersona" runat="server">
        <div class="login-page">

            <div class="form">
                <h2>Registro de Persona</h2>
                <div class="styled-select">
                    <asp:DropDownList ID="cmbx_Tipo_Id" runat="server">
                        <asp:ListItem Text="Cedula Ciudadania"/>
                        <asp:ListItem Text="Tarjeta Identidad"/>
                        <asp:ListItem Text="Pasaporte"/>
                      
                    </asp:DropDownList>
                </div>
                <br />
                <asp:TextBox ID="txtID" runat="server" placeholder="Numero de Identificacion" CssClass="form-input" required="required"  AutoPostBack ="true"></asp:TextBox>
                 <asp:TextBox ID="txtIdentificador" runat="server" placeholder="Identificador" CssClass="form-input" required="required" AutoPostBack ="true" Enabled ="false" ></asp:TextBox>
                <asp:TextBox ID="txtNombres" runat="server" placeholder="Nombres" CssClass="form-input" required="required"></asp:TextBox>
                <asp:TextBox ID="txtApellidos" runat="server" placeholder="Apellidos" CssClass="form-input" required="required"></asp:TextBox>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-input" required="required"></asp:TextBox>
                <asp:Button ID="btnRegistrar_Persona" runat="server" Text="Registrar" CssClass="btn-style" OnClick="btnRegistrar_Click" />
            </div>

            <div class="login-page">
                <div class="form">
                    <h2>Registro de Usuario</h2>
                    <asp:TextBox ID="txtIdentificador_us" runat="server" placeholder="Identificador" CssClass="form-input" required="required" Enabled="false"></asp:TextBox>
                    <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario" CssClass="form-input" required="required"></asp:TextBox>
                    <asp:TextBox ID="txtPass" runat="server" placeholder="Pass" CssClass="form-input" required="required"></asp:TextBox>
                    <asp:Button ID="btnRegistrar_Usuario" runat="server" Text="Registrar" CssClass="btn-style" OnClick="btnRegistrar_Usuario_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
    
</html>
