using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvEng.Models
{
    internal class Word
    {
        private static int i = 1;
        public int Id { get; set; }
        public string WordValue { get; set; }
        public string Translate { get; set; }

        public Word(string word, string translate)
        {
            this.Id = i++;
            WordValue = word;
            Translate = translate;
        }
    }
}
