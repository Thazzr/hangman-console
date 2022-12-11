namespace hangman_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> Words = new List<string>();
            List<string> RndWords = new List<string>();
            bool doubleword = false;
            string wordtemp;
            Random rnd = new Random();

            Words.Add("Hase");
            Words.Add("Raumschiff");
            Words.Add("Roboter");
            Words.Add("Software");
            Words.Add("Entwickler");
            Words.Add("Elektrizitätswirtschaftsorganisationsgesetz");
            Words.Add("Burgverlies");
            Words.Add("lizensieren");

            for (int i = 0; i < 5;)
            {
                wordtemp = Words[rnd.Next(Words.Count())];
                foreach (string word in RndWords) 
                { 
                    
                    if (word == wordtemp)
                    {
                        doubleword = true;
                        break;
                    }
                }
                if (!doubleword)
                {
                    RndWords.Add(wordtemp);
                    i++;
                }
                RndWords.Add(Words[rnd.Next(Words.Count())]);
            }
            


            Console.WriteLine(rnd.Next(Words.Count()));


            //for (int i = 0; i < 5; i++)
            //{
                
            //    doublenumber = false;
            //    foreach (int n in RndNumbers)
            //    {
            //      if (i == n)
            //        {
            //            doublenumber= true;
            //        }
            //    }
            //    if (!doublenumber)
            //    {
            //        RndNumbers.Add(i);
            //    }
                

            //}
            



            //foreach (string word in Words)
            //{
            //    Console.Write(i + " ");
            //    foreach (char n in word)
            //    {
            //        Console.Write("_");
            //    }
            //    Console.WriteLine();
            //    i++;
            //}

        }
    }
}