#include "piladocume.h"

PilaDocume::PilaDocume()
{

}

struct NodoPDOC
{
public:
    NodoPDOC* sig;
    NodoPDOC* ant;

    int indice;

} *primeroPDOC, *ultimoPDOC;

void PilaDocume::InsertarD(int i)
{
    NodoPDOC* nuevo = new NodoPDOC();
    nuevo->indice = i;


    if(primeroPDOC == NULL)
    {
        primeroPDOC = nuevo;
        ultimoPDOC = nuevo;
        primeroPDOC->sig = primeroPDOC;
        primeroPDOC->ant = primeroPDOC;
    }
    else
    {
        ultimoPDOC->sig = nuevo;
        nuevo->ant = ultimoPDOC;
        nuevo->sig = primeroPDOC;
        ultimoPDOC = nuevo;
        primeroPDOC->ant = ultimoPDOC;
    }
}

NodoPDOC* PilaDocume::SetPrimeroD(){return primeroPDOC;}

void PilaDocume::EliminarD()
{
    bool Encontro = false;
    NodoPDOC* tmp = new NodoPDOC();
    NodoPDOC* rec = new NodoPDOC();
    rec = NULL;
    tmp = primeroPDOC;

    if(primeroPDOC != NULL)
    {
        do
        {
            //cout << "\n\n  EL DATO FUE ENCONTRADO EN LA LISTA DE DOCUMENTOS \n\n";
            Encontro = true;

            if(primeroPDOC->sig == primeroPDOC && primeroPDOC->ant == primeroPDOC)
            {
                primeroPDOC = NULL;
                break;
            }

            if(tmp == primeroPDOC)
            {
                primeroPDOC = primeroPDOC->sig;
                primeroPDOC->ant = ultimoPDOC;
                ultimoPDOC->sig = primeroPDOC;
            }
            else if(tmp == ultimoPDOC)
            {
                ultimoPDOC = rec;
                ultimoPDOC->sig = primeroPDOC;
                primeroPDOC->ant = ultimoPDOC;
            }
            else
            {
                rec->sig = tmp->sig;
                tmp->sig->ant = rec;
            }
            rec = tmp;
            tmp = tmp->sig;
        }while(tmp!=primeroPDOC&&Encontro!=true);
        if(!Encontro)
        {
            cout << "\n\n  EL DATO NO EXISTE EN LA LISTA DE DOCUMENTOS \n\n";
        }
        else
        {
            free(rec);
        }
    }
    else
    {
        cout << "\n\n LA LISTA DE ESTACIONES NO CONTIENE DOCUMENTOS \n\n";
    }
}
