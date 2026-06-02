using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouraniZdi
{
    internal class clsKulicka
    {

        // objekt grafiky pro kreslení

        Graphics mobjGrafika;


        //hodnoty kuličky
        int mintSouradniceX, mintSouradniceY;
        int mintPosunX, mintPosunY;
        const int cnVelikost = 20;


        //-----------------------------------
        // konstruktor
        //-----------------------------------

        public clsKulicka(Graphics objGrafika, int intX, int intY)
        {
            mobjGrafika = objGrafika;
            mintSouradniceX = intX;
            mintSouradniceY = intY;

            mintPosunX = mintPosunY = 3;
        }

        //-----------------------------------
        // nakreslení kuličky
        //-----------------------------------
        public void NakresliSe()
        {
            //smazání kuličky
            mobjGrafika.FillEllipse(Brushes.White, mintSouradniceX, mintSouradniceY, cnVelikost, cnVelikost);

            //posun kuličky
            mintSouradniceX = mintSouradniceX + mintPosunX;
            mintSouradniceY = mintSouradniceY + mintPosunY;

            // odraz v Y
            if ((mintSouradniceY + cnVelikost > mobjGrafika.VisibleClipBounds.Height) || (mintSouradniceY < 0))
                mintPosunY = mintPosunY * (-1);

            // odraz v X
            if ((mintSouradniceX + cnVelikost > mobjGrafika.VisibleClipBounds.Width) || (mintSouradniceX < 0))
                mintPosunX = mintPosunX * (-1);

            // nakreslení kuličky
            mobjGrafika.FillEllipse(Brushes.Blue, mintSouradniceX, mintSouradniceY, cnVelikost, cnVelikost);
        }
    }
}
