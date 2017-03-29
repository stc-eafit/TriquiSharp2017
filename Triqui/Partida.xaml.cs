using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Triqui
{
    /// <summary>
    /// Interaction logic for Partida.xaml
    /// </summary>
    public partial class Partida : Page
    {
        // Ambas clases se llaman igual, Partida, pero tienen namespace diferente.
        private Triqui.Logica.Partida partida;

        public Partida()
        {
            InitializeComponent();
            //Máquina será X - Revisar constructor de Partida en Logica
            partida = new Triqui.Logica.Partida(true);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Cerrar Ventana
            App.Current.MainWindow.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Reiniciar la partida menos la puntuacion
            Reiniciar();
        }
        private void Jugar_Click(object sender, RoutedEventArgs e)
        {
            //Revisen la codificacion de los botones para entender
            var btn = (Button)sender;
            // El nombre tiene codificado fila y columna
            string name = btn.Name;
            int fila = Int16.Parse(""+name[1]);
            int columna = Int16.Parse(""+name[2]);
            // Ejecuta la jugada
            partida.HacerJugada(fila, columna);
            // Se pinta en la pantalla - logica y pantalla separadas
            PintarPartida();
            //Hay ganador?
            int ganador = partida.RevisarGanador();
            //Sigue Actualizar los controles
            MensajeGanador(ganador);
        }
        /// <summary>
        /// Mensaje para el ganador
        /// </summary>
        /// <param name="ganador">int 1= personas, 2 = maquina, 0 = nadie</param>
        private void MensajeGanador(int ganador)
        {
            if (ganador == 1)
            {
                MessageBox.Show("Gana la Persona");
                partida.PuntuacionPersona++;
                TBPuntuacionPersona.Text = "" + partida.PuntuacionPersona;
            }
            else if (ganador == 2)
            {
                MessageBox.Show("Gana la Maquina");
                partida.PuntuacionMaquina++;
                TBPuntuacionMaquina.Text = "" + partida.PuntuacionMaquina;
            }
        }
        /// <summary>
        /// Limpiar pantalla y reiniciar la partida
        /// </summary>
        private void Reiniciar()
        {
            partida.Reiniciar();
            PintarPartida();
        }
        /// <summary>
        /// Pintar la pantalla con X O 
        /// </summary>
        private void PintarPartida()
        {
            int[,] tablero = partida.Tablero;
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                     if (tablero[i, j] == 1)
                    {
                        var btn = (Button)FindName("b" + i + j);
                        btn.Content = "O";
                    }
                     else if (tablero[i, j] == 2)
                     {
                         var btn = (Button)FindName("b" + i + j);
                         btn.Content = "X";
                     }
                     else
                     {
                         var btn = (Button)FindName("b" + i + j);
                         btn.Content = "";
                     }
                }
            }
        }


    }
}
