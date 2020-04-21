using ClashRoyal.src.tools.Objects;
using ClashRoyal.src.views.components;
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
    public partial class Juego : Form
    {
        private Jugador _jugador;
        private Thread _hilo_personajeJugador;
        private Thread _hilo_defensaOponenteTorre1;
        private Thread _hilo_defensaOponenteTorre2;
        private Thread _hilo_defensaOponenteRey;
        private Thread _hilo_personajeOponente;
        private Thread _hilo_defensaJugadorTorre1;
        private Thread _hilo_defensaJugadorTorre2;
        private Thread _hilo_defensaJugadorRey;

        private delegate void del(Control c, int x, int y);


        private Carta _carta;
        public Juego(Jugador jugador)
        {
            InitializeComponent();
            _jugador = jugador;
            cargarCartas();
            configuracion();
        }

        private void del_mover(Control c, int x, int y)
        {
            if (InvokeRequired)
            {
                del mover = new del(del_mover);
                Object[] parametros = new Object[] { c, x, y };
                Invoke(mover, parametros);
            }
            else
            {
                c.Location = new Point(x, y);
            }
        }
        private void del_crear(Control c, int x = 0, int y = 0)
        {
            if (InvokeRequired)
            {
                del crear = new del(del_crear);
                Object[] parametros = new Object[] { c, x, y };
                Invoke(crear, parametros);
            }
            else
            {
                c.Parent = pictureBox_arena;
                this.Controls.Add(c);
                pictureBox_arena.SendToBack();

            }
        }
        private void del_borrar(Control c, int x = 0, int y = 0)
        {
            if (InvokeRequired)
            {
                del borrar = new del(del_borrar);
                Object[] parametros = new Object[] { c, x, y };
                Invoke(borrar, parametros);
            }
            else
            {
                c.Dispose();
            }
        }
        private void del_quitarVida(Control c, int x, int y = 0)
        {
            if (InvokeRequired)
            {
                del quitar = new del(del_quitarVida);
                Object[] parametros = new Object[] { c, x, y };
                Invoke(quitar, parametros);
            }
            else
            {
                ProgressBar vida = (ProgressBar)c;
                if (vida.Value > 0)
                    vida.Value = x;
            }

        }
        private void del_quitarVidaPersonaje(Control c, int x, int y = 0)
        {
            if (InvokeRequired)
            {
                del quitar = new del(del_quitarVidaPersonaje);
                Object[] parametros = new Object[] { c, x, y };
                Invoke(quitar, parametros);
            }
            else
            {
                personaje_component personaje = c as personaje_component;
                personaje.retarVida(x);
            }

        }
        
        void cartasclick_presionado(object sender, MouseEventArgs e)
        {
            this._carta = (sender as Cartas_component).Carta;
        }
        void cartasclick_sinPresionar(object sender, MouseEventArgs e)
        {
            if (pictureBox_arena.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                if (this.panel_spawnJugador.Bounds.Contains(this.PointToClient(Cursor.Position)))
                {
                    personaje_component personaje = new personaje_component();
                    personaje.setPersonaje(this._carta);
                    personaje.Location = this.PointToClient(Cursor.Position);
                    personaje.Parent = pictureBox_arena;
                    this.Controls.Add(personaje);
                    this.pictureBox_arena.SendToBack();
                    _hilo_personajeJugador = new Thread(moverPersonajeJugador);
                    _hilo_personajeJugador.Start(personaje);
                }
            }
            this._carta = null;
        }
        private void moverPersonajeJugador(object sender)
        {
            personaje_component personaje = sender as personaje_component;
            
            if (panel_areanaIzquierda.Bounds.Contains(personaje.Location))//los que aparecen en la izquierda
            {
                if (personaje.Location.X < pictureBox_arena.Location.X + panel_areanaIzquierda.Width / 2)//si están en la izquierda de la izquierda
                {
                    while (personaje.Location.X != (pictureBox_arena.Location.X + panel_areanaIzquierda.Width / 2) - 15)//lo movemos al ventro
                    {
                        if (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))//si llega al area de ataque o al centro,  se para el ciclo
                        {
                            del_mover(personaje, personaje.Location.X + 1, personaje.Location.Y - 5);
                            Thread.Sleep(100);
                        }
                        else
                        {
                            break;
                        }
                        if (!pictureBox_arena.Bounds.Contains(personaje.Location))//si se sale de la arena :v
                        {
                            del_borrar(personaje);
                        }
                    }
                    if (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))//si llega al centro de la izquierda, pero no llega al area de ataque
                    {
                        while (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))
                        {
                            del_mover(personaje, personaje.Location.X, personaje.Location.Y - 5);
                            Thread.Sleep(100);
                        }
                        if (!pictureBox_arena.Bounds.Contains(personaje.Location))//si se sale de la arena, se borra 
                        {
                            del_borrar(personaje);
                        }

                    }
                }
                if (personaje.Location.X > pictureBox_arena.Location.X + panel_areanaIzquierda.Width / 2)//si están en la derecha de la izquierda
                {
                    while (personaje.Location.X != (pictureBox_arena.Location.X + panel_areanaIzquierda.Width / 2) - 15) // los centramos o lo movemos a larea de ataque
                    {
                        if (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))
                        {
                            del_mover(personaje, personaje.Location.X - 3, personaje.Location.Y - 5);
                            Thread.Sleep(100);
                        }
                        else
                        {
                            break;
                        }
                        if (!pictureBox_arena.Bounds.Contains(personaje.Location)) //si se sale de la arena, se borra
                        {
                            del_borrar(personaje);
                        }
                    }
                    if (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))//si llega al centro pero no al area de ataque
                    {
                        while (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))
                        {
                            del_mover(personaje, personaje.Location.X, personaje.Location.Y - 5);
                            Thread.Sleep(100);
                        }
                        if (!pictureBox_arena.Bounds.Contains(personaje.Location))
                        {
                            del_borrar(personaje);
                        }
                    }
                }
                bool vive = true;
                while (vida_torre1Oponente.Value > 0)//aqui empieza a atacar
                {
                    _hilo_defensaOponenteTorre1 = new Thread(defensaOponenteTorre1);
                    _hilo_defensaOponenteTorre1.Start(personaje);
                    
                    if (personaje.Vida > 0)
                    {
                        PictureBox ataque = new PictureBox();
                        ataque.BackColor = Color.Blue;
                        ataque.Location = new Point(personaje.Location.X + (personaje.Size.Width / 2), personaje.Location.Y - 15);
                        ataque.Size = new Size(10, 15);
                        del_crear(ataque);
                        Thread.Sleep(2000);
                        while (!panel_torre1Oponente.Bounds.Contains(ataque.Location))
                        {
                            del_mover(ataque, ataque.Location.X, ataque.Location.Y - 1);
                            Thread.Sleep(100);

                        }

                        del_quitarVida(this.vida_torre1Oponente, vida_torre1Oponente.Value - 5);
                        del_borrar(ataque);
                    }
                    else
                    {
                        vive = false;
                        break;
                    }
                }
                if (vive)
                {
                    while (personaje.Location.Y > this.vida_reyOponente.Location.Y + 100)
                    {
                        del_mover(personaje, personaje.Location.X, personaje.Location.Y - 5);
                        Thread.Sleep(100);
                    }
                    while (personaje.Location.Y > this.vida_reyOponente.Location.Y + 80 && personaje.Location.X < this.vida_reyOponente.Location.X)
                    {
                        del_mover(personaje, personaje.Location.X + 4, personaje.Location.Y - 1);
                        Thread.Sleep(100);
                    }
                    while (vida_reyOponente.Value > 0)//aqui empieza a atacar
                    {
                        if (personaje.Vida > 0)
                        {
                            _hilo_defensaOponenteRey = new Thread(defensaReyOponente);
                            _hilo_defensaOponenteRey.Start(personaje);
                            PictureBox ataque = new PictureBox();
                            ataque.BackColor = Color.Blue;
                            ataque.Location = new Point(personaje.Location.X + (personaje.Size.Width / 2), personaje.Location.Y - 15);
                            ataque.Size = new Size(10, 15);
                            del_crear(ataque);
                            Thread.Sleep(2000);
                            while (!panel_reyOponente.Bounds.Contains(ataque.Location))
                            {
                                del_mover(ataque, ataque.Location.X, ataque.Location.Y - 1);
                                Thread.Sleep(100);
                            }
                            del_quitarVida(this.vida_reyOponente, vida_reyOponente.Value - 5);
                            del_borrar(ataque);
                        }
                        else
                        {
                            vive = false;
                            break;
                        }
                    }
                }

                
            }
            var mitad = this.pictureBox_arena.Location.X + this.pictureBox_arena.Width / 2;
            if (personaje.Location.X > mitad)
            {
                var mitad2=mitad + (this.pictureBox_arena.Location.X + this.pictureBox_arena.Width)/4 - 55;
                if (personaje.Location.X < mitad2 )//si están en la izquierda de la derecha
                {
                    while (personaje.Location.X != mitad2)//lo movemos al centro
                    {
                        if (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))//si llega al area de ataque o al centro,  se para el ciclo
                        {
                            del_mover(personaje, personaje.Location.X + 1, personaje.Location.Y - 5);
                            Thread.Sleep(100);
                        }
                        else
                        {
                            break;
                        }
                        if (!pictureBox_arena.Bounds.Contains(personaje.Location))//si se sale de la arena :v
                        {
                            del_borrar(personaje);
                        }
                    }
                    if (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))//si llega al centro de la izquierda, pero no llega al area de ataque
                    {
                        while (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))
                        {
                            del_mover(personaje, personaje.Location.X, personaje.Location.Y - 5);
                            Thread.Sleep(100);
                        }
                        if (!pictureBox_arena.Bounds.Contains(personaje.Location))//si se sale de la arena, se borra 
                        {
                            del_borrar(personaje);
                        }

                    }
                }
                if (personaje.Location.X > mitad2)//si están en la derecha de la derecha
                {
                    while (personaje.Location.X != mitad2) // los centramos o lo movemos a larea de ataque
                    {
                        if (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))
                        {
                            del_mover(personaje, personaje.Location.X - 3, personaje.Location.Y - 5);
                            Thread.Sleep(100);
                        }
                        else
                        {
                            break;
                        }
                        if (!pictureBox_arena.Bounds.Contains(personaje.Location)) //si se sale de la arena, se borra
                        {
                            del_borrar(personaje);
                        }
                    }
                    if (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))//si llega al centro pero no al area de ataque
                    {
                        while (!panel_areaAtaqueOpoente.Bounds.Contains(personaje.Location))
                        {
                            del_mover(personaje, personaje.Location.X, personaje.Location.Y - 5);
                            Thread.Sleep(100);
                        }
                        if (!pictureBox_arena.Bounds.Contains(personaje.Location))
                        {
                            del_borrar(personaje);
                        }
                    }
                }
                bool vive = true;
                while (vida_torre2Oponente.Value > 0)//aqui empieza a atacar
                {
                    _hilo_defensaOponenteTorre2 = new Thread(defensaOponenteTorre2);
                    _hilo_defensaOponenteTorre2.Start(personaje);
                    if (personaje.Vida > 0)
                    {
                        PictureBox ataque = new PictureBox();
                        ataque.BackColor = Color.Blue;
                        ataque.Location = new Point(personaje.Location.X + (personaje.Size.Width / 2), personaje.Location.Y - 15);
                        ataque.Size = new Size(10, 15);
                        del_crear(ataque);
                        Thread.Sleep(2000);
                        while (!panel_torre2Oponente.Bounds.Contains(ataque.Location))
                        {
                            del_mover(ataque, ataque.Location.X, ataque.Location.Y - 1);
                            Thread.Sleep(100);

                        }

                        del_quitarVida(this.vida_torre2Oponente, vida_torre2Oponente.Value - 5);
                        del_borrar(ataque);
                    }
                    else
                    {
                        vive = false;
                        break;
                    }
                }
                if (vive)
                {
                    while (personaje.Location.Y > this.vida_reyOponente.Location.Y + 100)
                    {
                        del_mover(personaje, personaje.Location.X, personaje.Location.Y - 5);
                        Thread.Sleep(100);
                    }
                    while (personaje.Location.Y > this.vida_reyOponente.Location.Y + 80 && personaje.Location.X > this.vida_reyOponente.Location.X)
                    {
                        del_mover(personaje, personaje.Location.X - 4, personaje.Location.Y - 1);
                        Thread.Sleep(100);
                    }
                    while (vida_reyOponente.Value > 0)//aqui empieza a atacar
                    {
                        _hilo_defensaOponenteRey = new Thread(defensaReyOponente);
                        _hilo_defensaOponenteRey.Start(personaje);
                        if (personaje.Vida > 0)
                        {
                            PictureBox ataque = new PictureBox();
                            ataque.BackColor = Color.Blue;
                            ataque.Location = new Point(personaje.Location.X + (personaje.Size.Width / 2), personaje.Location.Y - 15);
                            ataque.Size = new Size(10, 15);
                            del_crear(ataque);
                            Thread.Sleep(2000);
                            while (!panel_reyOponente.Bounds.Contains(ataque.Location))
                            {
                                del_mover(ataque, ataque.Location.X, ataque.Location.Y - 1);
                                Thread.Sleep(100);
                            }
                            del_quitarVida(this.vida_reyOponente, vida_reyOponente.Value - 5);
                            del_borrar(ataque);
                        }
                        else
                        {
                            vive = false;
                            break;
                        }
                    }
                }
                panel_torre1Oponente.FindForm();

            }
        }
        private void defensaOponenteTorre2(object sender)
        {
            personaje_component personaje = sender as personaje_component;
            var ubicacion = panel_torre2Oponente.Location;
            var tamanio = panel_torre2Oponente.Size;
            while (personaje.Vida > 0 || vida_torre2Oponente.Value > 0)
            {
                PictureBox ataque = new PictureBox();
                ataque.BackColor = Color.Red;
                ataque.Location = new Point(ubicacion.X + tamanio.Width / 2, ubicacion.Y + tamanio.Height - 50);
                ataque.Size = new Size(10, 15);
                del_crear(ataque);
                while (!personaje.Bounds.Contains(ataque.Location))
                {
                    del_mover(ataque, ataque.Location.X, ataque.Location.Y + 15);
                    Thread.Sleep(100);
                }
                del_quitarVidaPersonaje(personaje, personaje.Vida - 20);
                del_borrar(ataque);
                Thread.Sleep(2000);
                if (personaje.Vida == 0)
                {
                    del_borrar(personaje);
                    del_borrar(ataque);
                    break;
                }
            }
        }
        private void defensaReyOponente(object sender)
        {
            personaje_component personaje = sender as personaje_component;
            var ubicacion = panel_reyOponente.Location;
            var tamanio = panel_reyOponente.Size;
            while (personaje.Vida > 0 || vida_torre1Oponente.Value > 0)
            {
                PictureBox ataque = new PictureBox();
                ataque.BackColor = Color.Red;
                ataque.Location = new Point(personaje.Location.X + personaje.Width / 2, ubicacion.Y + tamanio.Height - 50);
                ataque.Size = new Size(10, 15);
                del_crear(ataque);
                while (!personaje.Bounds.Contains(ataque.Location))
                {
                    del_mover(ataque, ataque.Location.X, ataque.Location.Y + 15);
                    Thread.Sleep(100);
                }
                del_quitarVidaPersonaje(personaje, personaje.Vida - 20);
                del_borrar(ataque);
                Thread.Sleep(1000);
                if (personaje.Vida == 0)
                {
                    del_borrar(personaje);
                    del_borrar(ataque);
                    break;
                }
            }
        }
        private void defensaOponenteTorre1(object sender)
        {
            personaje_component personaje = sender as personaje_component;
            var ubicacion = panel_torre1Oponente.Location;
            var tamanio = panel_torre1Oponente.Size;
            while (personaje.Vida > 0 || vida_torre1Oponente.Value > 0)
            {
                PictureBox ataque = new PictureBox();
                ataque.BackColor = Color.Red;
                ataque.Location = new Point(ubicacion.X + tamanio.Width / 2, ubicacion.Y + tamanio.Height - 50);
                ataque.Size = new Size(10, 15);
                del_crear(ataque);
                while (!personaje.Bounds.Contains(ataque.Location))
                {
                    del_mover(ataque, ataque.Location.X, ataque.Location.Y + 15);
                    Thread.Sleep(100);
                }
                del_quitarVidaPersonaje(personaje, personaje.Vida - 20);
                del_borrar(ataque);
                Thread.Sleep(2000);
                if (personaje.Vida == 0)
                {
                    del_borrar(personaje);
                    del_borrar(ataque);
                    break;
                }
            }
        }
        private void cargarCartas()
        {
            this.cartaMosquetera_jugador.setCarta(0);
            this.cartaBebeDragon_jugador.setCarta(1);
            this.cartaEsbirros_jugador.setCarta(2);
            this.cartaBruja_jugador.setCarta(3);
            this.cartaMago_jugador.setCarta(4);
        }
        private void configuracion()
        {
            this.panel_areaAtaqueJugador.Parent = pictureBox_arena;
            this.panel_areaAtaqueOpoente.Parent = pictureBox_arena;
            this.panel_areanaIzquierda.Parent = pictureBox_arena;
            this.panel_arenaDerecha.Parent = pictureBox_arena;
            this.panel_reyJugador.Parent = pictureBox_arena;
            this.panel_reyOponente.Parent = pictureBox_arena;
            this.panel_spawnJugador.Parent = pictureBox_arena;
            this.panel_spawnOponente.Parent = pictureBox_arena;
            this.panel_torre1Jugador.Parent = pictureBox_arena;
            this.panel_torre1Oponente.Parent = pictureBox_arena;
            this.panel_torre2Jugador.Parent = pictureBox_arena;
            this.panel_torre2Oponente.Parent = pictureBox_arena;
            //this.panel_puente1.Parent = pictureBox_arena;
            //this.panel_puente2.Parent = pictureBox_arena;

            this.panel_areaAtaqueJugador.BackColor = Color.Transparent;
            this.panel_areaAtaqueOpoente.BackColor = Color.Transparent;
            this.panel_areanaIzquierda.BackColor = Color.Transparent;
            this.panel_arenaDerecha.BackColor = Color.Transparent;
            this.panel_reyJugador.BackColor = Color.Transparent;
            this.panel_reyOponente.BackColor = Color.Transparent;
            this.panel_spawnJugador.BackColor = Color.Transparent;
            this.panel_spawnOponente.BackColor = Color.Transparent;
            this.panel_torre1Jugador.BackColor = Color.Transparent;
            this.panel_torre1Oponente.BackColor = Color.Transparent;
            this.panel_torre2Jugador.BackColor = Color.Transparent;
            this.panel_torre2Oponente.BackColor = Color.Transparent;
            this.panel_puente1.BackColor = Color.Transparent;
            this.panel_puente2.BackColor = Color.Transparent;

            
        }

    }
}