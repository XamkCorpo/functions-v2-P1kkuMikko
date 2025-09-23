using System.Globalization;

namespace Calculator
{
    internal class Program
    {
        /// <summary>
        /// Kysyy käyttäjältä laskutoimituksen (1-4) ja varmistaa, että valinta on kelvollinen.
        /// </summary>
        /// <returns>Valittu laskutoimitus numerona: 1=Yhteenlasku, 2=Vähennyslasku, 3=Kertolasku, 4=Jakolasku.</returns>
        static int ValitseLaskutoimitus()
        {
            while (true)
            {
                System.Console.WriteLine("Valitse laskutoimitus:");
                System.Console.WriteLine("  1) Yhteenlasku");
                System.Console.WriteLine("  2) Vähennyslasku");
                System.Console.WriteLine("  3) Kertolasku");
                System.Console.WriteLine("  4) Jakolasku");
                System.Console.Write("Syötä valinta (1-4): ");

                var input = System.Console.ReadLine();
                if (int.TryParse(input, out int valinta) && valinta >= 1 && valinta <= 4)
                {
                    return valinta;
                }

                System.Console.WriteLine("Virheellinen valinta. Yritä uudelleen.\n");
            }
        }

        /// <summary>
        /// Pyytää käyttäjältä luvun ja varmistaa, että syöte on kelvollinen desimaaliluku.
        /// Hyväksyy sekä pilkun (",") että pisteen (".") desimaalierottimena.
        /// </summary>
        /// <param name="viesti">Käyttäjälle näytettävä pyyntöviesti.</param>
        /// <returns>Kelvollinen desimaaliluku.</returns>
        static decimal KysyLuku(string viesti = "Syötä luku: ")
        {
            while (true)
            {
                System.Console.Write(viesti);
                var input = System.Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    System.Console.WriteLine("Syöte ei ollut kelvollinen numero. Yritä uudelleen.\n");
                    continue;
                }

                input = input.Trim();

                // Jos sekä piste että pilkku löytyy, syöte on epäselvä
                if (input.Contains('.') && input.Contains(','))
                {
                    System.Console.WriteLine("Käytä vain yhtä desimaalierotinta (',' tai '.'). Yritä uudelleen.\n");
                    continue;
                }

                // Normalisoi desimaalipilkku pisteeksi ja käytä invariant-kulttuuria
                var normalized = input.Replace(',', '.');
                if (decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal luku))
                {
                    return luku;
                }

                System.Console.WriteLine("Syöte ei ollut kelvollinen numero. Yritä uudelleen.\n");
            }
        }

        /// <summary>
        /// Laskee kahden luvun summan.
        /// </summary>
        /// <param name="a">Ensimmäinen luku.</param>
        /// <param name="b">Toinen luku.</param>
        /// <returns>Lukujen summa.</returns>
        static decimal Yhteenlasku(decimal a, decimal b) => a + b;

        /// <summary>
        /// Laskee kahden luvun erotuksen.
        /// </summary>
        /// <param name="a">Ensimmäinen luku.</param>
        /// <param name="b">Toinen luku.</param>
        /// <returns>Lukujen erotus (a - b).</returns>
        static decimal Vahennyslasku(decimal a, decimal b) => a - b;

        /// <summary>
        /// Laskee kahden luvun tulon.
        /// </summary>
        /// <param name="a">Ensimmäinen luku.</param>
        /// <param name="b">Toinen luku.</param>
        /// <returns>Lukujen tulo.</returns>
        static decimal Kertolasku(decimal a, decimal b) => a * b;

        /// <summary>
        /// Laskee kahden luvun osamäärän desimaalilukuna.
        /// </summary>
        /// <param name="a">Laskettava luku (jaettava).</param>
        /// <param name="b">Jakaja (ei saa olla nolla).</param>
        /// <returns>Osamäärä (a / b) desimaalilukuna.</returns>
        static decimal Jakolasku(decimal a, decimal b) => a / b;

        /// <summary>
        /// Tulostaa laskutoimituksen tuloksen käyttäjälle.
        /// </summary>
        /// <param name="a">Ensimmäinen luku.</param>
        /// <param name="b">Toinen luku.</param>
        /// <param name="operaattori">Laskutoimituksen symboli, esim. '+', '-', '*', '/'.</param>
        /// <param name="tulos">Laskutoimituksen tulos.</param>
        static void TulostaTulos(decimal a, decimal b, char operaattori, decimal tulos)
        {
            System.Console.WriteLine($"\nTulos: {a} {operaattori} {b} = {tulos}");
        }

        static void Main(string[] args)
        {
            int valinta = ValitseLaskutoimitus();

            decimal a = KysyLuku("Syötä ensimmäinen luku: ");

            decimal b;
            if (valinta == 4)
            {
                // Jakolasku: varmista, ettei jakaja ole nolla
                while (true)
                {
                    b = KysyLuku("Syötä toinen luku (ei nolla): ");
                    if (b != 0m) break;
                    System.Console.WriteLine("Nollalla ei voi jakaa. Yritä uudelleen.\n");
                }
            }
            else
            {
                b = KysyLuku("Syötä toinen luku: ");
            }

            decimal tulos;
            char op;
            switch (valinta)
            {
                case 1:
                    tulos = Yhteenlasku(a, b);
                    op = '+';
                    break;
                case 2:
                    tulos = Vahennyslasku(a, b);
                    op = '-';
                    break;
                case 3:
                    tulos = Kertolasku(a, b);
                    op = '*';
                    break;
                case 4:
                    tulos = Jakolasku(a, b);
                    op = '/';
                    break;
                default:
                    // Ei pitäisi koskaan päätyä tänne, mutta asetetaan oletus varmuuden vuoksi
                    tulos = 0m;
                    op = '?';
                    break;
            }

            TulostaTulos(a, b, op, tulos);
        }
    }
}
