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
                personaje = global::ClashRoyal.Properties.Resources.Mosquetera,
                danio = 5,
                elixir = 2
            },
            new Carta{
                nombre = "Bebé dragón",
                imagen = global::ClashRoyal.Properties.Resources.bebe_dragon___carta,
                personaje = global::ClashRoyal.Properties.Resources.Bebe_Dragon,
                danio = 10,
                elixir = 4
            },
            new Carta{
                nombre = "Esbirros",
                imagen = global::ClashRoyal.Properties.Resources.esbirros__carta,
                personaje = global::ClashRoyal.Properties.Resources.Esbirros,
                danio = 5,
                elixir = 3
            },
            new Carta{
                nombre = "Bruja",
                imagen = global::ClashRoyal.Properties.Resources.bruja___carta,
                personaje = global::ClashRoyal.Properties.Resources.Bruja,
                danio = 10,
                elixir = 5
            },
            new Carta{
                nombre = "Mago",
                imagen = global::ClashRoyal.Properties.Resources.mago___carta,
                personaje = global::ClashRoyal.Properties.Resources.Mago,
                danio = 10,
                elixir = 5
            },

        };
        public Carta Carta { get; set; }
        public Cartas_component()
        {
            InitializeComponent();
            
        }

        public void setCarta(int value)
        {
            Carta = this.cartas[value];
            this.imagen.Image = Carta.imagen;
            this.nombre.Text = Carta.nombre;
        }


    }
}
