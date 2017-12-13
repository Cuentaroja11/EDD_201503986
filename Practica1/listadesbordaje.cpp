#include "listadesbordaje.h"

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

ListaDesbordaje::ListaDesbordaje()
{

}

struct NodoLDESA
{
public:
    NodoLDESA* sig;
    NodoLDESA* ant;
    int maletas;
    int documentos;
    int turnos;
} *primeroLDESA, *ultimoLDESA;

void ListaDesbordaje::Insertar(int m, int d, int tr)
{
    NodoLDESA* nuevo = new NodoLDESA();
    nuevo->maletas = m;
    nuevo->documentos = d;
    nuevo->turnos = tr;

    if(primeroLDESA == NULL)
    {
        primeroLDESA = nuevo;
        ultimoLDESA = nuevo;
        primeroLDESA->sig = primeroLDESA;
        primeroLDESA->ant = primeroLDESA;
    }
    else
    {
        ultimoLDESA->sig = nuevo;
        nuevo->ant = ultimoLDESA;
        nuevo->sig = primeroLDESA;
        ultimoLDESA = nuevo;
        primeroLDESA->ant = ultimoLDESA;
    }
}

void ListaDesbordaje::RecorrerDer()
{
    fstream AgregarADot;
    AgregarADot.open("C:\\Grafo\\Grafo.dot", ios::app);

    if(primeroLDESA != NULL)
    {
        cout<<"Grafo de Pasajeros--------------------------------------"<<endl;
        //cout << "subgraph Pasajeros { Pasajeros ";
        AgregarADot << "subgraph Pasajeros { Pasajeros ";
        NodoLDESA* tmp = new NodoLDESA();
        tmp = primeroLDESA;
        do
        {
           /*cout << "\n" << '"' << tmp << '"' << "[label=" << '"' << "Maletas: " << tmp->maletas << "\n Documentos: " << tmp->documentos <<
                   "\n Turnos: " << tmp->turnos << '"' << "]";*/
           AgregarADot << "\n" << '"' << tmp << '"' << "[label=" << '"' << "Maletas: " << tmp->maletas << "\n Documentos: " << tmp->documentos <<
                   "\n Turnos: " << tmp->turnos << '"' << "]";
           tmp = tmp->sig;
        }while(tmp != primeroLDESA);
        //cout << "\n Pasajeros";
        AgregarADot << "\n Pasajeros";
        tmp = primeroLDESA;
        do
        {
           //cout << "->" << '"' << tmp << '"';
           AgregarADot << "->" << '"' << tmp << '"';
           tmp = tmp->sig;
        }while(tmp != primeroLDESA);
        //cout << "Pasajeros}\n";
        AgregarADot << "Pasajeros}\n";
        cout << endl;
    }
    else
    {
         //cout << "subgraph Pasajeros { Pasajeros }" << endl;
         AgregarADot << "subgraph Pasajeros { Pasajeros }" << endl;
    }
    AgregarADot.close();

}

void ListaDesbordaje::RecorrerIzq()
{
    cout << "\n Pasajeros \n";
    NodoLDESA* tmp = new NodoLDESA();
    tmp = ultimoLDESA;
    if(primeroLDESA != NULL)
    {
        do
        {
            cout << '"' << tmp << '"' << "->";
            tmp = tmp->ant;
        }while(tmp != ultimoLDESA);
    }
    else
    {
        cout << "\n\n LA LISTA DE DESABORDAJE ESTA VACIA \n\n";
    }
    cout << "Pasajeros";
    cout << "}";
    cout<<"\n";
}

void ListaDesbordaje::Eliminar()
{
    bool Encontro = false;
    NodoLDESA* tmp = new NodoLDESA();
    NodoLDESA* rec = new NodoLDESA();
    rec = NULL;
    tmp = primeroLDESA;

    if(primeroLDESA != NULL)
    {
        do
        {
            //cout << "\n\n  EL DATO FUE ENCONTRADO EN LA LISTA DE DESABORDAJE \n\n";
            Encontro = true;

            if(primeroLDESA->sig == primeroLDESA && primeroLDESA->ant == primeroLDESA)
            {
                primeroLDESA = NULL;
                break;
            }

            if(tmp == primeroLDESA)
            {
                primeroLDESA = primeroLDESA->sig;
                primeroLDESA->ant = ultimoLDESA;
                ultimoLDESA->sig = primeroLDESA;
            }
            else if(tmp == ultimoLDESA)
            {
                ultimoLDESA = rec;
                ultimoLDESA->sig = primeroLDESA;
                primeroLDESA->ant = ultimoLDESA;
            }
            else
            {
                rec->sig = tmp->sig;
                tmp->sig->ant = rec;
            }
            rec = tmp;
            tmp = tmp->sig;
        }while(tmp!=primeroLDESA&&Encontro!=true);
        if(!Encontro)
        {
            LDDESAVacia = 1;
            cout << "\n\n  EL DATO NO EXISTE EN LA LISTA DE DESABORDAJE \n\n";
        }
        else
        {
            free(rec);
        }
    }
    else
    {
        LDDESAVacia = 1;
        cout << "\n\n LA LISTA DE DESABORDAJE NO CONTIENE ELEMENTOS \n\n";
    }
}

int ListaDesbordaje::Conteo()
{
    NodoLDESA* tmp = new NodoLDESA();
    tmp = primeroLDESA;
    int Conteo = 0;
    if(primeroLDESA != NULL)
    {
        do
        {
            tmp = tmp->sig;
            Conteo++;
        }while(tmp != primeroLDESA);
    }
    return Conteo;
}

NodoLDESA* ListaDesbordaje::SetPrimero(){return primeroLDESA;}
