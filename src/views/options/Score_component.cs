using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClashRoyal.src.tools.Objects;
using ClashRoyal.src.tools.database;

namespace ClashRoyal.src.views.options
{
    public partial class Score_component : UserControl
    {
        private Jugador _jugador;
        private int _danio;
        private int _tiempo;
        private int _elixir;
        private List<Estadistica> estadisticas;
        private String _personaje;
        public Score_component()
        {
            InitializeComponent();
            estadisticas = new List<Estadistica>();
        }
        
        public void insertarNombre(Jugador jugador)
        {
            _jugador = jugador;
            llenarTabla();
            this.label2.Text = "Score de " + _jugador.Nombre + " " + _jugador.Apepat + " " + _jugador.Apemat;
        }

        private void llenarTabla()
        {
            lblMejorPartida.Parent = pictureBox1;
            lblMejorPartida.BackColor = Color.Transparent;
            estadisticas = (new Conexion()).consultarEstadisticas(_jugador);
            dataGridView1.DataSource = estadisticas;
            obtenerPuntiajes();
            lblMejorPartida.Text = "Puntuaje: Daño recibido " + _danio +
                                 "\n          Tiempo jugador " + _tiempo+
                                 "\n          Elixir usado " + _elixir+
                                 "\n          Personaje más usado: "+_personaje;
        }

        private void obtenerPuntiajes()
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;
            foreach (var item in estadisticas)
            {
                _danio += item.danio;
                _tiempo += item.tiempo;
                _elixir += item.elixir;
                switch (item.personaje)
                {
                    case "Mosquetera":
                        p1++;
                        break;
                    case "Bebé dragón":
                        p2++;
                        break;
                    case "Esbirros":
                        p3++;
                        break;
                    case "Bruja":
                        p4++;
                        break;
                    case "mago":
                        p5++;
                        break;
                }
            }
            if (p1 > p2 && p1 > p3 && p1 > p4 && p1 > p5)
                _personaje = "Mosquetera";
            if (p2 > p1 && p2 > p3 && p2 > p4 && p2 > p5)
                _personaje = "Bebé dragón";
            if (p3 > p2 && p3 > p1 && p3 > p4 && p3 > p5)
                _personaje = "Esbirros";
            if (p4 > p2 && p4 > p3 && p4 > p1 && p4 > p5)
                _personaje = "Bruja";
            if (p5 > p2 && p5 > p3 && p5 > p4 && p5 > p1)
                _personaje = "Mago";
            
        }
    }
}
