using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyal.src.tools
{
    public class ClashRoyalExcepction : Exception 
    {
        private String _mensaje;
        public ClashRoyalExcepction(String mensaje)
        {
            _mensaje = mensaje;
        }

        public override string ToString()
        {
            return "Error: " + _mensaje + ".";
        }
    }
}
