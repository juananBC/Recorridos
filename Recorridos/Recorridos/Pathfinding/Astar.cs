using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Pathfinding {
    class A_Star {

        private int numNodos;
        private int Origen;
        private int Destino;
        private float[] g; //Coste de ir desde el origen al nodo N
        private float[] f; //Coste de ir desde el origen al nodo N, más heuristica desde N al nodo destino



        public A_Star(int origen, int destino, int numNodos) {
            this.Origen = origen;
            this.Destino = destino;
            this.numNodos = numNodos;

            g = new float[numNodos];
            f = new float[numNodos];
            
           
           
        }

        /// <summary>
        /// Inicia el algoritmo A*. Se le ha de pasar la función para calcular la heuristica.
        /// </summary>
        /// <param name="heuristica"></param>
        public int[] run(Func<int, int, float> heuristica, Func<int, int[]> vecinos, Func<int, int, float> dist) {
            // Nodos ya evaluados
            HashSet<int> evaluados = new HashSet<int>();

            // Nodos a evaluar
            HashSet<int> descubiertos = new HashSet<int>();
            descubiertos.Add(Origen);

            // Contiene el nodo desde el que se llega de forma más barata al nodo del indice.
            int[] vieneDesde = new int[numNodos];
            for (int i = 0; i < numNodos; i++)
                vieneDesde[i] = -1;

            // Coste de ir desde el nodo inicial a él mismo es 0.
            g[0] = 0;
            f[0] = heuristica(Origen, Destino);

            // A los demás nodos, el coste es, inicialmente, infinito.
            for (int i = 1; i < g.Length; i++) {
                g[i] = int.MaxValue;
                f[i] = int.MaxValue;
            }

            while (descubiertos.Count != 0) {
                int actual = getMenorCoste(descubiertos);
                if (actual == Destino) break;

                descubiertos.Remove(actual);
                evaluados.Add(actual);

                foreach (int vecino in vecinos(actual)) {
                    // Si el vecino ya ha sido evaluado, lo descarta
                    if (evaluados.Contains(vecino)) continue;

                    float g_posible = g[actual] + dist(actual, vecino);

                    if (!descubiertos.Contains(vecino))
                        descubiertos.Add(vecino);                    
                    else if (g_posible >= g[vecino])
                        //El coste g no mejora con esta elección
                        continue;

                    vieneDesde[vecino] = actual;
                    g[vecino] = g_posible;
                    f[vecino] = g[vecino] + heuristica(vecino, Destino);

                }                
            }

            return vieneDesde;
        }

        /// <summary>
        /// Reconstruye el camino desde el nodo destino hasta el nodo origen.
        /// </summary>
        /// <param name="vieneDesde"></param>
        /// <returns></returns>
        public List<int> ReconstruirCamino(int[] vieneDesde) {
            List<int> camino = new List<int>();
            int actual = Destino;
            Console.Write("Camino inverso: ");
            while (vieneDesde[actual] >= 0) {
                Console.Write(actual + " " );
                camino.Add(actual);
                actual = vieneDesde[actual];
            }
            return camino;
        }


        /// <summary>
        /// Obtiene el nodo con el menor coste f. Seria f = g + heuristica.
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        private int getMenorCoste(HashSet<int> set) {
            int menor = 0;
            foreach (int v in set) {
                if (f[v] < f[menor])
                    menor = v;
            }

            return menor;
        }


       
    }
}
