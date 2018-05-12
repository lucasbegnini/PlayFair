using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayFairDecipher.src;

namespace PlayFairDecipher
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayFair _playFair = new PlayFair();
            string text = "O mundo e bao sebastiao";
            string cipherText = "TgzurtpfrqupdbtuaksV";
            Console.WriteLine(text);
            string compare = "mundo";
            string[] testes = { "cipher", "gord", "car" };
            List<string> results = new List<string>();

            Parallel.ForEach(
            testes,
            (currentWord) =>
            {
                string plainText = _playFair.Decipher(cipherText, currentWord);
                if (plainText.Contains(compare)) {
                   results.Add(currentWord); 
                }
            }
            );

            if (results.Count == 0) {
                Console.WriteLine("Nao existe palavras chaves que possa quebrar no dicionario");
            } else
            {
                Console.WriteLine("as possiveis palavras sao:");
                for(int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine(results[i]);
                }
            }

            Console.ReadKey(true);
        }
    }
}
