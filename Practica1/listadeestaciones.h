#ifndef LISTADEESTACIONES_H
#define LISTADEESTACIONES_H

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

typedef struct NodoLM NodoLM;

class ListaDeEstaciones
{
public:
    ListaDeEstaciones();
    int Conteo();
    void Eliminar();
    QString RecorrerDer();
    void Insertar(int i, QString tip, int tipi, int pas, int des, int man, int c);
    bool EstaVacia();
    NodoLM* SetPrimero();
};

#endif // LISTADEESTACIONES_H
