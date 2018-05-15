using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayFairDecipher.src
{
    class TestFiles
    {
        int _numberOfWords;
        string _word;
        public TestFiles(int numberOfWords, string word ) {
            NumberOfWords = numberOfWords;
            Word = word;
        }

        public int NumberOfWords { get => _numberOfWords; set => _numberOfWords = value; }
        public string Word { get => _word; set => _word = value; }
    }
}
