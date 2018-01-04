<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageAdministrador.aspx.cs" Inherits="EDDS.PageAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 1558px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp; Pagina del Administrador de Naval Wars</div>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Area del Arbol y su Arbol Espejo: &nbsp;&nbsp;
            <asp:Button ID="Button16" runat="server" OnClick="Button16_Click" Text="Ocultar" />
        </p>
        <asp:Panel ID="Panel1" runat="server" BackColor="White" BorderStyle="Double" ForeColor="#0033CC" Height="494px" Width="766px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Carga de Usuarios:<br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Ubicacion:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Width="561px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Contenido del Archivo:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Height="261px" TextMode="MultiLine" Width="719px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button18" runat="server" OnClick="Button18_Click" Text="Cargar" />
            <br />
        </asp:Panel>
        <p>
            </p>
        <asp:Panel ID="Panel3" runat="server" BorderStyle="Double" Height="409px" Width="394px">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; ABC Arbol de Jugadores:<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Incertar Jugador:&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Contraseña:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox6" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Correo:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox7" runat="server" Width="236px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Conectado:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox8" runat="server" Width="82px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Nombre nuevo:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Incertar" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Eliminar" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Modificar" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button15" runat="server" OnClick="Button15_Click" Text="Ocultar " />
        </asp:Panel>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Arbol de Jugadores:</p>
        <p>
            <asp:Image ID="Image3" runat="server" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp; Arbol Espejo de Jugadores&nbsp;</p>
        <p>
            <asp:Image ID="Image4" runat="server" />
        </p>
        <p>
            &nbsp;</p>
        <asp:Panel ID="Panel2" runat="server" BorderStyle="Double" Height="580px" Width="766px">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Carga de Juegos:<br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Ubicacion:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Width="558px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cargar" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Contenido del Archivo:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" Height="347px" OnTextChanged="TextBox4_TextChanged" TextMode="MultiLine" Width="716px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button19" runat="server" OnClick="Button19_Click" Text="Cargar" />
        </asp:Panel>
        <p>
            &nbsp;</p>
        <p>
            </p>
        <asp:Panel ID="Panel7" runat="server" BorderStyle="Double" Height="505px" Width="421px">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; ABC de Lista de Juegos en los Jugadores:<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Usuario Base:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox30" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Oponente:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox31" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Unidades desplegadas:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox32" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Unidades sobrevieientes:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox33" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Unidades destruidas:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox34" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Gano:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox35" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button22" runat="server" OnClick="Button22_Click" Text="Incertar" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button23" runat="server" Text="Eliminar" />
        </asp:Panel>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp; Top Jugadores con mas Juegos Ganados:</p>
        <p>
            &nbsp;</p>
        <asp:Image ID="Image13" runat="server" />
        <p>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp; Top Jugadores con mas Unidades Destruidas</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Image ID="Image14" runat="server" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp; Area de Matrices:&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="Button17" runat="server" OnClick="Button17_Click" Text="Ocultar" />
        </p>
        <p>
            &nbsp;</p>
        <asp:Panel ID="Panel4" runat="server" BorderStyle="Double" Height="509px" Width="766px">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Carga de Tablero:<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Ubicacion:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox10" runat="server" Width="553px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Cargar" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Contenido del Archivo:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox11" runat="server" Height="316px" TextMode="MultiLine" Width="711px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Matriz de Sobrebivientes" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Matriz de unidades destruidas" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button20" runat="server" OnClick="Button20_Click" Text="Cargar" />
        </asp:Panel>
        <p>
            &nbsp;</p>
        <asp:Panel ID="Panel5" runat="server" BorderStyle="Double" Height="449px" Width="423px">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; ABC de Matriz:<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Fila:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
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
        </asp:Panel>
        <p>
            </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp; Matris de Unidades Sobrevivientes&nbsp;Nivel 0</p>
        <p>
            <asp:Image ID="Image5" runat="server" />
        </p>
        <p>
            </p>
        <p>
            &nbsp;&nbsp;&nbsp; Matris de Unidades Sobrevivientes&nbsp;Nivel 1&nbsp;</p>
        <p>
            <asp:Image ID="Image6" runat="server" Height="16px" />
            <asp:Image ID="Image15" runat="server" />
        </p>
        <p>
            </p>
        <p>
            &nbsp;&nbsp;&nbsp; Matris de Unidades Sobrevivientes&nbsp;Nivel 2&nbsp;</p>
        <p>
            <asp:Image ID="Image7" runat="server" />
        </p>
        <p>
            </p>
        <p>
            &nbsp;&nbsp;&nbsp; Matris de Unidades Sobrevivientes&nbsp;Nivel 3&nbsp;</p>
        <asp:Image ID="Image8" runat="server" />
        <p>
            </p>
        <p>
            &nbsp;&nbsp;&nbsp; Matris de Unidades Destruidas Nivel 0&nbsp;</p>
        <asp:Image ID="Image9" runat="server" />
        <p>
            </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp; Matris de Unidades Destruidas Nivel 1&nbsp;</p>
        <p>
            <asp:Image ID="Image10" runat="server" />
        </p>
        <p>
            </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp; Matris de Unidades Destruidas Nivel 2&nbsp;</p>
        <p>
            <asp:Image ID="Image11" runat="server" />
        </p>
        <p>
            </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Matris de Unidades Destruidas Nivel 3&nbsp;</p>
        <asp:Image ID="Image12" runat="server" />
        <p>
            </p>
        <p>
            </p>
        <asp:Panel ID="Panel6" runat="server" BorderStyle="Double" Height="949px" Width="766px">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Parametros del Juego:<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Cargar Parametros:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox27" runat="server" Width="504px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="Abrir" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox29" runat="server" Height="98px" TextMode="MultiLine" Width="654px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button21" runat="server" OnClick="Button21_Click" Text="Cargar" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Jugador 1:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Jugador 2:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Naves Nivel 1:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Naves Nivel 2:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Naves Nivel 3:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Naves Nivel 4:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Tamño &lt;X&gt; &lt;Y&gt;<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox23" runat="server" Width="40px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox24" runat="server" Width="46px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Tipo de Juego:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox25" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp; Tiempo:<br /> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox26" runat="server" Width="117px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text="Aceptar" />
        </asp:Panel>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
