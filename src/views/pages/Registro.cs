using ClashRoyal.src.tools;
using ClashRoyal.src.tools.database;
using ClashRoyal.src.tools.Objects;
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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Jugador jugador = new Jugador
                {
                    Usuario = txtUsuario.Text,
                    Clave = txtClave.Text,
                    Nombre = txtNombre.Text,
                    Apepat = txtApepat.Text,
                    Apemat = txtApemat.Text,
                };
                (new Conexion()).registro(jugador);
                Login login = new Login();
                login.Show();
                this.Dispose();
            }
            catch (ClashRoyalExcepction ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Dispose();
        }
    }
}
