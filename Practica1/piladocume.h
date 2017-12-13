#ifndef PILADOCUME_H
#define PILADOCUME_H

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

typedef struct NodoPDOC NodoPDOC;

class PilaDocume
{
public:
    PilaDocume();
    void InsertarD(int i);
    NodoPDOC* SetPrimeroD();
    void EliminarD();
};

#endif // PILADOCUME_H
