using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors_Placement_Tool
{
    public class Rij
    {
        public int Id { get; set; }
        public Vak Vak { get; set; }

        public Rij(int id)
        {
            Id = id;
        }
        public Rij(int id, Vak vak)
        {
            Id = id;
            Vak = vak;
        }
    }
}
