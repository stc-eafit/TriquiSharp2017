using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Triqui.Logica
{
    class Maquina
    {
        private Random _numeroaleatorio;
        public bool EsX { get; set; }
        public Maquina(bool esX)
        {
            _numeroaleatorio = new Random();
            EsX = esX;
        }
        /// <summary>
        /// Ejecu´ción logica de parte de la maquina, intenten mejorar la logica.
        /// </summary>
        /// <param name="tablero">arreglo que representa el juego</param>
        /// <param name="totalJugadas">cuantas jugadas van</param>
        public void HacerJugada(ref int[,] tablero,ref int totalJugadas)
        {
            bool encontrado = false;
            while(!encontrado && totalJugadas < 9){
                int fila = _numeroaleatorio.Next(3);
                int columna = _numeroaleatorio.Next(3);
                if (tablero[fila, columna] == 0)
                {
                    encontrado = true;
                    // 2 para maquina, 1 para persona, 0 sin jugada
                    tablero[fila, columna] = 2;
                    totalJugadas++;
                }
            }
        }
    }
}
