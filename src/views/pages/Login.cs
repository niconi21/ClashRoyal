using ClashRoyal.src.tools.database;
using ClashRoyal.src.tools.Objects;
using ClashRoyal.src.tools;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            String usuario = txtNombre.Text;
            String clave = txtClave.Text;
            try
            {
                Jugador jugador = (new Conexion()).login(usuario, clave);
                if (jugador != null)
                {
                    Cargar c = new Cargar(jugador);
                    c.Show();
                    this.Dispose();
                }
            }
            catch (ClashRoyalExcepction ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            this.Dispose();
        }
    }
}
