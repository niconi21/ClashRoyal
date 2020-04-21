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
    public partial class personaje_component : UserControl
    {
        public Carta Carta { get; set; }
        public int Vida { get; set; }
        public personaje_component()
        {
            InitializeComponent();
        }

        public void setPersonaje(Carta carta)
        {
            this.Carta = carta;
            this.pictureBox1.Image = Carta.personaje;
            this.Vida = this.progressBar1.Value;
        }

        public void retarVida(int value){
            if (this.Vida > 0 )
            {
                this.Vida = value;
                this.progressBar1.Value = value;
            }
        }
    }
}
