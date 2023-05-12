using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors_Placement_Tool
{
    public class Bezoeker
    {
        public int Id { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public DateTime AanmeldDatum { get; set; }
        public Groep Groep { get; set; }

        public Bezoeker()
        {

        }

        public Bezoeker (int id, DateTime geboorteDatum, DateTime aanmeldDatum, Groep groep)
        {
            Id = id;
            GeboorteDatum = geboorteDatum;
            AanmeldDatum = aanmeldDatum;
            Groep = groep;
        }

        public Bezoeker (int id, DateTime geboorteDatum, DateTime aanmeldDatum)
        {
            Id = id;
            GeboorteDatum = geboorteDatum;
            AanmeldDatum = aanmeldDatum;
        }
    }
}
