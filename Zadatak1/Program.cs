//ne treba pisat ono system, namespace itd
//je li bolje to pisat kao nekakav standard?

class TicTacToe
{

    //inicijalizacija
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char currentPlayer = 'X';

    static void Main()
    {
        //inicijalizacija
        int turnCount = 0;
        bool gameEnded = false;

        while (!gameEnded)
        {
            //priprema konzole nakon svakog igranja u igri
            Console.Clear();
            DisplayBoard();
            Console.WriteLine($"Igrač {currentPlayer}, unesite broj (1-9) za vaš potez:");
            
            //parsiranje i provjera valjanosti unosa
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
            {
                board[choice - 1] = currentPlayer;
                turnCount++;

                //provjera pobjede ili neriješenog rezultata
                if (CheckWin())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine($"Igrač {currentPlayer} pobjeđuje! Čestitamo!");
                    gameEnded = true;
                }
                else if (turnCount == 9)
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine("Neriješeno! Nema slobodnih poteza.");
                    gameEnded = true;
                }
                else
                {
                    //ako igra idalje traje, zamijeni igrača
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
            else
            {
                Console.WriteLine("Nevažeći unos. Pokušajte ponovno.");
            }
        }
    }

    //funkcija za ispis ploče
    static void DisplayBoard()
    {
        Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
    }

    //funkcija za provjeru stanja igre
    static bool CheckWin()
    {
        //sve moguće pobjedničke kombinacije
        int[,] winConditions = new int[,] {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
            { 0, 4, 8 }, { 2, 4, 6 }
        };

        for (int i = 0; i < winConditions.GetLength(0); i++)
        {
            if (board[winConditions[i, 0]] == currentPlayer &&
                board[winConditions[i, 1]] == currentPlayer &&
                board[winConditions[i, 2]] == currentPlayer)
            {
                return true;
            }
        }

        return false;
    }
}