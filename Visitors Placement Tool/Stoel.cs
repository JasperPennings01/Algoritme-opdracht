using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors_Placement_Tool
{
    public class Stoel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Rij Rij { get; set; }
        public Bezoeker Bezoeker { get; set; }

        public Stoel(int id)
        {
            Id = id;
        }

        public Stoel(int id, string name, Rij rij)
        {
            Id = id;
            Name = name;
            Rij = rij;
        }

        public Stoel(int id, string name, Rij rij, Bezoeker bezoeker)
        {
            Id = id;
            Name = name;
            Rij = rij;
            Bezoeker = bezoeker;
        }
    }
}
