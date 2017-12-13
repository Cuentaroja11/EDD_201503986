#include "mainwindow.h"
#include "ui_mainwindow.h"

#include "listadobleaviones.h"
#include "listadesbordaje.h"
#include "listadeestaciones.h"
#include "colamantenimiento.h"
#include "listacirculardoblemaletas.h"
#include "listadeescritorios.h"

#include <iostream>
#include <cstdlib>
#include <random>
#include <ctime>
#include <QString>
#include <fstream>
#include <stdlib.h>
using namespace std;

int clicksiguinete, turnoactual, cantclientes, maletas, documentos, turnos, EstacionesMantenimiento, Escritorios = 0;
int indicecliente, avionprimero = 1;
QString SGrafoAviones = "subgraph Aviones { Aviones ";
QString SGrafoFinal = "digraph grafo {";
QString Historial="";

ListaDobleAviones ListaDeAviones;
ListaDesbordaje ListaDeDesabordaje;
ListaDeEstaciones ListaEstaciones;
ListaDeEstaciones ListaMantenimiento;
ColaMantenimiento ColaDeMantenimiento;
ListaCircularDobleMaletas ListaDeMaletas;
ListaDeEscritorios ListaEscritorios;

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

struct NodoCM
{

    NodoCM* sig;
    NodoCM* ant;
    QString tipo;
    int pasageros;
    int desabordaje;
    int mantenimiento;

};

struct NodoLM
{
public:
    NodoLM* sig;
    NodoLM* ant;
    int indice;
    int conteo;
    QString tipo;
    int tipoint;
    int pasageros;
    int desabordaje;
    int mantenimiento;
};

struct NodoLDA
{
public:
    NodoLDA* sig;
    NodoLDA* ant;
    int indice;
    QString tipo;
    int tipoint;
    int pasageros;
    int desabordaje;
    int mantenimiento;
};

struct NodoPDOC
{
public:
    NodoPDOC* sig;
    NodoPDOC* ant;

    int indice;

};

struct NodoCPAS
{
public:
    NodoCPAS* sig;
    NodoCPAS* ant;

    int maletas;
    int documentos;
    int turnos;

};

struct NodoLDE
{
public:
    NodoLDE* sig;
    NodoLDE* ant;
    int indice;
    int conteo;

    int maletas;
    int documentos;
    int turnos;
};

struct NodoLDESA
{
public:
    NodoLDESA* sig;
    NodoLDESA* ant;
    int maletas;
    int documentos;
    int turnos;
};

struct NodoLCDM
{
public:
    NodoLCDM* sig;
    NodoLCDM* ant;
    int indice;
};

void MainWindow::on_pushButton_clicked()
{
    ofstream ArchivoDot;
    ArchivoDot.open("C:\\Grafo\\Grafo.dot");
    ArchivoDot << "digraph Grafo{";
    ArchivoDot.close();

    for(int i = 0; i<10; i++)
    {
        ListaDeDesabordaje.Insertar(i+1,i+1,i+1);
    }

    ListaDeDesabordaje.RecorrerDer();

    for(int i = 0; i < 3; i++)
    {
        ListaEscritorios.InsertarE(i+1,0,0,0,0);
    }

    ListaEscritorios.RecorrerDer();

    /*for(int i = 0; i<4; i++)
    {
        ListaDeMaletas.Insertar(i);
    }

    ListaDeMaletas.RecorrerDer();*/

    fstream AgregarADot;
    AgregarADot.open("C:\\Grafo\\Grafo.dot", ios::app);
    AgregarADot << "}";
    AgregarADot.close();
    system("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\Grafo.dot -o C:\\Grafo\\Grafo.png");    

}

