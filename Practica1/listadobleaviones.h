#ifndef LISTADOBLEAVIONES_H
#define LISTADOBLEAVIONES_H

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

typedef struct NodoLDA NodoLDA;

class ListaDobleAviones
{
public:
    ListaDobleAviones();
    void Insertar(int i, QString tip, int tipi, int pas, int des, int man);
    void RecorrerDer();
    void RecorrerIzq();
    void Eliminar(int Dato);
    void Ordenar();
    int Conteo();
    bool EstaVacia();
    int Desabordajes();
    int Pasajeros();
    int LAVacia = 0;
    NodoLDA* SetPrimero();
};

#endif // LISTADOBLEAVIONES_H
