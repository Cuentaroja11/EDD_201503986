#include "mainwindow.h"
#include <QApplication>

#include <iostream>
#include <cstdlib>
#include <random>
#include <ctime>
#include <QString>
#include <fstream>
#include <stdlib.h>
using namespace std;

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.show();

    return a.exec();
}
