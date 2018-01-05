<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageUser.aspx.cs" Inherits="EDDS.PageUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 2712px">
    <form id="form1" runat="server">
    <div style="height: 2716px">
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Pagina de Usuario:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; Versus&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tamaño de Tablero:&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
&nbsp; X&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tipo de Juego:&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tiempo:&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; min.<br />
        <br />
        <br />
        <asp:Panel ID="Panel5" runat="server" BorderStyle="Double" Height="552px" Width="423px">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; ABC de Matriz:<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Fila:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox12" runat="server" Height="22px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Columna:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Pieza:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Jugador:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Destruida:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Incertar" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Eliminar" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button14" runat="server" OnClick="Button14_Click" Text="Modificar" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Matriz de unidades destruidas" Width="254px" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Matriz de Sobrebivientes" Width="253px" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp; Matris de Unidades Sobrevivientes&nbsp;Nivel 0</p>
            <asp:Image ID="Image5" runat="server" />
            <p>
                &nbsp;&nbsp;&nbsp; Matris de Unidades Sobrevivientes&nbsp;Nivel 1&nbsp;</p>
            <asp:Image ID="Image15" runat="server" />
            <p>
                &nbsp;&nbsp;&nbsp; Matris de Unidades Sobrevivientes&nbsp;Nivel 2&nbsp;</p>
            <asp:Image ID="Image7" runat="server" />
            <p>
                &nbsp;&nbsp;&nbsp; Matris de Unidades Sobrevivientes&nbsp;Nivel 3&nbsp;</p>
            <asp:Image ID="Image8" runat="server" />
            <br />
            <br />
            <br />
            <br />
            <p>
                &nbsp;&nbsp;&nbsp; Matris de Unidades Destruidas Nivel 0&nbsp;</p>
            <asp:Image ID="Image9" runat="server" />
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp; Matris de Unidades Destruidas Nivel 1&nbsp;</p>
            <asp:Image ID="Image10" runat="server" />
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp; Matris de Unidades Destruidas Nivel 2&nbsp;</p>
            <asp:Image ID="Image11" runat="server" />
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Matris de Unidades Destruidas Nivel 3&nbsp;</p>
            <asp:Image ID="Image12" runat="server" />
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel6" runat="server" BorderStyle="Double" Height="1047px" Width="570px">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp; Juego<br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp; Piesa que reailza ataque:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp; Coordenada inicial X:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp; Coordenada inicial Y:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp; Coordenada final X:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp; Coordenada final Y:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp; Piesa que recive ataque:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button15" runat="server" OnClick="Button15_Click" Text="Atacar" />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp; Historial de juego:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox20" runat="server" Height="282px" TextMode="MultiLine" Width="512px"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button17" runat="server" OnClick="Button17_Click" Text="Lista de Ataques" />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button18" runat="server" OnClick="Button18_Click" Text="Lista de Ataques 2" />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button19" runat="server" OnClick="Button19_Click" Text="Lista de Eliminadas" />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button16" runat="server" OnClick="Button16_Click" Text="Finalizar Juego Actual" />
            </asp:Panel>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
