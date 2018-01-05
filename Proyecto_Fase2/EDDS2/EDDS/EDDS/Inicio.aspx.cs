using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDDS
{   
    public partial class Inicio : System.Web.UI.Page
    {
        ServiceRef.ServicioWebSoapClient Servicio = new ServiceRef.ServicioWebSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //TextBox1.Text = Servicio.HelloWorld();
            String nombre = TextBox1.Text;
            String passwo = TextBox2.Text;
            if (String.Compare(nombre, "Edwar") == 0 && String.Compare(passwo, "admin") == 0)
            {
                //Servicio.InsercionMasivaArbol("Edwar", "admin", "cuentaroja11@gmai.com", 1);
                Response.Redirect("PageAdministrador.aspx");
            }
            else
            {
                if (Servicio.BuscarEnArbol(TextBox1.Text, TextBox2.Text) == true)
                {
                    if (Servicio.RetJugador1().Equals(TextBox1.Text) == true || Servicio.RetJugador2().Equals(TextBox1.Text) == true)
                    {
                        Servicio.SetActual(TextBox1.Text);
                        Response.Redirect("PageUser.aspx");
                    }
                }
                else
                {
                    Label1.Text = "Usuario o contrasenia equivocado";
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                }                
            }        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
        }
    }
}