using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Entorno {

    
    class Casilla {

        public enum ESTADO {LIBRE, OCUPADO};
        private ESTADO estado;

        public Casilla(ESTADO estado) {
            this.estado = estado;
        }


    }
}
