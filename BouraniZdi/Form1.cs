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

        //hodnoty kuličky
        int mintSouradniceX, mintSouradniceY;
        int mintPosunX, mintPosunY;
        const int cnVelikost = 20;


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
            // připojení grafiky na picturebox
            mobjGrafika = pbPlatno.CreateGraphics();

            // nastavit kuličku
            mintSouradniceX = mintSouradniceY = 100;
            mintPosunX = mintPosunY = 3;

            // nastartovat timer
            tmrVykreslení.Interval = 20;
            tmrVykreslení.Start();
        }



        


        private void pbPlatno_Click(object sender, EventArgs e)
        {
            
        }



        //------------------------------------------------
        // vykreslování hry
        //------------------------------------------------

        private void tmrVykreslení_Tick(object sender, EventArgs e)
        {
            //smazání kuličky
            mobjGrafika.FillEllipse(Brushes.White, mintSouradniceX, mintSouradniceY, cnVelikost, cnVelikost);

            //posun kuličky
            mintSouradniceX = mintSouradniceX + mintPosunX;
            mintSouradniceY = mintSouradniceY + mintPosunY;

            // odraz v Y
            if ((mintSouradniceY + cnVelikost > pbPlatno.Height) || (mintSouradniceY < 0))
                mintPosunY = mintPosunY * (-1);

            // odraz v X
            if ((mintSouradniceX + cnVelikost > pbPlatno.Width) || (mintSouradniceX < 0))
                mintPosunX = mintPosunX * (-1);

            // nakreslení kuličky
            mobjGrafika.FillEllipse(Brushes.Blue, mintSouradniceX, mintSouradniceY, cnVelikost, cnVelikost);
        }
    }
}
