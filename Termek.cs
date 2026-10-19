namespace RaktarApp
{
    public class Termek
    {
        public string Cikkszam { get; set; }

        protected int alapar;
        public int Alapar
        {
            get { return alapar; }
            set
            {
                alapar = value <= 0 ? 1000 : value;
            }
        }

        private static int osszesTermekSzama;
        public static int OsszesTermekSzama
        {
            get { return osszesTermekSzama; }
        }

        public Termek(string _cikkszam, int _alapar)
        {
            Cikkszam = _cikkszam;
            Alapar = _alapar;

            osszesTermekSzama++;
        }

        public virtual int ErtekSzamitas(int darabszam)
        {
            return Alapar * darabszam;
        }

        public override string ToString()
        {
            return $"Termék {Cikkszam} | Egységár: {Alapar} Ft";
        }
    }
}
