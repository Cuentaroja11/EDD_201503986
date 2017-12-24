using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace EDDS
{
    public class Estructuras
    {

    }
    public class Arbol
    {
        public class NodoArbol
        {
            public NodoArbol(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst)
            {
                this.Nickname = Nick;
                this.Contrasena = Pass;
                this.Correo = Mail;
                this.Conectado = Log;
                this.Izq = null;
                this.Der = null;
                if (lst == null) { this.Lista = new ListaDelArbol(); }
                else { this.Lista = lst; }

            }
            public int Perdidas;
            public int Ganadas;
            public int Destruidas;
            public String Nickname;
            public String Contrasena;
            public String Correo;
            public int Conectado;
            public NodoArbol Izq;
            public NodoArbol Der;
            public ListaDelArbol Lista;
        }

        public NodoArbol Raiz;
        public NodoArbol Actual;
        public int Contador = 0;
        public int Altura = 0;
        public int NodosHoja = 0;
        public int NodosRama = 0;
        public int CantNodos = 0;
        public ListaNodoArbol ListaNodos;

        public bool Vacio(NodoArbol r) { return r == null; }
        public void InsertaEnLista(String UB, String Op, int UnDesp, int UnS, int UnE, int Gan)
        {
            Actual = Raiz;
            while (Actual != null)
            {
                if (String.Compare(UB, Actual.Nickname) == 0)
                {
                    Actual.Ganadas = Actual.Ganadas + Gan;
                    Actual.Destruidas = Actual.Destruidas + UnE;
                    Actual.Lista.Insertar(UB, Op, UnDesp, UnS, UnE, Gan);
                    break;
                }
                if (String.Compare(UB, Actual.Nickname) > 0) { Actual = Actual.Der; }
                else if (String.Compare(UB, Actual.Nickname) < 0) { Actual = Actual.Izq; }
            }
        }
        public void EliminarEnLista(String Hoja, String Oponente)
        {
            Actual = Raiz;
            while (Actual != null)
            {
                if (String.Compare(Hoja, Actual.Nickname) == 0)
                {
                    Actual.Lista.Eliminar(Oponente);
                    break;
                }
                else if (String.Compare(Hoja, Actual.Nickname) > 0) { Actual = Actual.Der; }
                else if (String.Compare(Hoja, Actual.Nickname) < 0) { Actual = Actual.Izq; }
            }
        }
        public void Modificar(String Ant, String Nick, String Pass, String Mail, int Log)
        {
            if (String.Compare(Ant, Nick) == 0)
            {
                Actual = Raiz;
                while (Actual != null)
                {
                    if (String.Compare(Ant, Actual.Nickname) == 0)
                    {
                        Actual.Contrasena = Pass;
                        Actual.Correo = Mail;
                        Actual.Conectado = Log;
                        break;
                    }
                    else if (String.Compare(Ant, Actual.Nickname) > 0) { Actual = Actual.Der; }
                    else if (String.Compare(Ant, Actual.Nickname) < 0) { Actual = Actual.Izq; }
                }
            }
            else
            {
                ListaDelArbol lsttmp = new ListaDelArbol();
                Actual = Raiz;
                while (Actual != null)
                {
                    if (String.Compare(Ant, Actual.Nickname) == 0)
                    {
                        lsttmp = Actual.Lista;
                        break;
                    }
                    else if (String.Compare(Ant, Actual.Nickname) > 0) { Actual = Actual.Der; }
                    else if (String.Compare(Ant, Actual.Nickname) < 0) { Actual = Actual.Izq; }
                }
                Borrar(Ant);
                Insertar(Nick, Pass, Mail, Log, lsttmp);
            }
        }
        public void Insertar(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst)
        {
            NodoArbol padre = null;
            Actual = Raiz;
            while (!(Actual == null) && (String.Compare(Nick, Actual.Nickname) != 0))
            {
                padre = Actual;
                if (String.Compare(Nick, Actual.Nickname) > 0) { Actual = Actual.Der; }
                else if (String.Compare(Nick, Actual.Nickname) < 0) { Actual = Actual.Izq; }
            }

            if (Actual != null) return;
            if (padre == null) Raiz = new NodoArbol(Nick, Pass, Mail, Log, lst);
            else if (String.Compare(Nick, padre.Nickname) < 0) { padre.Izq = new NodoArbol(Nick, Pass, Mail, Log, lst); }
            else if (String.Compare(Nick, padre.Nickname) > 0) { padre.Der = new NodoArbol(Nick, Pass, Mail, Log, lst); }

        }
        public void InsertarEspejo(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst)
        {

            NodoArbol padre = null;
            Actual = Raiz;
            while (!(Actual == null) && String.Compare(Nick, Actual.Nickname) != 0)
            {
                padre = Actual;
                if (String.Compare(Nick, Actual.Nickname) < 0) { Actual = Actual.Der; }
                else if (String.Compare(Nick, Actual.Nickname) > 0) { Actual = Actual.Izq; }
            }

            if (Actual != null) return;
            if (padre == null) Raiz = new NodoArbol(Nick, Pass, Mail, Log, lst);
            else if (String.Compare(Nick, padre.Nickname) > 0) { padre.Izq = new NodoArbol(Nick, Pass, Mail, Log, lst); }
            else if (String.Compare(Nick, padre.Nickname) < 0) { padre.Der = new NodoArbol(Nick, Pass, Mail, Log, lst); }

        }
        public void InOrder(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            if (nodo.Izq != null) InOrder(nodo.Izq, false);
            Console.Write(nodo.Nickname + " ");
            if (nodo.Der != null) InOrder(nodo.Der, false);
        }
        public void CalcularGanDest(Arbol a)
        {
            SacarNodos(a.Raiz, true);
            ListaNodoArbol lstnatmp = new ListaNodoArbol();
            lstnatmp = ListaNodos;
            lstnatmp.OrdenarGanadas();
            lstnatmp.OrdenarDestruidas();
        }
        public void PrePintarArbol(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            if (nodo != null)
            {
                if (nodo.Izq != null) PrePintarArbol(nodo.Izq, false);
                StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoA.dot");
                agregar.WriteLine(nodo.Nickname + "[label=" + '"' + "Jugador: " + nodo.Nickname + "\n Contrasena: " + nodo.Contrasena + "\n Correo: " + nodo.Correo + "\n Conectado: " + nodo.Conectado + '"' + "]");
                if (nodo.Lista != null)
                {
                    agregar.WriteLine(nodo.Lista.RecorrerDer());
                    if (nodo.Lista.primero != null)
                    {
                        agregar.WriteLine(nodo.Nickname + "->" + "ListaDe" + nodo.Lista.primero.UsuarioBase);
                        //Lista += "\n" + primero.UsuarioBase + "->" + "ListaDe" + primero.UsuarioBase;//
                    }
                }
                agregar.Close();
                if (nodo.Der != null) PrePintarArbol(nodo.Der, false);
            }

        }
        public void PintarArbol(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            if (nodo != null)
            {
                if (nodo.Izq != null)
                {
                    StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoA.dot");
                    agregar.WriteLine(nodo.Nickname + "->" + nodo.Izq.Nickname);
                    agregar.Close();
                    PintarArbol(nodo.Izq, false);
                }
                //Console.Write(nodo.Dato.ToString() + " ");
                if (nodo.Der != null)
                {
                    StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoA.dot");
                    agregar.WriteLine(nodo.Nickname + "->" + nodo.Der.Nickname);
                    agregar.Close();
                    PintarArbol(nodo.Der, false);
                }
            }

        }
        public void PrePintarArbolEspejo(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            if (nodo != null)
            {
                if (nodo.Izq != null) PrePintarArbolEspejo(nodo.Izq, false);
                StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoAESP.dot");
                agregar.WriteLine(nodo.Nickname + "[label=" + '"' + "Jugador: " + nodo.Nickname + "\n Contrasena: " + nodo.Contrasena + "\n Correo: " + nodo.Correo + "\n Conectado: " + nodo.Conectado + '"' + "]");
                if (nodo.Lista != null)
                {
                    agregar.WriteLine(nodo.Lista.RecorrerDer());
                    if (nodo.Lista.primero != null)
                    {
                        agregar.WriteLine(nodo.Nickname + "->" + "ListaDe" + nodo.Lista.primero.UsuarioBase);
                        //Lista += "\n" + primero.UsuarioBase + "->" + "ListaDe" + primero.UsuarioBase;//
                    }
                }
                agregar.Close();
                if (nodo.Der != null) PrePintarArbolEspejo(nodo.Der, false);
            }

        }
        public void PintarArbolEspejo(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            if (nodo != null)
            {
                if (nodo.Izq != null)
                {
                    StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoAESP.dot");
                    agregar.WriteLine(nodo.Nickname + "->" + nodo.Izq.Nickname);
                    agregar.Close();
                    PintarArbolEspejo(nodo.Izq, false);
                }
                //Console.Write(nodo.Dato.ToString() + " ");
                if (nodo.Der != null)
                {
                    StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoAESP.dot");
                    agregar.WriteLine(nodo.Nickname + "->" + nodo.Der.Nickname);
                    agregar.Close();
                    PintarArbolEspejo(nodo.Der, false);
                }
            }

        }
        public void PreOrder(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            Console.Write(nodo.Nickname + " ");
            if (nodo.Izq != null) PreOrder(nodo.Izq, false);
            if (nodo.Der != null) PreOrder(nodo.Der, false);
        }
        public void PostOrder(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            if (nodo.Izq != null) PostOrder(nodo.Izq, false);
            if (nodo.Der != null) PostOrder(nodo.Der, false);
            Console.Write(nodo.Nickname + " ");
        }
        public void ContadorNodos(NodoArbol tmp)
        {
            Contador++;
            if (tmp.Izq == null && tmp.Der == null) { NodosHoja++; }
            if (tmp.Izq != null) { ContadorNodos(tmp.Izq); }
            if (tmp.Der != null) { ContadorNodos(tmp.Der); }
            NodosRama = Contador - NodosHoja;
        }
        public void AlturaArbol(NodoArbol tmp)
        {
            Altura = 0;
            AuxAltura(tmp, 0);
        }
        public void AuxAltura(NodoArbol tmp, int a)
        {
            if (tmp.Izq != null) { AuxAltura(tmp.Izq, a + 1); }
            if (tmp.Der != null) { AuxAltura(tmp.Der, a + 1); }
            if ((tmp.Der == null && tmp.Izq == null) && a > Altura) { Altura = a; }
        }
        public void Borrar(String Nick)
        {
            NodoArbol padre = null;
            NodoArbol nodo;

            String Nickn;
            String Pass;
            String Mail;
            int Log;
            ListaDelArbol lst;

            Actual = Raiz;
            while (Actual != null)
            {
                if (Actual.Nickname == Nick)
                {
                    if (Actual.Der == null && Actual.Izq == null)
                    {
                        if (padre.Der == Actual) { padre.Der = null; }
                        else if (padre.Izq == Actual) { padre.Izq = null; }
                        Actual = null;
                        return;
                    }
                    else
                    {
                        padre = Actual;
                        if (Actual.Der != null)
                        {
                            nodo = Actual.Der;
                            while (nodo.Izq != null)
                            {
                                padre = nodo;
                                nodo = nodo.Izq;
                            }
                        }
                        else
                        {
                            nodo = Actual.Izq;
                            while (nodo.Der != null)
                            {
                                padre = nodo;
                                nodo = nodo.Der;
                            }
                        }
                        Nickn = Actual.Nickname;
                        Pass = Actual.Contrasena;
                        Mail = Actual.Correo;
                        Log = Actual.Conectado;
                        lst = Actual.Lista;
                        Actual.Nickname = nodo.Nickname;
                        Actual.Contrasena = nodo.Contrasena;
                        Actual.Correo = nodo.Correo;
                        Actual.Conectado = nodo.Conectado;
                        Actual.Lista = nodo.Lista;
                        nodo.Nickname = Nickn;
                        nodo.Contrasena = Pass;
                        nodo.Correo = Mail;
                        nodo.Conectado = Log;
                        nodo.Lista = lst;
                        Actual = nodo;
                    }
                }
                else
                {
                    padre = Actual;
                    if (String.Compare(Nick, Actual.Nickname) > 0) { Actual = Actual.Der; }
                    else if (String.Compare(Nick, Actual.Nickname) < 0) { Actual = Actual.Izq; }
                }
            }
        }
        public void BorrarEspejo(String Nick)
        {
            NodoArbol padre = null;
            NodoArbol nodo;

            String Nickn;
            String Pass;
            String Mail;
            int Log;
            ListaDelArbol lst;

            Actual = Raiz;
            while (Actual != null)
            {
                if (Actual.Nickname == Nick)
                {
                    if (Actual.Der == null && Actual.Izq == null)
                    {
                        if (padre.Der == Actual) { padre.Der = null; }
                        else if (padre.Izq == Actual) { padre.Izq = null; }
                        Actual = null;
                        return;
                    }
                    else
                    {
                        padre = Actual;
                        if (Actual.Der != null)
                        {
                            nodo = Actual.Der;
                            while (nodo.Izq != null)
                            {
                                padre = nodo;
                                nodo = nodo.Izq;
                            }
                        }
                        else
                        {
                            nodo = Actual.Izq;
                            while (nodo.Der != null)
                            {
                                padre = nodo;
                                nodo = nodo.Der;
                            }
                        }
                        Nickn = Actual.Nickname;
                        Pass = Actual.Contrasena;
                        Mail = Actual.Correo;
                        Log = Actual.Conectado;
                        lst = Actual.Lista;
                        Actual.Nickname = nodo.Nickname;
                        Actual.Contrasena = nodo.Contrasena;
                        Actual.Correo = nodo.Correo;
                        Actual.Conectado = nodo.Conectado;
                        Actual.Lista = nodo.Lista;
                        nodo.Nickname = Nickn;
                        nodo.Contrasena = Pass;
                        nodo.Correo = Mail;
                        nodo.Conectado = Log;
                        nodo.Lista = lst;
                        Actual = nodo;
                    }
                }
                else
                {
                    padre = Actual;
                    if (String.Compare(Nick, Actual.Nickname) < 0) { Actual = Actual.Der; }
                    else if (String.Compare(Nick, Actual.Nickname) > 0) { Actual = Actual.Izq; }
                }
            }
        }
        public void SacarNodos(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            if (nodo != null)
            {
                if (nodo.Izq != null) SacarNodos(nodo.Izq, false);
                if (nodo.Der != null) SacarNodos(nodo.Der, false);
                ListaNodos.Insertar(nodo.Nickname, nodo.Contrasena, nodo.Correo, nodo.Conectado, nodo.Lista, nodo.Ganadas, nodo.Destruidas);
            }

        }
    }
    public class ListaDelArbol
    {
        public class NodoLDA
        {
            public NodoLDA(String UB, String Op, int UnDesp, int UnS, int UnE, int Gan)
            {
                this.UsuarioBase = UB;
                this.Oponente = Op;
                this.UnDesplegadas = UnDesp;
                this.UnSobrebibiente = UnS;
                this.UnEliminadas = UnE;
                this.Gano = Gan;
                this.Ant = null;
                this.Sig = null;
            }
            public String UsuarioBase;
            public String Oponente;
            public int UnDesplegadas;
            public int UnSobrebibiente;
            public int UnEliminadas;
            public int Gano;
            public NodoLDA Sig;
            public NodoLDA Ant;
        }

        public NodoLDA primero;
        public NodoLDA ultimo;
        public int CantElementos = 0;

        public void Insertar(String UB, String Op, int UnDesp, int UnS, int UnE, int Gan)
        {
            NodoLDA nuevo = new NodoLDA(UB, Op, UnDesp, UnS, UnE, Gan);
            if (primero == null)
            {
                primero = nuevo;
                ultimo = nuevo;
                primero.Sig = primero;
                primero.Ant = primero;
            }
            else
            {
                ultimo.Sig = nuevo;
                nuevo.Ant = ultimo;
                nuevo.Sig = primero;
                ultimo = nuevo;
                primero.Ant = ultimo;
            }
        }
        public String RecorrerDer()
        {
            String Lista = "";
            NodoLDA tmp = primero;
            if (tmp != null)
            {
                do
                {
                    Lista += tmp.UsuarioBase + tmp.Oponente + "[label=" + '"' + "Oponente: " + tmp.Oponente + "\n Unidades Desplegadas: " + tmp.UnDesplegadas + "\n Unidades Sobreviven: " + tmp.UnSobrebibiente + "\n Unidades Destruidas: "
                        + tmp.UnEliminadas + "\n Gano: " + tmp.Gano + '"' + "]\n";
                    tmp = tmp.Sig;
                } while (tmp != ultimo);
                tmp = primero;
                Lista += "ListaDe" + tmp.UsuarioBase;//
                do
                {
                    Lista += "->" + tmp.UsuarioBase + tmp.Oponente;
                    tmp = tmp.Sig;
                }
                while (tmp != ultimo);
            }

            return Lista;
        }
        public void Eliminar(String Op)
        {

        }
    }
    public class ListaNodoArbol
    {
        public class NodoLA
        {
            public NodoLA(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst, int Gan, int Des)
            {
                this.Nickname = Nick;
                this.Contrasena = Pass;
                this.Correo = Mail;
                this.Conectado = Log;
                this.Ant = null;
                this.Sig = null;
                this.Lista = lst;
                this.Ganadas = Gan;
                this.Destruidas = Des;
            }
            public int Perdidas;
            public int Ganadas;
            public int Destruidas;
            public String Nickname;
            public String Contrasena;
            public String Correo;
            public int Conectado;
            public NodoLA Sig;
            public NodoLA Ant;
            public ListaDelArbol Lista;
        }

        public NodoLA primero;
        public NodoLA ultimo;

        public void Insertar(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst, int Gan, int Des)
        {
            NodoLA nuevo = new NodoLA(Nick, Pass, Mail, Log, lst, Gan, Des);
            if (primero == null)
            {
                primero = nuevo;
                ultimo = nuevo;
                primero.Sig = primero;
                primero.Ant = primero;
            }
            else
            {
                ultimo.Sig = nuevo;
                nuevo.Ant = ultimo;
                nuevo.Sig = primero;
                ultimo = nuevo;
                primero.Ant = ultimo;
            }
        }
        public void SacarEspejo(Arbol atmp)
        {
            ListaNodoArbol ltmp = new ListaNodoArbol();
            ltmp = atmp.ListaNodos;
            NodoLA tmp;
            Arbol aespejo = new Arbol();
            tmp = ltmp.ultimo;
            if (ltmp.primero != null)
            {
                do
                {
                    aespejo.InsertarEspejo(tmp.Nickname, tmp.Contrasena, tmp.Correo, tmp.Conectado, tmp.Lista);
                    tmp = tmp.Ant;
                } while (tmp != ltmp.ultimo);
                aespejo.PrePintarArbolEspejo(aespejo.Raiz, true);
                aespejo.PintarArbolEspejo(aespejo.Raiz, true);
            }
            else
            {
                Console.WriteLine("\n\n LA LISTA DE NODOS DE ARBOL ESTA VACIA \n\n");
            }
        }
        public void OrdenarGanadas()
        {
            String Nick;
            String Pass;
            String Mail;
            int Log;
            ListaDelArbol lst;
            int Gan;
            int Des;

            NodoLA tmp = primero.Sig;
            bool salir = false;
            int cambio = 1;

            if (primero != null)
            {
                while (salir == false)
                {
                    if (tmp.Sig != ultimo)
                    {
                        if (tmp.Ganadas < tmp.Sig.Ganadas)
                        {
                            Nick = tmp.Nickname;
                            Pass = tmp.Contrasena;
                            Mail = tmp.Correo;
                            Log = tmp.Conectado;
                            lst = tmp.Lista;
                            Gan = tmp.Ganadas;
                            Des = tmp.Destruidas;

                            tmp.Nickname = tmp.Sig.Nickname;
                            tmp.Contrasena = tmp.Sig.Contrasena;
                            tmp.Correo = tmp.Sig.Correo;
                            tmp.Conectado = tmp.Sig.Conectado;
                            tmp.Ganadas = tmp.Sig.Ganadas;
                            tmp.Destruidas = tmp.Sig.Destruidas;

                            tmp.Sig.Nickname = Nick;
                            tmp.Sig.Contrasena = Pass;
                            tmp.Sig.Correo = Mail;
                            tmp.Sig.Conectado = Log;
                            tmp.Sig.Ganadas = Gan;
                            tmp.Sig.Destruidas = Des;

                            cambio = cambio + 1;
                        }
                        tmp = tmp.Sig;
                    }
                    else
                    {
                        if (cambio == 0) { salir = true; }
                        cambio = 0;
                        tmp = tmp.Sig;
                    }
                }
            }
            else
            {
                Console.WriteLine("LA LISTA DE NODOS DE ARBOL NO CONTIENE ELEMENTOS EN GANADAS");
            }
            tmp = primero;
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoLG.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();
            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoLG.dot");
            if (tmp != null)
            {
                while (tmp != ultimo)
                {
                    agregar.WriteLine(tmp.Nickname + "[label=" + '"' + tmp.Nickname + "\n Correo: " + tmp.Correo + "\n Conectado: " + tmp.Conectado + "\n Ganadas: " + tmp.Ganadas + "\n Destruidas: " + tmp.Destruidas + '"' + "]");
                    tmp = tmp.Sig;
                }
            }
            agregar.Write("Top_Juegos_Ganados");
            tmp = primero;
            if (tmp != null)
            {
                while (tmp != ultimo)
                {
                    agregar.Write("->" + tmp.Nickname);
                    tmp = tmp.Sig;
                }
            }
            agregar.WriteLine("}");
            agregar.Close();
        }
        public void OrdenarDestruidas()
        {
            String Nick;
            String Pass;
            String Mail;
            int Log;
            ListaDelArbol lst;
            int Gan;
            int Des;

            NodoLA tmp = primero.Sig;
            bool salir = false;
            int cambio = 1;

            if (primero != null)
            {
                while (salir == false)
                {
                    if (tmp.Sig != ultimo)
                    {
                        if (tmp.Destruidas < tmp.Sig.Destruidas)
                        {
                            Nick = tmp.Nickname;
                            Pass = tmp.Contrasena;
                            Mail = tmp.Correo;
                            Log = tmp.Conectado;
                            lst = tmp.Lista;
                            Gan = tmp.Ganadas;
                            Des = tmp.Destruidas;

                            tmp.Nickname = tmp.Sig.Nickname;
                            tmp.Contrasena = tmp.Sig.Contrasena;
                            tmp.Correo = tmp.Sig.Correo;
                            tmp.Conectado = tmp.Sig.Conectado;
                            tmp.Ganadas = tmp.Sig.Ganadas;
                            tmp.Destruidas = tmp.Sig.Destruidas;

                            tmp.Sig.Nickname = Nick;
                            tmp.Sig.Contrasena = Pass;
                            tmp.Sig.Correo = Mail;
                            tmp.Sig.Conectado = Log;
                            tmp.Sig.Ganadas = Gan;
                            tmp.Sig.Destruidas = Des;

                            cambio = cambio + 1;
                        }
                        tmp = tmp.Sig;
                    }
                    else
                    {
                        if (cambio == 0) { salir = true; }
                        cambio = 0;
                        tmp = tmp.Sig;
                    }
                }
            }
            else
            {
                Console.WriteLine("LA LISTA DE NODOS DE ARBOL NO CONTIENE ELEMENTOS EN DESTRUIDAS");
            }
            tmp = primero;
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoLD.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();
            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoLD.dot");
            if (tmp != null)
            {
                while (tmp != ultimo)
                {
                    agregar.WriteLine(tmp.Nickname + "[label=" + '"' + tmp.Nickname + "\n Destruidas: " + tmp.Destruidas + "\n Correo: " + tmp.Correo + "\n Conectado: " + tmp.Conectado + "\n Ganadas: " + tmp.Ganadas + '"' + "]");
                    tmp = tmp.Sig;
                }
            }
            agregar.Write("Top_Juegos_Piesas_Destruidas");
            tmp = primero;
            if (tmp != null)
            {
                while (tmp != ultimo)
                {
                    agregar.Write("->" + tmp.Nickname);
                    tmp = tmp.Sig;
                }
            }
            agregar.WriteLine("}");
            agregar.Close();
        }
    }

    public class Matriz
    {
        public LE EF = new LE();
        public LE EC = new LE();
        public class Nodom
        {
            public Nodom(int fil, int col, int niv, int vis, String jug, String uni, int mov, int alc, int dan, int vid)
            {
                this.fil = fil;
                this.col = col;
                this.niv = niv;
                this.vis = vis;
                this.jugador = jug;
                this.unidad = uni;
                this.movimiento = mov;
                this.alcanse = alc;
                this.dano = dan;
                this.vida = vid;
                this.abj = null;
                this.arr = null;
                this.der = null;
                this.izq = null;
                this.sup = null;
                this.inf = null;
            }
            public int fil;
            public int col;
            public int niv;
            public int vis;
            public String jugador;
            public String unidad;
            public int movimiento;
            public int alcanse;
            public int dano;
            public int vida;
            public Nodom der;
            public Nodom izq;
            public Nodom arr;
            public Nodom abj;
            public Nodom sup;
            public Nodom inf;
        }

        public class En
        {
            public En(int id)
            {
                this.id = id;
                this.sig = null;
                this.ant = null;
                this.acceso = null;
            }
            public int id;
            public En sig;
            public En ant;
            public Nodom acceso;
        }
        public class LE
        {
            public En primero;
            public void Insertar(En nuevo)
            {
                if (primero == null) { primero = nuevo; }
                else
                {
                    if (nuevo.id < primero.id)
                    {
                        nuevo.sig = primero;
                        primero.ant = nuevo;
                        primero = nuevo;
                    }
                    else
                    {
                        En actual = primero;
                        while (actual.sig != null)
                        {
                            if (nuevo.id < actual.sig.id)
                            {
                                nuevo.sig = actual.sig;
                                actual.sig.ant = nuevo;
                                nuevo.ant = actual;
                                actual.sig = nuevo;
                                break;
                            }
                            actual = actual.sig;
                        }
                        if (actual.sig == null)
                        {
                            actual.sig = nuevo;
                            actual.ant = actual;
                        }
                    }
                }
            }
            public En getEn(int id)
            {
                En actual = primero;
                while (actual != null)
                {
                    if (actual.id == id)
                    {
                        return actual;
                    }
                    actual = actual.sig;
                }
                return null;
            }
        }

        public void Insertar(String jug, int col, int fil, String uni, int des)
        {
            String cad = uni;
            if (cad.ToUpper().Contains("NEOSATELITE"))
            {
                if (Buscar(fil, col) == false) { Insertar1(fil, col, 3, 1, jug, uni, 6, 0, 2, 10); }
                else { Insertar2(fil, col, 3, 1, jug, uni, 6, 0, 2, 10); }
            }
            if (cad.ToUpper().Contains("BOMBARDERO"))
            {
                if (Buscar(fil, col) == false) { Insertar1(fil, col, 2, 1, jug, uni, 7, 0, 5, 10); }
                else { Insertar2(fil, col, 2, 1, jug, uni, 7, 0, 5, 10); }
            }
            if (cad.ToUpper().Contains("CAZA"))
            {
                if (Buscar(fil, col) == false) { Insertar1(fil, col, 2, 1, jug, uni, 9, 1, 2, 20); }
                else { Insertar2(fil, col, 2, 1, jug, uni, 9, 1, 2, 20); }
            }
            if (cad.ToUpper().Contains("HELICOPTERO"))
            {
                if (Buscar(fil, col) == false) { Insertar1(fil, col, 2, 1, jug, uni, 9, 1, 3, 15); }
                else { Insertar2(fil, col, 2, 1, jug, uni, 9, 1, 3, 15); }
            }
            if (cad.ToUpper().Contains("FRAGATA"))
            {
                if (Buscar(fil, col) == false) { Insertar1(fil, col, 1, 1, jug, uni, 5, 6, 3, 10); }
                else { Insertar2(fil, col, 1, 1, jug, uni, 5, 6, 3, 10); }
            }
            if (cad.ToUpper().Contains("CRUCERO"))
            {
                if (Buscar(fil, col) == false) { Insertar1(fil, col, 1, 1, jug, uni, 6, 1, 3, 15); }
                else { Insertar2(fil, col, 1, 1, jug, uni, 6, 1, 3, 15); }
            }
            if (cad.ToUpper().Contains("SUBMARINO"))
            {
                if (Buscar(fil, col) == false) { Insertar1(fil, col, 0, 1, jug, uni, 5, 1, 2, 10); }
                else { Insertar2(fil, col, 0, 1, jug, uni, 5, 1, 2, 10); }
            }
        }
        public void Insertar1(int fil, int col, int niv, int vis, String jug, String uni, int mov, int alc, int dan, int vid)
        {
            Nodom nuevo = new Nodom(fil, col, niv, vis, jug, uni, mov, alc, dan, vid);
            Nodom vand1 = new Nodom(fil, col, niv, 0, "", "", 0, 0, 0, 0);
            Nodom vand2 = new Nodom(fil, col, niv, 0, "", "", 0, 0, 0, 0);
            //Incertar en filas
            En eF = EF.getEn(fil);
            if (eF == null) //Si no existe el encabezado de fila
            {
                if (niv == 0)
                {
                    eF = new En(fil);
                    EF.Insertar(eF);
                    eF.acceso = vand1;

                    vand1.inf = nuevo;
                    nuevo.sup = vand1;
                }
                if (niv == 1)
                {
                    eF = new En(fil);
                    EF.Insertar(eF);
                    eF.acceso = nuevo;
                }
                if (niv == 2)
                {
                    eF = new En(fil);
                    EF.Insertar(eF);
                    eF.acceso = vand1;

                    vand1.sup = nuevo;
                    nuevo.inf = vand1;
                }
                if (niv == 3)
                {
                    eF = new En(fil);
                    EF.Insertar(eF);
                    eF.acceso = vand1;

                    vand1.sup = vand2;
                    vand2.inf = vand1;
                    vand2.sup = nuevo;
                    nuevo.inf = vand2;
                }

            }
            else
            {
                if (nuevo.col < eF.acceso.col) //Incerta al inicio
                {
                    if (niv == 0)
                    {
                        vand1.der = eF.acceso;
                        eF.acceso.izq = vand1;
                        eF.acceso = vand1;

                        vand1.inf = nuevo;
                        nuevo.sup = vand1;
                    }
                    if (niv == 1)
                    {
                        nuevo.der = eF.acceso;
                        eF.acceso.izq = nuevo;
                        eF.acceso = nuevo;
                    }
                    if (niv == 2)
                    {
                        vand1.der = eF.acceso;
                        eF.acceso.izq = vand1;
                        eF.acceso = vand1;

                        vand1.sup = nuevo;
                        nuevo.inf = vand1;
                    }
                    if (niv == 3)
                    {
                        vand1.der = eF.acceso;
                        eF.acceso.izq = vand1;
                        eF.acceso = vand1;

                        vand1.sup = vand2;
                        vand2.inf = vand1;
                        vand2.sup = nuevo;
                        nuevo.inf = vand2;
                    }

                }
                else
                {
                    Nodom actual = eF.acceso;
                    while (actual.der != null)
                    {
                        if (nuevo.col < actual.der.col) //Incerta en medio
                        {
                            if (niv == 0)
                            {
                                vand1.der = actual.der;
                                actual.der.izq = vand1;
                                vand1.izq = actual;
                                actual.der = vand1;

                                vand1.inf = nuevo;
                                nuevo.sup = vand1;
                                break;
                            }
                            if (niv == 1)
                            {
                                nuevo.der = actual.der;
                                actual.der.izq = nuevo;
                                nuevo.izq = actual;
                                actual.der = nuevo;
                                break;
                            }
                            if (niv == 2)
                            {
                                vand1.der = actual.der;
                                actual.der.izq = vand1;
                                vand1.izq = actual;
                                actual.der = vand1;

                                vand1.sup = nuevo;
                                nuevo.inf = vand1;
                                break;
                            }
                            if (niv == 3)
                            {
                                vand1.der = actual.der;
                                actual.der.izq = vand1;
                                vand1.izq = actual;
                                actual.der = vand1;

                                vand1.sup = vand2;
                                vand2.inf = vand1;
                                vand2.sup = nuevo;
                                nuevo.inf = vand2;
                                break;
                            }

                        }
                        actual = actual.der;
                    }
                    if (actual.der == null) //Incerta al final
                    {
                        if (niv == 0)
                        {
                            actual.der = vand1;
                            vand1.izq = actual;

                            vand1.inf = nuevo;
                            nuevo.sup = vand1;
                        }
                        if (niv == 1)
                        {
                            actual.der = nuevo;
                            nuevo.izq = actual;
                        }
                        if (niv == 2)
                        {
                            actual.der = vand1;
                            vand1.izq = actual;

                            vand1.sup = nuevo;
                            nuevo.inf = vand1;
                        }
                        if (niv == 3)
                        {
                            actual.der = vand1;
                            vand1.izq = actual;

                            vand1.sup = vand2;
                            vand2.inf = vand1;
                            vand2.sup = nuevo;
                            nuevo.inf = vand2;
                        }
                    }
                }
            }
            //Incertar en columnas
            En eC = EC.getEn(col);
            if (eC == null) //Si no existe el encabezado de columna
            {
                if (niv == 0)
                {
                    eC = new En(col);
                    EC.Insertar(eC);
                    eC.acceso = vand1;

                    vand1.inf = nuevo;
                    nuevo.sup = vand1;
                }
                if (niv == 1)
                {
                    eC = new En(col);
                    EC.Insertar(eC);
                    eC.acceso = nuevo;
                }
                if (niv == 2)
                {
                    eC = new En(col);
                    EC.Insertar(eC);
                    eC.acceso = vand1;

                    vand1.sup = nuevo;
                    nuevo.inf = vand1;
                }
                if (niv == 3)
                {
                    eC = new En(col);
                    EC.Insertar(eC);
                    eC.acceso = vand1;

                    vand1.sup = vand2;
                    vand2.inf = vand1;
                    vand2.sup = nuevo;
                    nuevo.inf = vand2;
                }
            }
            else
            {
                if (nuevo.fil < eC.acceso.fil) //Incerta al inicio
                {
                    if (niv == 0)
                    {
                        vand1.abj = eC.acceso;
                        eC.acceso.arr = vand1;
                        eC.acceso = vand1;

                        vand1.inf = nuevo;
                        nuevo.sup = vand1;
                    }
                    if (niv == 1)
                    {
                        nuevo.abj = eC.acceso;
                        eC.acceso.arr = nuevo;
                        eC.acceso = nuevo;
                    }
                    if (niv == 2)
                    {
                        vand1.abj = eC.acceso;
                        eC.acceso.arr = vand1;
                        eC.acceso = vand1;

                        vand1.sup = nuevo;
                        nuevo.inf = vand1;
                    }
                    if (niv == 3)
                    {
                        vand1.abj = eC.acceso;
                        eC.acceso.arr = vand1;
                        eC.acceso = vand1;

                        vand1.sup = vand2;
                        vand2.inf = vand1;
                        vand2.sup = nuevo;
                        nuevo.inf = vand2;
                    }
                }
                else
                {
                    Nodom actual = eC.acceso;
                    while (actual.abj != null)
                    {
                        if (nuevo.fil < actual.abj.fil) //Incerta en medio
                        {
                            if (niv == 0)
                            {
                                vand1.abj = actual.abj;
                                actual.abj.arr = vand1;
                                vand1.arr = actual;
                                actual.abj = vand1;

                                vand1.inf = nuevo;
                                nuevo.sup = vand1;
                                break;
                            }
                            if (niv == 1)
                            {
                                nuevo.abj = actual.abj;
                                actual.abj.arr = nuevo;
                                nuevo.arr = actual;
                                actual.abj = nuevo;
                                break;
                            }
                            if (niv == 2)
                            {
                                vand1.abj = actual.abj;
                                actual.abj.arr = vand1;
                                vand1.arr = actual;
                                actual.abj = vand1;

                                vand1.sup = nuevo;
                                nuevo.inf = vand1;
                                break;
                            }
                            if (niv == 3)
                            {
                                vand1.abj = actual.abj;
                                actual.abj.arr = vand1;
                                vand1.arr = actual;
                                actual.abj = vand1;

                                vand1.sup = vand2;
                                vand2.inf = vand1;
                                vand2.sup = nuevo;
                                nuevo.inf = vand2;
                                break;
                            }
                        }
                        actual = actual.abj;
                    }
                    if (actual.abj == null) //Incerta al final
                    {
                        if (niv == 0)
                        {
                            actual.abj = vand1;
                            vand1.arr = actual;

                            vand1.inf = nuevo;
                            nuevo.sup = vand1;
                        }
                        if (niv == 1)
                        {
                            actual.abj = nuevo;
                            nuevo.arr = actual;
                        }
                        if (niv == 2)
                        {
                            actual.abj = vand1;
                            vand1.arr = actual;

                            vand1.sup = nuevo;
                            nuevo.inf = vand1;
                        }
                        if (niv == 3)
                        {
                            actual.abj = vand1;
                            vand1.arr = actual;

                            vand1.sup = vand2;
                            vand2.inf = vand1;
                            vand2.sup = nuevo;
                            nuevo.inf = vand2;
                        }
                    }
                }
            }
        }
        public void Insertar2(int fil, int col, int niv, int vis, String jug, String uni, int mov, int alc, int dan, int vid)
        {
            if (niv == 0)
            {
                En tmp = EF.primero;
                while (tmp != null)
                {
                    Nodom actual = tmp.acceso;
                    while (actual != null)
                    {
                        if (actual.col == col && actual.fil == fil)
                        {
                            if (actual.inf != null)
                            {
                                actual.inf.fil = fil;
                                actual.inf.col = col;
                                actual.inf.niv = niv;
                                actual.inf.vis = vis;
                                actual.inf.jugador = jug;
                                actual.inf.unidad = uni;
                                actual.inf.movimiento = mov;
                                actual.inf.alcanse = alc;
                                actual.inf.dano = dan;
                                actual.inf.vida = vid;
                            }
                            else
                            {
                                Nodom nuevo = new Nodom(fil, col, niv, vis, jug, uni, mov, alc, dan, vid);
                                nuevo.sup = actual;
                                actual.inf = nuevo;
                            }
                        }
                        actual = actual.der;
                    }
                    tmp = tmp.sig;
                }
            }
            if (niv == 1)
            {
                En tmp = EF.primero;
                while (tmp != null)
                {
                    Nodom actual = tmp.acceso;
                    while (actual != null)
                    {
                        if (actual.col == col && actual.fil == fil)
                        {
                            actual.fil = fil;
                            actual.col = col;
                            actual.niv = niv;
                            actual.vis = vis;
                            actual.jugador = jug;
                            actual.unidad = uni;
                            actual.movimiento = mov;
                            actual.alcanse = alc;
                            actual.dano = dan;
                            actual.vida = vid;
                        }
                        actual = actual.der;
                    }
                    tmp = tmp.sig;
                }
            }
            if (niv == 2)
            {
                En tmp = EF.primero;
                while (tmp != null)
                {
                    Nodom actual = tmp.acceso;
                    while (actual != null)
                    {
                        if (actual.col == col && actual.fil == fil)
                        {
                            if (actual.sup != null)
                            {
                                actual.sup.fil = fil;
                                actual.sup.col = col;
                                actual.sup.niv = niv;
                                actual.sup.vis = vis;
                                actual.sup.jugador = jug;
                                actual.sup.unidad = uni;
                                actual.sup.movimiento = mov;
                                actual.sup.alcanse = alc;
                                actual.sup.dano = dan;
                                actual.sup.vida = vid;
                            }
                            else
                            {
                                Nodom nuevo = new Nodom(fil, col, niv, vis, jug, uni, mov, alc, dan, vid);
                                nuevo.inf = actual;
                                actual.sup = nuevo;
                            }
                        }
                        actual = actual.der;
                    }
                    tmp = tmp.sig;
                }
            }
            if (niv == 3)
            {
                En tmp = EF.primero;
                while (tmp != null)
                {
                    Nodom actual = tmp.acceso;
                    while (actual != null)
                    {
                        if (actual.col == col && actual.fil == fil)
                        {
                            if (actual.sup != null)
                            {
                                if (actual.sup.sup != null)
                                {
                                    actual.sup.sup.fil = fil;
                                    actual.sup.sup.col = col;
                                    actual.sup.sup.niv = niv;
                                    actual.sup.sup.vis = vis;
                                    actual.sup.sup.jugador = jug;
                                    actual.sup.sup.unidad = uni;
                                    actual.sup.sup.movimiento = mov;
                                    actual.sup.sup.alcanse = alc;
                                    actual.sup.sup.dano = dan;
                                    actual.sup.sup.vida = vid;
                                }
                                else
                                {
                                    Nodom nuevo = new Nodom(fil, col, niv, vis, jug, uni, mov, alc, dan, vid);
                                    nuevo.inf = actual.sup;
                                    actual.sup.sup = nuevo;
                                }
                            }
                            else
                            {
                                Nodom nuevo = new Nodom(fil, col, niv, vis, jug, uni, mov, alc, dan, vid);
                                Nodom vand1 = new Nodom(fil, col, niv, 0, "", "", 0, 0, 0, 0);
                                actual.sup = vand1;
                                vand1.inf = actual;
                                nuevo.inf = vand1;
                                vand1.sup = nuevo;
                            }
                        }
                        actual = actual.der;
                    }
                    tmp = tmp.sig;
                }
            }
        }
        public void GraficarMatriz()
        {
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoM.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();

            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoM.dot");

            En tmpo = EF.primero;
            while (tmpo != null)
            {
                Nodom actual = tmpo.acceso;
                while (actual != null)
                {
                    if (actual != null && actual.vis != 0)
                    {
                        agregar.WriteLine('"' + "" + actual.col + "," + actual.fil + '"' + "[label=" + '"' + actual.col + "," + actual.fil + "\n Jugador: " + actual.jugador + "\n Unidad: " + actual.unidad
                            + "\n Movimiento: " + actual.movimiento + "\n Alcance: " + actual.alcanse + "\n Dano: " + actual.dano + "\n Vida: " + actual.vida + '"' + "]");
                    }
                    actual = actual.der;
                }
                tmpo = tmpo.sig;
            }

            En tmp = EC.primero;
            String SEncX = "";
            agregar.WriteLine("{rank=min;Matriz;");
            while (tmp != null)
            {
                agregar.WriteLine("X" + tmp.id);
                tmp = tmp.sig;
            }
            agregar.WriteLine("}");

            En tmp2 = EF.primero;
            while (tmp2 != null)
            {
                agregar.WriteLine("{rank=same");
                agregar.WriteLine("Y" + tmp2.id);
                Nodom actual = tmp2.acceso;
                while (actual != null)
                {
                    if (actual.vis != 0)
                    {
                        agregar.WriteLine('"' + "" + actual.col + "," + actual.fil + '"');

                    }
                    actual = actual.der;

                }
                agregar.WriteLine("};");
                tmp2 = tmp2.sig;
            }

            En tmp3 = EC.primero;
            while (tmp3 != null)
            {
                Nodom actual2 = tmp3.acceso;
                while (actual2 != null)
                {
                    if (actual2.abj != null)
                    {
                        if ((actual2.vis != 0) && (actual2.abj.vis != 0))
                        {
                            agregar.WriteLine('"' + "" + actual2.col + "," + actual2.fil + '"' + "->" + '"' + "" + actual2.abj.col + "," + actual2.abj.fil + '"');
                            agregar.WriteLine('"' + "" + actual2.abj.col + "," + actual2.abj.fil + '"' + "->" + '"' + "" + actual2.col + "," + actual2.fil + '"');
                        }

                    }
                    actual2 = actual2.abj;
                }
                tmp3 = tmp3.sig;
            }

            En tmp4 = EC.primero;
            while (tmp4 != null)
            {
                if (tmp4.acceso.vis != 0)
                {
                    agregar.WriteLine("X" + tmp4.id + "->" + '"' + "" + tmp4.acceso.col + "," + tmp4.acceso.fil + '"');
                }
                tmp4 = tmp4.sig;
            }

            En tmp5 = EF.primero;
            while (tmp5 != null)
            {
                Nodom actual3 = tmp5.acceso;
                while (actual3 != null)
                {
                    if (actual3.der != null)
                    {
                        if ((actual3.vis != 0) && (actual3.der.vis != 0))
                        {
                            agregar.WriteLine('"' + "" + actual3.col + "," + actual3.fil + '"' + "->" + '"' + "" + actual3.der.col + "," + actual3.der.fil + '"' + "[constraint=false]");
                            agregar.WriteLine('"' + "" + actual3.der.col + "," + actual3.der.fil + '"' + "->" + '"' + "" + actual3.col + "," + actual3.fil + '"' + "[constraint=false]");
                        }

                    }
                    actual3 = actual3.der;
                }
                tmp5 = tmp5.sig;
            }

            En tmp6 = EF.primero;
            while (tmp6 != null)
            {
                if (tmp6.acceso.vis != 0)
                {
                    agregar.WriteLine("Y" + tmp6.id + "->" + '"' + "" + tmp6.acceso.col + "," + tmp6.acceso.fil + '"');
                }
                tmp6 = tmp6.sig;
            }

            En tmp7 = EC.primero;
            if (tmp7 != null)
            {
                agregar.WriteLine("Matriz->" + "X" + EC.primero.id);
                while (tmp7.sig != null)
                {
                    agregar.WriteLine("X" + tmp7.id + "->" + "X" + tmp7.sig.id);
                    tmp7 = tmp7.sig;
                }
            }

            En tmp8 = EF.primero;
            if (tmp8 != null)
            {
                agregar.WriteLine("Matriz->" + "Y" + EF.primero.id + "[rankdir=UD]");
                while (tmp8.sig != null)
                {
                    agregar.WriteLine("Y" + tmp8.id + "->" + "Y" + tmp8.sig.id + "[rankdir=UD]");
                    tmp8 = tmp8.sig;
                }
            }

            agregar.WriteLine("}");
            agregar.Close();
        }
        public void GraficarMatriz0()
        {
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoM0.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();

            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoM0.dot");

            En tmpo = EF.primero;
            while (tmpo != null)
            {
                Nodom actual = tmpo.acceso;
                while (actual != null)
                {
                    if (actual.inf != null && actual.inf.vis != 0)
                    {
                        agregar.WriteLine('"' + "" + actual.inf.col + "," + actual.inf.fil + '"' + "[label=" + '"' + actual.inf.col + "," + actual.inf.fil + " " + "\n Jugador: " + actual.inf.jugador
                            + "\n Unidad: " + actual.inf.unidad + "\n Movimiento: " + actual.inf.movimiento + "\n Alcance: " + actual.inf.alcanse + "\n Dano: " + actual.inf.dano + "\n Vida: " + actual.inf.vida + '"' + "]");
                    }
                    actual = actual.der;
                }
                tmpo = tmpo.sig;
            }

            En tmp = EC.primero;
            String SEncX = "";
            agregar.WriteLine("{rank=min;Matriz;");
            while (tmp != null)
            {
                agregar.WriteLine("X" + tmp.id);
                tmp = tmp.sig;
            }
            agregar.WriteLine("}");

            En tmp2 = EF.primero;
            while (tmp2 != null)
            {
                agregar.WriteLine("{rank=same");
                agregar.WriteLine("Y" + tmp2.id);
                Nodom actual = tmp2.acceso;
                while (actual != null)
                {
                    if (actual.inf != null && actual.inf.vis != 0)
                    {
                        agregar.WriteLine('"' + "" + actual.inf.col + "," + actual.inf.fil + '"');

                    }
                    actual = actual.der;

                }
                agregar.WriteLine("};");
                tmp2 = tmp2.sig;
            }

            En tmp3 = EC.primero;
            while (tmp3 != null)
            {
                Nodom actual2 = tmp3.acceso;
                while (actual2 != null)
                {
                    if (actual2.abj != null)
                    {
                        if ((actual2.inf != null && actual2.abj.inf != null) && (actual2.inf.vis != 0 && actual2.abj.inf.vis != 0))
                        {
                            agregar.WriteLine('"' + "" + actual2.inf.col + "," + actual2.inf.fil + '"' + "->" + '"' + "" + actual2.abj.inf.col + "," + actual2.abj.inf.fil + '"');
                            agregar.WriteLine('"' + "" + actual2.abj.inf.col + "," + actual2.abj.inf.fil + '"' + "->" + '"' + "" + actual2.inf.col + "," + actual2.inf.fil + '"');
                        }

                    }
                    actual2 = actual2.abj;
                }
                tmp3 = tmp3.sig;
            }

            En tmp4 = EC.primero;
            while (tmp4 != null)
            {
                if (tmp4.acceso.inf != null && tmp4.acceso.inf.vis != 0)
                {
                    agregar.WriteLine("X" + tmp4.id + "->" + '"' + "" + tmp4.acceso.inf.col + "," + tmp4.acceso.inf.fil + '"');
                }
                tmp4 = tmp4.sig;
            }

            En tmp5 = EF.primero;
            while (tmp5 != null)
            {
                Nodom actual3 = tmp5.acceso;
                while (actual3 != null)
                {
                    if (actual3.der != null)
                    {
                        if ((actual3.inf != null && actual3.der.inf != null) && (actual3.inf.vis != 0 && actual3.der.inf.vis != 0))
                        {
                            agregar.WriteLine('"' + "" + actual3.inf.col + "," + actual3.inf.fil + '"' + "->" + '"' + "" + actual3.der.inf.col + "," + actual3.der.inf.fil + '"' + "[constraint=false]");
                            agregar.WriteLine('"' + "" + actual3.der.inf.col + "," + actual3.der.inf.fil + '"' + "->" + '"' + "" + actual3.inf.col + "," + actual3.inf.fil + '"' + "[constraint=false]");
                        }

                    }
                    actual3 = actual3.der;
                }
                tmp5 = tmp5.sig;
            }

            En tmp6 = EF.primero;
            while (tmp6 != null)
            {
                if (tmp6.acceso.inf != null && tmp6.acceso.inf.vis != 0)
                {
                    agregar.WriteLine("Y" + tmp6.id + "->" + '"' + "" + tmp6.acceso.inf.col + "," + tmp6.acceso.inf.fil + '"');
                }
                tmp6 = tmp6.sig;
            }

            En tmp7 = EC.primero;
            if (tmp7 != null)
            {
                agregar.WriteLine("Matriz->" + "X" + EC.primero.id);
                while (tmp7.sig != null)
                {
                    agregar.WriteLine("X" + tmp7.id + "->" + "X" + tmp7.sig.id);
                    tmp7 = tmp7.sig;
                }
            }


            En tmp8 = EF.primero;
            if (tmp8 != null)
            {
                agregar.WriteLine("Matriz->" + "Y" + EF.primero.id + "[rankdir=UD]");
                while (tmp8.sig != null)
                {
                    agregar.WriteLine("Y" + tmp8.id + "->" + "Y" + tmp8.sig.id + "[rankdir=UD]");
                    tmp8 = tmp8.sig;
                }
            }

            agregar.WriteLine("}");
            agregar.Close();
        }
        public void GraficarMatriz2()
        {
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoM2.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();

            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoM2.dot");

            En tmpo = EF.primero;
            while (tmpo != null)
            {
                Nodom actual = tmpo.acceso;
                while (actual != null)
                {
                    if (actual.sup != null && actual.sup.vis != 0)
                    {
                        agregar.WriteLine('"' + "" + actual.sup.col + "," + actual.sup.fil + '"' + "[label=" + '"' + actual.sup.col + "," + actual.sup.fil + " " + "\n Jugador: " + actual.sup.jugador
                            + "\n Unidad: " + actual.sup.unidad + "\n Movimiento: " + actual.sup.movimiento + "\n Alcance: " + actual.sup.alcanse + "\n Dano: " + actual.sup.dano + "\n Vida: " + actual.sup.vida + '"' + "]");
                    }
                    actual = actual.der;
                }
                tmpo = tmpo.sig;
            }

            En tmp = EC.primero;
            String SEncX = "";
            agregar.WriteLine("{rank=min;Matriz;");
            while (tmp != null)
            {
                agregar.WriteLine("X" + tmp.id);
                tmp = tmp.sig;
            }
            agregar.WriteLine("}");

            En tmp2 = EF.primero;
            while (tmp2 != null)
            {
                agregar.WriteLine("{rank=same");
                agregar.WriteLine("Y" + tmp2.id);
                Nodom actual = tmp2.acceso;
                while (actual != null)
                {
                    if (actual.sup != null && actual.sup.vis != 0)
                    {
                        agregar.WriteLine('"' + "" + actual.sup.col + "," + actual.sup.fil + '"');

                    }
                    actual = actual.der;

                }
                agregar.WriteLine("};");
                tmp2 = tmp2.sig;
            }

            En tmp3 = EC.primero;
            while (tmp3 != null)
            {
                Nodom actual2 = tmp3.acceso;
                while (actual2 != null)
                {
                    if (actual2.abj != null)
                    {
                        if ((actual2.sup != null && actual2.abj.sup != null) && (actual2.sup.vis != 0 && actual2.abj.sup.vis != 0))
                        {
                            agregar.WriteLine('"' + "" + actual2.sup.col + "," + actual2.sup.fil + '"' + "->" + '"' + "" + actual2.abj.sup.col + "," + actual2.abj.sup.fil + '"');
                            agregar.WriteLine('"' + "" + actual2.abj.sup.col + "," + actual2.abj.sup.fil + '"' + "->" + '"' + "" + actual2.sup.col + "," + actual2.sup.fil + '"');
                        }

                    }
                    actual2 = actual2.abj;
                }
                tmp3 = tmp3.sig;
            }

            En tmp4 = EC.primero;
            while (tmp4 != null)
            {
                if (tmp4.acceso.sup != null && tmp4.acceso.sup.vis != 0)
                {
                    agregar.WriteLine("X" + tmp4.id + "->" + '"' + "" + tmp4.acceso.sup.col + "," + tmp4.acceso.sup.fil + '"');
                }
                tmp4 = tmp4.sig;
            }

            En tmp5 = EF.primero;
            while (tmp5 != null)
            {
                Nodom actual3 = tmp5.acceso;
                while (actual3 != null)
                {
                    if (actual3.der != null)
                    {
                        if ((actual3.sup != null && actual3.der.sup != null) && (actual3.sup.vis != 0 && actual3.der.sup.vis != 0))
                        {
                            agregar.WriteLine('"' + "" + actual3.sup.col + "," + actual3.sup.fil + '"' + "->" + '"' + "" + actual3.der.sup.col + "," + actual3.der.sup.fil + '"' + "[constraint=false]");
                            agregar.WriteLine('"' + "" + actual3.der.sup.col + "," + actual3.der.sup.fil + '"' + "->" + '"' + "" + actual3.sup.col + "," + actual3.sup.fil + '"' + "[constraint=false]");
                        }

                    }
                    actual3 = actual3.der;
                }
                tmp5 = tmp5.sig;
            }

            En tmp6 = EF.primero;
            while (tmp6 != null)
            {
                if (tmp6.acceso.sup != null && tmp6.acceso.sup.vis != 0)
                {
                    agregar.WriteLine("Y" + tmp6.id + "->" + '"' + "" + tmp6.acceso.sup.col + "," + tmp6.acceso.sup.fil + '"');
                }
                tmp6 = tmp6.sig;
            }

            En tmp7 = EC.primero;
            if (tmp7 != null)
            {
                agregar.WriteLine("Matriz->" + "X" + EC.primero.id);
                while (tmp7.sig != null)
                {
                    agregar.WriteLine("X" + tmp7.id + "->" + "X" + tmp7.sig.id);
                    tmp7 = tmp7.sig;
                }
            }

            En tmp8 = EF.primero;
            if (tmp8 != null)
            {
                agregar.WriteLine("Matriz->" + "Y" + EF.primero.id + "[rankdir=UD]");
                while (tmp8.sig != null)
                {
                    agregar.WriteLine("Y" + tmp8.id + "->" + "Y" + tmp8.sig.id + "[rankdir=UD]");
                    tmp8 = tmp8.sig;
                }
            }

            agregar.WriteLine("}");
            agregar.Close();
        }
        public void GraficarMatriz3()
        {
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoM3.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();

            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoM3.dot");

            En tmpo = EF.primero;
            while (tmpo != null)
            {
                Nodom actual = tmpo.acceso;
                while (actual != null)
                {
                    if (actual.sup != null)
                    {
                        if (actual.sup.sup != null && actual.sup.sup.vis != 0)
                        {
                            agregar.WriteLine('"' + "" + actual.sup.sup.col + "," + actual.sup.sup.fil + '"' + "[label=" + '"' + actual.sup.sup.col + "," + actual.sup.sup.fil + " " + "\n Jugador: "
                                + actual.sup.sup.jugador + "\n Unidad: " + actual.sup.sup.unidad + "\n Movimiento: " + actual.sup.sup.movimiento + "\n Alcance: " + actual.sup.sup.alcanse + "\n Dano: "
                                + actual.sup.sup.dano + "\n Vida: " + actual.sup.sup.vida + '"' + "]");
                        }
                    }
                    actual = actual.der;
                }
                tmpo = tmpo.sig;
            }

            En tmp = EC.primero;
            String SEncX = "";
            agregar.WriteLine("{rank=min;Matriz;");
            while (tmp != null)
            {
                agregar.WriteLine("X" + tmp.id);
                tmp = tmp.sig;
            }
            agregar.WriteLine("}");

            En tmp2 = EF.primero;
            while (tmp2 != null)
            {
                agregar.WriteLine("{rank=same");
                agregar.WriteLine("Y" + tmp2.id);
                Nodom actual = tmp2.acceso;
                while (actual != null)
                {
                    if (actual.sup != null)
                    {
                        if (actual.sup.sup != null && actual.sup.sup.vis != 0)
                        {
                            agregar.WriteLine('"' + "" + actual.sup.sup.col + "," + actual.sup.sup.fil + '"');
                        }

                    }
                    actual = actual.der;

                }
                agregar.WriteLine("};");
                tmp2 = tmp2.sig;
            }

            En tmp3 = EC.primero;
            while (tmp3 != null)
            {
                Nodom actual2 = tmp3.acceso;
                while (actual2 != null)
                {
                    if (actual2.abj != null)
                    {
                        if ((actual2.sup != null && actual2.abj.sup != null))
                        {
                            if ((actual2.sup.sup != null && actual2.abj.sup.sup != null) && (actual2.sup.sup.vis != 0 && actual2.abj.sup.sup.vis != 0))
                            {
                                agregar.WriteLine('"' + "" + actual2.sup.sup.col + "," + actual2.sup.sup.fil + '"' + "->" + '"' + "" + actual2.abj.sup.sup.col + "," + actual2.abj.sup.sup.fil + '"');
                                agregar.WriteLine('"' + "" + actual2.abj.sup.sup.col + "," + actual2.abj.sup.sup.fil + '"' + "->" + '"' + "" + actual2.sup.sup.col + "," + actual2.sup.sup.fil + '"');
                            }

                        }

                    }
                    actual2 = actual2.abj;
                }
                tmp3 = tmp3.sig;
            }

            En tmp4 = EC.primero;
            while (tmp4 != null)
            {
                if (tmp4.acceso.sup != null)
                {
                    if (tmp4.acceso.sup.sup != null && tmp4.acceso.sup.sup.vis != 0)
                    {
                        agregar.WriteLine("X" + tmp4.id + "->" + '"' + "" + tmp4.acceso.sup.sup.col + "," + tmp4.acceso.sup.sup.fil + '"');
                    }

                }
                tmp4 = tmp4.sig;
            }

            En tmp5 = EF.primero;
            while (tmp5 != null)
            {
                Nodom actual3 = tmp5.acceso;
                while (actual3 != null)
                {
                    if (actual3.der != null)
                    {
                        if ((actual3.sup != null && actual3.der.sup != null))
                        {
                            if ((actual3.sup.sup != null && actual3.der.sup.sup != null) && (actual3.sup.sup.vis != 0 && actual3.der.sup.sup.vis != 0))
                            {
                                agregar.WriteLine('"' + "" + actual3.sup.sup.col + "," + actual3.sup.sup.fil + '"' + "->" + '"' + "" + actual3.der.sup.sup.col + "," + actual3.der.sup.sup.fil + '"' + "[constraint=false]");
                                agregar.WriteLine('"' + "" + actual3.der.sup.sup.col + "," + actual3.der.sup.sup.fil + '"' + "->" + '"' + "" + actual3.sup.sup.col + "," + actual3.sup.sup.fil + '"' + "[constraint=false]");
                            }

                        }

                    }
                    actual3 = actual3.der;
                }
                tmp5 = tmp5.sig;
            }

            En tmp6 = EF.primero;
            while (tmp6 != null)
            {
                if (tmp6.acceso.sup != null)
                {
                    if (tmp6.acceso.sup.sup != null && tmp6.acceso.sup.sup.vis != 0)
                    {
                        agregar.WriteLine("Y" + tmp6.id + "->" + '"' + "" + tmp6.acceso.sup.col + "," + tmp6.acceso.sup.fil + '"');
                    }
                }
                tmp6 = tmp6.sig;
            }

            En tmp7 = EC.primero;
            if (tmp7 != null)
            {
                agregar.WriteLine("Matriz->" + "X" + EC.primero.id);
                while (tmp7.sig != null)
                {
                    agregar.WriteLine("X" + tmp7.id + "->" + "X" + tmp7.sig.id);
                    tmp7 = tmp7.sig;
                }
            }

            En tmp8 = EF.primero;
            if (tmp8 != null)
            {
                agregar.WriteLine("Matriz->" + "Y" + EF.primero.id + "[rankdir=UD]");
                while (tmp8.sig != null)
                {
                    agregar.WriteLine("Y" + tmp8.id + "->" + "Y" + tmp8.sig.id + "[rankdir=UD]");
                    tmp8 = tmp8.sig;
                }
            }

            agregar.WriteLine("}");
            agregar.Close();
        }
        public bool Buscar(int fil, int col)
        {
            int c = 0;
            En tmp = EF.primero;
            while (tmp != null)
            {
                Nodom actual = tmp.acceso;
                while (actual != null)
                {
                    if (actual.col == col && actual.fil == fil) { c++; }
                    actual = actual.der;
                }
                tmp = tmp.sig;
            }
            if (c > 0) { return true; }
            return false;
        }
        public void Eliminar(int fil, int col, int niv)
        {
            En tmp = EF.primero;
            while (tmp != null)
            {
                Nodom actual = tmp.acceso;
                while (actual != null)
                {
                    if (actual.col == col && actual.fil == fil)
                    {
                        if (niv == 0)
                        {
                            if (actual.inf != null)
                            {
                                actual.inf.fil = fil;
                                actual.inf.col = col;
                                actual.inf.niv = niv;
                                actual.inf.vis = 0;
                                actual.inf.jugador = "";
                                actual.inf.unidad = "";
                                actual.inf.movimiento = 0;
                                actual.inf.alcanse = 0;
                                actual.inf.dano = 0;
                                actual.inf.vida = 0;
                            }
                        }
                        if (niv == 1)
                        {
                            actual.fil = fil;
                            actual.col = col;
                            actual.niv = niv;
                            actual.vis = 0;
                            actual.jugador = "";
                            actual.unidad = "";
                            actual.movimiento = 0;
                            actual.alcanse = 0;
                            actual.dano = 0;
                            actual.vida = 0;
                        }
                        if (niv == 2)
                        {
                            if (actual.sup != null)
                            {
                                actual.sup.fil = fil;
                                actual.sup.col = col;
                                actual.sup.niv = niv;
                                actual.sup.vis = 0;
                                actual.sup.jugador = "";
                                actual.sup.unidad = "";
                                actual.sup.movimiento = 0;
                                actual.sup.alcanse = 0;
                                actual.sup.dano = 0;
                                actual.sup.vida = 0;
                            }
                        }
                        if (niv == 3)
                        {
                            if (actual.sup != null)
                            {
                                if (actual.sup.sup != null)
                                {
                                    actual.sup.sup.fil = fil;
                                    actual.sup.sup.col = col;
                                    actual.sup.sup.niv = niv;
                                    actual.sup.sup.vis = 0;
                                    actual.sup.sup.jugador = "";
                                    actual.sup.sup.unidad = "";
                                    actual.sup.sup.movimiento = 0;
                                    actual.sup.sup.alcanse = 0;
                                    actual.sup.sup.dano = 0;
                                    actual.sup.sup.vida = 0;
                                }
                            }
                        }
                    }
                    actual = actual.der;
                }
                tmp = tmp.sig;
            }
        }
    }
}