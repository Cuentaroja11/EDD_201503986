#include "listadobleaviones.h"

#include <string.h>
#include <iostream>
#include <fstream>
#include <mainwindow.h>
#include <cstdlib>
#include <random>
#include <ctime>
#include <QString>
#include <stdlib.h>
using namespace std;

ListaDobleAviones::ListaDobleAviones()
{

}

struct NodoLDA
{
public:
    NodoLDA* sig;
    NodoLDA* ant;
    int indice;
    QString tipo;
    int tipoint;
    int pasageros;
    int desabordaje;
    int mantenimiento;
} *primeroLDA, *ultimoLDA;

void ListaDobleAviones::Insertar(int i, QString tip, int tipi, int pas, int des, int man)
{
    NodoLDA* nuevo = new NodoLDA();
    nuevo->indice = i;
    nuevo->tipo = tip;
    nuevo->pasageros = pas;
    nuevo->desabordaje = des;
    nuevo->mantenimiento = man;

    if(primeroLDA == NULL)
    {
        primeroLDA = nuevo;
        ultimoLDA = nuevo;
        primeroLDA->sig = primeroLDA;
        primeroLDA->ant = primeroLDA;
    }
    else
    {
        ultimoLDA->sig = nuevo;
        nuevo->ant = ultimoLDA;
        nuevo->sig = primeroLDA;
        ultimoLDA = nuevo;
        primeroLDA->ant = ultimoLDA;
    }
}

void ListaDobleAviones::RecorrerDer()
{
    fstream AgregarADot;
    AgregarADot.open("C:\\Grafo\\Grafo.dot", ios::app);

    if(primeroLDA!=NULL)
    {       
        cout<<"Grafo de Aviones--------------------------------------"<<endl;
        //cout << "subgraph Aviones { Aviones ";
        AgregarADot << "subgraph Aviones { Aviones ";
        NodoLDA* tmp = new NodoLDA();
        tmp = primeroLDA;
        do
        {
           /*cout << "\n" << '"' << tmp << '"' << "[label=" << '"' << "Tipo: " << tmp->tipo.toStdString() << "\n Pasajeros: " << tmp->pasageros <<
                   "\n Desabordaje: " << tmp->desabordaje << "\n Mantenimiento: " << tmp->mantenimiento << '"' << "]";*/
           AgregarADot << "\n" << '"' << tmp << '"' << "[label=" << '"' << "Tipo: " << tmp->tipo.toStdString() << "\n Pasajeros: " << tmp->pasageros <<
                   "\n Desabordaje: " << tmp->desabordaje << "\n Mantenimiento: " << tmp->mantenimiento << '"' << "]";
           tmp = tmp->sig;
        }while(tmp != primeroLDA);
        //cout << "\n Aviones";
        AgregarADot << "\n Aviones";
        tmp = primeroLDA;
        do
        {
           //cout << "->" << '"' << tmp << '"';
           AgregarADot << "->" << '"' << tmp << '"';
           tmp = tmp->sig;
        }while(tmp != primeroLDA);
        tmp = ultimoLDA;
        //cout << "\n Aviones \n\n Aviones \n";
        AgregarADot << "\n Aviones \n\n Aviones \n";
        do
        {
            //cout << '"' << tmp << '"' << "->";
            AgregarADot << '"' << tmp << '"' << "->";
            tmp = tmp->ant;
        }while(tmp != ultimoLDA);
        //cout << "Aviones}\n";
        AgregarADot << "Aviones}\n";
        cout << endl;
    }
    else
    {
         //cout << "subgraph Aviones { Aviones }" << endl;
         AgregarADot << "subgraph Aviones { Aviones }" << endl;
    }    
    AgregarADot.close();

}

void ListaDobleAviones::RecorrerIzq()
{
    cout << "\n Aviones \n";
    NodoLDA* tmp = new NodoLDA();
    tmp = ultimoLDA;
    if(primeroLDA!=NULL)
    {
        do
        {
            cout << '"' << tmp << '"' << "->";
            tmp = tmp->ant;
        }while(tmp != ultimoLDA);
    }
    else
    {
        cout << "\n\n LA LISTA DOBLE DE AVIONES ESTA VACIA \n\n";
    }
    cout << "Aviones";
    cout << "}";
    cout<<"\n";
}

