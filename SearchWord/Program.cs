using System;
using System.Collections.Generic;
using System.IO;

namespace SearchWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Дима\\Downloads\\input.txt";

            Dictionary<string, long> wordCounts = new Dictionary<string, long>();
            char[] delimiters = new char[] { '-', ':', ' ', ',', '.', ';', '!', '?', '\n', '\r', '\t' };

            foreach (string line in File.ReadLines(filePath))
            {
                string lowerLine = line.ToLower();
                string[] words = lowerLine.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;  
                    }
                    else
                    {
                        wordCounts[word] = 1; 
                    }
                }
            }

            // не оптимально но работает
            SortedDictionary<long, string> sortedWordCounts = new SortedDictionary<long, string>(); 

            foreach (var pair in wordCounts)
            {
                long k = pair.Value;  
                string word = pair.Key;   
                sortedWordCounts[k] = word;
            }

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(sortedWordCounts.Last());
                sortedWordCounts.Remove(sortedWordCounts.Keys.Last());
            }
            // не оптимально но работает
            Console.WriteLine();
            // оптимально 
            List<KeyValuePair<string, long>> sortedList = new List<KeyValuePair<string, long>>(wordCounts); 

            sortedList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            int count = 0;
            foreach (var pair in sortedList)
            {
                if (count >= 10) break;
                Console.WriteLine(pair);
                count++;
            }


        }
    }
}
// первый способ не оптимален тк может потеряться значение но в данном случае тоже работает