using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace EDDS
{
    public partial class PageAdministrador : System.Web.UI.Page
    {
        int visibleA = 1;
        ServiceRef.ServicioWebSoapClient Servicio = new ServiceRef.ServicioWebSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(TextBox1.Text);
            String line;
            line = sr.ReadLine();
            String Contenido = "";
            int evitar = 0;
            while (line != null)
            {
                if (evitar == 0) { evitar++; }
                else { Contenido += line + "\n"; }                
                line = sr.ReadLine();
            }
            sr.Close();
            TextBox2.Text = Contenido;

            String Cont = Contenido;
            String[] ss = new String[] { "\n" };
            String[] st = new String[] { "," };
            String[] Lineas = Cont.Split(ss, StringSplitOptions.None);
            String nick = "";
            String pasw = "";
            String mail = "";
            int conect = 0;
            int conteo = 0;

            foreach (String s in Lineas)
            {
                String[] Valores = s.Split(st, StringSplitOptions.None);
                foreach (String v in Valores)
                {
                    if (conteo == 0) { nick = v; }
                    if (conteo == 1) { pasw = v; }
                    if (conteo == 2) { mail = v; }
                    if (conteo == 3)
                    {
                        int valor;
                        int.TryParse(v, out valor);
                        conect = valor;
                    }
                    conteo++;
                    if (conteo == 4)
                    {
                        Servicio.InsercionMasivaArbol(nick, pasw, mail, conect);
                        conteo = 0;
                    }
                }
            }
            Servicio.Pintar();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
            Image3.ImageUrl = "./Imagenes/GrafoA.png";
            Image4.ImageUrl = "./Imagenes/GrafoAESP.png";
            //StreamWriter crear = new StreamWriter(Server.MapPath("Imagenes/a.txt"));
            //crear.WriteLine("digraph grafo{");
            //crear.Close();           
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(TextBox3.Text);
            String line;
            line = sr.ReadLine();
            String Contenido = "";
            int evitar = 0;
            while (line != null)
            {
                if (evitar == 0) { evitar++; }
                else { Contenido += line + "\n"; }
                line = sr.ReadLine();
            }
            sr.Close();
            TextBox4.Text = Contenido;

            String Cont = Contenido;
            String[] ss = new String[] { "\n" };
            String[] st = new String[] { "," };
            String[] Lineas = Cont.Split(ss, StringSplitOptions.None);
            String ub = "";
            String op = "";
            int undep = 0;
            int unsob = 0;
            int undet = 0;
            int gano = 0;
            int conteo = 0;

            foreach (string s in Lineas)
            {
                string[] Valores = s.Split(st, StringSplitOptions.None);
                foreach (string v in Valores)
                {
                    if (conteo == 0) { ub = v; }
                    if (conteo == 1) { op = v; }
                    if (conteo == 2)
                    {
                        int valor;
                        int.TryParse(v, out valor);
                        undep = valor;
                    }
                    if (conteo == 3)
                    {
                        int valor;
                        int.TryParse(v, out valor);
                        unsob = valor;
                    }
                    if (conteo == 4)
                    {
                        int valor;
                        int.TryParse(v, out valor);
                        undet = valor;
                    }
                    if (conteo == 5)
                    {
                        int valor;
                        int.TryParse(v, out valor);
                        gano = valor;
                    }
                    conteo++;
                    if (conteo == 6)
                    {
                        Servicio.InsercionMasivaListasDelArbol(ub, op, undep, unsob, undet, gano);                         
                        conteo = 0;
                    }
                }
            }
            Servicio.Pintar();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
            Image3.ImageUrl = "./Imagenes/GrafoA.png";
            Image4.ImageUrl = "./Imagenes/GrafoAESP.png";
            Image13.ImageUrl = "./Imagenes/GrafoLG.png";
            Image14.ImageUrl = "./Imagenes/GrafoLD.png";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Servicio.HelloWorld();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int valor;
            int.TryParse(TextBox8.Text, out valor);
            Servicio.InsercionMasivaArbol(TextBox5.Text, TextBox6.Text, TextBox7.Text, valor);
            Servicio.Pintar();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
            Image3.ImageUrl = "./Imagenes/GrafoA.png";
            Image4.ImageUrl = "./Imagenes/GrafoAESP.png";
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Servicio.EliminarEnArbol(TextBox5.Text);
            Servicio.Pintar();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
            Image3.ImageUrl = "./Imagenes/GrafoA.png";
            Image4.ImageUrl = "./Imagenes/GrafoAESP.png";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            int valor;
            int.TryParse(TextBox8.Text, out valor);
            Servicio.ModificarEnArbol(TextBox5.Text, TextBox9.Text, TextBox6.Text, TextBox7.Text, valor);
            Servicio.Pintar();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
            Image3.ImageUrl = "./Imagenes/GrafoA.png";
            Image4.ImageUrl = "./Imagenes/GrafoAESP.png";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(TextBox10.Text);
            String line;
            line = sr.ReadLine();
            String Contenido = "";
            int evitar = 0;
            while (line != null)
            {
                if (evitar == 0) { evitar++; }
                else { Contenido += line + ";\n"; }
                line = sr.ReadLine();
            }
            sr.Close();
            TextBox11.Text = Contenido;

            String Cont = Contenido;
            String[] ss = new String[] { ";" };
            String[] st = new String[] { "," };
            String[] Lineas = Cont.Split(ss, StringSplitOptions.None);
            String jug = "";
            int col = 0;
            int fil = 0;
            String uni = "";
            int des = 0;
            int conteo = 0;

            foreach (string s in Lineas)
            {
                string[] Valores = s.Split(st, StringSplitOptions.None);
                foreach (string v in Valores)
                {
                    if (conteo == 0) { jug = v; }
                    if (conteo == 1)
                    {
                        int valor;
                        int.TryParse(v, out valor);
                        col = valor;
                    }
                    if (conteo == 2)
                    {
                        int valor;
                        int.TryParse(v, out valor);
                        fil = valor;
                    }
                    if (conteo == 3) { uni = v; }
                    if (conteo == 4)
                    {
                        int valor;
                        int.TryParse(v, out valor);
                        des = valor;
                    }
                    conteo++;
                    if (conteo == 5)
                    {
                        Servicio.IncertarEnMatrizLive(jug, col, fil, uni, des);
                        conteo = 0;
                    }
                }
            }
            
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Servicio.PintarMSobrevivientes();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
            Image9.Visible = false;
            Image10.Visible = false;
            Image11.Visible = false;
            Image12.Visible = false;
            Image5.ImageUrl = "./Imagenes/GrafoM0.png";
            Image15.ImageUrl = "./Imagenes/GrafoM.png";
            Image7.ImageUrl = "./Imagenes/GrafoM2.png";
            Image8.ImageUrl = "./Imagenes/GrafoM3.png";
            Image5.Visible = true;
            Image15.Visible = true;
            Image7.Visible = true;
            Image8.Visible = true;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Image5.Visible = false;
            Image15.Visible = false;
            Image7.Visible = false;
            Image8.Visible = false;
            Servicio.PintarMDestruidas();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
            Image9.ImageUrl = "./Imagenes/GrafoM0.png";
            Image10.ImageUrl = "./Imagenes/GrafoM.png";
            Image11.ImageUrl = "./Imagenes/GrafoM2.png";
            Image12.ImageUrl = "./Imagenes/GrafoM3.png";
            Image9.Visible = true;
            Image10.Visible = true;
            Image11.Visible = true;
            Image12.Visible = true;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            int fil;
            int.TryParse(TextBox12.Text, out fil);
            int col;
            int.TryParse(TextBox13.Text, out col);
            Servicio.IncertarEnMatrizLive(TextBox15.Text, col, fil, TextBox14.Text, 1);
            Servicio.PintarMSobrevivientes();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
            Image9.Visible = false;
            Image10.Visible = false;
            Image11.Visible = false;
            Image12.Visible = false;
            Image5.ImageUrl = "./Imagenes/GrafoM0.png";
            Image15.ImageUrl = "./Imagenes/GrafoM.png";
            Image7.ImageUrl = "./Imagenes/GrafoM2.png";
            Image8.ImageUrl = "./Imagenes/GrafoM3.png";
            Image5.Visible = true;
            Image15.Visible = true;
            Image7.Visible = true;
            Image8.Visible = true;
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            String cad = TextBox14.Text;
            int fil;
            int.TryParse(TextBox12.Text, out fil);
            int col;
            int.TryParse(TextBox13.Text, out col);
            if (cad.ToUpper().Contains("NEOSATELITE"))
            {
                Servicio.EliminarEnMatriz(TextBox15.Text, fil, col, TextBox14.Text, 3);
            }
            if (cad.ToUpper().Contains("BOMBARDERO"))
            {
                Servicio.EliminarEnMatriz(TextBox15.Text, fil, col, TextBox14.Text, 2);
            }
            if (cad.ToUpper().Contains("CAZA"))
            {
                Servicio.EliminarEnMatriz(TextBox15.Text, fil, col, TextBox14.Text, 2);
            }
            if (cad.ToUpper().Contains("HELICOPTERO"))
            {
                Servicio.EliminarEnMatriz(TextBox15.Text, fil, col, TextBox14.Text, 2);
            }
            if (cad.ToUpper().Contains("FRAGATA"))
            {
                Servicio.EliminarEnMatriz(TextBox15.Text, fil, col, TextBox14.Text, 1);
            }
            if (cad.ToUpper().Contains("CRUCERO"))
            {
                Servicio.EliminarEnMatriz(TextBox15.Text, fil, col, TextBox14.Text, 1);
            }
            if (cad.ToUpper().Contains("SUBMARINO"))
            {
                Servicio.EliminarEnMatriz(TextBox15.Text, fil, col, TextBox14.Text, 0);
            }
            Servicio.PintarMSobrevivientes();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
            Image9.Visible = false;
            Image10.Visible = false;
            Image11.Visible = false;
            Image12.Visible = false;
            Image5.ImageUrl = "./Imagenes/GrafoM0.png";
            Image15.ImageUrl = "./Imagenes/GrafoM.png";
            Image7.ImageUrl = "./Imagenes/GrafoM2.png";
            Image8.ImageUrl = "./Imagenes/GrafoM3.png";
            Image5.Visible = true;
            Image15.Visible = true;
            Image7.Visible = true;
            Image8.Visible = true;
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(TextBox27.Text);
            String line;
            line = sr.ReadLine();
            String Contenido = "";
            int evitar = 0;
            while (line != null)
            {
                if (evitar == 0) { evitar++; }
                else if(evitar == 1)
                {
                    Contenido += line;
                    evitar++;
                }
                line = sr.ReadLine();
            }
            sr.Close();

            String Cont = Contenido;
            String[] st = new String[] { "," };
            String[] Lineas = Cont.Split(st, StringSplitOptions.None);

            int conteo = 0;

            foreach (string s in Lineas)
            {
                if (conteo == 0) { TextBox17.Text = s; }
                if (conteo == 1) { TextBox18.Text = s; }
                if (conteo == 2) { TextBox19.Text = s; }
                if (conteo == 3) { TextBox20.Text = s; }
                if (conteo == 4) { TextBox21.Text = s; }
                if (conteo == 5) { TextBox22.Text = s; }
                if (conteo == 6) { TextBox23.Text = s; }
                if (conteo == 7) { TextBox24.Text = s; }
                if (conteo == 8) { TextBox25.Text = s; }
                if (conteo == 9) { TextBox26.Text = s; }
                conteo++;
                if (conteo == 10)
                {
                    //Servicio.IncertarEnMatrizLive(jug, col, fil, uni, des);
                    conteo = 0;
                }
            }
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            int fil;
            int.TryParse(TextBox12.Text, out fil);
            int col;
            int.TryParse(TextBox13.Text, out col);
            Servicio.IncertarEnMatrizLive(TextBox15.Text, col, fil, TextBox14.Text, 1);
            Servicio.PintarMSobrevivientes();
            Servicio.CopiarImagenes(Server.MapPath("Imagenes/"));
            Image9.Visible = false;
            Image10.Visible = false;
            Image11.Visible = false;
            Image12.Visible = false;
            Image5.ImageUrl = "./Imagenes/GrafoM0.png";
            Image15.ImageUrl = "./Imagenes/GrafoM.png";
            Image7.ImageUrl = "./Imagenes/GrafoM2.png";
            Image8.ImageUrl = "./Imagenes/GrafoM3.png";
            Image5.Visible = true;
            Image15.Visible = true;
            Image7.Visible = true;
            Image8.Visible = true;
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            if (Image3.Visible == true)
            {
                Image3.Visible = false;
                Image4.Visible = false;
            }
            else
            {
                Image3.Visible = true;
                Image4.Visible = true;
            }
            
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            if (Panel1.Visible == true)
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Image3.Visible = false;
                Image4.Visible = false;
                Image13.Visible = false;
                Image14.Visible = false;
            }
            else
            {
                Panel1.Visible = true;
                Panel3.Visible = true;
                Panel2.Visible = true;
                Image3.Visible = true;
                Image4.Visible = true;
                Image13.Visible = true;
                Image14.Visible = true;
            }
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            if (Panel4.Visible == true)
            {
                Panel4.Visible = false;
                Panel5.Visible = false;
                Image5.Visible = false;
                Image15.Visible = false;
                Image7.Visible = false;
                Image8.Visible = false;
                Image9.Visible = false;
                Image10.Visible = false;
                Image11.Visible = false;
                Image12.Visible = false;
            }
            else
            {
                Panel4.Visible = true;
                Panel5.Visible = true;
                Image5.Visible = true;
                Image15.Visible = true;
                Image7.Visible = true;
                Image8.Visible = true;
                Image9.Visible = true;
                Image10.Visible = true;
                Image11.Visible = true;
                Image12.Visible = true;
            }
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Servicio.Parametros(TextBox17.Text, TextBox18.Text, TextBox19.Text, TextBox20.Text, TextBox21.Text, TextBox22.Text, TextBox23.Text, TextBox24.Text, TextBox25.Text, TextBox26.Text);
            Response.Redirect("PageUser.aspx");
        }
    }
}