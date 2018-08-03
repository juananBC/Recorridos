using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Graph {

    class Nodo {
        private static int IDS = 0;

        private int id;
        private int x, y;

        public Nodo( int x, int y) {
            this.x = x;
            this.y = y;

            this.id = IDS++;
        }


    }
}
