#include "listadeestaciones.h"
#include "mainwindow.h"

ListaDeEstaciones::ListaDeEstaciones()
{

}

struct NodoLM
{
public:
    NodoLM* sig;
    NodoLM* ant;
    int indice;
    int conteo;
    QString tipo;
    int tipoint;
    int pasageros;
    int desabordaje;
    int mantenimiento;
} *primeroLM, *ultimoLM;

void ListaDeEstaciones::Insertar(int i, QString tip, int tipi, int pas, int des, int man, int c)
{
    NodoLM* nuevo = new NodoLM();
    nuevo->indice = i;
    nuevo->tipo = tip;
    nuevo->tipoint = tipi;
    nuevo->pasageros = pas;
    nuevo->desabordaje = des;
    nuevo->mantenimiento = man;
    nuevo->conteo = c;

    if(primeroLM == NULL)
    {
        primeroLM = nuevo;
        ultimoLM = nuevo;
        primeroLM->sig = primeroLM;
        primeroLM->ant = primeroLM;
    }
    else
    {
        ultimoLM->sig = nuevo;
        nuevo->ant = ultimoLM;
        nuevo->sig = primeroLM;
        ultimoLM = nuevo;
        primeroLM->ant = ultimoLM;
    }
}

QString ListaDeEstaciones::RecorrerDer()
{
    QString Retorno="";
    fstream AgregarADot;
    AgregarADot.open("C:\\Grafo\\Grafo.dot", ios::app);
    Retorno += "--------------------------------------------------------------\n+++++++++ Estaciones de Servicio ++++++++\n";

    if(primeroLM != NULL)
    {
        cout<<"Grafo de Estaciones--------------------------------------"<<endl;
        //cout << "subgraph Estaciones { Estaciones ";
        AgregarADot << "subgraph Estaciones { Estaciones ";
        NodoLM* tmp = new NodoLM();
        tmp = primeroLM;
        do
        {
           /*cout << "\n" << '"' << tmp << '"' << "[label=" << '"' << "Estacion: " << tmp->indice << "\n Tipo: " << tmp->tipo.toStdString() << "\n Pasajeros: " <<
                   tmp->pasageros << "\n Desabordaje: " << tmp->desabordaje << "\n Mantenimiento: " << tmp->mantenimiento << "\n Turnos: " <<
                   tmp->conteo << " de " << tmp->mantenimiento << '"' << "]";*/
           AgregarADot << "\n" << '"' << tmp << '"' << "[label=" << '"' << "Estacion: " << tmp->indice << "\n Tipo: " << tmp->tipo.toStdString() << "\n Pasajeros: " <<
                   tmp->pasageros << "\n Desabordaje: " << tmp->desabordaje << "\n Mantenimiento: " << tmp->mantenimiento << "\n Turnos: " <<
                   tmp->conteo << " de " << tmp->mantenimiento << '"' << "]";
           QString Ocupacion = "";
           QString Tamano = tmp->tipo;
           if(tmp->mantenimiento==0){Ocupacion="Libre";}else{Ocupacion="Ocupado";}
           Retorno += "Estacion " + QString::number(tmp->indice) + ": " + Ocupacion + "\n" ;
           Retorno += "\t Avion en mantenimiento: " + Tamano + "\n";
           Retorno += "\t Turnos restantes: " + QString::number(tmp->conteo) + " de: " + QString::number(tmp->mantenimiento) + "\n";
           tmp = tmp->sig;
        }while(tmp != primeroLM);
        //cout << "\n Estaciones";
        AgregarADot << "\n Estaciones";
        tmp = primeroLM;
        do
        {
           //cout << "->" << '"' << tmp << '"';
           AgregarADot << "->" << '"' << tmp << '"';
           tmp = tmp->sig;
        }while(tmp != primeroLM);
        tmp = ultimoLM;
        //cout << "\n Estaciones \n";
        AgregarADot << "\n Estaciones \n";
        do
        {
            //cout << '"' << tmp << '"' << "->";
            AgregarADot << '"' << tmp << '"' << "->";
            tmp = tmp->ant;
        }while(tmp != ultimoLM);
        //cout << "Estaciones}\n";
        AgregarADot << "Estaciones}\n";
        cout << endl;
    }
    else
    {
         //cout << "subgraph Estaciones { Estaciones }" << endl;
         AgregarADot << "subgraph Estaciones { Estaciones }" << endl;
    }
    AgregarADot.close();
    Retorno += "--------------------------------------------------------------\n";
    return Retorno;

}

void ListaDeEstaciones::Eliminar()
{
    bool Encontro = false;
    NodoLM* tmp = new NodoLM();
    NodoLM* rec = new NodoLM();
    rec = NULL;
    tmp = primeroLM;

    if(primeroLM != NULL)
    {
        do
        {
            //cout << "\n\n  EL DATO FUE ENCONTRADO EN LA LISTA DE ESTACIONES \n\n";
            Encontro = true;

            if(primeroLM->sig == primeroLM && primeroLM->ant == primeroLM)
            {
                primeroLM = NULL;
                break;
            }

            if(tmp == primeroLM)
            {
                primeroLM = primeroLM->sig;
                primeroLM->ant = ultimoLM;
                ultimoLM->sig = primeroLM;
            }
            else if(tmp == ultimoLM)
            {
                ultimoLM = rec;
                ultimoLM->sig = primeroLM;
                primeroLM->ant = ultimoLM;
            }
            else
            {
                rec->sig = tmp->sig;
                tmp->sig->ant = rec;
            }
            rec = tmp;
            tmp = tmp->sig;
        }while(tmp!=primeroLM&&Encontro!=true);
        if(!Encontro)
        {
            cout << "\n\n  EL DATO NO EXISTE EN LA LISTA DE ESTACIONES \n\n";
        }
        else
        {
            free(rec);
        }
    }
    else
    {
        cout << "\n\n LA LISTA DE ESTACIONES NO CONTIENE ELEMENTOS \n\n";
    }
}

int ListaDeEstaciones::Conteo()
{
    NodoLM* tmp = new NodoLM();
    tmp = primeroLM;
    int Conteo = 0;
    if(primeroLM != NULL)
    {
        do
        {
            tmp = tmp->sig;
            Conteo++;
        }while(tmp != primeroLM);
    }
    return Conteo;
}

bool ListaDeEstaciones::EstaVacia()
{
    if(primeroLM == NULL){return true;}else{return false;}
}

NodoLM* ListaDeEstaciones::SetPrimero(){return primeroLM;}
