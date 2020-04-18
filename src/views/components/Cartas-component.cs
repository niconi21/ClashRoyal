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

namespace ClashRoyal.src.views.components
{
    public partial class Cartas_component : UserControl
    {
        private Carta[] cartas = new Carta[] {
            new Carta{
                nombre = "Mosquetera",
                imagen = global::ClashRoyal.Properties.Resources.Mosquetera___carta,
                danio = 5
            },
            new Carta{
                nombre = "Bebé dragón",
                imagen = global::ClashRoyal.Properties.Resources.bebe_dragon___carta,
                danio = 10
            },
            new Carta{
                nombre = "Esbirros",
                imagen = global::ClashRoyal.Properties.Resources.esbirros__carta,
                danio = 5
            },
            new Carta{
                nombre = "Bruja",
                imagen = global::ClashRoyal.Properties.Resources.bruja___carta,
                danio = 10
            },
            new Carta{
                nombre = "Mago",
                imagen = global::ClashRoyal.Properties.Resources.mago___carta,
                danio = 10
            },

        };
        public Carta Carta { get; set; }
        public Cartas_component()
        {
            InitializeComponent();
            Random r = new Random();
            int aleatorio = r.Next(0, 4);
            Carta = this.cartas[aleatorio];
            this.imagen.Image = Carta.imagen;
            this.nombre.Text = Carta.nombre;
        }
    }
}
