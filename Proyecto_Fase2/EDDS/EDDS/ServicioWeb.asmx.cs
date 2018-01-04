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
        static void PintarAAVL(String UB)
        {
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoAVL.dot");
            crear.WriteLine("digraph grafo{Info" + "[label=" + '"' + "Arbol AVL de: " + UB + '"' + "]");
            crear.Close();
            a.PintarElAVL(UB);
            StreamWriter agregar2 = File.AppendText("C:\\Grafo\\GrafoAVL.dot");
            agregar2.WriteLine("}");
            agregar2.Close();
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoAVL.dot -o C:\\Grafo\\GrafoAVL.png");
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
            agregar.WriteLine("Informacion[label=" + '"' + "Altura: " + (a.Altura + 1) + "\n Nodos Hoja: " + a.NodosHoja + "\n Nodos Rama: " + (a.NodosRama - 1) + "\n Niveles: " + (a.Altura) + '"' + "]");
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
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoLCON.dot -o C:\\Grafo\\GrafoLCON.png");
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoLG.dot -o C:\\Grafo\\GrafoLG.png");
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoLD.dot -o C:\\Grafo\\GrafoLD.png");
        }
        //Final de Metodos y Funciones Estaticas-------------------------------------------------------------------

        static Matriz m = new Matriz();
        static Matriz m2 = new Matriz();
        static ListaJugadas lj = new ListaJugadas();
        static Arbol a = new Arbol();
        static ArbolAVL av = new ArbolAVL();
        static TablaHash th = new TablaHash(44);
        static String Ruta = "";

        static String Jugador1 = "";
        static int eliminaj1 = 0;
        static int nataquej1 = 0;
        static String Jugador2 = "";
        static int eliminaj2 = 0;
        static int nataquej2 = 0;
        static int njuego = 1;
        static String NNivel1 = "";
        static String NNivel2 = "";
        static String NNivel3 = "";
        static String NNivel4 = "";
        static String TX = "";
        static String TY = "";
        static String Tipo = "";
        static String Tiempo = "";
        static String Actual = "";
        static int entra = 0;
        static String Historial = "";

        [WebMethod]
        public void PintarListaAtaques()
        {
            lj.OrdenarAtaques();
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoLAT.dot -o C:\\Grafo\\GrafoLAT.png");
        }
        [WebMethod]
        public void PintarListaAtaques2()
        {
            lj.OrdenarAtaques2();
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoLAT2.dot -o C:\\Grafo\\GrafoLAT2.png");
        }
        [WebMethod]
        public void PintarListaEliminadas()
        {
            lj.OrdenarEliminadas();
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoLEL.dot -o C:\\Grafo\\GrafoLEL.png");
        }
        [WebMethod]
        public void finJuego(String J1, String J2, int NJ, int AJ1, int AJ2, int EJ1, int EJ2)
        {
            lj.Insertar(J1, J2, NJ, AJ1, AJ2, EJ1, EJ2);
            njuego++;
                                  
            m = new Matriz();
            m2 = new Matriz();
            Historial = "";
            Jugador1 = "";
            eliminaj1 = 0;
            nataquej1 = 0;
            Jugador2 = "";
            eliminaj2 = 0;
            nataquej2 = 0;            
                       
        }
        [WebMethod]
        public void EliminarEnHash(String v)
        {
            th.eliminar(v);
            th.pintarTabla();
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoHASH.dot -o C:\\Grafo\\GrafoHASH.png");
        }
        [WebMethod]
        public int retfil(int niv, String pieemi, String jemi)
        {
            int a = m.retfil(niv, pieemi, jemi);
            return a;
        }
        [WebMethod]
        public int retcol(int niv, String pieemi, String jemi)
        {
            int a = m.retcol(niv, pieemi, jemi);
            return a;
        }
        [WebMethod]
        public bool Mover(int fil, int col, int niv, String pieemi, int golpe, String pieresep, String jemi, String jresep, String fech, String tm, int Nataq)
        {
            bool encuentra = m.Eliminar2(fil, col, niv, pieemi, golpe, pieresep, jemi, jresep, fech, tm, Nataq);
            return encuentra;
        }
        [WebMethod]
        public String Atacar(int ncol, int nfil, int niv, int dano, String jemi, String presep)
        {
            String ataca = m.Ataque(ncol, nfil, niv, dano, jemi, presep);
            return ataca;
        }
        [WebMethod]
        public int retNEliminadasJ2()
        {
            return eliminaj2;
        }
        [WebMethod]
        public int retNEliminadasJ1()
        {
            return eliminaj1;
        }
        [WebMethod]
        public int retNAtaquesJ2()
        {
            return nataquej2;
        }
        [WebMethod]
        public int retNAtaquesJ1()
        {
            return nataquej1;
        }
        [WebMethod]
        public int retNJuego()
        {
            return njuego;
        }
        [WebMethod]
        public void MasAtaques(String a)
        {
            if (a.Equals(Jugador1) == true) { nataquej1++; } else { nataquej2++; }
        }
        [WebMethod]
        public void MasNJuego()
        {
            njuego++;
        }
        [WebMethod]
        public void MasEliminadas(String a)
        {
            if (a.Equals(Jugador1) == true) { eliminaj1++; } else { eliminaj2++; }
        }
        [WebMethod]
        public void MasHistorial(String a)
        {
            Historial = a;
        }
        [WebMethod]
        public String GetHistorial()
        {
            return Historial;
        }
        [WebMethod]
        public void SetActual(String a)
        {
            Actual = a;
        }
        [WebMethod]
        public String GetActual()
        {
            return Actual;
        }

        [WebMethod]
        public void SetEntra(String a)
        {
            if (a.Equals(Jugador1)) { entra = 0; }
            else { entra = 1; }
        }
        [WebMethod]
        public int GetEntra()
        {
            return entra;
        }

        [WebMethod]
        public void Prueva2()
        {
            

        }
        [WebMethod]
        public void Prueva()
        {
                    

        }
        [WebMethod]
        public void NuevaHASH()
        {
            th = new TablaHash(44);
        }
        [WebMethod]
        public void PintarHASH()
        {
            th.IncercionMasiva(a.ListaNodos);
            th.pintarTabla();
            EjecutarCMD("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\GrafoHASH.dot -o C:\\Grafo\\GrafoHASH.png");
        }
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
            return "Adios";
        }
        [WebMethod]
        public void InsercionMasivaArbol(String Us, String Cont, String Corr, int Logi)
        {
            a.Insertar(Us, Cont, Corr, Logi, null, null);
        }
        [WebMethod]
        public void InsercionMasivaListasDelArbol(String UsB, String Op, int bb, int cc, int dd, int ee)
        {
            a.InsertaEnLista(UsB, Op, bb, cc, dd, ee);
        }
        [WebMethod]
        public void InsercionMasivaAVLDelArbol(String UB, String Op, String pass, String mail)
        {
            a.InsertaEnAVL(UB, Op, pass, mail);
            PintarAAVL(UB);
        }
        [WebMethod]
        public void BorrarEnAVLDelArbol(String UB, String Op)
        {
            a.BorrarEnAVL(UB, Op);
            PintarAAVL(UB);
        }
        [WebMethod]
        public void ModificarEnAVLDelArbol(String UB, String Op, String pass, String mail)
        {
            a.ModificarEnAVL(UB, Op, pass, mail);
            PintarAAVL(UB);
        }
        [WebMethod]
        public void PintarAVLDelArbol(String UB)
        {
            PintarAAVL(UB);
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
        public bool BuscarEnArbol(String nickn, String pass)
        {
            bool respuesta = a.Buscar(nickn, pass);
            return respuesta;
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
