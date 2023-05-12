using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors_Placement_Tool
{
    public class Groep
    {
        public int Id { get; set; }
        public List<Bezoeker> Bezoekers { get; set; }

        public Groep ()
        {

        }
    }
}
