class Program
{
    static void Main()
    {
        Console.Write("Unesite broj redova: ");
        int n = int.Parse(Console.ReadLine());

        //gornji dio dijamanta
        for (int i = 1; i <= n; i += 2)
        {
            //ispis razmaka prije zvjezdica
            Console.Write(new string(' ', (n - i) / 2));
            //ispis zvjezdica
            Console.WriteLine(new string('*', i));
        }

        //donji dio dijamanta
        for (int i = n - 2; i >= 1; i -= 2)
        {
            //ispis razmaka prije zvjezdica
            Console.Write(new string(' ', (n - i) / 2));
            //ispis zvjezdica
            Console.WriteLine(new string('*', i));
        }
    }
}