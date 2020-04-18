using ClashRoyal.src.tools.Objects;
using ClashRoyal.src.views.options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashRoyal.src.views.pages
{
    public partial class Inicio : Form
    {
        private Inicio_component _inicio;
        private Jugador _jugador;
        public Inicio(Jugador jugador)
        {
            InitializeComponent();
            _jugador = jugador;
            _inicio = new Inicio_component();
            _inicio.insertarNombre(_jugador);
            meterContenedor(_inicio);
            
        }

        private void menu_entrar(Object sender, EventArgs e)
        {
            Control panel = sender as Control;
            panel.BackColor = Color.FromArgb(10, 138, 160);
        }

        private void menu_salir(Object sender, EventArgs e)
        {
            Control panel = sender as Control;
            if (!panel.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                panel.BackColor = Color.FromArgb(7, 109, 127);
            }
        }

        private void panel_inicio_Click(object sender, EventArgs e)
        {
            _inicio = new Inicio_component();
            _inicio.insertarNombre(_jugador);
            meterContenedor(_inicio);
        }

        private void panel_score_Click(object sender, EventArgs e)
        {
            _inicio.pararHilo();
            Score_component score = new Score_component();
            score.insertarNombre(_jugador);
            meterContenedor(score);
        }

        private void panel_estadistica_Click(object sender, EventArgs e)
        {
            _inicio.pararHilo();
            Estadistica_component estadistica = new Estadistica_component();
            estadistica.insertarNombre(_jugador);
            meterContenedor(estadistica);
        }

        private void panel_creitos_Click(object sender, EventArgs e)
        {
            _inicio.pararHilo();
            Creditos_component creditos = new Creditos_component();
            meterContenedor(creditos);
        }

        private void meterContenedor(Control c)
        {
            c.Dock = DockStyle.Fill;
            this.panel_contenedor.Controls.Clear();
            this.panel_contenedor.Controls.Add(c);
        }

        private void Inicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Juego juego = new Juego(_jugador);
                juego.Show();
                _inicio.pararHilo();
                this.Dispose();
            }
        }
    }
}
