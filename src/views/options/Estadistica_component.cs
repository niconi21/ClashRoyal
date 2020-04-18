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
    public partial class Estadistica_component : UserControl
    {
        private Jugador _jugador;
        private List<Estadistica> estadisticas;
        private int _danio;
        private int _tiempo;
        private int _elixir;
        private String _personaje;
        public Estadistica_component()
        {
            InitializeComponent();
        }
        public void insertarNombre(Jugador jugador)
        {
            _jugador = jugador;
            label2.Text = "Estadisticas de " + jugador.Nombre + " " + jugador.Apepat + " " + jugador.Apemat;
            graficar();
        }
        private void graficar()
        {
            estadisticas = (new Conexion()).consultarEstadisticas(_jugador);
            obtenerPuntiajes();
            chart1.Series[0].Points.AddY(_danio);
            chart1.Series[1].Points.AddY(_tiempo);
            chart1.Series[2].Points.AddY(_elixir);
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
                    case "Mago":
                        p5++;
                        break;
                }
            }
            chart2.Series[0].Points.AddY(p1);
            chart2.Series[1].Points.AddY(p2);
            chart2.Series[2].Points.AddY(p3);
            chart2.Series[3].Points.AddY(p4);
            chart2.Series[4].Points.AddY(p5);

        }
    }
}