void MainWindow::InsercionAleatoria()
{
    srand(time(0));
    QString stipo;

    int tip = 1 + rand()%3;
    if(tip==1){stipo="Pequeno";}
    if(tip==2){stipo="Mediano";}
    if(tip==3){stipo="Grande";}
    int pasajeros = 0;
    while(true)
    {
        int p = 1 + rand()%40;
        if(tip==1)
        {
            if(p>4 && p<11)
            {
                pasajeros = p;
                break;
            }
        }
        if(tip==2)
        {
            if(p>14 && p<26)
            {
                pasajeros = p;
                break;
            }
        }
        if(tip==3)
        {
            if(p>29 && p<41)
            {
                pasajeros = p;
                break;
            }
        }
    }
    int desabordaje = tip;
    int mantenimiento = 0;
    while(true)
    {
        int m = 1 + rand()%6;
        if(tip==1)
        {
            if(m<4)
            {
                mantenimiento = m;
                break;
            }
        }
        if(tip==2)
        {
            if(m>1 && m<5)
            {
                mantenimiento = m;
                break;
            }
        }
        if(tip==3)
        {
            if(m>2 && m<7)
            {
                mantenimiento = m;
                break;
            }
        }
    }

    ui->label_9->setText(stipo);
    ui->label_10->setText("X");
    QString pas = QString::number(pasajeros);
    ui->label_11->setText(pas);
    QString des = QString::number(desabordaje);
    ui->label_12->setText(des);
    QString man = QString::number(mantenimiento);
    ui->label_13->setText(man);

    ListaDeAviones.Insertar(clicksiguinete,stipo,tip,pasajeros,desabordaje,mantenimiento);
}

