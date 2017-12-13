#include "colamantenimiento.h"

ColaMantenimiento::ColaMantenimiento()
{

}

struct NodoCM
{

    NodoCM* sig;
    NodoCM* ant;
    QString tipo;
    int pasageros;
    int desabordaje;
    int mantenimiento;

} *primeroCM, *ultimoCM;

void ColaMantenimiento::Insertar(QString tip, int pas, int des, int man)
{
    NodoCM* nuevo = new NodoCM();
    nuevo->tipo = tip;
    nuevo->pasageros = pas;
    nuevo->desabordaje = des;
    nuevo->mantenimiento = man;

    if(primeroCM == NULL)
    {
        primeroCM = nuevo;
        ultimoCM = nuevo;
        primeroCM->sig = primeroCM;
        primeroCM->ant = primeroCM;
    }
    else
    {
        ultimoCM->sig = nuevo;
        nuevo->ant = ultimoCM;
        nuevo->sig = primeroCM;
        ultimoCM = nuevo;
        primeroCM->ant = ultimoCM;
    }
}

void ColaMantenimiento::RecorrerMan()
{
    fstream AgregarADot;
    AgregarADot.open("C:\\Grafo\\Grafo.dot", ios::app);

    if(primeroCM != NULL)
    {
        cout<<"Grafo de Cola de Mantenimiento--------------------------------------"<<endl;
        //cout << "subgraph ColaMantenimiento { ColaMantenimiento ";
        AgregarADot << "subgraph ColaMantenimiento { ColaMantenimiento ";
        NodoCM* tmp = new NodoCM();
        tmp = primeroCM;
        do
        {
           AgregarADot << "\n" << '"' << tmp << '"' << "[label=" << '"' << "\n Tipo: " << tmp->tipo.toStdString() << "\n Pasajeros: " <<
                   tmp->pasageros << "\n Desabordaje: " << tmp->desabordaje << "\n Mantenimiento: " << tmp->mantenimiento << '"' << "]";
           tmp = tmp->sig;
        }while(tmp != primeroCM);
        //cout << "\n ColaMantenimiento";
        AgregarADot << "\n ColaMantenimiento";
        tmp = primeroCM;
        do
        {
           //cout << "->" << '"' << tmp << '"';
           AgregarADot << "->" << '"' << tmp << '"';
           tmp = tmp->sig;
        }while(tmp != primeroCM);
        tmp = ultimoCM;
        //cout << "\n ColaMantenimiento \n";
        AgregarADot << "\n Estaciones \n";
        do
        {
            //cout << '"' << tmp << '"' << "->";
            AgregarADot << '"' << tmp << '"' << "->";
            tmp = tmp->ant;
        }while(tmp != ultimoCM);
        //cout << "ColaMantenimiento}\n";
        AgregarADot << "ColaMantenimiento}\n";
        cout << endl;
    }
    else
    {
         //cout << "subgraph ColaMantenimiento { ColaMantenimiento }" << endl;
         AgregarADot << "subgraph ColaMantenimiento { ColaMantenimiento }" << endl;
    }
    AgregarADot.close();

}

void ColaMantenimiento::Eliminar()
{
    bool Encontro = false;
    NodoCM* tmp = new NodoCM();
    NodoCM* rec = new NodoCM();
    rec = NULL;
    tmp = primeroCM;

    if(primeroCM != NULL)
    {
        do
        {
            //cout << "\n\n  EL DATO FUE ENCONTRADO EN LA COLA DE MANTENIMIENTO \n\n";
            Encontro = true;

            if(primeroCM->sig == primeroCM && primeroCM->ant == primeroCM)
            {
                primeroCM = NULL;
                break;
            }

            if(tmp == primeroCM)
            {
                primeroCM = primeroCM->sig;
                primeroCM->ant = ultimoCM;
                ultimoCM->sig = primeroCM;
            }
            else if(tmp == ultimoCM)
            {
                ultimoCM = rec;
                ultimoCM->sig = primeroCM;
                primeroCM->ant = ultimoCM;
            }
            else
            {
                rec->sig = tmp->sig;
                tmp->sig->ant = rec;
            }
            rec = tmp;
            tmp = tmp->sig;
        }while(tmp!=primeroCM&&Encontro!=true);
        if(!Encontro)
        {
            cout << "\n\n  EL DATO NO EXISTE EN LA COLA DE MANTENIMIENTO \n\n";
        }
        else
        {
            free(rec);
        }
    }
    else
    {
        cout << "\n\n LA COLA DE MANTENIMIENTO NO CONTIENE ELEMENTOS \n\n";
    }
}

int ColaMantenimiento::Conteo()
{
    NodoCM* tmp = new NodoCM();
    tmp = primeroCM;
    int Conteo = 0;
    if(primeroCM != NULL)
    {
        do
        {
            tmp = tmp->sig;
            Conteo++;
        }while(tmp != primeroCM);
    }
    return Conteo;
}

bool ColaMantenimiento::EstaVacia()
{
    if(primeroCM == NULL){return true;}else{return false;}
}

QString ColaMantenimiento::GetTipo(){if(!primeroCM == NULL){primeroCM->tipo;}else{return NULL;}}
int ColaMantenimiento::GetPasajeros(){if(!primeroCM == NULL){primeroCM->pasageros;}else{return NULL;}}
int ColaMantenimiento::GetDesabordaje(){if(!primeroCM == NULL){primeroCM->desabordaje;}else{return NULL;}}
int ColaMantenimiento::GetMantenimiento(){if(!primeroCM == NULL){primeroCM->mantenimiento;}else{return NULL;}}

NodoCM* ColaMantenimiento::SetPrimero(){return primeroCM;}
