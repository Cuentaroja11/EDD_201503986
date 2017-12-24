using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace EDDS
{
    /// <summary>
    /// Summary description for ServicioWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioWeb : System.Web.Services.WebService
    {
        //Metodos y Funciones Estaticas----------------------------------------------------------------------------
        static void EjecutarCMD(string cmd)
        {
            System.Diagnostics.ProcessStartInfo PSInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + cmd);
            PSInfo.RedirectStandardOutput = true;
            PSInfo.UseShellExecute = false;
            PSInfo.CreateNoWindow = false;
            System.Diagnostics.Process proceso = new System.Diagnostics.Process();
            proceso.StartInfo = PSInfo;
            proceso.Start();
            string resultado = proceso.StandardOutput.ReadToEnd();
            Console.WriteLine(resultado);
        }
        static void PintarArboles(Arbol a)
        {
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoA.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();
            a.PrePintarArbol(a.Raiz, true);
            a.PintarArbol(a.Raiz, true);
            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoA.dot");
            a.ContadorNodos(a.Raiz);
            a.AlturaArbol(a.Raiz);
            agregar.WriteLine("Informacion[label=" + '"' + "Altura: " + (a.Altura + 1) + "\n Nodos Hoja: " + a.NodosHoja + "\n Nodos Rama: " + (a.NodosRama - 1) + "\n Niveles: " + (a.Altura + 1) + '"' + "]");
            agregar.WriteLine("}");
            agregar.Close();

            StreamWriter crear2 = new StreamWriter("C:\\Grafo\\GrafoAESP.dot");
            crear2.WriteLine("digraph grafo{");
            crear2.Close();
            a.ListaNodos = new ListaNodoArbol();
            a.SacarNodos(a.Raiz, true);
            ListaNodoArbol lna = new ListaNodoArbol();
            lna.SacarEspejo(a);
            StreamWriter agregar2 = File.AppendText("C:\\Grafo\\GrafoAESP.dot");
            agregar2.WriteLine("}");
            agregar2.Close();

            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoA.dot -o C:\\Grafo\\GrafoA.png");
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoAESP.dot -o C:\\Grafo\\GrafoAESP.png");
        }
        static void PintarMatrices(Matriz m)
        {
            m.GraficarMatriz();
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoM.dot -o C:\\Grafo\\GrafoM.png");
            m.GraficarMatriz0();
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoM0.dot -o C:\\Grafo\\GrafoM0.png");
            m.GraficarMatriz2();
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoM2.dot -o C:\\Grafo\\GrafoM2.png");
            m.GraficarMatriz3();
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoM3.dot -o C:\\Grafo\\GrafoM3.png");
        }
        static void PintarListas()
        {
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoLG.dot -o C:\\Grafo\\GrafoLG.png");
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoLD.dot -o C:\\Grafo\\GrafoLD.png");
        }
        //Final de Metodos y Funciones Estaticas-------------------------------------------------------------------

        static Matriz m = new Matriz();
        static Matriz m2 = new Matriz();
        static Arbol a = new Arbol();
        static String Ruta = "";

        static String Jugador1 = "";
        static String Jugador2 = "";
        static String NNivel1 = "";
        static String NNivel2 = "";
        static String NNivel3 = "";
        static String NNivel4 = "";
        static String TX = "";
        static String TY = "";
        static String Tipo = "";
        static String Tiempo = "";

        [WebMethod]
        public void Parametros(String j1, String j2, String nn1, String nn2, String nn3, String nn4, String tx, String ty, String tip, String tim)
        {
            Jugador1 = j1;
            Jugador2 = j2;
            NNivel1 = nn1;
            NNivel2 = nn2;
            NNivel3 = nn3;
            NNivel4 = nn4;
            TX = tx;
            TY = ty;
            Tipo = tip;
            Tiempo = tim;
        }

        [WebMethod]
        public String RetJugador1()
        {
            return Jugador1;
        }
        [WebMethod]
        public String RetJugador2()
        {
            return Jugador2;
        }
        [WebMethod]
        public String RetTamanoX()
        {
            return TX;
        }
        [WebMethod]
        public String RetTamanoY()
        {
            return TY;
        }
        [WebMethod]
        public String RetTipo()
        {
            return Tipo;
        }
        [WebMethod]
        public String RetTiempo()
        {
            return Tiempo;
        }

        [WebMethod]
        public string HelloWorld()
        {
            a.Insertar("Mord86", "NPZ44VGE5FD", "scelerisque.sed@lectusa.com", 1, null);
            a.Insertar("Stin94", "WAG95DOM2LZ", "in.tempus@a.com", 1, null);
            a.Insertar("Asro25", "PDW92QLF0HC", "turpis.Aliquam.adipiscing@tincidunt.net", 0, null);
            a.Insertar("Imre78", "MDQ80CXX3XT", "eget.dictum.placerat@atsem.net", 0, null);
            a.Insertar("Taon95", "USW07EIK1AC", "parturient@Nulla.co.uk", 0, null);
            a.Insertar("Avey48", "ZEE21HJG3WL", "Class@orci.net", 0, null);

            a.InsertaEnLista("Mord86", "Stin94", 10, 8, 2, 1);
            a.InsertaEnLista("Mord86", "Asro25", 15, 10, 5, 1);
            a.InsertaEnLista("Mord86", "Imre78", 20, 3, 17, 0);
            a.InsertaEnLista("Mord86", "Taon95", 16, 10, 6, 0);
            a.InsertaEnLista("Mord86", "Avey48", 18, 8, 10, 0);
            a.InsertaEnLista("Mord86", "Kaez42", 20, 10, 10, 0);
            a.InsertaEnLista("Mord86", "Idin94", 30, 29, 1, 1);
            a.InsertaEnLista("Mord86", "Jado86", 25, 1, 24, 0);

            a.InsertaEnLista("Stin94", "Mord86", 21, 15, 6, 0);
            a.InsertaEnLista("Stin94", "Asro25", 19, 14, 5, 0);
            a.InsertaEnLista("Stin94", "Imre78", 18, 16, 2, 1);
            a.InsertaEnLista("Stin94", "Taon95", 10, 9, 1, 0);
            a.InsertaEnLista("Stin94", "Avey48", 19, 10, 9, 1);
            a.InsertaEnLista("Stin94", "Kaez42", 17, 8, 9, 0);
            a.InsertaEnLista("Stin94", "Idin94", 23, 3, 20, 1);
            a.InsertaEnLista("Stin94", "Jado86", 28, 5, 2, 1);

            PintarArboles(a);
            a.CalcularGanDest(a);
            PintarListas();
            
            return "Adios";
        }

        [WebMethod]
        public void InsercionMasivaArbol(String Us, String Cont, String Corr, int Logi)
        {
            a.Insertar(Us, Cont, Corr, Logi, null);
        }

        [WebMethod]
        public void InsercionMasivaListasDelArbol(String UsB, String Op, int bb, int cc, int dd, int ee)
        {
            a.InsertaEnLista(UsB, Op, bb, cc, dd, ee);
        }

        [WebMethod]
        public void Pintar()
        {
            PintarArboles(a);
            a.CalcularGanDest(a);
            PintarListas();
        }

        [WebMethod]
        public void EliminarEnArbol(String nickn)
        {
            a.Borrar(nickn);
        }

        [WebMethod]
        public void ModificarEnArbol(String Ant, String Nick, String Pass, String Mail, int Log)
        {
            a.Modificar(Ant, Nick, Pass, Mail, Log);
        }

        [WebMethod]
        public void IncertarEnMatrizLive(String jug, int col, int fil, String uni, int des)
        {
            if (des == 0) { m2.Insertar(jug, col, fil, uni, des); }
            if (des == 1) { m.Insertar(jug, col, fil, uni, des); }
        }

        [WebMethod]
        public void PintarMSobrevivientes()
        {
            PintarMatrices(m);
        }
        [WebMethod]
        public void PintarMDestruidas()
        {
            PintarMatrices(m2);
        }

        [WebMethod]
        public void EliminarEnMatriz(String jug, int col, int fil, String uni, int niv)
        {
            m2.Insertar(jug, col, fil, uni, 0);
            m.Eliminar(col, fil, niv);
            PintarMatrices(m2);
        }
        [WebMethod]
        public void CopiarImagenes(String r)
        {
            Ruta = r;
            String Comando1 = "copy " + "C:\\Grafo\\GrafoA.png " + '"' + r + '"';
            String Comando2 = "copy " + "C:\\Grafo\\GrafoAESP.png " + '"' + r + '"';
            String Comando3 = "copy " + "C:\\Grafo\\GrafoLD.png " + '"' + r + '"';
            String Comando4 = "copy " + "C:\\Grafo\\GrafoLG.png " + '"' + r + '"';
            String Comando5 = "copy " + "C:\\Grafo\\GrafoM.png " + '"' + r + '"';
            String Comando6 = "copy " + "C:\\Grafo\\GrafoM0.png " + '"' + r + '"';
            String Comando7 = "copy " + "C:\\Grafo\\GrafoM2.png " + '"' + r + '"';
            String Comando8 = "copy " + "C:\\Grafo\\GrafoM3.png " + '"' + r + '"';
            EjecutarCMD(Comando1);
            EjecutarCMD(Comando2);
            EjecutarCMD(Comando3);
            EjecutarCMD(Comando4);
            EjecutarCMD(Comando5);
            EjecutarCMD(Comando6);
            EjecutarCMD(Comando7);
            EjecutarCMD(Comando8);
        }
    }
}
