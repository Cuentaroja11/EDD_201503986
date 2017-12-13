#ifndef LISTADEESCRITORIOS_H
#define LISTADEESCRITORIOS_H

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

#include <colapasaje.h>
#include <piladocume.h>

typedef struct NodoLDE NodoLDE;

class ListaDeEscritorios
{
public:
    ListaDeEscritorios();
    void InsertarE(int i, int c, int m, int d, int t);
    NodoLDE* SetPrimeroE();
    void EliminarE();
    QString RecorrerDer();    
    ColaPasaje* Cola;
    PilaDocume* Pila;
};

#endif // LISTADEESCRITORIOS_H
