using Recorridos.Recorridos.Entorno;
using Recorridos.Recorridos.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Pathfinding {
    class Controlador {

        private Grafo grafo;
        private Tablero tablero;

        public Controlador(Tablero tablero) {
            this.tablero = tablero;
            IniciarGrafo(tablero);
        }

        public void CambiarDestino(int id) {
            tablero.Destino = id;
        }

        public void CambiarOrigen(int id) {
            tablero.Origen = id;
        }

        private void IniciarGrafo(Tablero tablero) {
            grafo = new Matriz(tablero.Alto, tablero.Ancho);

            for (int x = 0; x < tablero.Ancho; x++) {
                for (int y = 0; y < tablero.Alto; y++) {

                    if (tablero.GetEstado(x, y) == Estado.libre) {
                        int id = tablero.GetId(x, y);
                        List<int> vecinos = tablero.CasillasAdyacentes(x, y);

                        vecinos.ForEach(vecino => {
                            if (tablero.GetEstado(vecino) != Estado.ocupado && !grafo.IsConectado(id, vecino)) {
                                float dist = tablero.GetDistancia(id, vecino);
                                grafo.AddArista(id, vecino, dist);
                            }
                        });

                    }
                }
            }

            Console.WriteLine("El grafo es: \n" + grafo.ToString());
        }

        public List<int> BuscarCamino() {

            A_Star pathfinding = new A_Star(tablero.Origen, tablero.Destino, grafo);
            pathfinding.Run();
            pathfinding.PrintCamino();

            List<int> recorrido  = pathfinding.Camino;
            return recorrido;
        }
    }
}
