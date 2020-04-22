﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyal.src.tools.Objects
{
    public class Carta
    {
        public String nombre { get; set; }
        public Image imagen { get; set; }
        public Image personaje { get; set; }
        public int danio { get; set; }
        public int elixir { get; set; }
    }
}
