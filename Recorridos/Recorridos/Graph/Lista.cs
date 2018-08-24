using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Graph {
    class Lista : Grafo {

        
        public Lista() {
        }



        public override void AddArista(int id1, int id2, float distancia) {
            throw new NotImplementedException();
        }

        public override float Distancia(int id1, int id2) {
            throw new NotImplementedException();
        }

        public override List<int> GetVecinos(int idNodo) {
            throw new NotImplementedException();
        }

  

        public override bool IsConectado(int id1, int id2) {
            throw new NotImplementedException();
        }

        public override void RemoveArista(Nodo n1, Nodo n2) {
            throw new NotImplementedException();
        }

        public override string ToString() {
            throw new NotImplementedException();
        }
    }
}
