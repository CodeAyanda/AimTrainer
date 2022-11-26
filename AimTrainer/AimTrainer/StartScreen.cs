using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedTyper
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            List<Tuple<string, string>> scoreList = new List<Tuple<string, string>>();

            var lines = File.ReadLines("leaderboard.txt");
            foreach (string line in lines)
            {
                string score = "";
                string name = "";

                char[] currentLine = line.ToCharArray();
                for (int i = 0; i < 2; i++)
                {
                    score += currentLine[i];
                }

                for (int i = getIndex(line, '%'); i < currentLine.Length; i++)
                {
                    name += currentLine[i];
                }

                scoreList.Add(new Tuple<string, string>(score, name));

            }
            int num = 1;
            var discendingOrder = scoreList.OrderByDescending(i => i);
            foreach(var currentScore in discendingOrder)
            {
                var finalScoreText = currentScore.ToString();
                var charsToRemove = new string[] { "(", ")" };
                foreach (var c in charsToRemove)
                {
                    finalScoreText = finalScoreText.Replace(c, string.Empty);
                }

                var charsToRemove2 = new string[] { "," };
                foreach (var c2 in charsToRemove2)
                {
                    finalScoreText = finalScoreText.Replace(c2, " -");
                }


                richTextBox1.Text += num + ". " + finalScoreText.ToString() + "\n";
                num++;
            }

        }

        public int getIndex(string str, char chr)
        {
            int index = 0;
            char[] stringArr = str.ToCharArray();
            for (int i = 0; i < stringArr.Length; i++)
            {
                if(stringArr[i] == chr)
                {
                    index = i;
                }
            }
            return index+1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 myForm = new Form1();
            myForm.Show();
            this.Hide();
        }
    }
}
