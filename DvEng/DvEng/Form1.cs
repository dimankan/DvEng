using DvEng.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvEng
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        List<Word> words = new List<Word>();
        bool[] emptyValueButtons = new bool[5];
        bool[] emptyTranslateButtons = new bool[5];

        public bool IsEmptyValueMore3
        {
            get
            {
                return emptyValueButtons.Where(x => x == false).Count() >= 3;
            }
        }

        public bool IsAllFillValueButtons
        {
            get
            {
                return emptyValueButtons.Where(x => x == false).Count() == 0;
            }
        }
        public bool IsAllFillTranslateButtons
        {
            get
            {
                return emptyTranslateButtons.Where(x => x == false).Count() == 0;
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            words.Add(new Word("work", "работа(ть)"));
            words.Add(new Word("see", "видеть"));
            words.Add(new Word("saw", "видел(и)"));
            words.Add(new Word("help", "помогать, помощь"));
            words.Add(new Word("have/has", "иметь /имеет (он)"));
            words.Add(new Word("had", "имел(и)"));
            words.Add(new Word("do/does", "делать/делает (она)"));
            words.Add(new Word("did", "(с)делал"));
            words.Add(new Word("make (made)", "делать(творч.)(прошедш)"));
            words.Add(new Word("prepare", "(при)готовить"));
            words.Add(new Word("carry", "нести, перевозить"));
            words.Add(new Word("like (2)", "нравиться; как, похожий"));
            words.Add(new Word("read (read)", "читать (прошедш)"));
            words.Add(new Word("go", "идти, ехать"));
            words.Add(new Word("went", "(у)шел, (у)ехал"));

            FillWordButtons();


        }

        private void FillWordButtons()
        {
            CheckEmptyButtons();

            if (IsAllFillValueButtons)
                return;
            if (IsAllFillTranslateButtons)
                return;


            if (!IsEmptyValueMore3)
                return;

            List<int> emptyButtonsC1 = new List<int>();

            for (int i = 0; i < emptyValueButtons.Length; i++)
                if (!emptyValueButtons[i])
                    emptyButtonsC1.Add(i);

            List<int> emptyButtonsC2 = new List<int>();
            
            for (int i = 0; i < emptyTranslateButtons.Length; i++)
                if (!emptyTranslateButtons[i])
                    emptyButtonsC2.Add(i);

            int emptyCount = emptyButtonsC1.Count();

            for (int i = 0; i < emptyCount; i++)
            {
                var randomWord = GetRandomWord();

                int randomButton1Index = random.Next(emptyButtonsC1.Count);
                int value = emptyButtonsC1[randomButton1Index];
                emptyButtonsC1.RemoveAt(randomButton1Index);

                switch (value)
                {
                    case 0:
                        btC1R1.Text = randomWord.WordValue;
                        break;
                    case 1:
                        btC1R2.Text = randomWord.WordValue;
                        break;
                    case 2:
                        btC1R3.Text = randomWord.WordValue;
                        break;
                    case 3:
                        btC1R4.Text = randomWord.WordValue;
                        break;
                    case 4:
                        btC1R5.Text = randomWord.WordValue;
                        break;
                }

                emptyValueButtons[value] = true;

                int randomButton2Index = random.Next(emptyButtonsC2.Count);
                int value2 = emptyButtonsC2[randomButton2Index];
                emptyButtonsC2.RemoveAt(randomButton2Index);

                switch (value2)
                {
                    case 0:
                        btC2R1.Text = randomWord.Translate;
                        break;
                    case 1:
                        btC2R2.Text = randomWord.Translate;
                        break;
                    case 2:
                        btC2R3.Text = randomWord.Translate;
                        break;
                    case 3:
                        btC2R4.Text = randomWord.Translate;
                        break;
                    case 4:
                        btC2R5.Text = randomWord.Translate;
                        break;
                }

                emptyTranslateButtons[value2] = true;
            }

        }

        private void CheckEmptyButtons()
        {
            if (string.IsNullOrEmpty(btC1R1.Text))
                emptyValueButtons[0] = false;
            if (string.IsNullOrEmpty(btC1R2.Text))
                emptyValueButtons[1] = false;
            if (string.IsNullOrEmpty(btC1R3.Text))
                emptyValueButtons[2] = false;
            if (string.IsNullOrEmpty(btC1R4.Text))
                emptyValueButtons[3] = false;
            if (string.IsNullOrEmpty(btC1R5.Text))
                emptyValueButtons[4] = false;

            if (string.IsNullOrEmpty(btC2R1.Text))
                emptyTranslateButtons[0] = false;
            if (string.IsNullOrEmpty(btC2R2.Text))
                emptyTranslateButtons[1] = false;
            if (string.IsNullOrEmpty(btC2R3.Text))
                emptyTranslateButtons[2] = false;
            if (string.IsNullOrEmpty(btC2R4.Text))
                emptyTranslateButtons[3] = false;
            if (string.IsNullOrEmpty(btC2R5.Text))
                emptyTranslateButtons[4] = false;
        }

        private Word GetRandomWord()
        {
            int randomWordIndex = random.Next(words.Count);
            return words[randomWordIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int randomWordIndex = random.Next(words.Count);
            string randomWord = words[randomWordIndex].WordValue;

            textBox1.Text = randomWord;


            FillWordButtons();
        }

        private void btC1R1_Click(object sender, EventArgs e)
        {
            //emptyButton1[0] = false;
            //btC1R1.Text = String.Empty;
            //btC1R1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;


            var name = Controls[$"{Name}"];
            //var zzz = Controls.To

            FillWordButtons();
        }

        private void btC1R2_Click(object sender, EventArgs e)
        {
            //emptyButton1[1] = false;
            btC1R2.Text = String.Empty;
            btC1R2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

            FillWordButtons();
        }

        private void btC1R3_Click(object sender, EventArgs e)
        {
            //emptyButton1[2] = false;
            btC1R3.Text = String.Empty;
            btC1R3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

            FillWordButtons();
        }

        private void btC1R4_Click(object sender, EventArgs e)
        {
            //emptyButton1[3] = false;
            btC1R4.Text = String.Empty;
            btC1R4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

            FillWordButtons();
        }

        private void btC1R5_Click(object sender, EventArgs e)
        {
            //emptyButton1[4] = false;
            btC1R5.Text = String.Empty;
            btC1R5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

            FillWordButtons();
        }
    }
}
