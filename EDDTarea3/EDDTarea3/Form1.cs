using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDTarea3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arbol a = new Arbol();
            ListaDelArbol b = new ListaDelArbol();
            ListaDelArbol c = new ListaDelArbol();
            a.Insertar(40, 40, "", b);
            a.Insertar(20, 20, "", c);
            a.Insertar(60, 60, "", b);
            a.Insertar(10, 10, "", c);
            a.Insertar(30, 30, "", b);
            a.Insertar(50, 50, "", c);
            a.Insertar(70, 70, "", b);
            a.Insertar(45, 45, "", c);
            a.Insertar(55, 55, "", b);
            a.Insertar(54, 54, "", c);

            Console.WriteLine("Recorrido InOrder: ");
            a.InOrder(a.Raiz, true);

            Console.WriteLine("\n Recorrido PreOrder: ");
            a.PreOrder(a.Raiz, true);

            Console.WriteLine("\n Recorrido PostOrder: ");
            a.PostOrder(a.Raiz, true);
        }
    }

    public class Arbol
    {
        public class NodoArbol
        {
            public NodoArbol(int dat, int per, String nom, ListaDelArbol lst)
            {
                this.Dato = dat;
                this.Perdidas = per;
                this.Nombre = nom;
                this.Izq = null;
                this.Der = null;
                this.Lista = lst;
            }
            public int Dato;
            public int Perdidas;
            public String Nombre;
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
        public ListaNodoArbol ListaNodos = new ListaNodoArbol();

        public bool Vacio(NodoArbol r) { return r == null; }
        public void Insertar(int dat, int per, String nom, ListaDelArbol lst)
        {

            NodoArbol padre = null;
            Actual = Raiz;
            while (!(Actual == null) && dat != Actual.Dato)
            {
                padre = Actual;
                if (dat > Actual.Dato) { Actual = Actual.Der; }
                else if (dat < Actual.Dato) { Actual = Actual.Izq; }
            }

            if (Actual != null) return;
            if (padre == null) Raiz = new NodoArbol(dat, per, nom, lst);
            else if (dat < padre.Dato) { padre.Izq = new NodoArbol(dat, per, nom, lst); }
            else if (dat > padre.Dato) { padre.Der = new NodoArbol(dat, per, nom, lst); }

        }
        
        public void InOrder(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            if (nodo.Izq != null) InOrder(nodo.Izq, false);
            Console.Write(nodo.Dato.ToString() + " ");
            if (nodo.Der != null) InOrder(nodo.Der, false);
        }
        
        
        public void PreOrder(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            Console.Write(nodo.Dato.ToString() + " ");
            if (nodo.Izq != null) PreOrder(nodo.Izq, false);
            if (nodo.Der != null) PreOrder(nodo.Der, false);
        }
        public void PostOrder(NodoArbol nodo, bool r)
        {
            if (r) nodo = Raiz;
            if (nodo.Izq != null) PostOrder(nodo.Izq, false);
            if (nodo.Der != null) PostOrder(nodo.Der, false);
            Console.Write(nodo.Dato.ToString() + " ");
        }
                             
        
    }
    public class ListaDelArbol
    {
        public class NodoLDA
        {
            public NodoLDA(int dat, int per, String nom)
            {
                this.Dato = dat;
                this.Perdidas = per;
                this.Nombre = nom;
                this.Ant = null;
                this.Sig = null;
            }
            public int Dato;
            public int Perdidas;
            public String Nombre;
            public NodoLDA Sig;
            public NodoLDA Ant;
        }

        public NodoLDA primero;
        public NodoLDA ultimo;

        public void Insertar(int dat, int per, String nom)
        {
            NodoLDA nuevo = new NodoLDA(dat, per, nom);
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
    }
    public class ListaNodoArbol
    {
        public class NodoLA
        {
            public NodoLA(int dat, int per, String nom, ListaDelArbol lst)
            {
                this.Dato = dat;
                this.Perdidas = per;
                this.Nombre = nom;
                this.Ant = null;
                this.Sig = null;
                this.Lista = lst;
            }
            public int Dato;
            public int Perdidas;
            public String Nombre;
            public NodoLA Sig;
            public NodoLA Ant;
            public ListaDelArbol Lista;
        }

        public NodoLA primero;
        public NodoLA ultimo;

        public void Insertar(int dat, int per, String nom, ListaDelArbol lst)
        {
            NodoLA nuevo = new NodoLA(dat, per, nom, lst);
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
       
    }
}
