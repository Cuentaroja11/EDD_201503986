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
    }
}