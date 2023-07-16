using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvEng.Models
{
    internal class Model
    {
        private string[] _values = new string[5];
        private string[] _translates = new string[5];

        private Random random = new Random();

        private List<Word> _words;
        private Word[] _currentWords = new Word[5];

        public string[] Values { get => _values; }
        public string[] Translates { get => _translates; }

        public void SetWords(List<Word> words)
        { _words = words; }

        public Model GetWords()
        {
       

            GenerateWords();

            for (int i = 0; i < _values.Length; i++)
            {
                if (string.IsNullOrEmpty(_values[i]))
                {
                    _values[i] = _currentWords[i].WordValue;
                    
                    var translateEmptyIndex = _translates.Select(x=>string.IsNullOrEmpty(x)).ToList();

                    bool isGood = false;
                    int randomTranslateEmptyIndex = 0;

                    while(isGood == false)
                    {
                        randomTranslateEmptyIndex = random.Next(translateEmptyIndex.Count);

                        if (translateEmptyIndex[randomTranslateEmptyIndex] == true)
                            isGood = true;
                    }

                    _translates[randomTranslateEmptyIndex] = _currentWords[i].Translate;
                }
            }

            return this;
        }

        public bool CheckWords(int indexC1, int indexC2)
        {
            bool result = false;

            string value = _values[indexC1];
            string translate = _translates[indexC2];

            Word word = _words.Where(x=>x.WordValue == value).FirstOrDefault();

            if(word.WordValue == value && word.Translate == translate)
            {
                result = true;

                int indexCurrentWords = Array.IndexOf(_currentWords, word);
                _currentWords[indexCurrentWords] = null;
                _values[indexC1] = string.Empty;
                _translates[indexC2] = string.Empty;
                
                //for (int i = 0; i < currentWords.Length; i++)
                //{
                //    currentWords[i] = null;
                //}
                //for (int i = 0; i < _values.Length; i++)
                //{
                //    _values[i] = null;
                //    _translates[i] = null;
                //}


            }

            return result;
        }

        private void GenerateWords()
        {
            for (int i = 0; i < _currentWords.Length; i++)
            {
                if (_currentWords[i] == null)
                {
                    _currentWords[i] = GetRandomWord();
                }
            }
        }

        private Word GetRandomWord()
        {
            int randomWordIndex = random.Next(_words.Count);
            return _words[randomWordIndex];
        }
    }
}
