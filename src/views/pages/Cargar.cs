using ClashRoyal.src.tools.Objects;
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
    public partial class Cargar : Form
    {
        private Thread _hiloBarra;
        private Jugador _jugador;

        private delegate void del(int i);
        public Cargar(Jugador jugador)
        {
            InitializeComponent();
            this.porcentaje.Parent = this.pictureBox1;
            _hiloBarra = new Thread(cargarBarra);
            _hiloBarra.Start();
            _jugador = jugador;
        }
        private void cargarBarra()
        {
            int i = 0;
            while (i <= 100)
            {
                Thread.Sleep(60);
                del_cargar(i);
                i++;
            }
            
        }
        private void del_cargar(int i)
        {
            if (InvokeRequired)
            {
                del cargar = new del(del_cargar);
                Object[] parametros = new object[] { i };
                Invoke(cargar, parametros);
            }
            else
            {
                this.barra.Value = i;
                this.porcentaje.Text = "Cargando... " + i + "%"; 
                if (this.barra.Value == this.barra.Maximum)
                {
                    Inicio inicio = new Inicio(_jugador);
                    inicio.Show();
                    _hiloBarra.Abort();
                    this.Dispose();

                }
            }
        }

    }
}
