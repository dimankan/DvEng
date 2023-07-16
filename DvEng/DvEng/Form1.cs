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
        List<Word> words = new List<Word>();

        Model model = new Model();

        Button[] buttonsC1 = new Button[5];
        Button[] buttonsC2 = new Button[5];

        Button selectedButtonC1 = null;
        Button selectedButtonC2 = null;


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

            model.SetWords(words);

            buttonsC1[0] = btC1R1;
            buttonsC1[1] = btC1R2;
            buttonsC1[2] = btC1R3;
            buttonsC1[3] = btC1R4;
            buttonsC1[4] = btC1R5;

            buttonsC2[0] = btC2R1;
            buttonsC2[1] = btC2R2;
            buttonsC2[2] = btC2R3;
            buttonsC2[3] = btC2R4;
            buttonsC2[4] = btC2R5;
            
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            model = model.GetWords();

            btC1R1.Text = model.Values[0];
            btC1R2.Text = model.Values[1];
            btC1R3.Text = model.Values[2];
            btC1R4.Text = model.Values[3];
            btC1R5.Text = model.Values[4];
            btC2R1.Text = model.Translates[0];
            btC2R2.Text = model.Translates[1];
            btC2R3.Text = model.Translates[2];
            btC2R4.Text = model.Translates[3];
            btC2R5.Text = model.Translates[4];

            

            for (int i = 0; i < buttonsC1.Length; i++)
            {
                buttonsC1[i].BackColor = SystemColors.ControlLightLight;
                buttonsC2[i].BackColor = SystemColors.ControlLightLight;

                buttonsC1[i].Enabled = true;
                buttonsC2[i].Enabled = true;
            }
        }

        private void btClickValue(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            foreach (Button item in buttonsC1)
            {
                item.BackColor = SystemColors.ControlLightLight;
            }
            clickedButton.BackColor = SystemColors.GradientInactiveCaption;

            selectedButtonC1 = (Button)clickedButton;
            if (selectedButtonC2 != null)
            {
                CheckResult();
            }
        }

   

        private void btClickTranslate(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            foreach (Button item in buttonsC2)
            {
                item.BackColor = SystemColors.ControlLightLight;
            }
            clickedButton.BackColor = SystemColors.GradientInactiveCaption;

            selectedButtonC2 = (Button)clickedButton;
            if (selectedButtonC1 != null)
            {
                CheckResult();
            }
        }


        private void CheckResult()
        {
            int indexC1 = Array.IndexOf(buttonsC1, selectedButtonC1);
            int indexC2 = Array.IndexOf(buttonsC2, selectedButtonC2);

            bool result = model.CheckWords(indexC1, indexC2);

            if (result)
            {
                buttonsC1[indexC1].Enabled = false;
                buttonsC2[indexC2].Enabled = false;

                buttonsC1[indexC1].Text = string.Empty;
                buttonsC2[indexC2].Text = string.Empty;

                for (int i = 0; i < buttonsC1.Length; i++)
                {
                    buttonsC1[i].BackColor = SystemColors.ControlLightLight;
                    buttonsC2[i].BackColor = SystemColors.ControlLightLight;
                }

                selectedButtonC1 = null;
                selectedButtonC2 = null;

                int countEmpty = buttonsC1.Where(x => string.IsNullOrEmpty(x.Text)).Count();

                if (countEmpty == 3)
                {
                    UpdateButtons();
                }
            }
            else
            {
                for (int i = 0; i < buttonsC1.Length; i++)
                {
                    buttonsC1[i].BackColor = SystemColors.ControlLightLight;
                    buttonsC2[i].BackColor = SystemColors.ControlLightLight;
                }

                selectedButtonC1 = null;
                selectedButtonC2 = null;
            }
        }



    }
}
