using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Entorno {
    class Tablero {
        private int ancho, largo;

        private Casilla[,] casillas;

        public Tablero(int ancho, int alto) {
            casillas = new Casilla[ancho, alto];

            for (int x = 0; x < ancho; x++) {
                for (int y = 0; y < alto; y++) {
                    casillas[x, y] = new Casilla(Casilla.ESTADO.LIBRE);
                }
            }

        }
    }
}
