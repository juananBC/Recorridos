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

        public Form1() {
            tamano = 10;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            tablero = new Tablero(DEFAULT_X, DEFAULT_Y);

            for (int x = 0; x < DEFAULT_X; x++) {
                for (int y = 0; y < DEFAULT_Y; y++) {

                }
            }
        }

        private void PintarNodo(Graphics g, int centroX, int centroY) {

            SolidBrush brocha = new SolidBrush(Color.Blue);


            float tam = RADIO_NODO * (TableroPanel.Width / TableroPanel.Height);

            float x = centroX - tam / 2;
            float y = centroY - tam / 2;

            g.FillEllipse(brocha, x, y, tam, tam);
        }

     
        private void DibujarTablero() {
            Graphics g = TableroPanel.CreateGraphics();
            g.Clear(COLOR_TABLERO);

            int width = TableroPanel.Width;
            int height = TableroPanel.Height;
            float ancho = width / tamano;
            float alto = height / tamano;

            Pen pincel = new Pen(Color.Black, 2);

            for (int x = 0; x < tamano; x++) {
                for (int y = 0; y < tamano; y++) {
                    g.DrawRectangle(pincel, x * ancho, y * alto, ancho, alto);
                }
            }

            this.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            DibujarTablero();
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void TableroPanel_Click(object sender, EventArgs e) {
            MouseEventArgs ev = (MouseEventArgs)e;

            Graphics g = TableroPanel.CreateGraphics();
            Console.WriteLine(MousePosition.X + " " + MousePosition.Y);
           
            PintarNodo(g, ev.X, ev.Y);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e) {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void TableroPanel_Resize(object sender, EventArgs e) {
            Console.WriteLine("Resize");
            DibujarTablero();
        }
    }
}
