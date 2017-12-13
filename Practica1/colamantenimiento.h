#ifndef COLAMANTENIMIENTO_H
#define COLAMANTENIMIENTO_H

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

typedef struct NodoCM NodoCM;

class ColaMantenimiento
{

public:
    ColaMantenimiento();
    int Conteo();
    void Eliminar();
    void RecorrerMan();
    void Insertar(QString tip, int pas, int des, int man);
    bool EstaVacia();
    QString GetTipo();
    int GetPasajeros();
    int GetDesabordaje();
    int GetMantenimiento();
    NodoCM* SetPrimero();

};


#endif // COLAMANTENIMIENTO_H
