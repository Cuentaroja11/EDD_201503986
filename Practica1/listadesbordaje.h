#ifndef LISTADESBORDAJE_H
#define LISTADESBORDAJE_H

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

typedef struct NodoLDESA NodoLDESA;

class ListaDesbordaje
{
public:
    ListaDesbordaje();
    void Insertar(int m, int d, int tr);
    void RecorrerDer();
    void RecorrerIzq();
    void Eliminar();
    int Conteo();
    int LDDESAVacia = 0;
    NodoLDESA* SetPrimero();
};

#endif // LISTADESBORDAJE_H
