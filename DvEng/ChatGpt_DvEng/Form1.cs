using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatGpt_DvEng
{
    public partial class MainForm : Form
    {
        private List<string> words;
        private List<string> translations;
        private List<Button> buttons;
        private Random random;
        private int guessedCount;

        public MainForm()
        {
            InitializeComponent();

            words = new List<string>
            {
                "apple", "banana", "cat", "dog", "elephant",
                "яблоко", "банан", "кошка", "собака", "слон"
            };

            translations = new List<string>();
            buttons = new List<Button>();
            random = new Random();
            guessedCount = 0;

            InitializeButtons();
            ShowRandomWords();
        }

        private void InitializeButtons()
        {
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
        }

        private void ShowRandomWords()
        {
            var shuffledWords = words.OrderBy(x => random.Next()).ToList();
            var shuffledTranslations = shuffledWords.Skip(5).OrderBy(x => random.Next()).ToList();

            for (int i = 0; i < buttons.Count; i++)
            {
                if (i < 5)
                {
                    buttons[i].Text = shuffledWords[i];
                    buttons[i].Tag = shuffledTranslations[i];
                }
                else
                {
                    buttons[i].Text = shuffledTranslations[i - 5];
                    buttons[i].Tag = shuffledWords[i - 5];
                }
            }
        }

        private void CheckGuess(Button button)
        {
            if (button.Tag.ToString() == button.Text)
            {
                button.Enabled = false;
                guessedCount++;
            }

            if (guessedCount == 3)
            {
                guessedCount = 0;
                RefreshButtons();
            }
        }

        private void RefreshButtons()
        {
            var remainingWords = words.Except(buttons.Select(b => b.Tag.ToString())).ToList();
            var remainingTranslations = remainingWords.Skip(5).ToList();
            remainingWords = remainingWords.Take(5).ToList();

            var shuffledWords = remainingWords.OrderBy(x => random.Next()).ToList();
            var shuffledTranslations = remainingTranslations.OrderBy(x => random.Next()).ToList();

            for (int i = 0; i < buttons.Count; i++)
            {
                if (i < 5)
                {
                    if (!buttons[i].Enabled)
                    {
                        buttons[i].Enabled = true;
                        buttons[i].Text = shuffledWords[i];
                        buttons[i].Tag = shuffledTranslations[i];
                    }
                }
                else
                {
                    if (!buttons[i].Enabled)
                    {
                        buttons[i].Enabled = true;
                        buttons[i].Text = shuffledTranslations[i - 5];
                        buttons[i].Tag = shuffledWords[i - 5];
                    }
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            CheckGuess(button);
        }
    }
}
