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
            public NodoArbol(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst, ArbolAVL avl)
            {
                this.Nickname = Nick;
                this.Contrasena = Pass;
                this.Correo = Mail;
                this.Conectado = Log;
                this.Izq = null;
                this.Der = null;
                if (lst == null) { this.Lista = new ListaDelArbol(); }
                else { this.Lista = lst; }
                if (avl == null) { this.AAvl = new ArbolAVL(); }
                else { this.AAvl = avl; }
            }
            public int Perdidas = 0;
            public int Ganadas = 0;
            public int Destruidas = 0;
            public int Desplegadas = 0;
            public int Sobrevivientes = 0;
            public int Contactos = 0;
            public String Nickname;
            public String Contrasena;
            public String Correo;
            public int Conectado;
            public NodoArbol Izq;
            public NodoArbol Der;
            public ListaDelArbol Lista;
            public ArbolAVL AAvl;
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
                    Actual.Desplegadas = Actual.Desplegadas + UnDesp;
                    Actual.Sobrevivientes = Actual.Sobrevivientes + UnS;
                    if (Gan == 0) { Actual.Perdidas++; }
                    Actual.Destruidas = Actual.Destruidas + UnE;
                    Actual.Lista.Insertar(UB, Op, UnDesp, UnS, UnE, Gan);
                    break;
                }
                if (String.Compare(UB, Actual.Nickname) > 0) { Actual = Actual.Der; }
                else if (String.Compare(UB, Actual.Nickname) < 0) { Actual = Actual.Izq; }
            }
        }
        public void InsertaEnAVL(String UB, String Op, String pass, String mail)
        {
            Actual = Raiz;
            while (Actual != null)
            {
                if (String.Compare(UB, Actual.Nickname) == 0)
                {
                    Actual.Contactos = Actual.Contactos + 1;
                    Actual.AAvl.Insertar(UB, Op, pass, mail);
                    break;
                }
                if (String.Compare(UB, Actual.Nickname) > 0) { Actual = Actual.Der; }
                else if (String.Compare(UB, Actual.Nickname) < 0) { Actual = Actual.Izq; }
            }
        }
        public void BorrarEnAVL(String UB, String Op)
        {
            Actual = Raiz;
            while (Actual != null)
            {
                if (String.Compare(UB, Actual.Nickname) == 0)
                {
                    Actual.Contactos = Actual.Contactos - 1;
                    Actual.AAvl.Borrar(Op);
                    break;
                }
                if (String.Compare(UB, Actual.Nickname) > 0) { Actual = Actual.Der; }
                else if (String.Compare(UB, Actual.Nickname) < 0) { Actual = Actual.Izq; }
            }
        }
        public void ModificarEnAVL(String UB, String Op, String pass, String mail)
        {
            Actual = Raiz;
            while (Actual != null)
            {
                if (String.Compare(UB, Actual.Nickname) == 0)
                {
                    Actual.AAvl.Modificar(Op, pass, mail);
                    break;
                }
                if (String.Compare(UB, Actual.Nickname) > 0) { Actual = Actual.Der; }
                else if (String.Compare(UB, Actual.Nickname) < 0) { Actual = Actual.Izq; }
            }
        }
        public void PintarElAVL(String UB)
        {
            Actual = Raiz;
            while (Actual != null)
            {
                if (String.Compare(UB, Actual.Nickname) == 0)
                {
                    Actual.AAvl.PrePintarArbolAVL(Actual.AAvl.Raiz, true);
                    Actual.AAvl.PintarArbolAVL(Actual.AAvl.Raiz, true);
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
                Insertar(Nick, Pass, Mail, Log, Actual.Lista, Actual.AAvl);
            }
        }
        public void Insertar(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst, ArbolAVL avl)
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
            if (padre == null) Raiz = new NodoArbol(Nick, Pass, Mail, Log, lst, avl);
            else if (String.Compare(Nick, padre.Nickname) < 0) { padre.Izq = new NodoArbol(Nick, Pass, Mail, Log, lst, avl); }
            else if (String.Compare(Nick, padre.Nickname) > 0) { padre.Der = new NodoArbol(Nick, Pass, Mail, Log, lst, avl); }

        }
        public void InsertarEspejo(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst, ArbolAVL avl)
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
            if (padre == null) Raiz = new NodoArbol(Nick, Pass, Mail, Log, lst, avl);
            else if (String.Compare(Nick, padre.Nickname) > 0) { padre.Izq = new NodoArbol(Nick, Pass, Mail, Log, lst, avl); }
            else if (String.Compare(Nick, padre.Nickname) < 0) { padre.Der = new NodoArbol(Nick, Pass, Mail, Log, lst, avl); }

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
            lstnatmp.OrdenarPorContactos();
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
        public bool Buscar(String Nick, String Pass)
        {
            Actual = Raiz;
            while (Actual != null)
            {
                if (Actual.Nickname == Nick)
                {
                    if (Actual.Contrasena == Pass)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }               
                }
                else
                {
                    if (String.Compare(Nick, Actual.Nickname) > 0) { Actual = Actual.Der; }
                    else if (String.Compare(Nick, Actual.Nickname) < 0) { Actual = Actual.Izq; }
                }
            }
            return false;
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
                ListaNodos.Insertar(nodo.Nickname, nodo.Contrasena, nodo.Correo, nodo.Conectado, nodo.Lista, nodo.Ganadas, nodo.Destruidas, nodo.Desplegadas, nodo.Perdidas, nodo.Sobrevivientes, nodo.Contactos);
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
            public NodoLA(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst, int Gan, int Des, int Desple, int Per, int Sobre, int contac)
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
                this.Desplegadas = Desple;
                this.Perdidas = Per;
                this.Sobrevivientes = Sobre;
                this.Contactos = contac;
            }
            public int Perdidas;
            public int Ganadas;
            public int Destruidas;
            public int Desplegadas;
            public int Sobrevivientes;
            public int Contactos;
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

        public void Insertar(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst, int Gan, int Des, int Desple, int Per, int Sobre, int contact)
        {
            NodoLA nuevo = new NodoLA(Nick, Pass, Mail, Log, lst, Gan, Des, Desple, Per, Sobre, contact);
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
                    aespejo.InsertarEspejo(tmp.Nickname, tmp.Contrasena, tmp.Correo, tmp.Conectado, tmp.Lista, null);
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
            int Desple;
            int Per;
            int Sobre;
            int contac;

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
                            Desple = tmp.Desplegadas;
                            Per = tmp.Perdidas;
                            Sobre = tmp.Sobrevivientes;
                            contac = tmp.Contactos;

                            tmp.Nickname = tmp.Sig.Nickname;
                            tmp.Contrasena = tmp.Sig.Contrasena;
                            tmp.Correo = tmp.Sig.Correo;
                            tmp.Conectado = tmp.Sig.Conectado;
                            tmp.Ganadas = tmp.Sig.Ganadas;
                            tmp.Destruidas = tmp.Sig.Destruidas;
                            tmp.Desplegadas = tmp.Sig.Desplegadas;
                            tmp.Perdidas = tmp.Sig.Perdidas;
                            tmp.Sobrevivientes = tmp.Sig.Sobrevivientes;
                            tmp.Contactos = tmp.Sig.Contactos;

                            tmp.Sig.Nickname = Nick;
                            tmp.Sig.Contrasena = Pass;
                            tmp.Sig.Correo = Mail;
                            tmp.Sig.Conectado = Log;
                            tmp.Sig.Ganadas = Gan;
                            tmp.Sig.Destruidas = Des;
                            tmp.Sig.Desplegadas = Desple;
                            tmp.Sig.Perdidas = Per;
                            tmp.Sig.Sobrevivientes = Sobre;
                            tmp.Sig.Contactos = contac;

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
            int conteo = 0;
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoLG.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();
            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoLG.dot");
            if (tmp != null)
            {
                while (tmp != ultimo)
                {
                    if (conteo < 10)
                    {
                        agregar.WriteLine(tmp.Nickname + "[label=" + '"' + tmp.Nickname + "\n Ganadas: " + tmp.Ganadas + "\n Correo: " + tmp.Correo + "\n Conectado: " + tmp.Conectado + "\n Destruidas: " +
                            tmp.Destruidas + "\n Perdidas: " + tmp.Perdidas + "\n Desplegadas: " + tmp.Desplegadas + "\n Sobrevivientes: " + tmp.Sobrevivientes + '"' + "]");                        
                    }
                    conteo++;
                    tmp = tmp.Sig;
                }
            }
            conteo = 0;
            agregar.Write("Top_Juegos_Ganados");
            tmp = primero;
            if (tmp != null)
            {
                while (tmp != ultimo)
                {
                    if (conteo < 10)
                    {
                        agregar.Write("->" + tmp.Nickname);
                    }
                    conteo++;
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
            int Desple;
            int Per;
            int Sobre;
            int contac;

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
                            Desple = tmp.Desplegadas;
                            Per = tmp.Perdidas;
                            Sobre = tmp.Sobrevivientes;
                            contac = tmp.Contactos;

                            tmp.Nickname = tmp.Sig.Nickname;
                            tmp.Contrasena = tmp.Sig.Contrasena;
                            tmp.Correo = tmp.Sig.Correo;
                            tmp.Conectado = tmp.Sig.Conectado;
                            tmp.Ganadas = tmp.Sig.Ganadas;
                            tmp.Destruidas = tmp.Sig.Destruidas;
                            tmp.Desplegadas = tmp.Sig.Desplegadas;
                            tmp.Perdidas = tmp.Sig.Perdidas;
                            tmp.Sobrevivientes = tmp.Sig.Sobrevivientes;
                            tmp.Contactos = tmp.Sig.Contactos;

                            tmp.Sig.Nickname = Nick;
                            tmp.Sig.Contrasena = Pass;
                            tmp.Sig.Correo = Mail;
                            tmp.Sig.Conectado = Log;
                            tmp.Sig.Ganadas = Gan;
                            tmp.Sig.Destruidas = Des;
                            tmp.Sig.Desplegadas = Desple;
                            tmp.Sig.Perdidas = Per;
                            tmp.Sig.Sobrevivientes = Sobre;
                            tmp.Sig.Contactos = contac;

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
            int conteo = 0;
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoLD.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();
            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoLD.dot");
            if (tmp != null)
            {
                while (tmp != ultimo)
                {
                    if (conteo < 10)
                    {
                        agregar.WriteLine(tmp.Nickname + "[label=" + '"' + tmp.Nickname + "\n Destruidas: " + tmp.Destruidas + "\n Correo: " + tmp.Correo + "\n Conectado: " + tmp.Conectado +
                            "\n Ganadas: " + tmp.Ganadas + "\n Perdidas: " + tmp.Perdidas + "\n Desplegadas: " + tmp.Desplegadas + "\n Sobrevivientes: " + tmp.Sobrevivientes + '"' + "]");
                    }
                    conteo++;
                    tmp = tmp.Sig;
                }
            }
            conteo = 0;
            agregar.Write("Top_Juegos_Piesas_Destruidas");
            tmp = primero;
            if (tmp != null)
            {
                while (tmp != ultimo)
                {
                    if (conteo < 10)
                    {
                        agregar.Write("->" + tmp.Nickname);
                    }
                    conteo++;
                    tmp = tmp.Sig;
                }
            }
            agregar.WriteLine("}");
            agregar.Close();
        }
        public void OrdenarPorContactos()
        {
            String Nick;
            String Pass;
            String Mail;
            int Log;
            ListaDelArbol lst;
            int Gan;
            int Des;
            int Desple;
            int Per;
            int Sobre;
            int contac;

            NodoLA tmp = primero.Sig;
            bool salir = false;
            int cambio = 1;

            if (primero != null)
            {
                while (salir == false)
                {
                    if (tmp.Sig != ultimo)
                    {
                        if (tmp.Contactos < tmp.Sig.Contactos)
                        {
                            Nick = tmp.Nickname;
                            Pass = tmp.Contrasena;
                            Mail = tmp.Correo;
                            Log = tmp.Conectado;
                            lst = tmp.Lista;
                            Gan = tmp.Ganadas;
                            Des = tmp.Destruidas;
                            Desple = tmp.Desplegadas;
                            Per = tmp.Perdidas;
                            Sobre = tmp.Sobrevivientes;
                            contac = tmp.Contactos;

                            tmp.Nickname = tmp.Sig.Nickname;
                            tmp.Contrasena = tmp.Sig.Contrasena;
                            tmp.Correo = tmp.Sig.Correo;
                            tmp.Conectado = tmp.Sig.Conectado;
                            tmp.Ganadas = tmp.Sig.Ganadas;
                            tmp.Destruidas = tmp.Sig.Destruidas;
                            tmp.Desplegadas = tmp.Sig.Desplegadas;
                            tmp.Perdidas = tmp.Sig.Perdidas;
                            tmp.Sobrevivientes = tmp.Sig.Sobrevivientes;
                            tmp.Contactos = tmp.Sig.Contactos;

                            tmp.Sig.Nickname = Nick;
                            tmp.Sig.Contrasena = Pass;
                            tmp.Sig.Correo = Mail;
                            tmp.Sig.Conectado = Log;
                            tmp.Sig.Ganadas = Gan;
                            tmp.Sig.Destruidas = Des;
                            tmp.Sig.Desplegadas = Desple;
                            tmp.Sig.Perdidas = Per;
                            tmp.Sig.Sobrevivientes = Sobre;
                            tmp.Sig.Contactos = contac;

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
            int conteo = 0;
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoLCON.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();
            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoLCON.dot");
            if (tmp != null)
            {
                while (tmp != ultimo)
                {
                    if (conteo < 10)
                    {
                        agregar.WriteLine(tmp.Nickname + "[label=" + '"' + tmp.Nickname + "\n Contactos: " + tmp.Contactos + "\n Ganadas: " + tmp.Ganadas + "\n Correo: " + tmp.Correo + "\n Conectado: " + tmp.Conectado + "\n Destruidas: " +
                            tmp.Destruidas + "\n Perdidas: " + tmp.Perdidas + "\n Desplegadas: " + tmp.Desplegadas + "\n Sobrevivientes: " + tmp.Sobrevivientes + '"' + "]");
                    }
                    conteo++;
                    tmp = tmp.Sig;
                }
            }
            conteo = 0;
            agregar.Write("Top_Contactos");
            tmp = primero;
            if (tmp != null)
            {
                while (tmp != ultimo)
                {
                    if (conteo < 10)
                    {
                        agregar.Write("->" + tmp.Nickname);
                    }
                    conteo++;
                    tmp = tmp.Sig;
                }
            }
            agregar.WriteLine("}");
            agregar.Close();
        }
    }

    public class ListaJugadas
    {
        public class NodoLJ
        {
            public NodoLJ(String J1, String J2, int NJ, int AJ1, int AJ2, int EJ1, int EJ2)
            {
                this.Jugador1 = J1;
                this.Jugador2 = J2;
                this.NumeroJuego = NJ;
                this.AtaquesJ1 = AJ1;
                this.AtaquesJ2 = AJ2;
                this.EliminadasJ1 = EJ1;
                this.EliminadasJ2 = EJ2;
                this.TotAtaques = AJ1 + AJ2;
                this.TotElimina = EJ1 + EJ2;
                this.Ant = null;
                this.Sig = null;
            }
            public int NumeroJuego;
            public int AtaquesJ1;
            public int AtaquesJ2;
            public int EliminadasJ1;
            public int EliminadasJ2;
            public String Jugador1;
            public String Jugador2;
            public int TotAtaques;
            public int TotElimina;
            public NodoLJ Sig;
            public NodoLJ Ant;
        }

        public NodoLJ primero;
        public NodoLJ ultimo;

        public void Insertar(String J1, String J2, int NJ, int AJ1, int AJ2, int EJ1, int EJ2)
        {
            NodoLJ nuevo = new NodoLJ(J1, J2, NJ, AJ1, AJ2, EJ1, EJ2);
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
        public void OrdenarAtaques()
        {
            String J1;
            String J2;
            int NJ;
            int AJ1;
            int AJ2;
            int EJ1;
            int EJ2;

            NodoLJ tmp = primero.Sig;
            bool salir = false;
            int cambio = 1;

            if (primero != null)
            {
                while (salir == false)
                {
                    if (tmp.Sig != ultimo)
                    {
                        if (tmp.TotAtaques < tmp.Sig.TotAtaques)
                        {
                            J1 = tmp.Jugador1;
                            J2 = tmp.Jugador2;
                            NJ = tmp.NumeroJuego;
                            AJ1 = tmp.AtaquesJ1;
                            AJ2 = tmp.AtaquesJ2;
                            EJ1 = tmp.EliminadasJ1;
                            EJ2 = tmp.EliminadasJ2;

                            tmp.Jugador1 = tmp.Sig.Jugador1;
                            tmp.Jugador2 = tmp.Sig.Jugador2;
                            tmp.NumeroJuego = tmp.Sig.NumeroJuego;
                            tmp.AtaquesJ1 = tmp.Sig.AtaquesJ1;
                            tmp.AtaquesJ2 = tmp.Sig.AtaquesJ2;
                            tmp.EliminadasJ1 = tmp.Sig.EliminadasJ1;
                            tmp.EliminadasJ2 = tmp.Sig.EliminadasJ2;

                            tmp.Sig.Jugador1 = J1;
                            tmp.Sig.Jugador2 = J2;
                            tmp.Sig.NumeroJuego = NJ;
                            tmp.Sig.AtaquesJ1 = AJ1;
                            tmp.Sig.AtaquesJ2 = AJ2;
                            tmp.Sig.EliminadasJ1 = EJ1;
                            tmp.Sig.EliminadasJ2 = EJ2;

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
                Console.WriteLine("LA LISTA DE ATAQUES NO CONTIENE ELEMENTOS EN GANADAS");
            }
            tmp = primero;
            int conteo = 0;
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoLAT.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();
            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoLAT.dot");
            if (tmp != null)
            {
                do
                {
                    if (conteo < 10)
                    {
                        agregar.WriteLine(tmp.NumeroJuego + "[label=" + '"' + "Total de ataques: " + (tmp.AtaquesJ1 + tmp.AtaquesJ2) + "\n Jugador1: " + tmp.Jugador1 +
                            "\n Ataques Jugador1: " + tmp.AtaquesJ1 + "\n Eliminadas Jugador1: " + tmp.EliminadasJ1 + "\n Jugador2: " + tmp.Jugador2 +
                            "\n Ataques Jugador2: " + tmp.AtaquesJ2 + "\n Eliminadas Jugador2: " + tmp.EliminadasJ2 + '"' + "]");
                    }
                    conteo++;
                    tmp = tmp.Sig;
                } while (tmp != primero);
            }
            conteo = 0;
            agregar.Write("Top_Juegos_com_menos_Ataques");
            tmp = primero;
            if (tmp != null)
            {
                do
                {
                    if (conteo < 10)
                    {
                        agregar.Write("->" + tmp.NumeroJuego);
                    }
                    conteo++;
                    tmp = tmp.Sig;
                } while (tmp != primero);
            }
            agregar.WriteLine("}");
            agregar.Close();
        }
        public void OrdenarAtaques2()
        {
            String J1;
            String J2;
            int NJ;
            int AJ1;
            int AJ2;
            int EJ1;
            int EJ2;

            NodoLJ tmp = primero.Sig;
            bool salir = false;
            int cambio = 1;

            if (primero != null)
            {
                while (salir == false)
                {
                    if (tmp.Sig != ultimo)
                    {
                        if (tmp.TotAtaques < tmp.Sig.TotAtaques)
                        {
                            J1 = tmp.Jugador1;
                            J2 = tmp.Jugador2;
                            NJ = tmp.NumeroJuego;
                            AJ1 = tmp.AtaquesJ1;
                            AJ2 = tmp.AtaquesJ2;
                            EJ1 = tmp.EliminadasJ1;
                            EJ2 = tmp.EliminadasJ2;

                            tmp.Jugador1 = tmp.Sig.Jugador1;
                            tmp.Jugador2 = tmp.Sig.Jugador2;
                            tmp.NumeroJuego = tmp.Sig.NumeroJuego;
                            tmp.AtaquesJ1 = tmp.Sig.AtaquesJ1;
                            tmp.AtaquesJ2 = tmp.Sig.AtaquesJ2;
                            tmp.EliminadasJ1 = tmp.Sig.EliminadasJ1;
                            tmp.EliminadasJ2 = tmp.Sig.EliminadasJ2;

                            tmp.Sig.Jugador1 = J1;
                            tmp.Sig.Jugador2 = J2;
                            tmp.Sig.NumeroJuego = NJ;
                            tmp.Sig.AtaquesJ1 = AJ1;
                            tmp.Sig.AtaquesJ2 = AJ2;
                            tmp.Sig.EliminadasJ1 = EJ1;
                            tmp.Sig.EliminadasJ2 = EJ2;

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
                Console.WriteLine("LA LISTA DE ATAQUES NO CONTIENE ELEMENTOS EN GANADAS");
            }
            tmp = ultimo;
            int conteo = 0;
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoLAT2.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();
            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoLAT2.dot");
            if (tmp != null)
            {
                do
                {
                    if (conteo < 10)
                    {
                        agregar.WriteLine(tmp.NumeroJuego + "[label=" + '"' + "Total de ataques: " + (tmp.AtaquesJ1 + tmp.AtaquesJ2) + "\n Jugador1: " + tmp.Jugador1 +
                            "\n Ataques Jugador1: " + tmp.AtaquesJ1 + "\n Eliminadas Jugador1: " + tmp.EliminadasJ1 + "\n Jugador2: " + tmp.Jugador2 +
                            "\n Ataques Jugador2: " + tmp.AtaquesJ2 + "\n Eliminadas Jugador2: " + tmp.EliminadasJ2 + '"' + "]");
                    }
                    conteo++;
                    tmp = tmp.Ant;
                } while (tmp != ultimo);
            }
            conteo = 0;
            agregar.Write("Top_Juegos_com_mas_Ataques");
            tmp = ultimo;
            if (tmp != null)
            {
                do
                {
                    if (conteo < 10)
                    {
                        agregar.Write("->" + tmp.NumeroJuego);
                    }
                    conteo++;
                    tmp = tmp.Ant;
                } while (tmp != ultimo);
            }
            agregar.WriteLine("}");
            agregar.Close();
        }
        public void OrdenarEliminadas()
        {
            String J1;
            String J2;
            int NJ;
            int AJ1;
            int AJ2;
            int EJ1;
            int EJ2;

            NodoLJ tmp = primero.Sig;
            bool salir = false;
            int cambio = 1;

            if (primero != null)
            {
                while (salir == false)
                {
                    if (tmp.Sig != ultimo)
                    {
                        if (tmp.TotElimina < tmp.Sig.TotElimina)
                        {
                            J1 = tmp.Jugador1;
                            J2 = tmp.Jugador2;
                            NJ = tmp.NumeroJuego;
                            AJ1 = tmp.AtaquesJ1;
                            AJ2 = tmp.AtaquesJ2;
                            EJ1 = tmp.EliminadasJ1;
                            EJ2 = tmp.EliminadasJ2;

                            tmp.Jugador1 = tmp.Sig.Jugador1;
                            tmp.Jugador2 = tmp.Sig.Jugador2;
                            tmp.NumeroJuego = tmp.Sig.NumeroJuego;
                            tmp.AtaquesJ1 = tmp.Sig.AtaquesJ1;
                            tmp.AtaquesJ2 = tmp.Sig.AtaquesJ2;
                            tmp.EliminadasJ1 = tmp.Sig.EliminadasJ1;
                            tmp.EliminadasJ2 = tmp.Sig.EliminadasJ2;

                            tmp.Sig.Jugador1 = J1;
                            tmp.Sig.Jugador2 = J2;
                            tmp.Sig.NumeroJuego = NJ;
                            tmp.Sig.AtaquesJ1 = AJ1;
                            tmp.Sig.AtaquesJ2 = AJ2;
                            tmp.Sig.EliminadasJ1 = EJ1;
                            tmp.Sig.EliminadasJ2 = EJ2;

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
                Console.WriteLine("LA LISTA DE ATAQUES NO CONTIENE ELEMENTOS EN GANADAS");
            }
            tmp = primero;
            int conteo = 0;
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoLEL.dot");
            crear.WriteLine("digraph grafo{");
            crear.Close();
            StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoLEL.dot");
            if (tmp != null)
            {
                do
                {
                    if (conteo < 10)
                    {
                        agregar.WriteLine(tmp.NumeroJuego + "[label=" + '"' + "Total de Eliminadas: " + (tmp.EliminadasJ1 + tmp.EliminadasJ2) + "\n Jugador1: " + tmp.Jugador1 +
                            "\n Ataques Jugador1: " + tmp.AtaquesJ1 + "\n Eliminadas Jugador1: " + tmp.EliminadasJ1 + "\n Jugador2: " + tmp.Jugador2 +
                            "\n Ataques Jugador2: " + tmp.AtaquesJ2 + "\n Eliminadas Jugador2: " + tmp.EliminadasJ2 + '"' + "]");
                    }
                    conteo++;
                    tmp = tmp.Sig;
                } while (tmp != primero);
            }
            conteo = 0;
            agregar.Write("Top_Juegos_com_mas_Eliminadas");
            tmp = primero;
            if (tmp != null)
            {
                do
                {
                    if (conteo < 10)
                    {
                        agregar.Write("->" + tmp.NumeroJuego);
                    }
                    conteo++;
                    tmp = tmp.Sig;
                } while (tmp != primero);
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
        public String Ataque(int ncol, int nfil, int niv, int dano, String jemi, String presep)
        {
            En tmp = EF.primero;
            while (tmp != null)
            {
                Nodom actual = tmp.acceso;
                while (actual != null)
                {
                    if (actual.col == ncol && actual.fil == nfil)
                    {
                        if (niv == 0)
                        { 
                            //Alcance 0
                            if (actual != null)
                            {
                                if (actual.vis != 0 && actual.unidad.Equals(presep) == true && actual.jugador.Equals(jemi) == false)
                                {
                                    actual.vida = actual.vida - dano;
                                    if (actual.vida <= 0)
                                    {                                        
                                        actual.vis = 0;
                                        return "0";
                                    }
                                    else { return actual.vida.ToString(); }
                                }                                                       
                            }
                            if (actual.sup != null)
                            {
                                if (actual.sup.vis != 0 && actual.sup.unidad.Equals(presep) == true && actual.sup.jugador.Equals(jemi) == false)
                                {
                                    actual.sup.vida = actual.sup.vida - dano;
                                    if (actual.sup.vida <= 0)
                                    {
                                        actual.sup.vis = 0;
                                        return "0";
                                    }
                                    else { return actual.sup.vida.ToString(); }
                                }                               
                            }
                            if (actual.sup != null)
                            {
                                if (actual.sup.sup != null)
                                {
                                    if (actual.sup.sup.vis != 0 && actual.sup.sup.unidad.Equals(presep) == true && actual.sup.sup.jugador.Equals(jemi) == false)
                                    {
                                        actual.sup.sup.vida = actual.sup.sup.vida - dano;
                                        if (actual.sup.sup.vida <= 0)
                                        {
                                            actual.sup.sup.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.sup.sup.vida.ToString(); }
                                    }                                    
                                }
                            }
                            //Alcance 1
                            if (actual.arr != null)//Arriba
                            {
                                if (actual.arr.unidad.Equals(presep) == true && actual.arr.jugador.Equals(jemi) == false && actual.arr.fil == (nfil - 1) && actual.arr.vis != 0)
                                {
                                    actual.arr.vida = actual.arr.vida - dano;
                                    if (actual.arr.vida <= 0)
                                    {
                                        actual.arr.vis = 0;
                                        return "0";
                                    } else { return actual.arr.vida.ToString(); }
                                }
                                if (actual.arr.sup != null)
                                {
                                    if (actual.arr.sup.unidad.Equals(presep) == true && actual.arr.sup.jugador.Equals(jemi) == false && actual.arr.sup.fil == (nfil - 1) && actual.arr.sup.vis != 0)
                                    {
                                        actual.arr.sup.vida = actual.arr.sup.vida - dano;
                                        if (actual.arr.sup.vida <= 0)
                                        {
                                            actual.arr.sup.vis = 0;
                                            return "0";
                                        } else { return actual.arr.sup.vida.ToString(); }
                                    }
                                }
                                if (actual.arr.sup != null)
                                {
                                    if (actual.arr.sup.sup != null)
                                    {
                                        if (actual.arr.sup.sup.unidad.Equals(presep) == true && actual.arr.sup.sup.jugador.Equals(jemi) == false && actual.arr.sup.sup.fil == (nfil - 1) && actual.arr.sup.sup.vis != 0)
                                        {
                                            actual.arr.sup.sup.vida = actual.arr.sup.sup.vida - dano;
                                            if (actual.arr.sup.sup.vida <= 0)
                                            {
                                                actual.arr.sup.sup.vis = 0;
                                                return "0";
                                            } else { return actual.arr.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.abj != null)//Abajo
                            {
                                if (actual.abj.unidad.Equals(presep) == true && actual.abj.jugador.Equals(jemi) == false && actual.abj.fil == (nfil + 1) && actual.abj.vis != 0)
                                {
                                    actual.abj.vida = actual.abj.vida - dano;
                                    if (actual.abj.vida <= 0)
                                    {
                                        actual.abj.vis = 0;
                                        return "0";
                                    } else { return actual.abj.vida.ToString(); }
                                }
                                if (actual.abj.sup != null)
                                {
                                    if (actual.abj.sup.unidad.Equals(presep) == true && actual.abj.sup.jugador.Equals(jemi) == false && actual.abj.sup.fil == (nfil + 1) && actual.abj.sup.vis != 0)
                                    {
                                        actual.abj.sup.vida = actual.abj.sup.vida - dano;
                                        if (actual.abj.sup.vida <= 0)
                                        {
                                            actual.abj.sup.vis = 0;
                                            return "0";
                                        } else { return actual.abj.sup.vida.ToString(); }
                                    }
                                }
                                if (actual.abj.sup != null)
                                {
                                    if (actual.abj.sup.sup != null)
                                    {
                                        if (actual.abj.sup.sup.unidad.Equals(presep) == true && actual.abj.sup.sup.jugador.Equals(jemi) == false && actual.abj.sup.sup.fil == (nfil + 1) && actual.abj.sup.sup.vis != 0)
                                        {
                                            actual.abj.sup.sup.vida = actual.abj.sup.sup.vida - dano;
                                            if (actual.abj.sup.sup.vida <= 0)
                                            {
                                                actual.abj.sup.sup.vis = 0;
                                                return "0";
                                            } else { return actual.abj.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.izq != null)//Izquierda
                            {
                                if (actual.izq.unidad.Equals(presep) == true && actual.izq.jugador.Equals(jemi) == false && actual.izq.col == (ncol - 1) && actual.izq.vis != 0)
                                {
                                    actual.izq.vida = actual.izq.vida - dano;
                                    if (actual.izq.vida <= 0)
                                    {
                                        actual.izq.vis = 0;
                                        return "0";
                                    } else { return actual.izq.vida.ToString(); }
                                }
                                if (actual.izq.sup != null)
                                {
                                    if (actual.izq.sup.unidad.Equals(presep) == true && actual.izq.sup.jugador.Equals(jemi) == false && actual.izq.sup.col == (ncol - 1) && actual.izq.sup.vis != 0)
                                    {
                                        actual.izq.sup.vida = actual.izq.sup.vida - dano;
                                        if (actual.izq.sup.vida <= 0)
                                        {
                                            actual.izq.sup.vis = 0;
                                            return "0";
                                        } else { return actual.izq.sup.vida.ToString(); }
                                    }
                                }
                                if (actual.izq.sup != null)
                                {
                                    if (actual.izq.sup.sup != null)
                                    {
                                        if (actual.izq.sup.sup.unidad.Equals(presep) == true && actual.izq.sup.sup.jugador.Equals(jemi) == false && actual.izq.sup.sup.col == (ncol - 1) && actual.izq.sup.sup.vis != 0)
                                        {
                                            actual.izq.sup.sup.vida = actual.izq.sup.sup.vida - dano;
                                            if (actual.izq.sup.sup.vida <= 0)
                                            {
                                                actual.izq.sup.sup.vis = 0;
                                                return "0";
                                            } else { return actual.izq.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.der != null)//Derecha
                            {
                                if (actual.der.unidad.Equals(presep) == true && actual.der.jugador.Equals(jemi) == false && actual.der.col == (ncol + 1) && actual.der.vis != 0)
                                {
                                    actual.der.vida = actual.der.vida - dano;
                                    if (actual.der.vida <= 0)
                                    {
                                        actual.der.vis = 0;
                                        return "0";
                                    } else { return actual.der.vida.ToString(); }
                                }
                                if (actual.der.sup != null)
                                {
                                    if (actual.der.sup.unidad.Equals(presep) == true && actual.der.sup.jugador.Equals(jemi) == false && actual.der.sup.col == (ncol + 1) && actual.der.sup.vis != 0)
                                    {
                                        actual.der.sup.vida = actual.der.sup.vida - dano;
                                        if (actual.der.sup.vida <= 0)
                                        {
                                            actual.der.sup.vis = 0;
                                            return "0";
                                        } else { return actual.der.sup.vida.ToString(); }
                                    }
                                }
                                if (actual.der.sup != null)
                                {
                                    if (actual.der.sup.sup != null)
                                    {
                                        if (actual.der.sup.sup.unidad.Equals(presep) == true && actual.der.sup.sup.jugador.Equals(jemi) == false && actual.der.sup.sup.col == (ncol + 1) && actual.der.sup.sup.vis != 0)
                                        {
                                            actual.der.sup.sup.vida = actual.der.sup.sup.vida - dano;
                                            if (actual.der.sup.sup.vida <= 0)
                                            {
                                                actual.der.sup.sup.vis = 0;
                                                return "0";
                                            } else { return actual.der.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                        }
                        if (niv == 1)
                        {
                            //Alcance 0
                            if (actual.inf != null)
                            {
                                if(actual.inf.vis != 0 && actual.inf.unidad.Equals(presep) == true && actual.inf.jugador.Equals(jemi) == false)
                                {
                                    actual.inf.vida = actual.inf.vida - dano;
                                    if (actual.inf.vida <= 0)
                                    {
                                        actual.inf.vis = 0;
                                        return "0";
                                    }
                                    else { return actual.inf.vida.ToString(); }
                                }                                
                            }
                            if (actual.sup != null)
                            {
                                if (actual.sup.vis != 0 && actual.sup.unidad.Equals(presep) == true && actual.sup.jugador.Equals(jemi) == false)
                                {
                                    actual.sup.vida = actual.sup.vida - dano;
                                    if (actual.sup.vida <= 0)
                                    {
                                        actual.sup.vis = 0;
                                        return "0";
                                    }
                                    else { return actual.sup.vida.ToString(); }
                                }                                
                            }
                            if (actual.sup != null)
                            {
                                if (actual.sup.sup != null)
                                {
                                    if (actual.sup.sup.vis != 0 && actual.sup.sup.unidad.Equals(presep) == true && actual.sup.sup.jugador.Equals(jemi) == false)
                                    {
                                        actual.sup.sup.vida = actual.sup.sup.vida - dano;
                                        if (actual.sup.sup.vida <= 0)
                                        {
                                            actual.sup.sup.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.sup.sup.vida.ToString(); }
                                    }                                    
                                }
                            }
                            //Alcance 1
                            if (actual.arr != null)//Arriba
                            {
                                if (actual.arr.inf != null)
                                {
                                    if (actual.arr.inf.unidad.Equals(presep) == true && actual.arr.inf.jugador.Equals(jemi) == false && actual.arr.inf.fil == (nfil - 1) && actual.arr.inf.vis != 0)
                                    {
                                        actual.arr.inf.vida = actual.arr.inf.vida - dano;
                                        if (actual.arr.inf.vida <= 0)
                                        {
                                            actual.arr.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.arr.inf.vida.ToString(); }
                                    }
                                }                               
                                if (actual.arr.sup != null)
                                {
                                    if (actual.arr.sup.unidad.Equals(presep) == true && actual.arr.sup.jugador.Equals(jemi) == false && actual.arr.sup.fil == (nfil - 1) && actual.arr.sup.vis != 0)
                                    {
                                        actual.arr.sup.vida = actual.arr.sup.vida - dano;
                                        if (actual.arr.sup.vida <= 0)
                                        {
                                            actual.arr.sup.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.arr.sup.vida.ToString(); }
                                    }
                                }
                                if (actual.arr.sup != null)
                                {
                                    if (actual.arr.sup.sup != null)
                                    {
                                        if (actual.arr.sup.sup.unidad.Equals(presep) == true && actual.arr.sup.sup.jugador.Equals(jemi) == false && actual.arr.sup.sup.fil == (nfil - 1) && actual.arr.sup.sup.vis != 0)
                                        {
                                            actual.arr.sup.sup.vida = actual.arr.sup.sup.vida - dano;
                                            if (actual.arr.sup.sup.vida <= 0)
                                            {
                                                actual.arr.sup.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.arr.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.abj != null)//Abajo
                            {
                                if (actual.abj.inf != null)
                                {
                                    if (actual.abj.inf.unidad.Equals(presep) == true && actual.abj.inf.jugador.Equals(jemi) == false && actual.abj.inf.fil == (nfil + 1) && actual.abj.inf.vis != 0)
                                    {
                                        actual.abj.inf.vida = actual.abj.inf.vida - dano;
                                        if (actual.abj.inf.vida <= 0)
                                        {
                                            actual.abj.inf.vis = 0;
                                            return "0";
                                        } else { return actual.abj.inf.vida.ToString(); }
                                    }
                                }                               
                                if (actual.abj.sup != null)
                                {
                                    if (actual.abj.sup.unidad.Equals(presep) == true && actual.abj.sup.jugador.Equals(jemi) == false && actual.abj.sup.fil == (nfil + 1) && actual.abj.sup.vis != 0)
                                    {
                                        actual.abj.sup.vida = actual.abj.sup.vida - dano;
                                        if (actual.abj.sup.vida <= 0)
                                        {
                                            actual.abj.sup.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.abj.sup.vida.ToString(); }
                                    }
                                }
                                if (actual.abj.sup != null)
                                {
                                    if (actual.abj.sup.sup != null)
                                    {
                                        if (actual.abj.sup.sup.unidad.Equals(presep) == true && actual.abj.sup.sup.jugador.Equals(jemi) == false && actual.abj.sup.sup.fil == (nfil + 1) && actual.abj.sup.sup.vis != 0)
                                        {
                                            actual.abj.sup.sup.vida = actual.abj.sup.sup.vida - dano;
                                            if (actual.abj.sup.sup.vida <= 0)
                                            {
                                                actual.abj.sup.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.abj.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.izq != null)//Izquierda
                            {
                                if (actual.izq.inf != null)
                                {
                                    if (actual.izq.inf.unidad.Equals(presep) == true && actual.izq.inf.jugador.Equals(jemi) == false && actual.izq.inf.col == (ncol - 1) && actual.izq.inf.vis != 0)
                                    {
                                        actual.izq.inf.vida = actual.izq.inf.vida - dano;
                                        if (actual.izq.inf.vida <= 0)
                                        {
                                            actual.izq.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.izq.inf.vida.ToString(); }
                                    }
                                }                                
                                if (actual.izq.sup != null)
                                {
                                    if (actual.izq.sup.unidad.Equals(presep) == true && actual.izq.sup.jugador.Equals(jemi) == false && actual.izq.sup.col == (ncol - 1) && actual.izq.sup.vis != 0)
                                    {
                                        actual.izq.sup.vida = actual.izq.sup.vida - dano;
                                        if (actual.izq.sup.vida <= 0)
                                        {
                                            actual.izq.sup.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.izq.sup.vida.ToString(); }
                                    }
                                }
                                if (actual.izq.sup != null)
                                {
                                    if (actual.izq.sup.sup != null)
                                    {
                                        if (actual.izq.sup.sup.unidad.Equals(presep) == true && actual.izq.sup.sup.jugador.Equals(jemi) == false && actual.izq.sup.sup.col == (ncol - 1) && actual.izq.sup.sup.vis != 0)
                                        {
                                            actual.izq.sup.sup.vida = actual.izq.sup.sup.vida - dano;
                                            if (actual.izq.sup.sup.vida <= 0)
                                            {
                                                actual.izq.sup.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.izq.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.der != null)//Derecha
                            {
                                if (actual.der.inf != null)
                                {
                                    if (actual.der.inf.unidad.Equals(presep) == true && actual.der.inf.jugador.Equals(jemi) == false && actual.der.inf.col == (ncol + 1) && actual.der.inf.vis != 0)
                                    {
                                        actual.der.inf.vida = actual.der.inf.vida - dano;
                                        if (actual.der.inf.vida <= 0)
                                        {
                                            actual.der.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.der.inf.vida.ToString(); }
                                    }
                                }                                
                                if (actual.der.sup != null)
                                {
                                    if (actual.der.sup.unidad.Equals(presep) == true && actual.der.sup.jugador.Equals(jemi) == false && actual.der.sup.col == (ncol + 1) && actual.der.sup.vis != 0)
                                    {
                                        actual.der.sup.vida = actual.der.sup.vida - dano;
                                        if (actual.der.sup.vida <= 0)
                                        {
                                            actual.der.sup.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.der.sup.vida.ToString(); }
                                    }
                                }
                                if (actual.der.sup != null)
                                {
                                    if (actual.der.sup.sup != null)
                                    {
                                        if (actual.der.sup.sup.unidad.Equals(presep) == true && actual.der.sup.sup.jugador.Equals(jemi) == false && actual.der.sup.sup.col == (ncol + 1) && actual.der.sup.sup.vis != 0)
                                        {
                                            actual.der.sup.sup.vida = actual.der.sup.sup.vida - dano;
                                            if (actual.der.sup.sup.vida <= 0)
                                            {
                                                actual.der.sup.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.der.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                        }
                        if (niv == 2)
                        {
                            //Alcance 0
                            if (actual.inf != null)
                            {
                                if (actual.inf.vis != 0 && actual.inf.unidad.Equals(presep) == true && actual.inf.jugador.Equals(jemi) == false)
                                {
                                    actual.inf.vida = actual.inf.vida - dano;
                                    if (actual.inf.vida <= 0)
                                    {
                                        actual.inf.vis = 0;
                                        return "0";
                                    }
                                    else { return actual.inf.vida.ToString(); }
                                }
                            }
                            if (actual != null)
                            {
                                if (actual.vis != 0 && actual.unidad.Equals(presep) == true && actual.jugador.Equals(jemi) == false)
                                {
                                    actual.vida = actual.vida - dano;
                                    if (actual.vida <= 0)
                                    {
                                        actual.vis = 0;
                                        return "0";
                                    }
                                    else { return actual.vida.ToString(); }
                                }
                            }
                            if (actual.sup != null)
                            {
                                if (actual.sup.sup != null)
                                {
                                    if (actual.sup.sup.vis != 0 && actual.sup.sup.unidad.Equals(presep) == true && actual.sup.sup.jugador.Equals(jemi) == false)
                                    {
                                        actual.sup.sup.vida = actual.sup.sup.vida - dano;
                                        if (actual.sup.sup.vida <= 0)
                                        {
                                            actual.sup.sup.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.sup.sup.vida.ToString(); }
                                    }
                                }
                            }
                            //Alcance 1
                            if (actual.arr != null)//Arriba
                            {
                                if (actual.arr.inf != null)
                                {
                                    if (actual.arr.inf.unidad.Equals(presep) == true && actual.arr.inf.jugador.Equals(jemi) == false && actual.arr.inf.fil == (nfil - 1) && actual.arr.inf.vis != 0)
                                    {
                                        actual.arr.inf.vida = actual.arr.inf.vida - dano;
                                        if (actual.arr.inf.vida <= 0)
                                        {
                                            actual.arr.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.arr.inf.vida.ToString(); }
                                    }
                                }
                                if (actual.arr != null)
                                {
                                    if (actual.arr.unidad.Equals(presep) == true && actual.arr.jugador.Equals(jemi) == false && actual.arr.fil == (nfil - 1) && actual.arr.vis != 0)
                                    {
                                        actual.arr.vida = actual.arr.vida - dano;
                                        if (actual.arr.vida <= 0)
                                        {
                                            actual.arr.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.arr.vida.ToString(); }
                                    }
                                }
                                if (actual.arr.sup != null)
                                {
                                    if (actual.arr.sup.sup != null)
                                    {
                                        if (actual.arr.sup.sup.unidad.Equals(presep) == true && actual.arr.sup.sup.jugador.Equals(jemi) == false && actual.arr.sup.sup.fil == (nfil - 1) && actual.arr.sup.sup.vis != 0)
                                        {
                                            actual.arr.sup.sup.vida = actual.arr.sup.sup.vida - dano;
                                            if (actual.arr.sup.sup.vida <= 0)
                                            {
                                                actual.arr.sup.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.arr.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.abj != null)//Abajo
                            {
                                if (actual.abj.inf != null)
                                {
                                    if (actual.abj.inf.unidad.Equals(presep) == true && actual.abj.inf.jugador.Equals(jemi) == false && actual.abj.inf.fil == (nfil + 1) && actual.abj.inf.vis != 0)
                                    {
                                        actual.abj.inf.vida = actual.abj.inf.vida - dano;
                                        if (actual.abj.inf.vida <= 0)
                                        {
                                            actual.abj.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.abj.inf.vida.ToString(); }
                                    }
                                }
                                if (actual.abj != null)
                                {
                                    if (actual.abj.unidad.Equals(presep) == true && actual.abj.jugador.Equals(jemi) == false && actual.abj.fil == (nfil + 1) && actual.abj.vis != 0)
                                    {
                                        actual.abj.vida = actual.abj.vida - dano;
                                        if (actual.abj.vida <= 0)
                                        {
                                            actual.abj.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.abj.vida.ToString(); }
                                    }
                                }
                                if (actual.abj.sup != null)
                                {
                                    if (actual.abj.sup.sup != null)
                                    {
                                        if (actual.abj.sup.sup.unidad.Equals(presep) == true && actual.abj.sup.sup.jugador.Equals(jemi) == false && actual.abj.sup.sup.fil == (nfil + 1) && actual.abj.sup.sup.vis != 0)
                                        {
                                            actual.abj.sup.sup.vida = actual.abj.sup.sup.vida - dano;
                                            if (actual.abj.sup.sup.vida <= 0)
                                            {
                                                actual.abj.sup.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.abj.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.izq != null)//Izquierda
                            {
                                if (actual.izq.inf != null)
                                {
                                    if (actual.izq.inf.unidad.Equals(presep) == true && actual.izq.inf.jugador.Equals(jemi) == false && actual.izq.inf.col == (ncol - 1) && actual.izq.inf.vis != 0)
                                    {
                                        actual.izq.inf.vida = actual.izq.inf.vida - dano;
                                        if (actual.izq.inf.vida <= 0)
                                        {
                                            actual.izq.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.izq.inf.vida.ToString(); }
                                    }
                                }
                                if (actual.izq != null)
                                {
                                    if (actual.izq.unidad.Equals(presep) == true && actual.izq.jugador.Equals(jemi) == false && actual.izq.col == (ncol - 1) && actual.izq.vis != 0)
                                    {
                                        actual.izq.vida = actual.izq.vida - dano;
                                        if (actual.izq.vida <= 0)
                                        {
                                            actual.izq.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.izq.vida.ToString(); }
                                    }
                                }
                                if (actual.izq.sup != null)
                                {
                                    if (actual.izq.sup.sup != null)
                                    {
                                        if (actual.izq.sup.sup.unidad.Equals(presep) == true && actual.izq.sup.sup.jugador.Equals(jemi) == false && actual.izq.sup.sup.col == (ncol - 1) && actual.izq.sup.sup.vis != 0)
                                        {
                                            actual.izq.sup.sup.vida = actual.izq.sup.sup.vida - dano;
                                            if (actual.izq.sup.sup.vida <= 0)
                                            {
                                                actual.izq.sup.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.izq.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.der != null)//Derecha
                            {
                                if (actual.der.inf != null)
                                {
                                    if (actual.der.inf.unidad.Equals(presep) == true && actual.der.inf.jugador.Equals(jemi) == false && actual.der.inf.col == (ncol + 1) && actual.der.inf.vis != 0)
                                    {
                                        actual.der.inf.vida = actual.der.inf.vida - dano;
                                        if (actual.der.inf.vida <= 0)
                                        {
                                            actual.der.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.der.inf.vida.ToString(); }
                                    }
                                }
                                if (actual.der != null)
                                {
                                    if (actual.der.unidad.Equals(presep) == true && actual.der.jugador.Equals(jemi) == false && actual.der.col == (ncol + 1) && actual.der.vis != 0)
                                    {
                                        actual.der.vida = actual.der.vida - dano;
                                        if (actual.der.vida <= 0)
                                        {
                                            actual.der.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.der.vida.ToString(); }
                                    }
                                }
                                if (actual.der.sup != null)
                                {
                                    if (actual.der.sup.sup != null)
                                    {
                                        if (actual.der.sup.sup.unidad.Equals(presep) == true && actual.der.sup.sup.jugador.Equals(jemi) == false && actual.der.sup.sup.col == (ncol + 1) && actual.der.sup.sup.vis != 0)
                                        {
                                            actual.der.sup.sup.vida = actual.der.sup.sup.vida - dano;
                                            if (actual.der.sup.sup.vida <= 0)
                                            {
                                                actual.der.sup.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.der.sup.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                        }
                        if (niv == 3)
                        {
                            //Alcance 0
                            if (actual.inf != null)
                            {
                                if (actual.inf.vis != 0 && actual.inf.unidad.Equals(presep) == true && actual.inf.jugador.Equals(jemi) == false)
                                {
                                    actual.inf.vida = actual.inf.vida - dano;
                                    if (actual.inf.vida <= 0)
                                    {
                                        actual.inf.vis = 0;
                                        return "0";
                                    }
                                    else { return actual.inf.vida.ToString(); }
                                }
                            }
                            if (actual != null)
                            {
                                if (actual.vis != 0 && actual.unidad.Equals(presep) == true && actual.jugador.Equals(jemi) == false)
                                {
                                    actual.vida = actual.vida - dano;
                                    if (actual.vida <= 0)
                                    {
                                        actual.vis = 0;
                                        return "0";
                                    }
                                    else { return actual.vida.ToString(); }
                                }
                            }
                            if (actual.sup != null)
                            {
                                if (actual.sup != null)
                                {
                                    if (actual.sup.vis != 0 && actual.sup.unidad.Equals(presep) == true && actual.sup.jugador.Equals(jemi) == false)
                                    {
                                        actual.sup.vida = actual.sup.vida - dano;
                                        if (actual.sup.vida <= 0)
                                        {
                                            actual.sup.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.sup.vida.ToString(); }
                                    }
                                }
                            }
                            //Alcance 1
                            if (actual.arr != null)//Arriba
                            {
                                if (actual.arr.inf != null)
                                {
                                    if (actual.arr.inf.unidad.Equals(presep) == true && actual.arr.inf.jugador.Equals(jemi) == false && actual.arr.inf.fil == (nfil - 1) && actual.arr.inf.vis != 0)
                                    {
                                        actual.arr.inf.vida = actual.arr.inf.vida - dano;
                                        if (actual.arr.inf.vida <= 0)
                                        {
                                            actual.arr.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.arr.inf.vida.ToString(); }
                                    }
                                }
                                if (actual.arr != null)
                                {
                                    if (actual.arr.unidad.Equals(presep) == true && actual.arr.jugador.Equals(jemi) == false && actual.arr.fil == (nfil - 1) && actual.arr.vis != 0)
                                    {
                                        actual.arr.vida = actual.arr.vida - dano;
                                        if (actual.arr.vida <= 0)
                                        {
                                            actual.arr.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.arr.vida.ToString(); }
                                    }
                                }
                                if (actual.arr.sup != null)
                                {
                                    if (actual.arr.sup != null)
                                    {
                                        if (actual.arr.sup.unidad.Equals(presep) == true && actual.arr.sup.jugador.Equals(jemi) == false && actual.arr.sup.fil == (nfil - 1) && actual.arr.sup.vis != 0)
                                        {
                                            actual.arr.sup.vida = actual.arr.sup.vida - dano;
                                            if (actual.arr.sup.vida <= 0)
                                            {
                                                actual.arr.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.arr.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.abj != null)//Abajo
                            {
                                if (actual.abj.inf != null)
                                {
                                    if (actual.abj.inf.unidad.Equals(presep) == true && actual.abj.inf.jugador.Equals(jemi) == false && actual.abj.inf.fil == (nfil + 1) && actual.abj.inf.vis != 0)
                                    {
                                        actual.abj.inf.vida = actual.abj.inf.vida - dano;
                                        if (actual.abj.inf.vida <= 0)
                                        {
                                            actual.abj.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.abj.inf.vida.ToString(); }
                                    }
                                }
                                if (actual.abj != null)
                                {
                                    if (actual.abj.unidad.Equals(presep) == true && actual.abj.jugador.Equals(jemi) == false && actual.abj.fil == (nfil + 1) && actual.abj.vis != 0)
                                    {
                                        actual.abj.vida = actual.abj.vida - dano;
                                        if (actual.abj.vida <= 0)
                                        {
                                            actual.abj.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.abj.vida.ToString(); }
                                    }
                                }
                                if (actual.abj.sup != null)
                                {
                                    if (actual.abj.sup != null)
                                    {
                                        if (actual.abj.sup.unidad.Equals(presep) == true && actual.abj.sup.jugador.Equals(jemi) == false && actual.abj.sup.fil == (nfil + 1) && actual.abj.sup.vis != 0)
                                        {
                                            actual.abj.sup.vida = actual.abj.sup.vida - dano;
                                            if (actual.abj.sup.vida <= 0)
                                            {
                                                actual.abj.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.abj.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.izq != null)//Izquierda
                            {
                                if (actual.izq.inf != null)
                                {
                                    if (actual.izq.inf.unidad.Equals(presep) == true && actual.izq.inf.jugador.Equals(jemi) == false && actual.izq.inf.col == (ncol - 1) && actual.izq.inf.vis != 0)
                                    {
                                        actual.izq.inf.vida = actual.izq.inf.vida - dano;
                                        if (actual.izq.inf.vida <= 0)
                                        {
                                            actual.izq.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.izq.inf.vida.ToString(); }
                                    }
                                }
                                if (actual.izq != null)
                                {
                                    if (actual.izq.unidad.Equals(presep) == true && actual.izq.jugador.Equals(jemi) == false && actual.izq.col == (ncol - 1) && actual.izq.vis != 0)
                                    {
                                        actual.izq.vida = actual.izq.vida - dano;
                                        if (actual.izq.vida <= 0)
                                        {
                                            actual.izq.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.izq.vida.ToString(); }
                                    }
                                }
                                if (actual.izq.sup != null)
                                {
                                    if (actual.izq.sup != null)
                                    {
                                        if (actual.izq.sup.unidad.Equals(presep) == true && actual.izq.sup.jugador.Equals(jemi) == false && actual.izq.sup.col == (ncol - 1) && actual.izq.sup.vis != 0)
                                        {
                                            actual.izq.sup.vida = actual.izq.sup.vida - dano;
                                            if (actual.izq.sup.vida <= 0)
                                            {
                                                actual.izq.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.izq.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                            if (actual.der != null)//Derecha
                            {
                                if (actual.der.inf != null)
                                {
                                    if (actual.der.inf.unidad.Equals(presep) == true && actual.der.inf.jugador.Equals(jemi) == false && actual.der.inf.col == (ncol + 1) && actual.der.inf.vis != 0)
                                    {
                                        actual.der.inf.vida = actual.der.inf.vida - dano;
                                        if (actual.der.inf.vida <= 0)
                                        {
                                            actual.der.inf.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.der.inf.vida.ToString(); }
                                    }
                                }
                                if (actual.der != null)
                                {
                                    if (actual.der.unidad.Equals(presep) == true && actual.der.jugador.Equals(jemi) == false && actual.der.col == (ncol + 1) && actual.der.vis != 0)
                                    {
                                        actual.der.vida = actual.der.vida - dano;
                                        if (actual.der.vida <= 0)
                                        {
                                            actual.der.vis = 0;
                                            return "0";
                                        }
                                        else { return actual.der.vida.ToString(); }
                                    }
                                }
                                if (actual.der.sup != null)
                                {
                                    if (actual.der.sup != null)
                                    {
                                        if (actual.der.sup.unidad.Equals(presep) == true && actual.der.sup.jugador.Equals(jemi) == false && actual.der.sup.col == (ncol + 1) && actual.der.sup.vis != 0)
                                        {
                                            actual.der.sup.vida = actual.der.sup.vida - dano;
                                            if (actual.der.sup.vida <= 0)
                                            {
                                                actual.der.sup.vis = 0;
                                                return "0";
                                            }
                                            else { return actual.der.sup.vida.ToString(); }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    actual = actual.der;
                }
                tmp = tmp.sig;
            }
            return "";
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
                    if (actual != null && actual.vis == 1)
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
                        if ((actual2.vis == 1) && (actual2.abj.vis == 1))
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
                if (tmp4.acceso.vis == 1)
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
                        if ((actual3.vis == 1) && (actual3.der.vis == 1))
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
                if (tmp6.acceso.vis == 1)
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
                    if (actual.inf != null && actual.inf.vis == 1)
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
                    if (actual.inf != null && actual.inf.vis == 1)
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
                        if ((actual2.inf != null && actual2.abj.inf != null) && (actual2.inf.vis == 1 && actual2.abj.inf.vis == 1))
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
                if (tmp4.acceso.inf != null && tmp4.acceso.inf.vis == 1)
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
                        if ((actual3.inf != null && actual3.der.inf != null) && (actual3.inf.vis == 1 && actual3.der.inf.vis == 1))
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
                if (tmp6.acceso.inf != null && tmp6.acceso.inf.vis == 1)
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
                    if (actual.sup != null && actual.sup.vis == 1)
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
                    if (actual.sup != null && actual.sup.vis == 1)
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
                        if ((actual2.sup != null && actual2.abj.sup != null) && (actual2.sup.vis == 1 && actual2.abj.sup.vis == 1))
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
                if (tmp4.acceso.sup != null && tmp4.acceso.sup.vis == 1)
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
                        if ((actual3.sup != null && actual3.der.sup != null) && (actual3.sup.vis == 1 && actual3.der.sup.vis == 1))
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
                if (tmp6.acceso.sup != null && tmp6.acceso.sup.vis == 1)
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
                        if (actual.sup.sup != null && actual.sup.sup.vis == 1)
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
                        if (actual.sup.sup != null && actual.sup.sup.vis == 1)
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
                            if ((actual2.sup.sup != null && actual2.abj.sup.sup != null) && (actual2.sup.sup.vis == 1 && actual2.abj.sup.sup.vis == 1))
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
                    if (tmp4.acceso.sup.sup != null && tmp4.acceso.sup.sup.vis == 1)
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
                            if ((actual3.sup.sup != null && actual3.der.sup.sup != null) && (actual3.sup.sup.vis == 1 && actual3.der.sup.sup.vis == 1))
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
                    if (tmp6.acceso.sup.sup != null && tmp6.acceso.sup.sup.vis == 1)
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
        public int retfil(int niv, String pieemi, String jemi)
        {
            int fila = 0;
            En tmp = EF.primero;
            while (tmp != null)
            {
                Nodom actual = tmp.acceso;
                while (actual != null)
                {
                    if ((actual.jugador.Equals(jemi) == true))
                    {
                        if (niv == 0)
                        {
                            if (actual.inf != null )
                            {
                                if (actual.inf.vis == 1 && (actual.inf.unidad.Equals(pieemi) == true)) { fila = actual.inf.fil; }
                                
                            }
                        }
                        if (niv == 1)
                        {
                            if (actual.vis == 1 && (actual.unidad.Equals(pieemi) == true)) { fila = actual.fil; }
                            
                        }
                        if (niv == 2)
                        {
                            if (actual.sup != null )
                            {
                                if (actual.sup.vis == 1 && (actual.sup.unidad.Equals(pieemi) == true)) { fila = actual.sup.fil; }                   
                                
                            }
                        }
                        if (niv == 3)
                        {
                            if (actual.sup != null)
                            {
                                if (actual.sup.sup != null )
                                {
                                    if (actual.sup.sup.vis == 1 && (actual.sup.sup.unidad.Equals(pieemi) == true)) { fila = actual.sup.sup.fil; }
                                    
                                }
                            }
                        }
                    }
                    actual = actual.der;
                }
                tmp = tmp.sig;
            }
            return fila;
        }
        public int retcol(int niv, String pieemi, String jemi)
        {
            int columna = 0;
            En tmp = EF.primero;
            while (tmp != null)
            {
                Nodom actual = tmp.acceso;
                while (actual != null)
                {
                    if ((actual.jugador.Equals(jemi) == true))
                    {
                        if (niv == 0)
                        {
                            if (actual.inf != null && actual.inf.vis == 1 && (actual.inf.unidad.Equals(pieemi) == true))
                            {
                                columna = actual.inf.col;
                            }
                        }
                        if (niv == 1 && actual.vis == 1 && (actual.unidad.Equals(pieemi) == true))
                        {
                            columna = actual.col;
                        }
                        if (niv == 2)
                        {
                            if (actual.sup != null && actual.sup.vis == 1 && (actual.sup.unidad.Equals(pieemi) == true))
                            {
                                columna = actual.sup.col;
                            }
                        }
                        if (niv == 3)
                        {
                            if (actual.sup != null)
                            {
                                if (actual.sup.sup != null && actual.sup.sup.vis == 1 && (actual.sup.sup.unidad.Equals(pieemi) == true))
                                {
                                    columna = actual.sup.sup.col;
                                }
                            }
                        }
                    }
                    actual = actual.der;
                }
                tmp = tmp.sig;
            }
            return columna;
        }
        public bool Eliminar2(int fil, int col, int niv, String pieemi, int golpe, String pieresep, String jemi, String jresep, String fech, String tm, int Nataq)
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
                            if (actual.inf != null && (actual.inf.jugador.Equals(jemi) == true) && (actual.inf.unidad.Equals(pieemi) == true))
                            {
                                actual.inf.fil = fil;
                                actual.inf.col = col;
                                actual.inf.niv = niv;
                                actual.inf.vis = 2;
                                actual.inf.jugador = "";
                                actual.inf.unidad = "";
                                actual.inf.movimiento = 0;
                                actual.inf.alcanse = 0;
                                actual.inf.dano = 0;
                                actual.inf.vida = 0;
                                return true;
                            }
                        }
                        if (niv == 1 && (actual.jugador.Equals(jemi) == true) && (actual.unidad.Equals(pieemi) == true))
                        {
                            actual.fil = fil;
                            actual.col = col;
                            actual.niv = niv;
                            actual.vis = 2;
                            actual.jugador = "";
                            actual.unidad = "";
                            actual.movimiento = 0;
                            actual.alcanse = 0;
                            actual.dano = 0;
                            actual.vida = 0;
                            return true;
                        }
                        if (niv == 2)
                        {
                            if (actual.sup != null && (actual.sup.jugador.Equals(jemi) == true) && (actual.sup.unidad.Equals(pieemi) == true))
                            {
                                actual.sup.fil = fil;
                                actual.sup.col = col;
                                actual.sup.niv = niv;
                                actual.sup.vis = 2;
                                actual.sup.jugador = "";
                                actual.sup.unidad = "";
                                actual.sup.movimiento = 0;
                                actual.sup.alcanse = 0;
                                actual.sup.dano = 0;
                                actual.sup.vida = 0;
                                return true;
                            }
                        }
                        if (niv == 3)
                        {
                            if (actual.sup != null)
                            {
                                if (actual.sup.sup != null && (actual.sup.sup.jugador.Equals(jemi) == true) && (actual.sup.sup.unidad.Equals(pieemi) == true))
                                {
                                    actual.sup.sup.fil = fil;
                                    actual.sup.sup.col = col;
                                    actual.sup.sup.niv = niv;
                                    actual.sup.sup.vis = 2;
                                    actual.sup.sup.jugador = "";
                                    actual.sup.sup.unidad = "";
                                    actual.sup.sup.movimiento = 0;
                                    actual.sup.sup.alcanse = 0;
                                    actual.sup.sup.dano = 0;
                                    actual.sup.sup.vida = 0;
                                    return true;
                                }
                            }
                        }
                    }
                    actual = actual.der;
                }
                tmp = tmp.sig;
            }
            return false;
        }
    }

    public class ArbolAVL
    {
        public class NodoAAVL
        {
            public NodoAAVL(String UB, String Op, String pass, String mail)
            {
                this.UserBase = UB;
                this.Oponente = Op;
                this.Contrasena = pass;
                this.Correo = mail;
                this.Izq = null;
                this.Der = null;
                this.Fe = 0;
            }
            public String UserBase;
            public String Oponente;
            public String Contrasena;
            public String Correo;
            public int Fe;
            public NodoAAVL Izq;
            public NodoAAVL Der;            
        }

        public NodoAAVL Raiz = null;
        public NodoAAVL Actual;

        public NodoAAVL Buscar(String d, NodoAAVL r)
        {
            if (Raiz == null) { return null; }
            else if (String.Compare(d, r.Oponente) == 0) { return r; }
            else if (String.Compare(d, r.Oponente) > 0) { return Buscar(d, r.Der); }
            else { return Buscar(d, r.Izq); }
        }
        public int RetFe(NodoAAVL t)
        {
            if (t == null) { return -1; }
            else { return t.Fe; }
        }
        public NodoAAVL RotSimpIzq(NodoAAVL t)
        {
            if(t.Izq != null)
            {
                NodoAAVL aux = t.Izq;
                t.Izq = aux.Der;
                aux.Der = t;
                t.Fe = Math.Max(RetFe(t.Izq), RetFe(t.Der)) + 1;
                aux.Fe = Math.Max(RetFe(aux.Izq), RetFe(aux.Der)) + 1;
                return aux;
            }
            else{ return t; }
                         
        }
        public NodoAAVL RotSimpDer(NodoAAVL t)
        {
            if (t.Der != null)
            {
                NodoAAVL aux = t.Der;
                t.Der = aux.Izq;
                aux.Izq = t;
                t.Fe = Math.Max(RetFe(t.Izq), RetFe(t.Der)) + 1;
                aux.Fe = Math.Max(RetFe(aux.Izq), RetFe(aux.Der)) + 1;
                return aux;
            }
            else { return t; }
            
        }
        public NodoAAVL RotDobIzq(NodoAAVL t)
        {
            NodoAAVL aux;
            t.Izq = RotSimpDer(t.Izq);
            aux = RotSimpIzq(t);
            return aux;
        }
        public NodoAAVL RotDobDer(NodoAAVL t)
        {
            NodoAAVL aux;
            t.Der = RotSimpIzq(t.Der);
            aux = RotSimpDer(t);
            return aux;
        }
        public NodoAAVL AuxInsertar(NodoAAVL n, NodoAAVL s)
        {
            NodoAAVL nPadre = s;
            if (String.Compare(n.Oponente, s.Oponente) < 0)
            {
                if (s.Izq == null) { s.Izq = n; }
                else
                {
                    s.Izq = AuxInsertar(n, s.Izq);
                    if ((RetFe(s.Izq) - RetFe(s.Der)) == 2)
                    {
                        if (String.Compare(n.Oponente, s.Oponente) < 0) { nPadre = RotSimpIzq(s); }
                        else { nPadre = RotDobIzq(s); }
                    }
                }
            }
            else if (String.Compare(n.Oponente, s.Oponente) > 0)
            {
                if (s.Der == null) { s.Der = n; }
                else
                {
                    s.Der = AuxInsertar(n, s.Der);
                    if ((RetFe(s.Der) - RetFe(s.Izq)) == 2)
                    {
                        if (String.Compare(n.Oponente, s.Oponente) > 0) { nPadre = RotSimpDer(s); }
                        else { nPadre = RotDobDer(s); }
                    }
                }
            }
            else { Console.WriteLine("Duplicado en AVL"); }

            if ((s.Izq == null) && (s.Der != null)) { s.Fe = s.Der.Fe + 1; }
            else if ((s.Der == null) && (s.Izq != null)) { s.Fe = s.Izq.Fe + 1; }
            else { s.Fe = (Math.Max(RetFe(s.Izq), RetFe(s.Der))) + 1; }
            return nPadre;
        }
        public void Insertar(String UB, String Op, String pass, String mail)
        {
            NodoAAVL nuevo = new NodoAAVL(UB, Op, pass, mail);
            if (Raiz == null) { Raiz = nuevo; }
            else { Raiz = AuxInsertar(nuevo, Raiz); }
        }
        public void Borrar(String d)
        {
            NodoAAVL padre = null;
            NodoAAVL padre2 = null;
            NodoAAVL nodo;

            String UBtmp;
            String Optmp;
            String passtmp;
            String mailtmp;

            Actual = Raiz;
            while (Actual != null)
            {
                if (String.Compare(Actual.Oponente, d) == 0)
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
                        UBtmp = Actual.UserBase;
                        Optmp = Actual.Oponente;
                        passtmp = Actual.Contrasena;
                        mailtmp = Actual.Correo;

                        Actual.UserBase = nodo.UserBase;
                        Actual.Oponente = nodo.Oponente;
                        Actual.Contrasena = nodo.Contrasena;
                        Actual.Correo = nodo.Correo;

                        nodo.UserBase = UBtmp;
                        nodo.Oponente = Optmp;
                        nodo.Contrasena = passtmp;
                        nodo.Correo = mailtmp;

                        Actual = nodo;
                    }
                }
                else
                {
                    padre = Actual;
                    if (String.Compare(d, Actual.Oponente) > 0) { padre2 = Actual; Actual = Actual.Der; }
                    else if (String.Compare(d, Actual.Oponente) < 0) { padre2 = Actual; Actual = Actual.Izq; }
                }
            }
        }
        public void Modificar(String Op, String pass, String mail)
        {
            NodoAAVL padre = null;
            NodoAAVL padre2 = null;

            Actual = Raiz;
            while (Actual != null)
            {
                if (String.Compare(Actual.Oponente, Op) == 0)
                {
                    Actual.Oponente = Op;
                    Actual.Contrasena = pass;
                    Actual.Correo = mail;
                    return;
                }
                else
                {
                    padre = Actual;
                    if (String.Compare(Op, Actual.Oponente) > 0) { padre2 = Actual; Actual = Actual.Der; }
                    else if (String.Compare(Op, Actual.Oponente) < 0) { padre2 = Actual; Actual = Actual.Izq; }
                }
            }
        }
        public void PrePintarArbolAVL(NodoAAVL nodo, bool r)
        {
            if (r) nodo = Raiz;
            if (nodo != null)
            {
                if (nodo.Izq != null) PrePintarArbolAVL(nodo.Izq, false);
                StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoAVL.dot");
                agregar.WriteLine(nodo.Oponente + "[label=" + '"' + "Jugador: " + nodo.UserBase + "\n Oponente: " + nodo.Oponente + "\n Contrasena: " + nodo.Contrasena + "\n Correo: " + nodo.Correo + '"' + "]");
                agregar.Close();
                if (nodo.Der != null) PrePintarArbolAVL(nodo.Der, false);
            }

        }
        public void PintarArbolAVL(NodoAAVL nodo, bool r)
        {

            if (r) nodo = Raiz;
            if (nodo != null)
            {
                if (nodo.Izq != null)
                {
                    StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoAVL.dot");
                    agregar.WriteLine(nodo.Oponente + "->" + nodo.Izq.Oponente);
                    agregar.Close();
                    PintarArbolAVL(nodo.Izq, false);
                }
                //Console.Write(nodo.Dato.ToString() + " ");
                if (nodo.Der != null)
                {
                    StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoAVL.dot");
                    agregar.WriteLine(nodo.Oponente + "->" + nodo.Der.Oponente);
                    agregar.Close();
                    PintarArbolAVL(nodo.Der, false);
                }
            }

        }
    }

    public class TablaHash
    {
        public class NodoLA
        {
            public NodoLA(String Nick, String Pass, String Mail, int Log, ListaDelArbol lst, int Gan, int Des, int Desple, int Per, int Sobre, int contac)
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
                this.Desplegadas = Desple;
                this.Perdidas = Per;
                this.Sobrevivientes = Sobre;
                this.Contactos = contac;
            }
            public int Perdidas;
            public int Ganadas;
            public int Destruidas;
            public int Desplegadas;
            public int Sobrevivientes;
            public int Contactos;
            public String Nickname;
            public String Contrasena;
            public String Correo;
            public int Conectado;
            public NodoLA Sig;
            public NodoLA Ant;
            public ListaDelArbol Lista;
        }

        public Object[] arregloArbol;
        public int sice, cont;
        public int nelementos = 0;
        public decimal densidad = 0;
        public decimal densidadreal = 0;
        public TablaHash(int s)
        {
            sice = s;
            arregloArbol = new Object[s];            
        }
        public void calculoDensidad()
        {
            int a = (nelementos + 1) * 100;
            decimal denso = a / sice;
            densidad = denso;
        }
        public void calculoDensidadReal()
        {
            int a = (nelementos) * 100;
            decimal denso = a / sice;
            densidadreal = denso;
        }
        public int RetIndice(String nick)
        {
            int valor = 0;
            char[] c= nick.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                valor = valor + (int)c[i];
            }
            return valor;
        }
        public void IncercionMasiva(ListaNodoArbol tmp)
        {
            ListaNodoArbol.NodoLA aux = tmp.primero;
            if (aux != null)
            {
                do
                {
                    if (aux != null)
                    {
                        funcion(aux, arregloArbol);
                    }                    
                    aux = aux.Sig;
                } while (aux != tmp.ultimo);
            }
        }
        public void eliminar(String nick)
        {
            int valor = RetIndice(nick);
            int indice = valor % (sice - 1);
            int conteo = 0;
            while (arregloArbol[indice] != null)
            {
                ListaNodoArbol.NodoLA tmp = (ListaNodoArbol.NodoLA)arregloArbol[indice];
                if (tmp.Nickname.Equals(nick))
                {
                    arregloArbol[indice] = null;
                    nelementos--;                    
                }
                indice++;
                indice %= sice;
                conteo++;
                if (conteo > sice) { break; }
            }
            calculoDensidadReal();
            if (densidadreal <= 30 && sice > 44)
            {
                funcionmenos();
            }
        }
        public void funcion(ListaNodoArbol.NodoLA val, Object[] arr)
        {
            bool repetido = false;
            if (densidad <= 50)
            {
                int valor = RetIndice(val.Nickname);
                int indice = valor % (sice - 1);

                int recont = 0;
                while (arr[indice] != null)
                {
                    recont++;
                    indice = indice + 1 + (recont ^ 2);                    
                    indice %= sice;
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    ListaNodoArbol.NodoLA tmp = (ListaNodoArbol.NodoLA)arr[i];
                    if (tmp != null)
                    {
                        if (tmp.Nickname.Equals(val.Nickname)) { repetido = true; }
                    }                  
                }
                if (repetido == false)
                {
                    arr[indice] = val;
                    nelementos++;
                    calculoDensidad();
                }                                                                   
            }
            else
            {
                funcionmas(val, arr);
            }
        }
        public void funcionmas(ListaNodoArbol.NodoLA val, Object[] arr)
        {
            Object[] arrtmp = new Object[sice];
            arrtmp = arr;

            sice = sice * 2;
            Object[] arrnuevo = new Object[sice];

            for (int i = 0; i < arrtmp.Length; i++)
            {
                int valor1 = RetIndice(val.Nickname);
                int indice1 = valor1 % (sice - 1);

                int recont = 0;
                while (arrnuevo[indice1] != null)
                {
                    recont++;
                    indice1 = indice1 + 1 + (recont ^ 2);
                    indice1 %= sice;
                }
                arrnuevo[indice1] = arrtmp[i];
            }

            int valor = RetIndice(val.Nickname);
            int indice = valor % (sice - 1);

            int recont2 = 0;
            while (arrnuevo[indice] != null)
            {
                recont2++;
                indice = indice + 1 + (recont2 ^ 2);
                indice %= sice;
            }
            arrnuevo[indice] = val;
            nelementos++;

            arregloArbol = new Object[sice];
            arregloArbol = arrnuevo;
            calculoDensidad();
        }
        public void funcionmenos()
        {
            Object[] arrtmp = new Object[sice];
            arrtmp = arregloArbol;
            int conteo = 0;

            sice = (sice / 2);
            Object[] arrnuevo = new Object[sice];

            for (int i = 0; i < arrtmp.Length; i++)
            {
                if (arrtmp[i] != null)
                {
                    ListaNodoArbol.NodoLA tmp = (ListaNodoArbol.NodoLA)arrtmp[i];
                    int valor = RetIndice(tmp.Nickname);
                    int indice1 = valor % (sice - 1);

                    int recont = 0;
                    while (arrnuevo[indice1] != null)
                    {
                        recont++;
                        indice1 = indice1 + 1 + (recont ^ 2);
                        indice1 %= sice;
                        conteo++;
                        if (conteo > sice) { break; }
                    }
                    arrnuevo[indice1] = tmp;
                }
            }

            arregloArbol = new Object[sice];
            arregloArbol = arrnuevo;
        }
        public void pintarTabla()
        {
            calculoDensidadReal();
            StreamWriter crear = new StreamWriter("C:\\Grafo\\GrafoHASH.dot");
            crear.WriteLine("digraph grafo{TablaHash" + "[label=" + '"' + "Tamanio: " + sice + "\n No. Elementos: " + nelementos + "\n Densidad %: " + densidadreal +  '"' + "]");
            crear.Close();

            for (int j = 0; j < sice; j++)
            {
                if (arregloArbol[j] != null)
                {
                    ListaNodoArbol.NodoLA tmp = (ListaNodoArbol.NodoLA)arregloArbol[j];
                    StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoHASH.dot");
                    agregar.WriteLine(j + "[label=" + '"' + "Indice: " + j + "\n Valor: " + tmp.Nickname + "\n Contrasena: " + tmp.Contrasena + "\n Correo: " + tmp.Correo
                        + "\n Conectado: " + tmp.Conectado + "\n Juegos ganados: " + tmp.Ganadas + "\n Contactos: " + tmp.Contactos + '"' + "]");
                    agregar.Close();
                }
                else
                {
                    StreamWriter agregar = File.AppendText("C:\\Grafo\\GrafoHASH.dot");
                    agregar.WriteLine(j + "[label=" + '"' + "Indice: " + j + "\n Valor: " + " " + '"' + "]");
                    agregar.Close();
                }
            }

            StreamWriter agregar2 = File.AppendText("C:\\Grafo\\GrafoHASH.dot");
            agregar2.WriteLine("TablaHash");
            agregar2.Close();

            for (int j = 0; j < sice; j++)
            {
                StreamWriter agregar3 = File.AppendText("C:\\Grafo\\GrafoHASH.dot");
                agregar3.WriteLine("->" + j);
                agregar3.Close();
            }

            StreamWriter agregar4 = File.AppendText("C:\\Grafo\\GrafoHASH.dot");
            agregar4.WriteLine("}");
            agregar4.Close();
        }
    }
}