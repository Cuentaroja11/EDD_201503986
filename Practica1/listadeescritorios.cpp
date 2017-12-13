#include "listadeescritorios.h"

ListaDeEscritorios::ListaDeEscritorios()
{

}

struct NodoLDE
{
public:
    NodoLDE* sig;
    NodoLDE* ant;
    int indice;
    int conteo;

    int maletas;
    int documentos;
    int turnos;

} *primeroLDE, *ultimoLDE;

struct NodoPDOC
{
public:
    NodoPDOC* sig;
    NodoPDOC* ant;

    int indice;

};

struct NodoCPAS
{
public:
    NodoCPAS* sig;
    NodoCPAS* ant;

    int maletas;
    int documentos;
    int turnos;

};

void ListaDeEscritorios::InsertarE(int i, int c, int m, int d, int t)
{
    NodoLDE* nuevo = new NodoLDE();
    nuevo->indice = i;
    nuevo->conteo = c;
    nuevo->maletas = m;
    nuevo->documentos = d;
    nuevo->turnos = t;

    if(primeroLDE == NULL)
    {
        primeroLDE = nuevo;
        ultimoLDE = nuevo;
        primeroLDE->sig = primeroLDE;
        primeroLDE->ant = primeroLDE;
    }
    else
    {
        ultimoLDE->sig = nuevo;
        nuevo->ant = ultimoLDE;
        nuevo->sig = primeroLDE;
        ultimoLDE = nuevo;
        primeroLDE->ant = ultimoLDE;
    }
}

NodoLDE* ListaDeEscritorios::SetPrimeroE(){return primeroLDE;}

void ListaDeEscritorios::EliminarE()
{
    bool Encontro = false;
    NodoLDE* tmp = new NodoLDE();
    NodoLDE* rec = new NodoLDE();
    rec = NULL;
    tmp = primeroLDE;

    if(primeroLDE != NULL)
    {
        do
        {
            //cout << "\n\n  EL DATO FUE ENCONTRADO EN LA LISTA DE ESCRITORIOS \n\n";
            Encontro = true;

            if(primeroLDE->sig == primeroLDE && primeroLDE->ant == primeroLDE)
            {
                primeroLDE = NULL;
                break;
            }

            if(tmp == primeroLDE)
            {
                primeroLDE = primeroLDE->sig;
                primeroLDE->ant = ultimoLDE;
                ultimoLDE->sig = primeroLDE;
            }
            else if(tmp == ultimoLDE)
            {
                ultimoLDE = rec;
                ultimoLDE->sig = primeroLDE;
                primeroLDE->ant = ultimoLDE;
            }
            else
            {
                rec->sig = tmp->sig;
                tmp->sig->ant = rec;
            }
            rec = tmp;
            tmp = tmp->sig;
        }while(tmp!=primeroLDE&&Encontro!=true);
        if(!Encontro)
        {
            cout << "\n\n  EL DATO NO EXISTE EN LA LISTA DE ESCRITORIOS \n\n";
        }
        else
        {
            free(rec);
        }
    }
    else
    {
        cout << "\n\n LA LISTA DE ESTACIONES NO CONTIENE ESCRITORIOS \n\n";
    }
}

QString ListaDeEscritorios::RecorrerDer()
{
    QString Retorno="";
    fstream AgregarADot;
    AgregarADot.open("C:\\Grafo\\Grafo.dot", ios::app);
    Retorno += "--------------------------------------------------------------\n+++++++++ Escritorios de registro ++++++++\n";

    if(primeroLDE != NULL)
    {
        cout<<"Grafo de Escritorios--------------------------------------"<<endl;
        //cout << "subgraph Escritorios { Escritorios ";
        AgregarADot << "subgraph Escritorios { Escritorios ";
        NodoLDE* tmp = new NodoLDE();
        tmp = primeroLDE;
        do
        {
           /*cout << "\n" << '"' << tmp << '"' << "[label=" << '"' << "Estacion: " << tmp->indice << "\n Tipo: " << tmp->tipo.toStdString() << "\n Pasajeros: " <<
                   tmp->pasageros << "\n Desabordaje: " << tmp->desabordaje << "\n Mantenimiento: " << tmp->mantenimiento << "\n Turnos: " <<
                   tmp->conteo << " de " << tmp->mantenimiento << '"' << "]";*/
           AgregarADot << "\n" << '"' << tmp << '"' << "[label=" << '"' << "Estacion: " << tmp->indice << "\n Maletas: " << tmp->maletas << "\n Documentos: " <<
                   tmp->documentos << "\n Turnos: " << tmp->conteo << " de " << tmp->turnos << '"' << "]";
           NodoCPAS* tmpCPAS = Cola->SetPrimeroP();
           NodoCPAS* tmpCPAS2 = Cola->SetPrimeroP();
           if(tmpCPAS != NULL)
           {
               do
               {
                   if(tmpCPAS==tmpCPAS2)
                   {

                   }
                   else
                   {

                   }
                   tmpCPAS = tmpCPAS->sig;
               }while(tmpCPAS != tmpCPAS2);
           }
           QString Ocupacion = "";
           if(tmp->documentos==0){Ocupacion="Libre";}else{Ocupacion="Ocupado";}
           Retorno += "Escritorio " + QString::number(tmp->indice) + ": " + Ocupacion + "\n" ;
           Retorno += "\t Cantidad de docs.: " + QString::number(tmp->documentos) + "\n";
           Retorno += "\t Turnos restantes: " + QString::number(tmp->conteo) + " de: " + QString::number(tmp->turnos) + "\n";
           tmp = tmp->sig;
        }while(tmp != primeroLDE);
        //cout << "\n Escritorios";
        AgregarADot << "\n Escritorios";
        tmp = primeroLDE;
        do
        {
           //cout << "->" << '"' << tmp << '"';
           AgregarADot << "->" << '"' << tmp << '"';
           tmp = tmp->sig;
        }while(tmp != primeroLDE);
        tmp = ultimoLDE;
        //cout << "\n Escritorios \n";
        AgregarADot << "\n Escritorios \n";
        do
        {
            //cout << '"' << tmp << '"' << "->";
            AgregarADot << '"' << tmp << '"' << "->";
            tmp = tmp->ant;
        }while(tmp != ultimoLDE);
        //cout << "Escritorios}\n";
        AgregarADot << "Escritorios}\n";
        cout << endl;
    }
    else
    {
         //cout << "subgraph Escritorios { Escritorios }" << endl;
         AgregarADot << "subgraph Estaciones { Escritorios }" << endl;
    }
    AgregarADot.close();
    Retorno += "--------------------------------------------------------------\n";
    return Retorno;

}
