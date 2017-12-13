#include "colapasaje.h"

ColaPasaje::ColaPasaje()
{

}

struct NodoCPAS
{
public:
    NodoCPAS* sig;
    NodoCPAS* ant;

    int maletas;
    int documentos;
    int turnos;

} *primeroCPAS, *ultimoCPAS;

void ColaPasaje::InsertarP(int m, int d, int t)
{
    NodoCPAS* nuevo = new NodoCPAS();
    nuevo->maletas = m;
    nuevo->documentos = d;
    nuevo->turnos = t;

    if(primeroCPAS == NULL)
    {
        primeroCPAS = nuevo;
        ultimoCPAS = nuevo;
        primeroCPAS->sig = primeroCPAS;
        primeroCPAS->ant = primeroCPAS;
    }
    else
    {
        ultimoCPAS->sig = nuevo;
        nuevo->ant = ultimoCPAS;
        nuevo->sig = primeroCPAS;
        ultimoCPAS = nuevo;
        primeroCPAS->ant = ultimoCPAS;
    }
}

NodoCPAS* ColaPasaje::SetPrimeroP(){return primeroCPAS;}

void ColaPasaje::EliminarP()
{
    bool Encontro = false;
    NodoCPAS* tmp = new NodoCPAS();
    NodoCPAS* rec = new NodoCPAS();
    rec = NULL;
    tmp = primeroCPAS;

    if(primeroCPAS != NULL)
    {
        do
        {
            //cout << "\n\n  EL DATO FUE ENCONTRADO EN LA LISTA DE PASAGEROS \n\n";
            Encontro = true;

            if(primeroCPAS->sig == primeroCPAS && primeroCPAS->ant == primeroCPAS)
            {
                primeroCPAS = NULL;
                break;
            }

            if(tmp == primeroCPAS)
            {
                primeroCPAS = primeroCPAS->sig;
                primeroCPAS->ant = ultimoCPAS;
                ultimoCPAS->sig = primeroCPAS;
            }
            else if(tmp == ultimoCPAS)
            {
                ultimoCPAS = rec;
                ultimoCPAS->sig = primeroCPAS;
                primeroCPAS->ant = ultimoCPAS;
            }
            else
            {
                rec->sig = tmp->sig;
                tmp->sig->ant = rec;
            }
            rec = tmp;
            tmp = tmp->sig;
        }while(tmp!=primeroCPAS&&Encontro!=true);
        if(!Encontro)
        {
            cout << "\n\n  EL DATO NO EXISTE EN LA LISTA DE PASAGEROS \n\n";
        }
        else
        {
            free(rec);
        }
    }
    else
    {
        cout << "\n\n LA LISTA DE ESTACIONES NO CONTIENE PASGEROS \n\n";
    }
}
