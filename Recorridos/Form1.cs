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

        private const int GROSOR_PINCEL = 2;
        private const int OFFSET_PINCEL = GROSOR_PINCEL / 2;

        Pen pincel = new Pen(Color.Black, GROSOR_PINCEL);
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

                    int xInicio = (int)(x * ancho + OFFSET_PINCEL);
                    int yInicio = (int)(y * alto + OFFSET_PINCEL);
                    int anchoOffset = (int)(ancho - OFFSET_PINCEL);
                    int altoOffset = (int)(alto - OFFSET_PINCEL);

                    switch (estado) {
                        case Tablero.Estado.libre:
                            g.DrawRectangle(pincel, x * ancho, y * alto, ancho, alto);
                            break;

                        case Tablero.Estado.ocupado:
                            g.FillRectangle(brochaNegra, xInicio, yInicio, anchoOffset, altoOffset);
                            break;

                        case Tablero.Estado.origen:
                            g.FillRectangle(brochaVerde, xInicio, yInicio, anchoOffset, altoOffset);
                            break;

                        case Tablero.Estado.destino:
                            g.FillRectangle(brochaRoja, xInicio, yInicio, anchoOffset, altoOffset);
                            break;
                    }
                }
            }

            this.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            RepaintTablero();
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

            String tipoNodo = getTextGroupBox(TipoNodo);
            int[] nodo = new int[2];
            nodo[0] = x;
            nodo[1] = y;

            switch (tipoNodo) {
                case ORIGEN:
                    if(tablero.Origen != null && tablero.Origen[0] >= 0)
                        tablero.SetEstado(tablero.Origen[0], tablero.Origen[1], Tablero.Estado.libre);

                    tablero.Origen = nodo;
                    tablero.SetEstado(x, y, Tablero.Estado.origen);

                    break;

                case DESTINO:
                    if (tablero.Destino != null && tablero.Destino[0] >= 0)
                        tablero.SetEstado(tablero.Destino[0], tablero.Destino[1], Tablero.Estado.libre);

                    tablero.Destino = nodo;
                    tablero.SetEstado(x, y, Tablero.Estado.destino);
                    break;

                case OBSTACULO:
                    if (tablero.GetEstado(x, y) == Tablero.Estado.ocupado)
                        tablero.SetEstado(x, y, Tablero.Estado.libre);
                    else
                        tablero.SetEstado(x, y, Tablero.Estado.ocupado);
                    break;

                default:
                    tablero.SetEstado(x, y, Tablero.Estado.libre);
                    break;
            }
            

            RepaintTablero();

        }


        private String getTextGroupBox(GroupBox gb) {
            return gb.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text; 
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