void MainWindow::on_pushButton_2_clicked()
{
    QString temp = ui->lineEdit_2->text();
    int maxaviones = temp.toInt();
    QString temp2 = ui->lineEdit->text();
    int maxturnos = temp2.toInt();

    clicksiguinete++;
    QString clicsig = QString::number(clicksiguinete);
    ui->label_8->setText(clicsig);

    ofstream ArchivoDot;
    ArchivoDot.open("C:\\Grafo\\Grafo.dot");
    ArchivoDot << "digraph Grafo{";
    ArchivoDot.close();

    if(maxaviones>=clicksiguinete)
    {
        InsercionAleatoria();
        ui->label_19->setText(clicsig);
    }

    if(maxturnos>=clicksiguinete)
    {
    Historial = ui->textEdit->toPlainText();
    Historial += "**************** Turno: " + clicsig + " *****************\n";
    }

    cout << endl;

    cout << "Tamano: " << ListaDeAviones.Conteo() << endl;

    if(!ListaDeAviones.EstaVacia())
    {
        turnoactual++;
        int turnoespera = ListaDeAviones.Desabordajes();
        cout << "Esperar turnos desabordaje: " << turnoactual << " de " << turnoespera << endl;

        if(maxturnos>=clicksiguinete)
        {
            if(turnoactual>=turnoespera)
            {
                cout << "Avion: " << avionprimero << endl;
                cantclientes = ListaDeAviones.Pasajeros();
                for(int i = 0; i < cantclientes; i++)
                {
                    srand(time(0));

                    int m = 1 + rand()%4;
                    int d = 1 + rand()%10;
                    int tr = 1 + rand()%3;

                    ListaDeDesabordaje.Insertar(m,d,tr);
                }

                cantclientes = 0;
                NodoLDA* inicioLDA = ListaDeAviones.SetPrimero();
                ColaDeMantenimiento.Insertar(inicioLDA->tipo,inicioLDA->pasageros,inicioLDA->desabordaje,inicioLDA->mantenimiento);
                ListaDeAviones.Eliminar(avionprimero);
                avionprimero++;
                turnoactual = 0;
            }
        }
    }

    ListaDeAviones.RecorrerDer();

    if(maxturnos>=clicksiguinete)
    {
        ui->label_23->setText(clicsig);

        NodoCM* inicioCM = ColaDeMantenimiento.SetPrimero();
        NodoLM* inicioLM = ListaEstaciones.SetPrimero();
        NodoLM* finalLM = ListaEstaciones.SetPrimero();

        if(inicioLM!=NULL)
        {
            do
            {
                if(inicioLM->conteo==inicioLM->mantenimiento)
                {
                    if(inicioCM!=NULL)
                    {
                        inicioLM->desabordaje=inicioCM->desabordaje;
                        inicioLM->mantenimiento=inicioCM->mantenimiento;
                        inicioLM->pasageros=inicioCM->pasageros;
                        inicioLM->tipo=inicioCM->tipo;
                        ColaDeMantenimiento.Eliminar();
                        inicioCM = ColaDeMantenimiento.SetPrimero();
                    }
                    else
                    {
                        inicioLM->desabordaje=0;
                        inicioLM->mantenimiento=0;
                        inicioLM->pasageros=0;
                        inicioLM->tipo="X";
                    }
                    inicioLM->conteo=0;
                }
                if(inicioLM->conteo<inicioLM->mantenimiento)
                {
                    inicioLM->conteo++;
                }
                inicioLM = inicioLM->sig;

            }while(inicioLM!=finalLM);
        }
    }

    NodoLDESA* inicioLDESA = ListaDeDesabordaje.SetPrimero();
    NodoLDE* inicioLDE = ListaEscritorios.SetPrimeroE();
    NodoLDE* finalLDE = ListaEscritorios.SetPrimeroE();

    if(inicioLDE!=NULL)
    {
        do
        {
            if(inicioLDE->conteo==inicioLDE->turnos)
            {
                for(int i=1;i<=inicioLDE->maletas;i++)
                {
                    ListaDeMaletas.Eliminar();
                }
                if(inicioLDESA!=NULL)
                {
                    inicioLDE->documentos=inicioLDESA->documentos;
                    inicioLDE->maletas=inicioLDESA->maletas;
                    inicioLDE->turnos=inicioLDESA->turnos;
                    for(int i=1;i<=inicioLDE->maletas;i++)
                    {
                        ListaDeMaletas.Insertar(i);
                    }
                    ListaDeDesabordaje.Eliminar();
                    inicioLDESA = ListaDeDesabordaje.SetPrimero();
                }
                else
                {
                    inicioLDE->documentos=0;
                    inicioLDE->maletas=0;
                    inicioLDE->turnos=0;
                }
                inicioLDE->conteo=0;
            }
            if(inicioLDE->conteo<inicioLDE->turnos)
            {
                inicioLDE->conteo++;
            }
            inicioLDE = inicioLDE->sig;

        }while(inicioLDE!=finalLDE);
    }
    ListaDeMaletas.Conteo();
    NodoLCDM* TotalMaletas = ListaDeMaletas.SetUltimo();
    int TTM;
    if(TotalMaletas!=NULL){TTM = TotalMaletas->indice + 1;}else{TTM=0;}

    ListaDeMaletas.RecorrerDer();
    ListaDeDesabordaje.RecorrerDer();
    QString Escritorios = ListaEscritorios.RecorrerDer();

    ColaDeMantenimiento.RecorrerMan();
    QString Estaciones = ListaEstaciones.RecorrerDer();
    //ListaDeDesabordaje.RecorrerDer();
    //ListaEstaciones.RecorrerDer();

    Historial += Escritorios;
    Historial += Estaciones;
    int TR = maxturnos - clicksiguinete;
    QString TurRes = QString::number(TR);
    QString STTM = QString::number(TTM);
    Historial += "Maletas en el sistema: " + STTM + "\n";
    Historial += "Turnos Restantes: " + TurRes + "\n";
    Historial += "*************** Fin Turno: " + clicsig + " ***************\n\n";
    ui->textEdit->setText(Historial);

    fstream AgregarADot;
    AgregarADot.open("C:\\Grafo\\Grafo.dot", ios::app);
    AgregarADot << "}";
    AgregarADot.close();
    system("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\Grafo.dot -o C:\\Grafo\\Grafo.png");
    QPixmap rutagrafo("C:/Grafo/Grafo.png");
    ui->label_27->setPixmap(rutagrafo);
}

