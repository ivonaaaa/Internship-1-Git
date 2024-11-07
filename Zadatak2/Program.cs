class Program
{
    static void Main()
    {
        //unos niza cijelih brojeva
        Console.WriteLine("Unesite niz cijelih brojeva, odvojenih razmacima: ");
        string? input = Console.ReadLine(); //!ovaj upitnik je tu jer se javljala greška zbog moguće unesene null vrijednsoti
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Neispravan unos. Molimo unesite cijele brojeve.");
            return;
        }

        //spremamo unesene brojeve u niz
        string[] inputArray = input.Split(' ');
        //instanciramo listu za kasnije
        List<int> numbers = new List<int>();

        //provjera je li broj cijeli, ako nije onda pretvorba
        foreach (string number in inputArray)
        {
            if (int.TryParse(number, out int num))
            {
                //kada je cijeli, dodajemo ga u novu listu
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine("Neispravan unos. Molimo unesite cijele brojeve.");
                return;
            }
        }

        //generiranje permutacija
        List<List<int>> permutations = new List<List<int>>();
        GeneratePermutations(numbers, 0, permutations);

        //ispis permutacija
        Console.WriteLine("Permutacije:");
        foreach (var perm in permutations)
        {
            Console.WriteLine(string.Join(" ", perm));
        }
    }

    //funkcija za izračun permutacija
    static void GeneratePermutations(List<int> numbers, int start, List<List<int>> result)
    {
        if (start >= numbers.Count)
        {
            result.Add(new List<int>(numbers));
            return;
        }

        for (int i = start; i < numbers.Count; i++)
        {
            Swap(numbers, start, i);
            GeneratePermutations(numbers, start + 1, result);
            Swap(numbers, start, i);
        }
    }

    //funkcija za zamjenu brojeva
    static void Swap(List<int> numbers, int i, int j)
    {
        int temp = numbers[i];
        numbers[i] = numbers[j];
        numbers[j] = temp;
    }
}