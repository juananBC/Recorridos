using Recorridos.Recorridos.Entorno;
using Recorridos.Recorridos.Graph;
using Recorridos.Recorridos.Pathfinding;
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

        private bool isPressed = false;

        private int tamano;
        private Tablero tablero;

        private const int GROSOR_PINCEL = 1;
        private const int OFFSET_PINCEL = GROSOR_PINCEL / 2;

        Pen pincel = new Pen(Color.Black, GROSOR_PINCEL);
        SolidBrush brochaNegra = new SolidBrush(Color.Black);
        SolidBrush brochaAzul = new SolidBrush(Color.FromArgb(153, 204, 255));
        SolidBrush brochaVerde = new SolidBrush(Color.FromArgb(77, 255, 77));
        SolidBrush brochaRoja = new SolidBrush(Color.FromArgb(255, 92, 51));
        SolidBrush brochaCeleste = new SolidBrush(Color.FromArgb(230, 242, 255));


        public Form1() {
            InitializeComponent();

            tamano = Decimal.ToInt32(tamanoTablero.Value);
            tablero = new Tablero(tamano, tamano);
        }

        private void Form1_Load(object sender, EventArgs e) {
            VaciarTablero();
        }
     
        /// <summary>
        /// Dibuja el tablero del tamaño seleccionado
        /// </summary>
        private void VaciarTablero() {
            tablero = new Tablero(tamano, tamano);

            for (int x = 0; x < tamano; x++) {
                for (int y = 0; y < tamano; y++) {
                    tablero.SetEstado(x, y, Estado.libre);
                }
            }

            this.TableroPanel.Invalidate();
        }

        /// <summary>
        /// Redibuja el tablero, manteniendo el estado en el que se encuentra.
        /// </summary>
        private void RepaintTablero(Graphics g) {

            int width = TableroPanel.Width;
            int height = TableroPanel.Height;
            float ancho = width / tamano;
            float alto = height / tamano;

            for (int x = 0; x < tamano; x++) {
                for (int y = 0; y < tamano; y++) {
                    Estado estado = tablero.GetEstado(x, y);

                    int xInicio = (int)(x * ancho + OFFSET_PINCEL);
                    int yInicio = (int)(y * alto + OFFSET_PINCEL);
                    int anchoOffset = (int)(ancho - OFFSET_PINCEL);
                    int altoOffset = (int)(alto - OFFSET_PINCEL);

                    switch (estado) {
                        case Estado.libre:
                            g.DrawRectangle(pincel, x * ancho, y * alto, ancho, alto);
                            break;

                        case Estado.ocupado:
                            g.FillRectangle(brochaNegra, xInicio, yInicio, anchoOffset, altoOffset);
                            break;

                        case Estado.origen:
                            g.FillRectangle(brochaVerde, xInicio, yInicio, anchoOffset, altoOffset);
                            break;

                        case Estado.destino:
                            g.FillRectangle(brochaRoja, xInicio, yInicio, anchoOffset, altoOffset);
                            break;

                        case Estado.visitado:
                            g.FillRectangle(brochaAzul, xInicio, yInicio, anchoOffset, altoOffset);
                            break;
                            
                        case Estado.evaluado:
                            g.FillRectangle(brochaCeleste, xInicio, yInicio, anchoOffset, altoOffset);
                            break;
                    }

                    g.DrawRectangle(pincel, x * ancho, y * alto, ancho, alto);
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            RepaintTablero(e.Graphics);
        }

 
        private void TableroPanel_Click(object sender, EventArgs e) {
            MouseEventArgs ev = (MouseEventArgs)e;

            if (ev.Button != MouseButtons.Left) return;

            float xOffset = TableroPanel.Width / tamano;
            float yOffset = TableroPanel.Height / tamano;

            int x = (int)Math.Ceiling(ev.X / xOffset) - 1;
            int y = (int)Math.Ceiling(ev.Y / yOffset) - 1;

            Console.WriteLine("Click en " + x + " " + y);

            tablero.QuitarRecorrido();

            String tipoNodo = getTextGroupBox(TipoNodo);
            int[] nodo = new int[2];
            nodo[0] = x;
            nodo[1] = y;

            if (x < 0 || y < 0 || x >= tablero.Ancho || y >= tablero.Alto)
                return;

            switch (tipoNodo) {
                case ORIGEN:
                    // Resetea el origen anterior
                    if (tablero.Origen >= 0) {
                        int origen = tablero.Origen;
                        tablero.SetEstado(tablero.GetX(origen), tablero.GetY(origen), Estado.libre);
                    }

                    tablero.Origen = tablero.GetId(x, y);
                    tablero.SetEstado(x, y, Estado.origen);
                    break;

                case DESTINO:
                    if (tablero.Destino >= 0) {
                        int destino = tablero.Destino;
                        tablero.SetEstado(tablero.GetX(destino), tablero.GetY(destino), Estado.libre);
                    }

                    tablero.Destino = tablero.GetId(x, y);
                    tablero.SetEstado(x, y, Estado.destino);
                    break;

                case OBSTACULO:
                    if (tablero.GetEstado(x, y) == Estado.ocupado)
                        tablero.SetEstado(x, y, Estado.libre);
                    else
                        tablero.SetEstado(x, y, Estado.ocupado);
                    break;

                default:
                    tablero.SetEstado(x, y, Estado.libre);
                    break;
            }            

            // Obliga a repintar el tablero. Llama al metodo Paint del panel.
           this.TableroPanel.Invalidate();

        }


        private String getTextGroupBox(GroupBox gb) {
            return gb.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text; 
        }

        private void TableroPanel_Resize(object sender, EventArgs e) {

            // RepaintTablero();
            this.TableroPanel.Invalidate();
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
            VaciarTablero();
        }

        private void Click_iniciarRecorrido(object sender, EventArgs e) {
            tablero.QuitarRecorrido();

            if (tablero.Origen >= 0 && tablero.Destino >= 0) {

                Controlador controlador = new Controlador(tablero);
                List<int> camino = controlador.BuscarCamino();

                // Marca los nodos que forman el camino
                for (int i = 1; i < camino.Count - 1; i++) {
                    tablero.SetEstado(camino[i], Estado.visitado);
                }

                // Marca los nodos que se han visitado
                HashSet<int> evaluados = controlador.GetEvaluados();
               
                for (int i = 0; i < evaluados.Count; i++) {
                    int id = evaluados.ElementAt(i);
                    if(tablero.GetEstado(id) == Estado.libre)
                        tablero.SetEstado(evaluados.ElementAt(i), Estado.evaluado);
                }


            }


            // RepaintTablero();
            this.TableroPanel.Invalidate();
        }

        private void Reiniciar_Click(object sender, EventArgs e) {
            tablero.Liberar();

            // RepaintTablero();
            this.TableroPanel.Invalidate();
        }

        private void MarcarRecorrido(object sender, EventArgs e) {
            Console.WriteLine("ENTER");
            if (!isPressed) return;

            tablero.QuitarRecorrido();

            if (tablero.Origen >= 0 && tablero.Destino >= 0) {

                Controlador controlador = new Controlador(tablero);
                List<int> camino = controlador.BuscarCamino();

                // Marca los nodos que forman el camino
                for (int i = 1; i < camino.Count - 1; i++) {
                    tablero.SetEstado(camino[i], Estado.visitado);
                }

                // Marca los nodos que se han visitado
                HashSet<int> evaluados = controlador.GetEvaluados();
                Console.WriteLine("EVAL: " + evaluados.Count);
                for (int i = 0; i < evaluados.Count; i++) {
                    int id = evaluados.ElementAt(i);
                    Console.Write("VISITA: " + id);
                    if (tablero.GetEstado(id) == Estado.libre)
                        tablero.SetEstado(evaluados.ElementAt(i), Estado.evaluado);
                }


            }


            // RepaintTablero();
            this.TableroPanel.Invalidate();
        }

        private void TableroPanel_MouseDown(object sender, MouseEventArgs e) {
            isPressed = true;
        }


        private void TableroPanel_MouseUp(object sender, MouseEventArgs e) {
            isPressed = false;
            TableroPanel_Click(sender, e);
        }


        private void PonerObstaculos(object sender, MouseEventArgs e) {
            if (!isPressed) return;

            MouseEventArgs ev = (MouseEventArgs)e;
            if (ev.Button != MouseButtons.Right) return;

            float xOffset = TableroPanel.Width / tamano;
            float yOffset = TableroPanel.Height / tamano;

            int x = (int)Math.Ceiling(ev.X / xOffset) - 1;
            int y = (int)Math.Ceiling(ev.Y / yOffset) - 1;

            if (x < 0 || y < 0 || x >= tablero.Ancho || y >= tablero.Alto) return;

           tablero.SetEstado(x, y, Estado.ocupado);

            this.TableroPanel.Invalidate();
        }


    }

}
