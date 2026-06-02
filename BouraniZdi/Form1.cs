using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouraniZdi
{
    public partial class Form1 : Form
    {
        // objekt grafiky pro kreslení

        Graphics mobjGrafika;

        // kulička
        clsKulicka mobjKulicka;

        // balonek
        clsBalonek [] mobjBalonek;
        const int cnPocetBalonku = 15;



        //------------------------------------------------
        // konstruktor
        //------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }

        //------------------------------------------------
        // nahrání folmuláře
        //------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            int lintX, lintY;
            // připojení grafiky na picturebox
            mobjGrafika = pbPlatno.CreateGraphics();

            // vytvořit kuličku
            mobjKulicka = new clsKulicka(mobjGrafika, 100, 100);

            // vytvořit indexované pole
            mobjBalonek = new clsBalonek[cnPocetBalonku];

            // vytvořit balonky
            lintX = lintY = 10;
            for (int i = 0; i < cnPocetBalonku; i++)
            { 
                // vytvořit balonek
                mobjBalonek[i] = new clsBalonek(mobjGrafika, lintX, lintY);

                // posunout x
                lintX = lintX + 60;

                // test zda nejsem za okrajem
                if (lintX+60 > pbPlatno. Width)
                {
                    lintX = 10;
                    lintY = lintY + 60;
                }
            }
            // nastartovat timer
            tmrVykreslení.Interval = 20;
            tmrVykreslení.Start();
        }




        //------------------------------------------------
        // vykreslování hry
        //------------------------------------------------

        private void tmrVykreslení_Tick(object sender, EventArgs e)
        {
            // nakresli kuličku
            mobjKulicka.NakresliSe();

            // nakresli balonky
            for (int i = 0; i < cnPocetBalonku; i++)
            {
                mobjBalonek[i].NakresliSe();
            }
        }
    }
}
