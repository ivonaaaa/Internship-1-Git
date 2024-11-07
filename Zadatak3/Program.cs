class Program
{
    static void Main()
    {
        //unos maksimalnog broja znakova po liniji
        Console.Write("Unesite maksimalan broj znakova po liniji (m): ");
        int m = int.Parse(Console.ReadLine());

        //unos dužine linije
        Console.Write("Unesite dužinu linije (n): ");
        int n = int.Parse(Console.ReadLine());

        //unos teksta
        Console.WriteLine("Unesite tekst (za završetak unesite praznu liniju):");
        string input = string.Empty;
        string fullText = string.Empty;

        while (true)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrEmpty(line))
            {
                break; //završava unos kada se unese prazna linija
            }
            fullText += line + "\n"; //dodaje unesenu liniju u cjelokupni tekst
        }

        //procesiranje teksta
        string[] words = fullText.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        string currentLine = string.Empty;

        foreach (var word in words)
        {
            //provjera može li se riječ dodati u trenutnu liniju
            if (currentLine.Length + word.Length + 1 <= m)
            {
                if (currentLine.Length > 0)
                {
                    currentLine += " ";
                }
                currentLine += word;
            }
            else
            {
                //ispis trenutne linije centrirano
                PrintCenteredLine(currentLine, n);
                currentLine = word;
            }
        }

        //ispis posljednje linije ako postoji
        if (currentLine.Length > 0)
        {
            PrintCenteredLine(currentLine, n);
        }
    }

    //funkcija za ispis centrirane linije
    static void PrintCenteredLine(string line, int totalLength)
    {
        int spacesToPad = totalLength - line.Length;
        int leftPadding = spacesToPad / 2;
        int rightPadding = spacesToPad - leftPadding;

        //ispis lijevog razmaka, zatim linije, zatim desnog razmaka
        Console.Write(new string(' ', leftPadding));
        Console.WriteLine(line);
        Console.Write(new string(' ', rightPadding));
    }
}