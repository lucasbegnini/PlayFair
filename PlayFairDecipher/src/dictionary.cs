using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayFairDecipher.src
{
    class Dictionary
    {
        List<string> m_dic = new List<string>();

        public List<string> Dic { get => m_dic; set => m_dic = value; }

        public void CreateDic()
        {
            var reader = new StreamReader(@"E:\Projetos ASP NET\PlayFairDecipher\PlayFair\PlayFairDecipher\Dicionary\dicionario.csv");

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string word = line.Split('\t').First();
                if (word.Length >= 3 && word.Length < 6)
                {
                    m_dic.Add(word);
                }
            }
        }

    }
}
