namespace RaktarApp
{
    public class TartosTermek : Termek
    {
        public int GaranciaEvek { get; set; }

        public TartosTermek(string _cikkszam, int _alapar, int _garanciaEvek) : base(_cikkszam, _alapar)
        {
            GaranciaEvek = _garanciaEvek;
        }

        public override int ErtekSzamitas(int darabszam)
        {
            return base.ErtekSzamitas(darabszam) + GaranciaEvek * darabszam * 500;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Garancia: {GaranciaEvek} év";
        }
    }
}
