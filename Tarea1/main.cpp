#include <QCoreApplication>
#include <iostream>
using namespace std;

void menu();
void Insertar(int v);
void Eliminar();
void MostrarA();

struct nodoLD {

public:
    nodoLD(int v, nodoLD *sig = NULL, nodoLD *ant = NULL) : dato(v), siguiente(sig), anterior(ant) {}
    int dato;
    nodoLD *siguiente;
    nodoLD *anterior;
};

typedef nodoLD *pnodoLD;

struct lista {

public:
    lista() : primerolista(NULL) {}
    tlista();
    bool ListaVacia() { return primerolista == NULL; }
    bool Actual() { return primerolista != NULL; }
    int datoActual() { return primerolista->dato; }
    void Insertar(int i);
    void Borrar(int i);
    void MostrarA(int tipo);
    void Siguiente();
    void Anterior();
    void Primero();
    void Ultimo();
    pnodoLD primerolista;
};

lista::tlista()
{
   pnodoLD aux;
   Primero();
   while(primerolista) {
      aux = primerolista;
      primerolista = primerolista->siguiente;
      delete aux;
   }
}

lista ListaDoble;

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    menu();

    return a.exec();
}

void lista::Primero()
{
   while(primerolista && primerolista->anterior) primerolista = primerolista->anterior;
}

void lista::Ultimo()
{
   while(primerolista && primerolista->siguiente) primerolista = primerolista->siguiente;
}

void lista::Siguiente()
{
   if(primerolista) primerolista = primerolista->siguiente;
}

void lista::Anterior()
{
   if(primerolista) primerolista = primerolista->anterior;
}

void lista::Insertar(int i)
{
   pnodoLD temp;

   Primero();
   if(ListaVacia() || primerolista->dato > i) {
      temp = new nodoLD(i, primerolista);
      if(!primerolista) primerolista = temp;
      else primerolista->anterior = temp;
   }
   else {
      while(primerolista->siguiente && primerolista->siguiente->dato <= i) Siguiente();
      temp = new nodoLD(i, primerolista->siguiente, primerolista);
      primerolista->siguiente = temp;
      if(temp->siguiente) temp->siguiente->anterior = temp;
   }
}

void lista::Borrar(int i)
{
   pnodoLD nodoLD;

   nodoLD = primerolista;
   while(nodoLD && nodoLD->dato < i) nodoLD = nodoLD->siguiente;
   while(nodoLD && nodoLD->dato > i) nodoLD = nodoLD->anterior;

   if(!nodoLD || nodoLD->dato != i) return;

   if(nodoLD->anterior)
      nodoLD->anterior->siguiente = nodoLD->siguiente;
   if(nodoLD->siguiente)
      nodoLD->siguiente->anterior = nodoLD->anterior;
   delete nodoLD;
}

void lista::MostrarA(int tipo)
{
   pnodoLD nodoLD;
   if(tipo == 1) {
      Primero();
      cout<<endl<<"Orden Ascendente: "<<endl<<endl;
      nodoLD = primerolista;
      while(nodoLD) {
         cout << nodoLD->dato << "-> ";
         nodoLD = nodoLD->siguiente;
      }
      cout<<endl;
   }
   else {
      Ultimo();
      cout<<endl<<"Orden Descendente: "<<endl<<endl;
      nodoLD = primerolista;
      while(nodoLD) {
         cout << nodoLD->dato << "-> ";
         nodoLD = nodoLD->anterior;
      }
      cout<<endl;
   }
   cout << endl;
}

void menu()
{
    int select;
    cout<<endl;
    cout<<"------------------------------"<<endl;
    cout<<"MENU LISTA DOBLEMENTE ENLAZADA"<<endl;
    cout<<"------------------------------"<<endl;
    cout<<"1) Incertar elemento nuevo"<<endl;
    cout<<"2) Eliminar un elemento"<<endl;
    cout<<"3) Mostrar ascendentemente"<<endl;
    cout<<"4) Mostrar descendentemente"<<endl<<endl;
    cout<<"Ingrese el numero de opcion:"<<endl;
    cin>>select;
    if(!(select==1 || select==2 || select==3 || select==4)){cout<<"Ingrese un numero valido"<<endl;menu();}
    if(select==1)
    {
        int dato = 5;
        cout<<"Ingrese un numero nuevo:"<<endl;
        cin>>dato;
        ListaDoble.Insertar(dato);
        cout<<endl<<"dato ingresado correctamente"<<endl;
        menu();
    }
    if(select==2)
    {
        int dato;
        cout<<"Ingrese un dato a borrar:"<<endl;
        cin>>dato;
        ListaDoble.Borrar(dato);
        cout<<endl<<"dato eliminado correctamente"<<endl;
        menu();
    }
    if(select==3){ListaDoble.MostrarA(1);menu();}
    if(select==4){ListaDoble.MostrarA(0);menu();}
}
