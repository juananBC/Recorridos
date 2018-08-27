using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Graph {

    class Matriz : Grafo {

        private const float SIN_CONECTAR = 0;

        private float[,] aristas;

        public Matriz(int ancho, int largo) {

            int numNodos = ancho * largo;
            this.aristas = new float[numNodos, numNodos];
            this.Nodos = new Nodo[numNodos];

            for (int id = 0; id < numNodos; id++) {
                for (int j = 0; j < numNodos; j++) {
                    this.aristas[id, j] = SIN_CONECTAR;
                }

                int x =  id % ancho;
                int y = (int)(id / ancho);
                
                Nodo nodo = new Nodo(id, x, y);
                this.Nodos[id] = nodo;
            }
        }

  
        public override void AddArista(int id1, int id2, float distancia) {
            aristas[id1, id2] = distancia;
            aristas[id2, id1] = distancia;
        }
        
        
        public override bool IsConectado(int id1, int id2) { 
            return aristas[id1, id2] != SIN_CONECTAR;
        }

   
        public override float Distancia(int id1, int id2) {
            return aristas[id1, id2];
        }
      
        public override void RemoveArista(Nodo n1, Nodo n2) {
            aristas[n1.ID, n2.ID] = SIN_CONECTAR;
            aristas[n2.ID, n1.ID] = SIN_CONECTAR;
        }

        public override List<int> GetVecinos(int idNodo) {
            List<int> vecinos = new List<int>();
            for (int i = 0; i < aristas.GetLength(0); i++) {
                if (aristas[idNodo, i] != SIN_CONECTAR) {
                    vecinos.Add(i);
                }
            }
            return vecinos;
        }

        public override string ToString() {
            String resultado = "";

            for (int x = 0; x < this.aristas.GetLength(0); x++) {
                resultado += "Nodo " + x + ": ";
                for (int y = 0; y < this.aristas.GetLength(1); y++) {

                    if (this.aristas[x, y] != SIN_CONECTAR) {
                        resultado += y +"(" + this.aristas[x, y] + "),  ";
                    }

                }
                resultado += "\n";
            }

            return resultado;
        }

    }

}
