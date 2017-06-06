//http://codekata.com/kata/kata06-anagrams/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace anagramsFromList
{
    class Program
    {
        static List<string> Words { get; set; }
        static List<string> LoadFile()
        {
            List<string> ListOfWords = new List<string>();

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("C:\\temp\\words.txt"))
                {

                    while (!sr.EndOfStream)
                        ListOfWords.Add(sr.ReadLine());

                    // Read the stream to a string, and write the string to the console.


                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return ListOfWords;
        }
        static Dictionary<string, int> CountAnagrams(List<string> words)
        {
            Dictionary<string, int> NumberOfAnagrams = new Dictionary<string, int>();

            foreach (var word in words)
            {

                var characters = word.ToLower().ToList();
                characters.Sort();
                string charString = "";
                foreach (var item in characters)
                {
                    charString += item;
                }
                //= characters.ToString();
                if (!NumberOfAnagrams.ContainsKey(charString))
                {
                    NumberOfAnagrams.Add(charString, 1);
                }
                else
                {
                    NumberOfAnagrams[charString] = NumberOfAnagrams[charString] + 1;
                }
            }


            return NumberOfAnagrams;
        }
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Words = LoadFile();
            sw.Start();
            var x = CountAnagrams(Words);
            sw.Stop();
            var y = 0;
            foreach (var item in x)
            {
                if (item.Value > 1)
                {
                    y++;
                }
            }
            Console.WriteLine("Anagrams found: " + y);
            Console.WriteLine(sw.Elapsed.ToString());
            Console.Read();
        }
    }
}
