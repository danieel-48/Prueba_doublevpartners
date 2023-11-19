<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log_In.aspx.cs" Inherits="Prueba_doublevpartners.Views.Login.Log_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar Sesión</title>
    <link href="~/Estilos.css" type="text/css" rel="stylesheet"/>

</head>
<body>
      <div class="login_page">
        <div class="form">
            <h2>Iniciar Sesión</h2>
            <form runat="server" class="login-form" method="post">
                <asp:TextBox ID="Usuariotxt" runat="server"  placeholder="Usuario" required="required"></asp:TextBox>
                 <asp:TextBox ID="Passtxt" runat="server"  placeholder="Contraseña" required="required" TextMode="Password"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Usuario no registrado" Enabled="False" Visible="False" ForeColor="Black"></asp:Label>
                <asp:Button ID="Button1" runat="server" class="btn-style" Text="Iniciar Sesión" OnClick="Button1_Click" type="submit" />
            </form>
        </div>
    </div>
</body>
</html>
