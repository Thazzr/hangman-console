namespace hangman_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> Words = new List<string>();
            List<string> RndWords = new List<string>();
            Random rnd = new Random();
            int randomword;
            int wordNr = 0;
            int selectedword;
            int faultcount;
            bool inputgood = false;

            Words.Add("Hase");
            Words.Add("Raumschiff");
            Words.Add("Roboter");
            Words.Add("Software");
            Words.Add("Entwickler");
            Words.Add("Elektrizitätswirtschaftsorganisationsgesetz");
            Words.Add("Burgverlies");
            Words.Add("lizensieren");

            for (int i = 0; i < 5; i++)
            {
                randomword = rnd.Next(Words.Count());
                RndWords.Add(Words[randomword]);
                Words.Remove(Words[randomword]);
            }

            

           

            while (!inputgood)
            {
                Console.WriteLine("Ein Wort wählen. \nZahl des Wortes eingeben und Enter drücken\n");

                foreach (string word in RndWords)
                {

                    Console.Write(wordNr + ": ");
                    foreach (char n in word)
                    {
                        Console.Write("_");
                    }
                    Console.WriteLine();
                    wordNr++;
                }

                Console.Write("\nZahl: ");
                inputgood = int.TryParse(Console.ReadLine(), out selectedword);
                wordNr= 0;
                if (!(inputgood && selectedword >= 0 && selectedword <= 4))
                {
                    inputgood = false;
                }
                Console.Clear();
            }

            Console.Clear();


            Console.WriteLine("  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n============");
            Console.WriteLine("selectedword");
        }
    }
}