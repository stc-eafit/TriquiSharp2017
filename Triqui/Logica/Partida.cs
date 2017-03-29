using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Triqui.Logica
{
    class Partida
    {
        public Maquina MMaquina{get;set;}
        private int _contadorJugadas;
        public int ContadorJugadas { get { return _contadorJugadas; } set { _contadorJugadas = value; } }
        private int[,] _tablero;
        public int[,] Tablero { get { return _tablero; } set { _tablero = value; } }
        public int PuntuacionPersona{get;set;}
        public int PuntuacionMaquina { get; set; }

        public Partida(bool maquinaEsX)
        {
            MMaquina = new Maquina(maquinaEsX);
            ContadorJugadas = 0;
            Tablero = new int[3, 3];
            PuntuacionPersona = 0;
        }

        public void Reiniciar()
        {
            _contadorJugadas = 0;
            _tablero = new int[3, 3];
        }
       
        public void HacerJugada(int fila, int columna)
        {
            if (ContadorJugadas < 9)
            {
                if (Tablero[fila, columna] == 0)
                {
                    Tablero[fila, columna] = 1;
                    ContadorJugadas++;
                    MMaquina.HacerJugada(ref _tablero, ref _contadorJugadas);
                }
               
            }
        }
        public int RevisarGanador()
        {
            //TODO
            for (int i = 1; i < 3; ++i)
            {
                if (_tablero[0, 0] == i && _tablero[0, 1] == i && _tablero[0, 2] == i)
                    return i;
                if (_tablero[1, 0] == i && _tablero[1, 1] == i && _tablero[1, 2] == i)
                    return i;
                if (_tablero[2, 0] == i && _tablero[2, 1] == i && _tablero[2, 2] == i)
                    return i;
                if (_tablero[0, 0] == i && _tablero[1, 0] == i && _tablero[2, 0] == i)
                    return i;
                if (_tablero[0, 1] == i && _tablero[1, 1] == i && _tablero[2, 1] == i)
                    return i;
                if (_tablero[0, 2] == i && _tablero[1, 2] == i && _tablero[2, 2] == i)
                    return i;
                if (_tablero[0, 0] == i && _tablero[1, 1] == i && _tablero[2, 2] == i)
                    return i;
                if (_tablero[0, 2] == i && _tablero[1, 1] == i && _tablero[2, 0] == i)
                    return i;
            }
            return 0;
        }

    }
}
