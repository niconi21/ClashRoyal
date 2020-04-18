using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyal.src.tools.Objects
{
    public class Estadistica
    {
        public int id_estadistica { get; set; }
        public int id_jugador { get; set; }
        public int danio { get; set; }
        public int tiempo { get; set; }
        public int elixir { get; set; }
        public String personaje { get; set; }
    }
}
