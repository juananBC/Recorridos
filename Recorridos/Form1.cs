using Recorridos.Recorridos.Entorno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recorridos {
    public partial class Form1 : Form {

        private const int DEFAULT_X = 10;
        private const int DEFAULT_Y = 10;
        private const int RADIO_NODO = 20;
        private static Color COLOR_TABLERO = Color.White;

        private int tamano;
        private Tablero tablero;

        Pen pincel = new Pen(Color.Black, 2);
        SolidBrush brochaNegra = new SolidBrush(Color.Black);
        SolidBrush brochaAzul = new SolidBrush(Color.Blue);
        SolidBrush brochaVerde = new SolidBrush(Color.Green);
        SolidBrush brochaRoja = new SolidBrush(Color.Red);


        public Form1() {

            InitializeComponent();

            tamano = Decimal.ToInt32(tamanoTablero.Value);
            tablero = new Tablero(tamano, tamano);
        }

        private void Form1_Load(object sender, EventArgs e) {
            DibujarTablero();
        }

        private void PintarNodo(Graphics g, int centroX, int centroY) {

            SolidBrush brocha = new SolidBrush(Color.Blue);


            float tam = RADIO_NODO * (TableroPanel.Width / TableroPanel.Height);

            float x = centroX - tam / 2;
            float y = centroY - tam / 2;

            g.FillEllipse(brocha, x, y, tam, tam);
        }

     
        /// <summary>
        /// Dibuja el tablero del tamaño seleccionado
        /// </summary>
        private void DibujarTablero() {
            Graphics g = TableroPanel.CreateGraphics();
            g.Clear(COLOR_TABLERO);

            int width = TableroPanel.Width;
            int height = TableroPanel.Height;
            float ancho = width / tamano;
            float alto = height / tamano;

            Pen pincel = new Pen(Color.Black, 2);
            tablero = new Tablero(tamano, tamano);

            for (int x = 0; x < tamano; x++) {
                for (int y = 0; y < tamano; y++) {
                    tablero.SetEstado(x, y, Tablero.Estado.libre);
                    g.DrawRectangle(pincel, x * ancho, y * alto, ancho, alto);
                }
            }

            this.Invalidate();
        }

        /// <summary>
        /// Redibuja el tablero, manteniendo el estado en el que se encuentra.
        /// </summary>
        private void RepaintTablero() {
            Graphics g = TableroPanel.CreateGraphics();
            g.Clear(COLOR_TABLERO);

            int width = TableroPanel.Width;
            int height = TableroPanel.Height;
            float ancho = width / tamano;
            float alto = height / tamano;

            


            for (int x = 0; x < tamano; x++) {
                for (int y = 0; y < tamano; y++) {
                    Tablero.Estado estado = tablero.GetEstado(x, y);

                    switch (estado) {
                        case Tablero.Estado.libre:
                            g.DrawRectangle(pincel, x * ancho, y * alto, ancho, alto);
                            break;

                        case Tablero.Estado.ocupado:
                            g.FillRectangle(brochaNegra, x * ancho, y * alto, ancho, alto);
                            break;

                        case Tablero.Estado.origen:
                            g.FillRectangle(brochaVerde, x * ancho, y * alto, ancho, alto);
                            break;

                        case Tablero.Estado.destino:
                            g.FillRectangle(brochaRoja, x * ancho, y * alto, ancho, alto);
                            break;
                    }
                }
            }

            this.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            RepaintTablero();
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void TableroPanel_Click(object sender, EventArgs e) {
            MouseEventArgs ev = (MouseEventArgs)e;

            Graphics g = TableroPanel.CreateGraphics();
            Console.WriteLine(MousePosition.X + " " + MousePosition.Y);

            float xOffset = TableroPanel.Width / tamano;
            float yOffset = TableroPanel.Height / tamano;

            int x = (int)Math.Ceiling(ev.X / xOffset) - 1;
            int y = (int)Math.Ceiling(ev.Y / yOffset) - 1;
            Console.WriteLine(x + " " + y);

            if(tablero.GetEstado(x, y) == Tablero.Estado.ocupado)
                tablero.SetEstado(x, y, Tablero.Estado.libre);
            else
                tablero.SetEstado(x, y, Tablero.Estado.ocupado);

            RepaintTablero();

          //  PintarNodo(g, ev.X, ev.Y);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e) {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void TableroPanel_Resize(object sender, EventArgs e) {
            RepaintTablero(); 
        }

        /// <summary>
        /// Establece el tamaño del tablero. El valor mínimo es un tablero de 4x4.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tamanoTablero_ValueChanged(object sender, EventArgs e) {
            int aux = Decimal.ToInt32(tamanoTablero.Value);
            if (aux <= 4) tamanoTablero.Value = 4;

            tamano = Decimal.ToInt32(tamanoTablero.Value);
            DibujarTablero();
        }
    }
}
