using Recorridos.Recorridos.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Pathfinding {
    class A_Star {

        private int numNodos;
        private int origen;
        private int destino;
        private Grafo grafo;
        private float[] g; //Coste de ir desde el origen al nodo N
        private float[] f; //Coste de ir desde el origen al nodo N, más heuristica desde N al nodo destino
        private int[] vieneDesde;  // Contiene el nodo desde el que se llega de forma más barata al nodo del indice.
        private List<int> camino;
        private HashSet<int> evaluados; // Nodos que ya se han evaluado (sean camino o no)
        private HashSet<int> descubiertos; // Nodos que se conoce su existencia, pero no se sabe si son camino


        public A_Star(int origen, int destino, Grafo grafo) {
            this.Origen = origen;
            this.Destino = destino;
            this.Grafo = grafo;
            this.NumNodos = grafo.Nodos.Length;

            G = new float[NumNodos];
            F = new float[NumNodos];

            evaluados = new HashSet<int>();
            descubiertos = new HashSet<int>();
        }

        /// <summary>
        /// Inicia el algoritmo A*. Se le ha de pasar la función para calcular la heuristica.
        /// </summary>
        public void Run() {

            if (Origen < 0 || Destino < 0) return;

            descubiertos = new HashSet<int>();
            evaluados = new HashSet<int>();

            descubiertos.Add(Origen);

            VieneDesde = new int[NumNodos];
            for (int i = 0; i < NumNodos; i++) {
                VieneDesde[i] = -1;
            }

            // A los demás nodos, el coste es, inicialmente, infinito.
            for (int i = 0; i < G.Length; i++) {
                G[i] = int.MaxValue;
                F[i] = int.MaxValue;
            }

            // Coste de ir desde el nodo inicial a él mismo es 0.
            G[Origen] = 0;
            F[Origen] = Heuristica(Origen, Destino);

            while (descubiertos.Count != 0) {
                int actual = getMenorCoste(descubiertos);
                if (actual == Destino) break;

                descubiertos.Remove(actual);
                evaluados.Add(actual);

                List<int> vecinos = Grafo.GetVecinos(actual);
                foreach (int vecino in vecinos) {

                    // Si el vecino ya ha sido evaluado, lo descarta
                    if (evaluados.Contains(vecino)) continue;

                    float g_posible = G[actual] + Grafo.Distancia(actual, vecino);

                    if (!descubiertos.Contains(vecino) && !evaluados.Contains(vecino))
                        descubiertos.Add(vecino);
                    else if (g_posible >= G[vecino])
                        continue;

                    VieneDesde[vecino] = actual;
                    G[vecino] = g_posible;
                    F[vecino] = G[vecino] + Heuristica(vecino, Destino);

                }
            }
            ReconstruirCamino();
        }


        /// <summary>
        /// Reconstruye el camino desde el nodo destino hasta el nodo origen.
        /// </summary>
        /// <param name="vieneDesde"></param>
        /// <returns></returns>
        public void ReconstruirCamino() {
            Camino = new List<int>();

            int actual = Destino;
            while (VieneDesde[actual] >= 0) {
                Camino.Add(actual);
                actual = VieneDesde[actual];
            }
            // Guarda el nodo origen en el camino encontrado.
            Camino.Add(Origen);

            // Ordena desde el nodo de origen al nodo destino
            Camino.Reverse();
        }


        public void PrintCamino() {
            String msg = "El camino es: ";
            for (int i = 0; i < Camino.Count; i++) 
                msg += Camino[i] + ", ";
            
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Usa como función heuristica la distancia euclidea que separa dos nodos.
        /// </summary>
        public float Heuristica(int idOrigen, int idDestino) {
            Nodo n1 = Grafo.GetNodo(idOrigen);
            Nodo n2 = Grafo.GetNodo(idDestino);

            float dist = (float)Math.Sqrt(Math.Pow((n1.X - n2.X), 2) + Math.Pow((n1.Y - n2.Y), 2));
            return dist;
        }

        /// <summary>
        /// Obtiene el nodo con el menor coste f. Seria f = g + heuristica.
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        private int getMenorCoste(HashSet<int> set) {
            int menor = Destino;
            foreach (int v in set) {
                if (F[v] < F[menor])
                    menor = v;
            }
            return menor;
        }

        
        public int NumNodos { get => numNodos; set => numNodos = value; }
        public int Origen { get => origen; set => origen = value; }
        public int Destino { get => destino; set => destino = value; }
        internal Grafo Grafo { get => grafo; set => grafo = value; }
        public float[] G { get => g; set => g = value; }
        public float[] F { get => f; set => f = value; }
        public int[] VieneDesde { get => vieneDesde; set => vieneDesde = value; }
        public List<int> Camino { get => camino; set => camino = value; }
        public HashSet<int> Evaluados { get => evaluados; }
        public HashSet<int> Descubiertos { get => descubiertos; }
    }
}
