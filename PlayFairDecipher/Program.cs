using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayFairDecipher.src;

namespace PlayFairDecipher
{
    class Program
    {
        private const string V = @"E:\Projetos ASP NET\PlayFairDecipher\PlayFair\PlayFairDecipher\out.csv";

        static void Main(string[] args)
        {
            string filePath = V;

            PlayFair _playFair = new PlayFair();
            Dictionary _dictionary = new Dictionary();

            _dictionary.CreateDic();

            Console.WriteLine("Dictionary with " + _dictionary.Dic.Count);

            string cypherText = "UhtohkmrmitrrbtupclZ";
            List<TestFiles> results = new List<TestFiles>();
            var csv = new StringBuilder();
            Parallel.ForEach(
            _dictionary.Dic,
            (currentWord) =>
            {
                string plainText = _playFair.Decipher(cypherText, currentWord);
                int numberOfWords = 0;
                for (int i = 0; i < _dictionary.Dic.Count; i++)
                {
                    if (plainText.Contains(_dictionary.Dic[i]))
                    {
                        numberOfWords++;
                    }
                }
                if (numberOfWords > 0) {
                    TestFiles _test = new TestFiles(numberOfWords, currentWord);
                    var newLine = string.Format("{0} ,{1} ", currentWord, numberOfWords);
                    csv.AppendLine(newLine);
                    results.Add(_test);

                }
            }
            );

            File.WriteAllText(filePath, csv.ToString());

            if (results.Count == 0)
            {
                Console.WriteLine("Nao existe palavras chaves que possa quebrar no dicionario");
            }
            else
            {
                TestFiles _bestFileGuess = results[0];
                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].NumberOfWords > _bestFileGuess.NumberOfWords) {
                        _bestFileGuess = results[i];
                    }
                }

                Console.WriteLine("a palavra que teve melhor desempenho foi :" + _bestFileGuess.Word);
                Console.WriteLine("Texto resultante : " + _playFair.Decipher(cypherText, _bestFileGuess.Word));
            }

            Console.ReadKey(true);
        }
    }
}
