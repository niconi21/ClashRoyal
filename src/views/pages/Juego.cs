using ClashRoyal.src.tools.Objects;
using ClashRoyal.src.views.components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashRoyal.src.views.pages
{
    public partial class Juego : Form
    {
        private Jugador _jugador;
        private Thread _hiloCartas;

        private int _cartasJugador;
        private int _cartasOponente;

        public Juego(Jugador jugador)
        {
            InitializeComponent();
            _jugador = jugador;
            _hiloCartas = new Thread(moverCartas);
            _hiloCartas.Start();
        }

        private void moverCartas()
        {
            Cartas_component carta = new Cartas_component();
            carta.Location = new Point(,605);
        }
    }
}
