using RaktarApp;

List <Termek> termekek = new List <Termek>();

int hibasSorokSzama = 0;

try
{
    string[] lines = File.ReadAllLines("termekek.txt").Skip(1).ToArray();

    foreach (string line in lines)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            hibasSorokSzama++;
            continue;
        }

        string[] adatok = line.Split('|');

        if (adatok.Length != 4)
        {
            hibasSorokSzama++;
            continue;
        }

        string tipus = adatok[0];
        if (!(tipus == "S" || tipus == "G"))
        {
            hibasSorokSzama++;
            continue;
        }

        string cikkszam = adatok[1];
        if (string.IsNullOrWhiteSpace(cikkszam))
        {
            hibasSorokSzama++;
            continue;
        }

        int alapar = 0;
        if (!int.TryParse(adatok[2], out alapar))
        {
            hibasSorokSzama++;
            continue;
        }

        int garanciaEvek = 0;
        if (!int.TryParse(adatok[3], out garanciaEvek))
        {
            hibasSorokSzama++;
            continue;
        }

        // Példányosítás

        if (tipus == "S")
        {
            Termek termek = new Termek(cikkszam, alapar);
            termekek.Add(termek);
        }
        else if (tipus == "G")
        {
            TartosTermek tartosTermek = new TartosTermek(cikkszam, alapar, garanciaEvek);
            termekek.Add(tartosTermek);
        }
    }
}
catch (Exception exc)
{
    Console.WriteLine(exc);
}

Console.WriteLine($"Sikeresen beolvasott termékek száma: {termekek.Count} db");
Console.WriteLine($"Hibás sorok száma: {hibasSorokSzama} db\n");
termekek.ForEach(Console.WriteLine);
Console.WriteLine($"\nÖsszérték 10 darabot feltételezve termékenként: {termekek.Sum(t => t.ErtekSzamitas(10))} Ft");
Console.WriteLine($"Termékek statikus száma: {Termek.OsszesTermekSzama} db");
