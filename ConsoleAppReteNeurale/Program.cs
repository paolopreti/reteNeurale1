namespace ConsoleAppReteNeurale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "pesi.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Errore: Il file pesi.txt non esiste!");
                return;
            }

            double[] datiConfig = File.ReadAllLines(filePath).Select(line => double.Parse(line, System.Globalization.CultureInfo.InvariantCulture)).ToArray();

            double[] pesi = datiConfig.Take(5).ToArray();
            double bias = datiConfig[5];

            // input dall'utente
            string[] domande = {
            "L'artista è bravo? (1 per Sì, 0 per No): ",
            "Il meteo è favorevole? (1 per Sì, 0 per No): ",
            "Viene un amico? (1 per Sì, 0 per No): ",
            "C'è del buon cibo? (1 per Sì, 0 per No): ",
            "C'è dell'alcol? (1 per Sì, 0 per No): "
        };

            double[] inputs = new double[5];

            Console.WriteLine("--- Decisione Concerto AI ---");
            for (int i = 0; i < domande.Length; i++)
            {
                Console.Write(domande[i]);
                inputs[i] = double.Parse(Console.ReadLine());
            }

            // calcolo della rete
            double sommaPonderata = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                sommaPonderata += inputs[i] * pesi[i];
            }

            double risultatoFinale = sommaPonderata + bias;

            // output
            Console.WriteLine("\n--- Risultato ---");
            Console.WriteLine($"Punteggio calcolato: {risultatoFinale:F2}");

            if (risultatoFinale > 0)
            {
                Console.WriteLine("è deciso. ci vai");
            }
            else
            {
                Console.WriteLine("meglio restare a casa");
            }

            Console.ResetColor();
        }
    }
}
