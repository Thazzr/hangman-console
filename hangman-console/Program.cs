using Microsoft.VisualBasic;
using System.Drawing;
using System.Globalization;

ConsoleColor startColor = Console.ForegroundColor;
List<string> Words = new List<string>();
List<string> RndWords = new List<string>();
List<char> Chars = new List<char>();
List<char> CharControl = new List<char>();
Random rnd = new Random();
int randomword;
int wordNr = 0;
int selectedword = 0;
int faultcount = 0;
bool inputgood = false;
string secredword;
bool initdone = false;
char inputchar;
bool inputchargood = false;
bool charfound = false;
string inputword;
bool win = false;
string wordplay = "";
bool inputok;
bool cheat = false;
int cheatquote;

for (; ; ) //loop to keep console alive and repeat game
{
    while (!initdone) //init data
    {
        Words.Clear();
        RndWords.Clear();
        Words.Add("Programmiersprache");
        Words.Add("Sourcecode");
        Words.Add("Compiler");
        Words.Add("Software");
        Words.Add("Entwickler");
        Words.Add("Funktion");
        Words.Add("Variable");
        Words.Add("Operator");
        Words.Add("Schleife");
        Words.Add("Debuggen");
        Words.Add("Algorithmus");
        Words.Add("Float");
        Words.Add("Integer");
        Words.Add("Schlüsselwort");
        Words.Add("Syntaxfehler");
        Words.Add("Zuweisung");
        Words.Add("c sharp");
        Words.Add("Boolean");
        Words.Add("Computer");
        Words.Add("GitHub");
        Words.Add("GitLab");
        Words.Add("Shell");
        Chars.Add(' ');

        for (int i = 0; i < 5; i++)
        {
            randomword = rnd.Next(Words.Count());
            RndWords.Add(Words[randomword]);
            Words.Remove(Words[randomword]);
        }
        initdone = true;
    }

    while (!inputgood)
    {
        Console.WriteLine("Hallo Spieler.\nEs befinden sich "
            + 
            (Words.Count() + 5)
            +
            " Woerter in der Datenbank, von dennen wir 5 nur fuer dich ausgewaehlt haben.\n" 
            +
            "Bitte gib die Zahl des Wortes ein, dass du erraten moechtest oder beende das Spiel durch eingabe der Zahl 99\n");


        foreach (string word in RndWords)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(wordNr + ": ");
            foreach (char n in word)
            {
                if (n == ' ')
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("_");
                }

            }
            Console.WriteLine();
            wordNr++;
        }
        Console.ForegroundColor = startColor;
        Console.Write("\nZahl: ");
        inputgood = int.TryParse(Console.ReadLine(), out selectedword);

        if (!(inputgood && selectedword >= 0 && selectedword <= 4))
        {
            inputgood = false;
            wordNr = 0;
        }
        
        if (selectedword == 99)
        {
            Environment.Exit(0);
        }
        Console.Clear();

    }
    secredword = RndWords[selectedword];

    while (!inputchargood)
    {
        while (faultcount <= 6)
        {
            if (wordplay == secredword)
            {
                win = true;
                break;
            }
            else
            {
                switch (faultcount)
                {
                    case 0:
                        Console.ForegroundColor = startColor;
                        Console.WriteLine("  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n============");
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n============");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n============");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n============");
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n============");
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n============");
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n============");
                        break;
                    default:
                        break;
                }

                switch (faultcount)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        Console.ForegroundColor = startColor;
                        Console.Write("Wort: ");
                        CharControl.Clear();
                        wordplay = "";
                        foreach (char schar in secredword)
                        {
                            foreach (char ichar in Chars)
                            {
                                if (Char.ToLower(schar) == Char.ToLower(ichar))
                                {
                                    charfound = true;
                                    break;
                                }
                                else
                                {
                                    charfound = false;
                                }
                            }
                            if (charfound)
                            {
                                CharControl.Add(schar);
                            }
                            else
                            {
                                CharControl.Add('_');
                            }
                        }
                        foreach (Char cc in CharControl)
                        {
                            wordplay = wordplay + cc;
                        }
                        Console.Write(wordplay);
                        if (wordplay == secredword)
                        {
                            win = true;
                            break;
                        }
                        else
                        {
                            if (cheat)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("\nCheat On: " + secredword);
                                Console.ForegroundColor = startColor;
                            }
                            Console.Write("\nBuchstabe oder Wort: ");
                            inputword = Console.ReadLine();
                            inputchargood = (char.TryParse(inputword, out inputchar));
                            inputok = false;
                        }

                        if (inputchargood)
                        {
                            Chars.Add(inputchar);
                            foreach (char sc in secredword)
                            {
                                if(Char.ToLower(sc) == Char.ToLower(inputchar))
                                {
                                    inputok = true;
                                }
                            }
                            if (!inputok)
                            {
                                faultcount++;
                            }
                        }
                        else if (String.Compare(secredword, inputword, true) == 0)
                        {
                            foreach (char iw in inputword)
                            {
                                Chars.Add(iw);
                            }
                            if (wordplay == secredword)
                            {
                                win = true;
                                break;
                            }
                        }
                        else if (inputword == "sudo cheat on")
                        {
                            cheat = true;
                        }
                        else if (inputword == "sudo exit")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            faultcount++;
                        }
                        break;
                    case 6:
                        Console.WriteLine("Leider Verloren! :/\ndas gesuchte Worte waere " + secredword + " gewesen\nViel Glueck beim nächsten Versuch.\nzum Wiederholen Enter druecken");
                        Console.ReadLine();
                        faultcount++;
                        break;
                    default:
                        break;
                }
            }

            if (win)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (cheat) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    cheatquote = rnd.Next(4);
                    switch (cheatquote)
                    {
                        case 0:
                            Console.WriteLine("\nOne lie is enough to question all the truth.");
                            break;
                        case 1:
                            Console.WriteLine("\nI don't understand why people cheat.");
                            break;
                        case 2:
                            Console.WriteLine("\nCheating is a choice, not a mistake");
                            break;
                        case 3:
                            Console.WriteLine("\nYou Cheated Not Only the Game, But Yourself");
                            break;
                        case 4:
                            Console.WriteLine("\nWhy did you do this?");
                            break;

                    }
                    Console.WriteLine("Druecke die Enter-Taste um das Spiel neu zu starten\nwomoeglich ohne zu schummeln?");
                }
                else
                {
                    Console.WriteLine("\nGlueckwunsch du hast das Wort erraten.\nzum Wiederholen Enter druecken");
                }
                Console.ReadLine();
                Console.Clear();
               
                break;
            }
            else
            {
                Console.Clear();
            }
           
        }

        //reset program
        Console.ForegroundColor = startColor;
        Words.Clear();
        RndWords.Clear();
        Chars.Clear();
        CharControl.Clear();
        inputword = "";
        secredword = "";
        wordNr = 0;
        faultcount = 0;
        inputchargood = false;
        initdone = false;
        inputgood = false;
        charfound = false;
        win = false;
        cheat = false;
        Console.Clear();
        break;
    }

}
