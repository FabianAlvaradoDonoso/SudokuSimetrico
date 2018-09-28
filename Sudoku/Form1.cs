using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Sudoku.Clases;


namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            eventosHoverGray();
            eventosHoverFire();
            eventosLeaveGray();
            eventosLeaveFire();
        }

        tableroSudoku s = new tableroSudoku(5);
        int cantidadfallos = 0;
        int solucionesTotales;
        int solucionesExitosas;

        

        private void Form1_Load(object sender, EventArgs e)
        {
            CrearSudoku(ref s);
            btnVolverLlenar.Enabled = false;
        }

        public void CrearSudoku(ref tableroSudoku s)
        {
            s = new tableroSudoku(5);

            int[,] arrayTablero = s.imprimeTablero();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Label current = (Label)this.Controls.Find("C" + i + "_" + j, true)[0];
                    current.Text = arrayTablero[i, j].ToString();
                }
            }
        }

        public void revelar(ref tableroSudoku s)
        {
            int[,] arrayTablero = s.casillasInversas();

            if(s.cantSoluciones(0,0,0) == 1)
            {
                imprimir(arrayTablero);
                solucionesExitosas++;
                solucionesTotales++;
                lblSolucion.Text = "Solución Única";
                lblExito.Text = solucionesExitosas.ToString();
                lblTotales.Text = solucionesTotales.ToString();
            }
            else
            {
                imprimir(arrayTablero);
                cantidadfallos++;
                solucionesTotales++;
                lblSolucion.Text = "Sin Solución Única";
                lblFallas.Text = cantidadfallos.ToString();
                lblTotales.Text = solucionesTotales.ToString();
            }

        }

        void imprimir(int[,] arrayTablero)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Label current = (Label)this.Controls.Find("C" + i + "_" + j, true)[0];
                    current.Text = arrayTablero[i, j].ToString();
                    if (arrayTablero[i, j].ToString() == "0") current.Text = "";

                }
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnVolverLlenar.PerformClick();
            CrearSudoku(ref s);
            lblSolucion.Text = "";
            cantidadfallos = 0;
            solucionesTotales = 0;
            solucionesExitosas = 0;
            lblFallas.Text = cantidadfallos.ToString();
            lblExito.Text = solucionesExitosas.ToString();
            lblTotales.Text = solucionesTotales.ToString();
        }

        private void btnRevelar_Click(object sender, EventArgs e)
        {
            revelar(ref s);
            btnRevelar.Enabled = false;
            btnVolverLlenar.Enabled = true;
        }

        private void btnVolverLlenar_Click(object sender, EventArgs e)
        {
            lblSolucion.Text = "";
            s.volverALlenar(0, 0);
            imprimir(s.imprimeTablero());

            btnRevelar.Enabled = true;
            btnVolverLlenar.Enabled = false;

        }


        //-------------------------- D E C O R A C I Ó N -------------------------\\

        void eventosHoverGray()
        {
            C0_0.MouseHover += new EventHandler(C0_0_MouseHover);
            C0_1.MouseHover += new EventHandler(C0_0_MouseHover);
            C0_2.MouseHover += new EventHandler(C0_0_MouseHover);
            C0_6.MouseHover += new EventHandler(C0_0_MouseHover);
            C0_7.MouseHover += new EventHandler(C0_0_MouseHover);
            C0_8.MouseHover += new EventHandler(C0_0_MouseHover);

            C1_0.MouseHover += new EventHandler(C0_0_MouseHover);
            C1_1.MouseHover += new EventHandler(C0_0_MouseHover);
            C1_2.MouseHover += new EventHandler(C0_0_MouseHover);
            C1_6.MouseHover += new EventHandler(C0_0_MouseHover);
            C1_7.MouseHover += new EventHandler(C0_0_MouseHover);
            C1_8.MouseHover += new EventHandler(C0_0_MouseHover);

            C2_0.MouseHover += new EventHandler(C0_0_MouseHover);
            C2_1.MouseHover += new EventHandler(C0_0_MouseHover);
            C2_2.MouseHover += new EventHandler(C0_0_MouseHover);
            C2_6.MouseHover += new EventHandler(C0_0_MouseHover);
            C2_7.MouseHover += new EventHandler(C0_0_MouseHover);
            C2_8.MouseHover += new EventHandler(C0_0_MouseHover);

            C3_3.MouseHover += new EventHandler(C0_0_MouseHover);
            C3_4.MouseHover += new EventHandler(C0_0_MouseHover);
            C3_5.MouseHover += new EventHandler(C0_0_MouseHover);
            C4_3.MouseHover += new EventHandler(C0_0_MouseHover);
            C4_4.MouseHover += new EventHandler(C0_0_MouseHover);
            C4_5.MouseHover += new EventHandler(C0_0_MouseHover);
            C5_3.MouseHover += new EventHandler(C0_0_MouseHover);
            C5_4.MouseHover += new EventHandler(C0_0_MouseHover);
            C5_5.MouseHover += new EventHandler(C0_0_MouseHover);

            C6_0.MouseHover += new EventHandler(C0_0_MouseHover);
            C6_1.MouseHover += new EventHandler(C0_0_MouseHover);
            C6_2.MouseHover += new EventHandler(C0_0_MouseHover);
            C6_6.MouseHover += new EventHandler(C0_0_MouseHover);
            C6_7.MouseHover += new EventHandler(C0_0_MouseHover);
            C6_8.MouseHover += new EventHandler(C0_0_MouseHover);

            C7_0.MouseHover += new EventHandler(C0_0_MouseHover);
            C7_1.MouseHover += new EventHandler(C0_0_MouseHover);
            C7_2.MouseHover += new EventHandler(C0_0_MouseHover);
            C7_6.MouseHover += new EventHandler(C0_0_MouseHover);
            C7_7.MouseHover += new EventHandler(C0_0_MouseHover);
            C7_8.MouseHover += new EventHandler(C0_0_MouseHover);

            C8_0.MouseHover += new EventHandler(C0_0_MouseHover);
            C8_1.MouseHover += new EventHandler(C0_0_MouseHover);
            C8_2.MouseHover += new EventHandler(C0_0_MouseHover);
            C8_6.MouseHover += new EventHandler(C0_0_MouseHover);
            C8_7.MouseHover += new EventHandler(C0_0_MouseHover);
            C8_8.MouseHover += new EventHandler(C0_0_MouseHover);


        }
        void eventosHoverFire()
        {
            C0_3.MouseHover += new EventHandler(C0_0_MouseHover);
            C0_4.MouseHover += new EventHandler(C0_0_MouseHover);
            C0_5.MouseHover += new EventHandler(C0_0_MouseHover);
            C1_3.MouseHover += new EventHandler(C0_0_MouseHover);
            C1_4.MouseHover += new EventHandler(C0_0_MouseHover);
            C1_5.MouseHover += new EventHandler(C0_0_MouseHover);
            C2_3.MouseHover += new EventHandler(C0_0_MouseHover);
            C2_4.MouseHover += new EventHandler(C0_0_MouseHover);
            C2_5.MouseHover += new EventHandler(C0_0_MouseHover);

            C3_0.MouseHover += new EventHandler(C0_0_MouseHover);
            C3_1.MouseHover += new EventHandler(C0_0_MouseHover);
            C3_2.MouseHover += new EventHandler(C0_0_MouseHover);
            C3_6.MouseHover += new EventHandler(C0_0_MouseHover);
            C3_7.MouseHover += new EventHandler(C0_0_MouseHover);
            C3_8.MouseHover += new EventHandler(C0_0_MouseHover);

            C4_0.MouseHover += new EventHandler(C0_0_MouseHover);
            C4_1.MouseHover += new EventHandler(C0_0_MouseHover);
            C4_2.MouseHover += new EventHandler(C0_0_MouseHover);
            C4_6.MouseHover += new EventHandler(C0_0_MouseHover);
            C4_7.MouseHover += new EventHandler(C0_0_MouseHover);
            C4_8.MouseHover += new EventHandler(C0_0_MouseHover);
        
            C5_0.MouseHover += new EventHandler(C0_0_MouseHover);
            C5_1.MouseHover += new EventHandler(C0_0_MouseHover);
            C5_2.MouseHover += new EventHandler(C0_0_MouseHover);
            C5_6.MouseHover += new EventHandler(C0_0_MouseHover);
            C5_7.MouseHover += new EventHandler(C0_0_MouseHover);
            C5_8.MouseHover += new EventHandler(C0_0_MouseHover);

            C6_3.MouseHover += new EventHandler(C0_0_MouseHover);
            C6_4.MouseHover += new EventHandler(C0_0_MouseHover);
            C6_5.MouseHover += new EventHandler(C0_0_MouseHover);
            C7_3.MouseHover += new EventHandler(C0_0_MouseHover);
            C7_4.MouseHover += new EventHandler(C0_0_MouseHover);
            C7_5.MouseHover += new EventHandler(C0_0_MouseHover);
            C8_3.MouseHover += new EventHandler(C0_0_MouseHover);
            C8_4.MouseHover += new EventHandler(C0_0_MouseHover);
            C8_5.MouseHover += new EventHandler(C0_0_MouseHover);
        }
        void eventosLeaveGray()
        {
            C0_0.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C0_0.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C0_1.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C0_2.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C0_6.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C0_7.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C0_8.MouseLeave += new EventHandler(C0_0_MouseLeave);

            C1_0.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C1_1.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C1_2.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C1_6.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C1_7.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C1_8.MouseLeave += new EventHandler(C0_0_MouseLeave);

            C2_0.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C2_1.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C2_2.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C2_6.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C2_7.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C2_8.MouseLeave += new EventHandler(C0_0_MouseLeave);

            C3_3.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C3_4.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C3_5.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C4_3.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C4_4.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C4_5.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C5_3.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C5_4.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C5_5.MouseLeave += new EventHandler(C0_0_MouseLeave);

            C6_0.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C6_1.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C6_2.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C6_6.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C6_7.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C6_8.MouseLeave += new EventHandler(C0_0_MouseLeave);

            C7_0.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C7_1.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C7_2.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C7_6.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C7_7.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C7_8.MouseLeave += new EventHandler(C0_0_MouseLeave);

            C8_0.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C8_1.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C8_2.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C8_6.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C8_7.MouseLeave += new EventHandler(C0_0_MouseLeave);
            C8_8.MouseLeave += new EventHandler(C0_0_MouseLeave);
        }
        void eventosLeaveFire()
        {
            C0_3.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C0_4.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C0_5.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C1_3.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C1_4.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C1_5.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C2_3.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C2_4.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C2_5.MouseLeave += new EventHandler(C0_3_MouseLeave);

            C3_0.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C3_1.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C3_2.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C3_6.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C3_7.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C3_8.MouseLeave += new EventHandler(C0_3_MouseLeave);
        
            C4_0.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C4_1.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C4_2.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C4_6.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C4_7.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C4_8.MouseLeave += new EventHandler(C0_3_MouseLeave);

            C5_0.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C5_1.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C5_2.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C5_6.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C5_7.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C5_8.MouseLeave += new EventHandler(C0_3_MouseLeave);

            C6_3.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C6_4.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C6_5.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C7_3.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C7_4.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C7_5.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C8_3.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C8_4.MouseLeave += new EventHandler(C0_3_MouseLeave);
            C8_5.MouseLeave += new EventHandler(C0_3_MouseLeave);
        }
        private void C0_0_MouseHover(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            string name = lbl.Name.Replace("C", "");
            string[] indexs = name.Split('_');
            int inversoI = 8 - Int32.Parse(indexs[0].ToString());
            int inversoJ = 8 - Int32.Parse(indexs[1].ToString());
            
            Label current = (Label)this.Controls.Find("C" + inversoI + "_" + inversoJ, true)[0];
            current.BackColor = Color.Aqua;

        }
        private void C0_0_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            string name = lbl.Name.Replace("C", "");
            string[] indexs = name.Split('_');
            int inversoI = 8 - Int32.Parse(indexs[0].ToString());
            int inversoJ = 8 - Int32.Parse(indexs[1].ToString());

            Label current = (Label)this.Controls.Find("C" + inversoI + "_" + inversoJ, true)[0];
            current.BackColor = Color.DarkGray;
        }
        private void C0_3_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            string name = lbl.Name.Replace("C", "");
            string[] indexs = name.Split('_');
            int inversoI = 8 - Int32.Parse(indexs[0].ToString());
            int inversoJ = 8 - Int32.Parse(indexs[1].ToString());

            Label current = (Label)this.Controls.Find("C" + inversoI + "_" + inversoJ, true)[0];
            current.BackColor = Color.Firebrick;
        }

        //------------------------------------------------------------------------\\
    }
}
