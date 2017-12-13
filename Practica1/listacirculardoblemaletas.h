#ifndef LISTACIRCULARDOBLEMALETAS_H
#define LISTACIRCULARDOBLEMALETAS_H

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

typedef struct NodoLCDM NodoLCDM;

class ListaCircularDobleMaletas
{
public:
    ListaCircularDobleMaletas();
    int Conteo();
    void Eliminar();
    QString RecorrerDer();
    void Insertar(int i);
    bool EstaVacia();
    NodoLCDM* SetPrimero();
    NodoLCDM* SetUltimo();
};

#endif // LISTACIRCULARDOBLEMALETAS_H