void MainWindow::on_pushButton_3_clicked()
{
    ui->lineEdit->setDisabled(true);
    ui->lineEdit_2->setDisabled(true);
    ui->lineEdit_3->setDisabled(true);
    ui->lineEdit_4->setDisabled(true);
    QString totalaviones = ui->lineEdit_2->text();
    ui->label_21->setText(totalaviones);
    QString totalturnos = ui->lineEdit->text();
    ui->label_25->setText(totalturnos);
    ui->pushButton_3->setDisabled(true);

    EstacionesMantenimiento = ui->lineEdit_4->text().toInt();
    for(int i = 0; i < EstacionesMantenimiento; i++)
    {
        ListaEstaciones.Insertar(i+1, "X",0,0,0,0,0);
    }
    Escritorios = ui->lineEdit_3->text().toInt();
    for(int i = 0; i < EstacionesMantenimiento; i++)
    {
        ListaEscritorios.InsertarE(i+1,0,0,0,0);
    }
}

void MainWindow::on_pushButton_4_clicked()
{
    ofstream ArchivoDot;
    ArchivoDot.open("C:\\Grafo\\Grafo.dot");
    ArchivoDot << "digraph Grafo{";
    ArchivoDot.close();

    /*NodoLDESA* inicioCM = ListaDeDesabordaje.SetPrimero();  ColaDeMantenimiento.SetPrimero();
    NodoLDE* inicioLM = ListaEscritorios.SetPrimeroE();
    NodoLDE* finalLM = ListaEscritorios.SetPrimeroE();*/

    NodoLDESA* inicioLDESA = ListaDeDesabordaje.SetPrimero();
    NodoLDE* inicioLDE = ListaEscritorios.SetPrimeroE();
    NodoLDE* finalLDE = ListaEscritorios.SetPrimeroE();

    if(inicioLDE!=NULL)
    {
        do
        {
            if(inicioLDE->conteo==inicioLDE->turnos)
            {
                for(int i=1;i<=inicioLDE->maletas;i++)
                {
                    ListaDeMaletas.Eliminar();
                }
                if(inicioLDESA!=NULL)
                {
                    inicioLDE->documentos=inicioLDESA->documentos;
                    inicioLDE->maletas=inicioLDESA->maletas;
                    inicioLDE->turnos=inicioLDESA->turnos;
                    for(int i=1;i<=inicioLDE->maletas;i++)
                    {
                        ListaDeMaletas.Insertar(i);
                    }
                    ListaDeDesabordaje.Eliminar();
                    inicioLDESA = ListaDeDesabordaje.SetPrimero();
                }
                else
                {
                    inicioLDE->documentos=0;
                    inicioLDE->maletas=0;
                    inicioLDE->turnos=0;
                }
                inicioLDE->conteo=0;
            }
            if(inicioLDE->conteo<inicioLDE->turnos)
            {
                inicioLDE->conteo++;
            }
            inicioLDE = inicioLDE->sig;

        }while(inicioLDE!=finalLDE);
    }
    ListaDeMaletas.Conteo();
    NodoLCDM* TotalMaletas = ListaDeMaletas.SetUltimo();
    int TTM;
    if(TotalMaletas!=NULL){TTM = TotalMaletas->indice + 1;}else{TTM=0;}
    cout<<"Maletas: "<<TTM + 1<<endl;

    ListaDeMaletas.RecorrerDer();
    ListaDeDesabordaje.RecorrerDer();
    ListaEscritorios.RecorrerDer();

    /*ListaDeMaletas.Eliminar();
    ListaDeMaletas.RecorrerDer();*/

    fstream AgregarADot;
    AgregarADot.open("C:\\Grafo\\Grafo.dot", ios::app);
    AgregarADot << "}";
    AgregarADot.close();
    system("\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\" -Tpng C:\\Grafo\\Grafo.dot -o C:\\Grafo\\Grafo.png");
    cout<<endl;

}
