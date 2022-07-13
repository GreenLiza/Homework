using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace String
{
    internal class Program
    {


        static void Main(string[] args)
        {
            var text = FileReader.ReadFile("sample.txt");
            
            // parse into sentences
            var sentences = TextParser.GetSentences(text);
            // parse into words and than sort them
            var wordsDict = TextSorter.CreateSortedWordsDictionary(TextParser.GetWords(sentences));
            // parse into symbols
            var symbols = TextParser.GetSymbols(text);

            using (var sw = new StreamWriter("SortedWords.txt", false))
            {
                foreach (var word in wordsDict)
                {
                    sw.WriteLine($"{word.Key} - {word.Value}");
                }
            }


            var longestSents = TextFinder.FindLongestSentence(sentences);
            var shortestSents = TextFinder.FindShortestSentence(sentences);
            var maxChars = TextFinder.FindMostCommonChars(text);

            using (var sw = new StreamWriter("SelectionResults.txt", false))
            {
                sw.WriteLine("Longest sentences (by symbols):");
                foreach (var keyValuePair in longestSents)
                {
                    sw.WriteLine($"{keyValuePair.Key} - has {keyValuePair.Value} symbol(s)");
                }
                
                if (shortestSents.Count != 0)
                {
                    sw.WriteLine($"There are {shortestSents.Count} sentences with {shortestSents[0].Value} word(s).");
                    sw.WriteLine($"First sentence which consists of {shortestSents[0].Value} word(s):");
                    sw.WriteLine(shortestSents[0].Key);
                }
                else
                {
                    sw.WriteLine("File doesn't contain any sentences");
                }
                
                sw.WriteLine("Most common letter(s):");
                foreach (var keyValuePair in maxChars)
                {
                    sw.WriteLine($"{keyValuePair.Key} - used in this text {keyValuePair.Value} times");
                }
            }

        }
    }
}