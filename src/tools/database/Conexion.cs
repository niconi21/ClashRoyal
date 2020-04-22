using ClashRoyal.src.tools.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyal.src.tools.database
{
    public class Conexion
    {

        private SqlConnection conexion;

        public Conexion()
        {
            conexion = new SqlConnection("server=DESKTOP-OE9RG4S ; database=ClashRoyal ; integrated security = true");
        }

        public Jugador login(String usuario, String clave)
        {
            conexion.Open();
            String consulta = "SELECT * FROM Jugador WHERE usuario = '" + usuario + "' AND clave = '" + clave + "'";
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            if (dr.Read())
            {
                Jugador jugador = new Jugador
                {
                    Id_jugador = int.Parse(dr["id_jugador"].ToString()),
                    Usuario = dr["usuario"].ToString(),
                    Clave = dr["clave"].ToString(),
                    Nombre = dr["nombre"].ToString(),
                    Apepat = dr["apepat"].ToString(),
                    Apemat = dr["apemat"].ToString()
                };
                dr.Close();
                conexion.Close();
                return jugador;
            }
            dr.Close();
            conexion.Close();
            throw new ClashRoyalExcepction("Usuario y/o contraseña incorrectos");
        }

        public void registro(Jugador jugador)
        {
            conexion.Open();
            String insertar = "INSERT INTO Jugador values ('" + jugador.Usuario + "','" + jugador.Clave + "','" + jugador.Nombre + "','" + jugador.Apepat + "','" + jugador.Apemat + "')";
            SqlCommand sqlCommand = new SqlCommand(insertar, conexion);
            sqlCommand.ExecuteNonQuery();
            conexion.Close();
        }

        public void insertarPartida(Jugador jugador, int gana)
        {
            conexion.Open();
            String insertar = "INSERT INTO Partida values (" + jugador.Id_jugador + "," + gana + ")";
            SqlCommand sqlCommand = new SqlCommand(insertar, conexion);
            sqlCommand.ExecuteNonQuery();
            conexion.Close();
        }
        public List<Partida> consultarPartida(Jugador jugador)
        {
            conexion.Open();
            String consulta = "SELECT * FROM Partida WHERE id_jugador = " + jugador.Id_jugador;
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            List<Partida> partidas = new List<Partida>();
            while (dr.Read())
            {
                Partida paritda = new Partida
                {
                    id_partida = int.Parse(dr.GetInt32(0).ToString()),
                    id_jugador = int.Parse(dr.GetInt32(1).ToString()),
                    gana = int.Parse(dr.GetInt32(2).ToString()),
                };
                partidas.Add(paritda);
            }
            return partidas;
        }

        public void insertarEstadistica(Estadistica estadistica)
        {
            conexion.Open();
            String insertar = "INSERT INTO Estadistica values (" + estadistica.id_jugador + "," + estadistica.danio + "," + estadistica.tiempo + "," + estadistica.elixir + ",'" + estadistica.personaje + "')";
            SqlCommand sqlCommand = new SqlCommand(insertar, conexion);
            sqlCommand.ExecuteNonQuery();
            conexion.Close();
        }


        public List<Estadistica> consultarEstadisticas(Jugador jugador)
        {
            conexion.Open();
            String consulta = "SELECT * FROM Estadistica WHERE id_jugador = " + jugador.Id_jugador;
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            List<Estadistica> estadisticas = new List<Estadistica>();
            while (dr.Read())
            {
                Estadistica estadistica = new Estadistica
                {
                    id_estadistica = int.Parse(dr["id_estadistica"].ToString()),
                    id_jugador = int.Parse(dr["id_jugador"].ToString()),
                    danio = int.Parse(dr["danio"].ToString()),
                    tiempo = int.Parse(dr["tiempo"].ToString()),
                    elixir = int.Parse(dr["elixir"].ToString()),
                    personaje = dr["personaje"].ToString()
                };
                estadisticas.Add(estadistica);
            }
            return estadisticas;
        }

    }
}
