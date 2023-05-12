using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors_Placement_Tool
{
    public class Program
    {

        static List<Groep> groepenZonderKinderen = new List<Groep>();
        static List<Groep> groepenMetKinderen = new List<Groep>();
        static List<Bezoeker> losseBezoekers = new List<Bezoeker>();

        static List<Vak> vakken = new List<Vak>();

        static void Main()
        {
            int bezoekersId = 0;
            int groepsNummer = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Wil je een groep met kinderen aanmelden? (Y/N)");
                bool nieuweGroepKinderen = Console.ReadLine().ToUpper() == "Y";

                if (nieuweGroepKinderen)
                {
                    Groep groep = BezoekersAddToGroep(groepsNummer, bezoekersId);
                    groepenMetKinderen.Add(groep);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wil je een groep met alleen volwassenen aanmelden? (Y/N)");
                    bool nieuweGroepVolwassenen = Console.ReadLine().ToUpper() == "Y";

                    if (nieuweGroepVolwassenen)
                    {
                        Groep groep = BezoekersAddToGroep(groepsNummer, bezoekersId);
                        groepenZonderKinderen.Add(groep);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Wil je een losse reservering maken? (Y/N)");
                        bool nieuweLosseBezoeker = Console.ReadLine().ToUpper() == "Y";

                        if (nieuweLosseBezoeker)
                        {
                            Console.Clear();
                            Console.WriteLine("Vul je geboortedatum (dd-mm-yyyy) in:");
                            DateTime geboorteDatum = DateTime.Parse(Console.ReadLine());
                            Bezoeker bezoeker = new Bezoeker(bezoekersId, geboorteDatum, DateTime.Now);
                            bezoekersId++;
                            losseBezoekers.Add(bezoeker);
                        }
                        else
                        {
                            losseBezoekers.Sort((bezoeker1, bezoeker2) => bezoeker1.GeboorteDatum.CompareTo(bezoeker2.GeboorteDatum));
                            break;
                        }
                    }
                }
            }

        }

        static Groep BezoekersAddToGroep(int groepsNummer, int bezoekersId)
        {
            Groep groep = new Groep();
            groep.Id = groepsNummer;
            groepsNummer++;

            List<Bezoeker> bezoekers = new List<Bezoeker>();

            while (true)
            {
                Console.WriteLine("Vul de geboortedatum (dd-mm-yyyy) van de groepsleden in:");
                DateTime geboorteDatum = DateTime.Parse(Console.ReadLine());
                Bezoeker bezoeker = NieuweAanmelding(bezoekersId, geboorteDatum, groep);
                bezoekersId++;

                bezoekers.Add(bezoeker);
                groep.Bezoekers = bezoekers;

                Console.Write("Wil je nog iemand toevoegen aan je groep? (Y/N)");
                string response = Console.ReadLine().ToUpper();
                if (response == "N")
                {
                    bezoekers.Sort((bezoeker1, bezoeker2) => bezoeker1.GeboorteDatum.CompareTo(bezoeker2.GeboorteDatum));
                    return groep;
                }
            }
        }

        static Bezoeker NieuweAanmelding(int id, DateTime geboortedatum, Groep groep)
        {
            Bezoeker bezoeker = new Bezoeker();
            bezoeker.Id = id;
            bezoeker.GeboorteDatum = geboortedatum;
            bezoeker.AanmeldDatum = DateTime.Now;
            bezoeker.Groep = groep;

            return bezoeker;
        }

        static void GroepPlaatsen(List<Groep> groepen) {
            foreach (var groep in groepen)
            {
                if (MeerDan10Kinderen(groep.Bezoekers))
                {
                    Vak vak = NieuwVak(10);
                }
            }

            
        }

        static bool HasEnoughSpace(List<Bezoeker> bezoekers)
        {
            return true;
        }

        static bool MeerDan10Kinderen(List<Bezoeker> bezoekers)
        {    
            int count = 0;
            foreach (Bezoeker bezoeker in bezoekers)
            {
                int age = DateTime.Today.Year - bezoeker.GeboorteDatum.Year;
                if (bezoeker.GeboorteDatum.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }

                if (age < 12)
                {
                    count++;
                }
            }

            if(count > 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int vakId = 0;

        static Vak NieuwVak(int rijLengte)
        {
            Vak vak = new Vak(vakId);
            for (int i = 0; i < 3; i++)
            {
                Rij rij = NieuweRij(rijLengte);
                vak.Rij = rij;
            }
            vakId++;
            vakken.Add(vak);
            return vak;
        }

        static int rijId = 0;

        static Rij NieuweRij(int rijLengte)
        {
            Rij rij = new Rij(rijId);
            for (int i = 0; i < rijLengte; i++)
            {
                Stoel stoel = NieuweStoel();
                rij.Stoel = stoel;
            }
            rijId++;
            if (rijId > 2)
            {
                rijId = 0;
            }
            return rij;
        }

        static int stoelId = 0;

        static Stoel NieuweStoel()
        {
            Stoel stoel = new Stoel(stoelId);
            stoelId++;
            return stoel;
        }
    }
}