void ListaDobleAviones::Eliminar(int Dato)
{
    bool Encontro = false;
    NodoLDA* tmp = new NodoLDA();
    NodoLDA* rec = new NodoLDA();
    rec = NULL;
    tmp = primeroLDA;

    if(primeroLDA!=NULL)
    {
        do
        {
            if(tmp->indice == Dato)
            {
                //cout << "\n\n  EL DATO FUE ENCONTRADO EN LA LISTA DOBLE DE AVIONES \n\n";
                Encontro = true;

                if(primeroLDA->sig == primeroLDA && primeroLDA->ant == primeroLDA)
                {
                    primeroLDA = NULL;
                    break;
                }

                if(tmp == primeroLDA)
                {
                    primeroLDA = primeroLDA->sig;
                    primeroLDA->ant = ultimoLDA;
                    ultimoLDA->sig = primeroLDA;
                }
                else if(tmp == ultimoLDA)
                {
                    ultimoLDA = rec;
                    ultimoLDA->sig = primeroLDA;
                    primeroLDA->ant = ultimoLDA;
                }
                else
                {
                    rec->sig = tmp->sig;
                    tmp->sig->ant = rec;
                }
            }
            rec = tmp;
            tmp = tmp->sig;
        }while(tmp!=primeroLDA&&Encontro!=true);
        if(!Encontro)
        {
            LAVacia = 1;
            cout << "\n\n  EL DATO NO EXISTE EN LA LISTA DOBLE DE AVIONES \n\n";
        }
        else
        {
            free(rec);
        }
    }
    else
    {
        LAVacia = 1;
        cout << "\n\n LA LISTA DOBLE DE AVIONES NO CONTIENE ELEMENTOS \n\n";
    }
}

void ListaDobleAviones::Ordenar()
{
    NodoLDA* tmp = new NodoLDA();
    bool salir = false;
    int cambio = 1;
    tmp = primeroLDA->sig;

    int i;
    QString tip;
    int tipi;
    string prob;
    int pas;
    int des;
    int man;

    if(primeroLDA!=NULL)
    {
        while(salir == false)
        {
            if(tmp->sig != primeroLDA)
            {
                if(tmp->indice > tmp->sig->indice)
                {
                    i = tmp->indice;
                    tip = tmp->tipo;
                    tipi = tmp->tipoint;
                    pas = tmp->pasageros;
                    des = tmp->desabordaje;
                    man = tmp->mantenimiento;

                    tmp->indice = tmp->sig->indice;
                    tmp->tipo = tmp->sig->tipo;
                    tmp->tipoint = tmp->sig->tipoint;
                    tmp->pasageros = tmp->sig->pasageros;
                    tmp->desabordaje = tmp->sig->desabordaje;
                    tmp->mantenimiento = tmp->sig->mantenimiento;

                    tmp->sig->indice = i;
                    tmp->sig->tipo = tip;
                    tmp->sig->tipoint = tipi;
                    tmp->sig->pasageros = pas;
                    tmp->sig->desabordaje = des;
                    tmp->sig->mantenimiento = man;

                    cambio = cambio + 1;
                }
                tmp = tmp->sig;
            }
            else
            {
                if(cambio == 0){salir = true;}
                cambio = 0;
                tmp = tmp->sig;
            }
        }
    }
    else
    {
        cout << "\n\n LA LISTA DOBLE DE AVIONES NO CONTIENE ELEMENTOS \n\n";
    }
    cout << "\n\n ORDENAMIENTO DE LA LISTA DOBLE DE AVIONES REALIZADO \n\n";
}

bool ListaDobleAviones::EstaVacia()
{
    if(primeroLDA == NULL){return true;}else{return false;}
}

int ListaDobleAviones::Desabordajes()
{
    NodoLDA* tmp = new NodoLDA();
    tmp = primeroLDA;
    return tmp->desabordaje;
}

int ListaDobleAviones::Pasajeros()
{
    NodoLDA* tmp = new NodoLDA();
    tmp = primeroLDA;
    return tmp->pasageros;
}

int ListaDobleAviones::Conteo()
{
    NodoLDA* tmp = new NodoLDA();
    tmp = primeroLDA;
    int Conteo = 0;
    if(primeroLDA!=NULL)
    {
        do
        {
            tmp = tmp->sig;
            Conteo++;
        }while(tmp != primeroLDA);
    }
    return Conteo;
}

NodoLDA* ListaDobleAviones::SetPrimero(){return primeroLDA;}
