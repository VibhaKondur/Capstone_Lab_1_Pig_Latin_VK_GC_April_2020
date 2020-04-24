using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Capstone_Lab_1_Pig_Latin_VK_GC_April_2020
{
    class Program
    {


        static void Main(string[] args)
        {

            //Console.WriteLine("Hey there! We're going to do some Pig Latin today! Let's translate a sentence to Pig Latin!");
            //Console.WriteLine("Type out a sentence!");
            //string input = Console.ReadLine();

            //Console.WriteLine("Enter a sentence to convert to PigLatin:");
            // string sentencetext = Console.ReadLine();

            Console.WriteLine("Welcome to the Pig Latin Translator!");

            bool runAgain = true;
            string runAgainstring = "";
            while (runAgain)
            {
                Console.WriteLine("Type out a sentence here and we'll translate it to Pig Latin.");
                string input = Console.ReadLine();
                string pigLatin = ToPigLatin(input);
                Console.WriteLine(pigLatin);

                Console.WriteLine("Awesome! Do you want to type out another sentence for us to translate to Pig Latin? y/n");

                runAgainstring = Console.ReadLine().ToLower();

                if (runAgainstring == "y")
                {
                    runAgain = true;
                }
                else
                {
                    Console.WriteLine("No problem. Have a great day!");
                    break;
                }

            }

        }
        public static string ToPigLatin(string sentencetext)
        {
            string vowels = "AEIOUaeiou";
            //string cons = "BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz";
            //STRING CONS = BCDFGHJKLMNPQRSTVWXYZ;
            List<string> newWords = new List<string>();


            foreach (string word in sentencetext.Split(' '))
            {
                if (word.Length == 1)
                {
                    newWords.Add(word + "way");
                }

                if (word.Length == 2 && vowels.Contains(word[0]))
                {
                    newWords.Add(word + "ay");
                }

                if (word.Length == 2 && vowels.Contains(word[1]) && !vowels.Contains(word[0]))
                {
                    newWords.Add(word.Substring(1) + word.Substring(0, 1) + "ay");
                }
                if (word.Length == 2 && !vowels.Contains(word[1]) && !vowels.Contains(word[0]))
                {
                    newWords.Add(word + "ay");
                }

                for (int i = 1; i < word.Length; i++)
                {
                    if (vowels.Contains(word[i]) && (vowels.Contains(word[0])))
                    {
                        newWords.Add(word.Substring(i) + word.Substring(0, i) + "ay");
                        break;
                    }
                }
                for (int i = 0; i < word.Length; i++)
                {
                    if (vowels.Contains(word[i]) && !(vowels.Contains(word[0])) && word.Length > 2)
                    {
                        newWords.Add(word.Substring(i) + word.Substring(0, i) + "ay");
                        break;
                    }
                }
            }
            return string.Join(" ", newWords);


        }
    }
}
