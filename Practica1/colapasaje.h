#ifndef COLAPASAJE_H
#define COLAPASAJE_H

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

typedef struct NodoCPAS NodoCPAS;

class ColaPasaje
{
public:
    ColaPasaje();
    void InsertarP(int m, int d, int t);
    NodoCPAS* SetPrimeroP();
    void EliminarP();
};

#endif // COLAPASAJE_H
