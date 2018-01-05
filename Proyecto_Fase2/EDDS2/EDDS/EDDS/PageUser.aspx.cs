using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDDS
{
    public partial class PageUser : System.Web.UI.Page
    {
        ServiceRef.ServicioWebSoapClient Servicio = new ServiceRef.ServicioWebSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Servicio.RetJugador1();
            Label2.Text = Servicio.RetJugador2();
            Label3.Text = Servicio.RetTamanoX();
            Label4.Text = Servicio.RetTamanoY();
            Label5.Text = Servicio.RetTipo();
            Label6.Text = Servicio.RetTiempo();
            Label7.Text = Servicio.GetActual();
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

        protected void Button15_Click(object sender, EventArgs e)
        {
            int tx;
            int.TryParse(Servicio.RetTamanoX(), out tx);
            int ty;
            int.TryParse(Servicio.RetTamanoY(), out ty);
            String cad = TextBox17.Text;
            String cad2 = TextBox23.Text;
            String respuesta = "";
            String Historial = "";
            int fil;
            int.TryParse(TextBox19.Text, out fil);
            int col;
            int.TryParse(TextBox18.Text, out col);
            int totalmov = fil + col;
            int nivel = 5;
            int nivel2 = 5;
            int nfil;
            int.TryParse(TextBox22.Text, out nfil);
            int ncol;
            int.TryParse(TextBox21.Text, out ncol);
            bool existe = false;
            int dano = 0;
            int W = 0;
            int P = 0;
            int Z = 0;
            if (fil < nfil) { W = nfil - fil; }//Y
            if (nfil < fil) { W = fil - nfil; }
            if (col < ncol) { P = ncol - col; }//X
            if (ncol < col) { P = col - ncol; }
            Z = W + P;
            int mismonivel = 0;
            //if (cad.ToUpper().Contains("NEOSATELITE") && cad2.ToUpper().Contains("NEOSATELITE") && nfil == fil && ncol == col) { mismonivel++; }
            //if (cad.ToUpper().Contains("BOMBARDERO") && cad2.ToUpper().Contains("BOMBARDERO") && nfil == fil && ncol == col) { mismonivel++; }
            //if (cad.ToUpper().Contains("CAZA") && cad2.ToUpper().Contains("CAZA") && nfil == fil && ncol == col) { mismonivel++; }
            //if (cad.ToUpper().Contains("HELICOPTERO") && cad2.ToUpper().Contains("HELICOPTERO") && nfil == fil && ncol == col) { mismonivel++; }
            //if (cad.ToUpper().Contains("FRAGATA") && cad2.ToUpper().Contains("FRAGATA") && nfil == fil && ncol == col) { mismonivel++; }
            //if (cad.ToUpper().Contains("CRUCERO") && cad2.ToUpper().Contains("CRUCERO") && nfil == fil && ncol == col) { mismonivel++; }
            //if (cad.ToUpper().Contains("SUBMARINO") && cad2.ToUpper().Contains("SUBMARINO") && nfil == fil && ncol == col) { mismonivel++; }
            if (cad2.ToUpper().Contains("NEOSATELITE")) { nivel2 = 3; }
            if (cad2.ToUpper().Contains("BOMBARDERO")) { nivel2 = 2; }
            if (cad2.ToUpper().Contains("CAZA")) { nivel2 = 2; }
            if (cad2.ToUpper().Contains("HELICOPTERO")) { nivel2 = 2; }
            if (cad2.ToUpper().Contains("FRAGATA")) { nivel2 = 1; }
            if (cad2.ToUpper().Contains("CRUCERO")) { nivel2 = 1; }
            if (cad2.ToUpper().Contains("SUBMARINO")) { nivel2 = 0; }
            if (nfil <= ty && ncol <= tx && mismonivel == 0)
            {
                if (cad.ToUpper().Contains("NEOSATELITE"))
                {
                    nivel = 3; dano = 2;
                    if (Z <= 6) { existe = Servicio.Mover(fil, col, nivel, cad, 0, "", Label7.Text, "", "", "", 0); }                    
                }
                if (cad.ToUpper().Contains("BOMBARDERO"))
                {
                    nivel = 2; dano = 5;
                    if (Z <= 7) { existe = Servicio.Mover(fil, col, nivel, cad, 0, "", Label7.Text, "", "", "", 0); }                                      
                }
                if (cad.ToUpper().Contains("CAZA"))
                {
                    nivel = 2; dano = 2;
                    if (Z <= 9) { existe = Servicio.Mover(fil, col, nivel, cad, 0, "", Label7.Text, "", "", "", 0); }                                        
                }
                if (cad.ToUpper().Contains("HELICOPTERO"))
                {
                    nivel = 2; dano = 3;
                    if (Z <= 9) { existe = Servicio.Mover(fil, col, nivel, cad, 0, "", Label7.Text, "", "", "", 0); }                                       
                }
                if (cad.ToUpper().Contains("FRAGATA"))
                {
                    nivel = 1; dano = 3;
                    if (Z <= 5) { existe = Servicio.Mover(fil, col, nivel, cad, 0, "", Label7.Text, "", "", "", 0); }                                       
                }
                if (cad.ToUpper().Contains("CRUCERO"))
                {
                    nivel = 1; dano = 3;
                    if (Z <= 6) { existe = Servicio.Mover(fil, col, nivel, cad, 0, "", Label7.Text, "", "", "", 0); }                                        
                }
                if (cad.ToUpper().Contains("SUBMARINO"))
                {
                    nivel = 0; dano = 2;
                    if (Z <= 5) { existe = Servicio.Mover(fil, col, nivel, cad, 0, "", Label7.Text, "", "", "", 0); }                                        
                }
                if (existe == true)
                {                   
                    Servicio.IncertarEnMatrizLive(Label7.Text, ncol, nfil, cad, 1);
                    respuesta = Servicio.Atacar(ncol, nfil, nivel, dano, Label7.Text.ToString(), cad2);
                }
            }
            if (respuesta.Equals("0") == true)
            {
                Servicio.MasAtaques(Label7.Text.ToString());
                Servicio.MasEliminadas(Label7.Text.ToString());
                Historial += Servicio.GetHistorial();
                Historial += "\n\nATAQUE REALIZADO CON ELIMINACION\n" + Label7.Text.ToString() + " ataca con: " + cad + " a " + cad2;
                Historial += "\n No. de ataques de: " + Servicio.RetJugador1() + " = " + Servicio.retNAtaquesJ1().ToString();
                Historial += "\n No. de ataques de: " + Servicio.RetJugador2() + " = " + Servicio.retNAtaquesJ2().ToString();
                Historial += "\n No. de eliminadas de: " + Servicio.RetJugador1() + " = " + Servicio.retNEliminadasJ1().ToString();
                Historial += "\n No. de eliminadas de: " + Servicio.RetJugador2() + " = " + Servicio.retNEliminadasJ2().ToString();
                Servicio.MasHistorial(Historial);
                TextBox20.Text = Servicio.GetHistorial();
            }
            if (respuesta.Equals("") == true)
            {
                Historial += Servicio.GetHistorial();
                Historial += "\nERROR DE LIMITES EN EL ATAQUE\n" + Label7.Text.ToString() + " ataca con: " + cad + " a " + cad2;
            }
            if (respuesta.Equals("0") == false && respuesta.Equals("") == false)
            {
                Servicio.MasAtaques(Label7.Text.ToString());
                Historial += Servicio.GetHistorial();
                Historial += "\n\nATAQUE REALIZADO\n" + Label7.Text.ToString() + " ataca con: " + cad + " a " + cad2;              
                Historial += "\n No. de ataques de: " + Servicio.RetJugador1() + " = " + Servicio.retNAtaquesJ1().ToString();
                Historial += "\n No. de ataques de: " + Servicio.RetJugador2() + " = " + Servicio.retNAtaquesJ2().ToString();
                Historial += "\n No. de eliminadas de: " + Servicio.RetJugador1() + " = " + Servicio.retNEliminadasJ1().ToString();
                Historial += "\n No. de eliminadas de: " + Servicio.RetJugador2() + " = " + Servicio.retNEliminadasJ2().ToString();
                Servicio.MasHistorial(Historial);
                TextBox20.Text = Servicio.GetHistorial();
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

        protected void Button16_Click(object sender, EventArgs e)
        {
            int totat = Servicio.retNAtaquesJ1() + Servicio.retNAtaquesJ2();
            int totel = Servicio.retNEliminadasJ1() + Servicio.retNEliminadasJ2();
            Servicio.finJuego(Servicio.RetJugador1(),Servicio.RetJugador2(),Servicio.retNJuego(),Servicio.retNAtaquesJ1(),Servicio.retNAtaquesJ2(),Servicio.retNEliminadasJ1(),Servicio.retNEliminadasJ2(), totat, totel);
            Response.Redirect("Inicio.aspx");
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            Servicio.PintarListaAtaques();
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            Servicio.PintarListaAtaques2();
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            Servicio.PintarListaEliminadas();
        }
    }
}