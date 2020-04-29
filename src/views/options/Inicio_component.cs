using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ClashRoyal.src.tools.Objects;

namespace ClashRoyal.src.views.options
{
    public partial class Inicio_component : UserControl
    {
         Thread hilo;
         private Jugador _jugador;
         public Inicio_component()
        {
            InitializeComponent();
            hilo = new Thread(parpadeo);
            hilo.Start();
        }

        
        public void insertarNombre(Jugador jugador)
        {
            _jugador = jugador;
            this.label2.Text = "Bienvenido " + _jugador.Nombre + " " + _jugador.Apepat + " " + _jugador.Apemat;
        }
    

        private void parpadeo()
        {
            while (true)
            {
                Thread.Sleep(1000);
                par();
            }
        }

        private void par()
        {
            if (InvokeRequired)
            {
                del_parpadeo dp = new del_parpadeo(par);
                Invoke(dp);
            }
            else
            {
                if (label1.Visible)
                {
                    label1.Visible = false;
                }
                else
                {
                    label1.Visible = true;
                }
            }
        }

        private delegate void del_parpadeo();

        public int nivel()
        {
            
                return  int.Parse(comboBox1.SelectedItem.ToString());
            
        }

        public void pararHilo()
        {
            this.hilo.Abort();
        }

    }
}
