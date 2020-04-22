using ClashRoyal.src.tools.database;
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

        private Thread _hilo_oponente;
        private Thread _hilo_personajeOponente;
        private Thread _hilo_defensaJugadorTorre1;
        private Thread _hilo_defensaJugadorTorre2;
        private Thread _hilo_defensaJugadorRey;

        private Thread _hilo_elixir;
        private Thread _hilo_ganador;
        private Thread _hilo_tiempo;

        private bool juegoTerminado = false;

        private int _vidaOponente = 100;
        private int _vidaJugaor = 100;
        private int _danioAtaqueTorres = 20;
        private int _elixir = 10;
        private int[] personajes = new int[5];
        private int _elixirUsado = 0;
        private int _tiempo = 0;

        private delegate void del(Control c, int x, int y);
        
        private Carta _carta;
        public Juego(Jugador jugador, int nivel)
        {
            InitializeComponent();
            _jugador = jugador;
            nivel = 1;
            switch (nivel)
            {
                case 1:
                    this._danioAtaqueTorres = 10;
                    break;
                case 2:
                    this._danioAtaqueTorres = 20;
                    break;
                case 3:
                    this._danioAtaqueTorres = 50;
                    break;
            }
                        
        }
        private void del_mover(Control c, int x, int y)
        {
            if (InvokeRequired)
            {
                try
                {
                    del mover = new del(del_mover);
                    Object[] parametros = new Object[] { c, x, y };
                    Invoke(mover, parametros);
                }
                catch { }
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
                try
                {
                    del borrar = new del(del_borrar);
                    Object[] parametros = new Object[] { c, x, y };
                    Invoke(borrar, parametros);
                }
                catch { }
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
                try
                {
                    del quitar = new del(del_quitarVida);
                    Object[] parametros = new Object[] { c, x, y };
                    Invoke(quitar, parametros);
                }
                catch { }
            }
            else
            {
                ProgressBar vida = (ProgressBar)c;
                try
                {
                    if (vida.Value > 0)
                    vida.Value = x;
                }
                catch
                {

                    vida.Value = 0;
                }
            }

        }
        private void del_quitarVidaPersonaje(Control c, int x, int y = 0)
        {
            
            if (InvokeRequired)
            {
                try
                {
                    del quitar = new del(del_quitarVidaPersonaje);
                    Object[] parametros = new Object[] { c, x, y };
                    Invoke(quitar, parametros);
                }
                catch { }
            }
            else
            {
                personaje_component personaje = c as personaje_component;
                personaje.retarVida(x);
            }

        }
        private void del_ganador(Control c, int x, int y = 0)
        {
            if (InvokeRequired)
            {
                try
                {
                    del ganador = new del(del_ganador);
                    Object[] parametros = new Object[] { c, x, y };
                    Invoke(ganador, parametros);
                }
                catch { }
            }
            else
            {
                if (x == 1)
                {
                    this.label_anuncio.Text = "¡Has pedido!";
                }
                else
                {
                    this.label_anuncio.Text = "¡Has Ganado!";
                }
                label_anuncio.Location = new Point(label_anuncio.Location.X + 50, label_anuncio.Location.Y);
                label_anuncio.Visible = true;
                juegoTerminado = true;
            }

        }
        private void del_elixir(Control c, int x, int y = 0)
        {
            if (InvokeRequired)
            {
                try
                {
                    del elixir = new del(del_elixir);
                    Object[] parametros = new Object[] { c, x, y };
                    Invoke(elixir, parametros);
                }
                catch { }
            }
            else
            {

                this.label_elixir.Text = "Elixir: " + x;
            }

        }
        private void del_tiempo(Control c, int x, int y = 0)
        {
            if (InvokeRequired)
            {
                try
                {
                    del tiempo = new del(del_tiempo);
                    Object[] parametros = new Object[] { c, x, y };
                    Invoke(tiempo, parametros);
                }
                catch { }
            }
            else
            {

                this.label_tiempo.Text = "Tiempo: " + x + " segundos";
            }

        }
        private void del_terminado(Control c, int x=0, int y = 0)
        {
            if (InvokeRequired)
            {
                try
                {
                    del tiempo = new del(del_terminado);
                    Object[] parametros = new Object[] { c, x, y };
                    Invoke(tiempo, parametros);
                }
                catch { }
            }
            else
            {
                Inicio inicio = new Inicio(_jugador);
                inicio.Show();
                this.Dispose();
                
            }

        }
        private void ganador()
        {
            while (this._vidaOponente > 0 && this._vidaJugaor > 0)
            {

            }
            del_ganador(label_anuncio, this._vidaJugaor > 0 ? 2 : 1);
            terminar();
            int veces = personajes[0];
            int mayor = 0;
            for (int i = 1; i < personajes.Length; i++)
            {
                if (veces <= personajes[i])
                {
                    veces = personajes[i];
                    mayor = i;
                }
            }
            String personaje = "";
            switch (mayor)
            {
                case 1:
                    personaje = "Mosquetera";
                    break;
                case 2:
                    personaje = "Bebé dragón";
                    break;
                case 3:
                    personaje = "Esbirros";
                    break;
                case 4:
                    personaje = "Bruja";
                    break;
                case 5:
                    personaje = "Mago";
                    break;
            }
            Estadistica estadistica = new Estadistica
            {
                id_jugador = this._jugador.Id_jugador,
                danio = 100 - this._vidaJugaor,
                tiempo = this._tiempo,
                elixir = this._elixirUsado,
                personaje = personaje
            };
            (new Conexion()).insertarEstadistica(estadistica);

            (new Conexion()).insertarPartida(_jugador, this._vidaJugaor > 0 ? 1 : 0);
            terminar();
            del_terminado(this);
        }
        private void elixir()
        {
            while (!juegoTerminado)
            {
                if (this._elixir < 10)
                {
                    this._elixir++;
                    del_elixir(this.label_elixir, this._elixir);
                    Thread.Sleep(3000);
                }
            }
        }
        private void tiempo()
        {
            while (!juegoTerminado)
            {
                this._tiempo++;
                Thread.Sleep(1000);
                del_tiempo(label_tiempo, this._tiempo);
            }
        }
        private void oponente()
        {
            while (this._vidaOponente > 0)
            {
                    Thread.Sleep(5000);
                    this._hilo_personajeOponente = new Thread(personajeOponente);
                    this._hilo_personajeOponente.Start();
                
            }
        }
        private void personajeOponente(object obj)
        {
            var ubicaciones = new Point[] { this.panel_torre1Oponente.Location, this.panel_torre2Oponente.Location };
            int aleatorio = (new Random()).Next(0, 2);
            var carta_componente = new Cartas_component();
            carta_componente.setCarta((new Random()).Next(0, 4), true);
            var carta = carta_componente.Carta;
            personaje_component personaje = new personaje_component();
            personaje.setPersonaje(carta);
            var ubicacion = ubicaciones[aleatorio];
            personaje.Location = new Point(aleatorio == 0 ? ubicacion.X + 40 : ubicacion.X, ubicacion.Y + 80);
            del_crear(personaje);
            if (aleatorio == 0)
            {
                while (!panel_areaAtaqueJugador.Bounds.Contains(personaje.Location))
                {
                    del_mover(personaje, personaje.Location.X, personaje.Location.Y + 5);
                    Thread.Sleep(100);
                }
                this._hilo_defensaJugadorTorre1 = new Thread(defensaJugadorTorre1);
                this._hilo_defensaJugadorTorre1.Start(personaje);
                while (this.vida_torre1Jugador.Value > 0)
                {
                    if (personaje.Vida > 0)
                    {
                        PictureBox ataque = new PictureBox();
                        ataque.BackColor = Color.Red;
                        ataque.Size = new Size(10, 15);
                        ataque.Location = new Point(personaje.Location.X + (personaje.Width / 2), personaje.Location.Y + 40);
                        del_crear(ataque);
                        while (!this.panel_torre1Jugador.Bounds.Contains(ataque.Location))
                        {
                            del_mover(ataque, ataque.Location.X, ataque.Location.Y + 5);
                            Thread.Sleep(100);
                        }
                        del_quitarVida(this.vida_torre1Jugador, this.vida_torre1Jugador.Value - personaje.Carta.danio);
                        del_borrar(ataque);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        break;
                    }
                }
                if (personaje.Vida > 0)
                {
                    while (panel_reyJugador.Location.Y - 50 > personaje.Location.Y)
                    {
                        del_mover(personaje, personaje.Location.X, personaje.Location.Y + 5);
                        Thread.Sleep(100);
                    }
                    while (panel_reyJugador.Location.X + 10 > personaje.Location.X)
                    {
                        del_mover(personaje, personaje.Location.X + 5, personaje.Location.Y);
                        Thread.Sleep(100);
                    }
                    while (vida_reyJugador.Value > 0)
                    {
                        if (personaje.Vida > 0)
                        {
                            this._hilo_defensaJugadorRey = new Thread(defensaJugadorRey);
                            this._hilo_defensaJugadorRey.Start(personaje);
                            PictureBox ataque = new PictureBox();
                            ataque.BackColor = Color.Red;
                            ataque.Size = new Size(10, 15);
                            ataque.Location = new Point(personaje.Location.X + (personaje.Width / 2), personaje.Location.Y + 40);
                            del_crear(ataque);
                            while (!this.panel_reyJugador.Bounds.Contains(ataque.Location))
                            {
                                del_mover(ataque, ataque.Location.X, ataque.Location.Y + 5);
                                Thread.Sleep(100);
                            }
                            del_quitarVida(this.vida_reyJugador, this.vida_reyJugador.Value - personaje.Carta.danio);
                            del_borrar(ataque);
                            this._vidaJugaor = this.vida_reyJugador.Value;
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            del_borrar(personaje);
                        }
                    }
                }
                else
                {
                    del_borrar(personaje);
                }
            }
            else
            {
                while (!panel_areaAtaqueJugador.Bounds.Contains(personaje.Location))
                {
                    del_mover(personaje, personaje.Location.X, personaje.Location.Y + 5);
                    Thread.Sleep(100);
                }
                while (vida_torre2Jugador.Value > 0)
                {
                    this._hilo_defensaJugadorTorre2 = new Thread(defensaJugadorTorre2);
                    this._hilo_defensaJugadorTorre2.Start(personaje);
                    if (personaje.Vida > 0)
                    {
                        PictureBox ataque = new PictureBox();
                        ataque.BackColor = Color.Red;
                        ataque.Size = new Size(10, 15);
                        ataque.Location = new Point(personaje.Location.X + (personaje.Width / 2), personaje.Location.Y + 40);
                        del_crear(ataque);
                        while (!this.panel_torre2Jugador.Bounds.Contains(ataque.Location))
                        {
                            del_mover(ataque, ataque.Location.X, ataque.Location.Y + 5);
                            Thread.Sleep(100);
                        }
                        del_quitarVida(this.vida_torre2Jugador, this.vida_torre2Jugador.Value - personaje.Carta.danio);
                        del_borrar(ataque);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        break;
                    }
                }
                if (personaje.Vida > 0)
                {
                    
                    while (panel_reyJugador.Location.Y - 50 > personaje.Location.Y)
                    {
                        del_mover(personaje, personaje.Location.X, personaje.Location.Y + 5);
                        Thread.Sleep(100);
                    }
                    while (panel_reyJugador.Location.X + 10 < personaje.Location.X)
                    {
                        del_mover(personaje, personaje.Location.X - 5, personaje.Location.Y);
                        Thread.Sleep(100);
                    }
                     while (vida_reyJugador.Value > 0)
                     {
                         if (personaje.Vida > 0)
                         {
                             this._hilo_defensaJugadorRey = new Thread(defensaJugadorRey);
                             this._hilo_defensaJugadorRey.Start(personaje);
                             PictureBox ataque = new PictureBox();
                             ataque.BackColor = Color.Red;
                             ataque.Size = new Size(10, 15);
                             ataque.Location = new Point(personaje.Location.X + (personaje.Width / 2), personaje.Location.Y + 40);
                             del_crear(ataque);
                             while (!this.panel_reyJugador.Bounds.Contains(ataque.Location))
                             {
                                 del_mover(ataque, ataque.Location.X, ataque.Location.Y + 5);
                                 Thread.Sleep(100);
                             }
                             del_quitarVida(this.vida_reyJugador, this.vida_reyJugador.Value - personaje.Carta.danio);
                             del_borrar(ataque);
                             this._vidaJugaor = this.vida_reyJugador.Value;
                             Thread.Sleep(2000);
                         }
                         else
                         {
                             del_borrar(personaje);
                         }
                     }
                }
                else
                {
                    del_borrar(personaje);
                }
            }
        }
        private void defensaJugadorTorre1(object sender)
        {
            personaje_component personaje = sender as personaje_component;
            while (personaje.Vida > 0)
            {
                if (vida_torre1Jugador.Value > 0)
                {
                    PictureBox ataque = new PictureBox();
                    ataque.BackColor = Color.Blue;
                    ataque.Location = new Point(this.panel_torre1Jugador.Location.X + this.panel_torre1Jugador.Width / 2, this.panel_torre1Jugador.Location.Y + this.panel_torre1Jugador.Height - 50);
                    ataque.Size = new Size(10, 15);
                    del_crear(ataque);
                    while (!personaje.Bounds.Contains(ataque.Location))
                    {
                        del_mover(ataque, ataque.Location.X, ataque.Location.Y - 5);
                        Thread.Sleep(100);
                    }
                    del_quitarVidaPersonaje(personaje, personaje.Vida - this._danioAtaqueTorres);
                    del_borrar(ataque);
                    Thread.Sleep(2000);
                }
                else
                {
                    break;
                }
            }
        }
        private void defensaJugadorRey(object sender)
        {
            personaje_component personaje = sender as personaje_component;
            while (personaje.Vida > 0)
            {
                if (vida_reyJugador.Value > 0)
                {
                    PictureBox ataque = new PictureBox();
                    ataque.BackColor = Color.Blue;
                    ataque.Location = new Point(this.panel_reyJugador.Location.X + this.panel_reyJugador.Width / 2, this.panel_reyJugador.Location.Y + this.panel_reyJugador.Height - 50);
                    ataque.Size = new Size(10, 15);
                    del_crear(ataque);
                    while (!personaje.Bounds.Contains(ataque.Location))
                    {
                        del_mover(ataque, ataque.Location.X, ataque.Location.Y - 5);
                        Thread.Sleep(100);
                    }
                    del_quitarVidaPersonaje(personaje, personaje.Vida - this._danioAtaqueTorres);
                    del_borrar(ataque);
                    Thread.Sleep(2000);
                }
                else
                {
                    break;
                }
            }
        }
        private void defensaJugadorTorre2(object sender)
        {
            personaje_component personaje = sender as personaje_component;
            while (personaje.Vida > 0)
            {
                if (vida_torre2Jugador.Value > 0)
                {
                    PictureBox ataque = new PictureBox();
                    ataque.BackColor = Color.Blue;
                    ataque.Location = new Point(this.panel_torre2Jugador.Location.X + this.panel_torre2Jugador.Width / 2, this.panel_torre2Jugador.Location.Y + this.panel_torre2Jugador.Height - 50);
                    ataque.Size = new Size(10, 15);
                    del_crear(ataque);
                    while (!personaje.Bounds.Contains(ataque.Location))
                    {
                        del_mover(ataque, ataque.Location.X, ataque.Location.Y - 5);
                        Thread.Sleep(100);
                    }
                    del_quitarVidaPersonaje(personaje, personaje.Vida - this._danioAtaqueTorres);
                    del_borrar(ataque);
                    Thread.Sleep(2000);
                }
                else
                {
                    break;
                }
            }
        }
        void cartasclick_presionado(object sender, MouseEventArgs e)
        {
            this._carta = (sender as Cartas_component).Carta;
        }
        void cartasclick_sinPresionar(object sender, MouseEventArgs e)
        {
            int diferencia = this._elixir - this._carta.elixir;
            if (diferencia>0)
            {
                this._elixir = diferencia;
                this._elixirUsado += this._carta.elixir;
                del_elixir(this.label_elixir, this._elixir);
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

                        switch (personaje.Carta.nombre)
                        {
                            case "Mosquetera":
                                personajes[0]++;
                                break;
                            case "Bebé dragón":
                                personajes[1]++;
                                break;
                            case "Esbirros":
                                personajes[2]++;
                                break;
                            case "Bruja":
                                personajes[3]++;
                                break;
                            case "Mago":
                                personajes[4]++;
                                break;
                        }
                    }
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
                            del_mover(ataque, ataque.Location.X, ataque.Location.Y - 5);
                            Thread.Sleep(100);

                        }

                        del_quitarVida(this.vida_torre1Oponente, vida_torre1Oponente.Value - personaje.Carta.danio);
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
                                del_mover(ataque, ataque.Location.X, ataque.Location.Y - 5);
                                Thread.Sleep(100);
                            }
                            del_quitarVida(this.vida_reyOponente, vida_reyOponente.Value - personaje.Carta.danio);
                            this._vidaOponente = this.vida_reyOponente.Value;
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
                            del_mover(ataque, ataque.Location.X, ataque.Location.Y - personaje.Carta.danio);
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
                        del_mover(personaje, personaje.Location.X - 4, personaje.Location.Y - 5);
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
                                del_mover(ataque, ataque.Location.X, ataque.Location.Y - 5);
                                Thread.Sleep(100);
                            }
                            del_quitarVida(this.vida_reyOponente, vida_reyOponente.Value - personaje.Carta.danio);
                            this._vidaOponente = this.vida_reyOponente.Value;
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
                del_quitarVidaPersonaje(personaje, personaje.Vida - this._danioAtaqueTorres);
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
                del_quitarVidaPersonaje(personaje, personaje.Vida - this._danioAtaqueTorres);
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
                del_quitarVidaPersonaje(personaje, personaje.Vida - this._danioAtaqueTorres);
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

            this._hilo_oponente = new Thread(oponente);
            this._hilo_oponente.Start();

            this._hilo_ganador = new Thread(ganador);
            this._hilo_ganador.Start();

            this._hilo_elixir = new Thread(elixir);
            this._hilo_elixir.Start();

            this._hilo_tiempo= new Thread(tiempo);
            this._hilo_tiempo.Start();
        }
        private void Juego_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.label_anuncio.Visible = false;
                cargarCartas();
                configuracion();
            }
            if (e.KeyChar == 27)
            {
                terminar();
                Inicio inicio = new Inicio(_jugador);
                inicio.Show();
                this.Dispose();
            }
        }
        private void terminar()
        {
            try
            {
                _hilo_personajeJugador.Abort();
            }
            catch { }
            try
            {
                _hilo_defensaOponenteTorre1.Abort();
            }
            catch { }
            try
            {
                _hilo_defensaOponenteTorre2.Abort();
            }
            catch { }
            try
            {
                _hilo_defensaOponenteRey.Abort();
            }
            catch { }
            try
            {
                _hilo_oponente.Abort();
            }
            catch { }
            try
            {
                _hilo_personajeOponente.Abort();
            }
            catch { }
            try
            {
                _hilo_defensaJugadorTorre1.Abort();
            }
            catch { }
            try
            {
                _hilo_defensaJugadorTorre2.Abort();
            }
            catch { }
            try
            {
                _hilo_defensaJugadorRey.Abort();
            }
            catch { }
            
            try
            {
                _hilo_elixir.Abort();
            }
            catch { }
            try
            {
                _hilo_tiempo.Abort();
            }
            catch { }

        }
        

    }
}