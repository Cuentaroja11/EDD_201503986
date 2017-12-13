#include "listacirculardoblemaletas.h"

ListaCircularDobleMaletas::ListaCircularDobleMaletas()
{

}

struct NodoLCDM
{
public:
    NodoLCDM* sig;
    NodoLCDM* ant;
    int indice;
} *primeroLCDM, *ultimoLCDM;

void ListaCircularDobleMaletas::Insertar(int i)
{
    NodoLCDM* nuevo = new NodoLCDM();
    nuevo->indice = i;

    if(primeroLCDM == NULL)
    {
        primeroLCDM = nuevo;
        ultimoLCDM = nuevo;
        primeroLCDM->sig = primeroLCDM;
        primeroLCDM->ant = primeroLCDM;
    }
    else
    {
        ultimoLCDM->sig = nuevo;
        nuevo->ant = ultimoLCDM;
        nuevo->sig = primeroLCDM;
        ultimoLCDM = nuevo;
        primeroLCDM->ant = ultimoLCDM;
    }
}

QString ListaCircularDobleMaletas::RecorrerDer()
{
    QString Retorno="";
    fstream AgregarADot;
    AgregarADot.open("C:\\Grafo\\Grafo.dot", ios::app);

    if(primeroLCDM != NULL)
    {
        cout<<"Grafo de Maletas--------------------------------------"<<endl;
        //cout << "subgraph Maletas { Maletas ";
        AgregarADot << "subgraph Maletas { Maletas ";
        NodoLCDM* tmp = new NodoLCDM();
        tmp = primeroLCDM;
        do
        {
           /*cout << "\n" << '"' << tmp << '"' << "[label=" << '"' << "Estacion: " << tmp->indice << "\n Tipo: " << tmp->tipo.toStdString() << "\n Pasajeros: " <<
                   tmp->pasageros << "\n Desabordaje: " << tmp->desabordaje << "\n Mantenimiento: " << tmp->mantenimiento << "\n Turnos: " <<
                   tmp->conteo << " de " << tmp->mantenimiento << '"' << "]";*/
           AgregarADot << "\n" << '"' << tmp << '"' << "[label=" << '"' << "Maleta: " << tmp->indice << '"' << "]";
           tmp = tmp->sig;
        }while(tmp != primeroLCDM);
        //cout << "\n Maletas";
        AgregarADot << "\n Maletas \n";
        tmp = primeroLCDM;
        do
        {
           //cout << "->" << '"' << tmp << '"';
           AgregarADot << '"' << tmp << '"' << "->";
           tmp = tmp->sig;
        }while(tmp != primeroLCDM);
        tmp = ultimoLCDM;
        //cout << "\n Maletas \n";
        AgregarADot << "Maletas \n";
        do
        {
            //cout << '"' << tmp << '"' << "->";
            AgregarADot << '"' << tmp << '"' << "->";
            tmp = tmp->ant;
        }while(tmp != ultimoLCDM);
        //cout << "Maletas}\n";
        AgregarADot << "Maletas\n";
        AgregarADot << "Maletas->" << '"' << primeroLCDM << '"' << "\n";
        AgregarADot << "Maletas->" << '"' << ultimoLCDM << '"' << "}";
        cout << endl;
    }
    else
    {
         //cout << "subgraph Maletas { Maletas }" << endl;
         AgregarADot << "subgraph Maletas { Maletas }" << endl;
    }
    AgregarADot.close();
    return Retorno;

}

void ListaCircularDobleMaletas::Eliminar()
{
    bool Encontro = false;
    NodoLCDM* tmp = new NodoLCDM();
    NodoLCDM* rec = new NodoLCDM();
    rec = NULL;
    tmp = primeroLCDM;

    if(primeroLCDM != NULL)
    {
        do
        {
            //cout << "\n\n  EL DATO FUE ENCONTRADO EN LA LISTA DE MALETAS \n\n";
            Encontro = true;

            if(primeroLCDM->sig == primeroLCDM && primeroLCDM->ant == primeroLCDM)
            {
                primeroLCDM = NULL;
                break;
            }

            if(tmp == primeroLCDM)
            {
                primeroLCDM = primeroLCDM->sig;
                primeroLCDM->ant = ultimoLCDM;
                ultimoLCDM->sig = primeroLCDM;
            }
            else if(tmp == ultimoLCDM)
            {
                ultimoLCDM = rec;
                ultimoLCDM->sig = primeroLCDM;
                primeroLCDM->ant = ultimoLCDM;
            }
            else
            {
                rec->sig = tmp->sig;
                tmp->sig->ant = rec;
            }
            rec = tmp;
            tmp = tmp->sig;
        }while(tmp!=primeroLCDM&&Encontro!=true);
        if(!Encontro)
        {
            cout << "\n\n  EL DATO NO EXISTE EN LA LISTA DE MALETAS \n\n";
        }
        else
        {
            free(rec);
        }
    }
    else
    {
        cout << "\n\n LA LISTA DE ESTACIONES NO CONTIENE MALETAS \n\n";
    }
}

int ListaCircularDobleMaletas::Conteo()
{
    NodoLCDM* tmp = new NodoLCDM();
    tmp = primeroLCDM;
    int Conteo = 1;
    if(primeroLCDM != NULL)
    {
        do
        {
            tmp = tmp->sig;
            tmp->indice = Conteo;
            Conteo++;
        }while(tmp != primeroLCDM);
    }
    return Conteo;
}

bool ListaCircularDobleMaletas::EstaVacia()
{
    if(primeroLCDM == NULL){return true;}else{return false;}
}

NodoLCDM* ListaCircularDobleMaletas::SetPrimero(){return primeroLCDM;}
NodoLCDM* ListaCircularDobleMaletas::SetUltimo(){return ultimoLCDM;}
