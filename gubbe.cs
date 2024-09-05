using System;
using System.Security.Cryptography;
using System.Text;


class Program
{
    static void ascii(int lifesLeft)
    {
        if (lifesLeft == 6)
        {
            Console.WriteLine("");
        }

        if (lifesLeft == 5)
        {
            Console.WriteLine("");
            Console.WriteLine(" O");
        }

        if (lifesLeft == 4)
        {
            Console.WriteLine("");
            Console.WriteLine(" O");
            Console.WriteLine("|");
        }

        if (lifesLeft == 3)
        {
            Console.WriteLine("");
            Console.WriteLine(" O");
            Console.WriteLine("/|");
        }

        if (lifesLeft == 2)
        {
            Console.WriteLine("");
            Console.WriteLine(" O");
            Console.WriteLine(@"/|\");
        }

        if (lifesLeft == 1)
        {
            Console.WriteLine("");
            Console.WriteLine(" O");
            Console.WriteLine(@"/|\");
            Console.WriteLine(" /");
        }

        if (lifesLeft == 0)
        {
            Console.WriteLine("");
            Console.WriteLine(" O");
            Console.WriteLine(@"/|\");
            Console.WriteLine(@" /\");
}
    }
    static void Main(string[] args)
    {
        bool playGame = true;
        int lifesLeft = 6;
        while (playGame == true)
        {
            List<string> guessedChars = new List<string>();
            string[] wordList = { "spel", "bakterie", "absolut", "egendom", "frukter", "annorlunda" };
            Random rnd = new Random();
            int wordChoice = rnd.Next(0, 5);
            string secretWord = (wordList[wordChoice]);
            Console.WriteLine(secretWord);
            StringBuilder displayString = new StringBuilder();

            for (int i = 0; i < secretWord.Length; i++)
            {
                displayString.Append('_');
            }

            while (lifesLeft > 0)
            {

                Console.WriteLine("gissa ett tecken");
                string inputLine = Console.ReadLine();
                char newChar = inputLine[0];
                bool hit = false;


                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (newChar == secretWord[i])
                    {
                        hit = true;
                    }
                }
                if (hit == true)
                {
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (newChar == secretWord[i])
                        {
                            displayString[i] = secretWord[i];
                        }
                    }
                    if (displayString.ToString() == secretWord)
                    {
                        break;
                    }
                    if (secretWord == inputLine)
                    {
                        break;
                    }
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.WriteLine("Du gissade rätt!");
                        Console.WriteLine(displayString);
                        Console.WriteLine("Gissade karaktärer:");
                        Console.WriteLine(String.Join(",", guessedChars));
                        ascii(lifesLeft);
                    
                }
                else
                {
                    if (guessedChars.Contains(inputLine))
                    {
                        Console.WriteLine("Du har redan gissat detta!");
                    }
                    else
                    {
                    lifesLeft--;
                        guessedChars.Add(inputLine);
                    }
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("tecknet fanns inte i ordet. " + lifesLeft + " liv kvar");
                    Console.WriteLine(displayString);
                    Console.WriteLine("Gissade karaktärer:");
                    Console.WriteLine(String.Join(",", guessedChars));
                    ascii(lifesLeft);
                }
            }

            if (lifesLeft == 0)
            {
                Console.WriteLine("Du förlorade! Ordet var " + secretWord);
                Console.WriteLine("Vill du spela igen? (ja/nej)");
                string answer = Console.ReadLine();
                if (answer == "ja")
                {
                }
                else {
                    playGame = false;
                }
            }
            else
            {
                Console.WriteLine("Du vann! Ordet var " + secretWord);
                Console.WriteLine("Vill du spela igen? (ja/new)");
                string answer = Console.ReadLine();
                if (answer == "ja")
                {
                    Console.Clear();
                    lifesLeft = 6;
                }
                else
                {
                    playGame = false;
                    Environment.Exit(0);
                }
            }
        }
}
}
