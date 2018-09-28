using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sudoku.Clases;


namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            lblSolucion.Text = "-";
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
            lblSolucion.Text = "-";
            s.volverALlenar(0, 0);
            imprimir(s.imprimeTablero());

            btnRevelar.Enabled = true;
            btnVolverLlenar.Enabled = false;

        }
    }
}
