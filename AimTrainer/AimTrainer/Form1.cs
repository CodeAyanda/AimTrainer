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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Visible = true;
        }
        

        public async void Timer()
        {
            int min = 0;
            int sec = 30;

            while (min > 0 || sec > 0)
            {
                await Task.Delay(1000);
                sec--;

                string timerr = min.ToString() + " : " + sec.ToString();
                timer.Text = timerr;

            }

            if(min == 0 && sec == 0)
            {
                pictureBox1.Visible = false;
                timer.Text = "Time's Up";
                button1.Visible = true;
                getAccuracy(score, clicks);
                label6.Visible = true;
                label7.Visible = true;
                button2.Visible = true;


            }
            

        }

        public void getAccuracy(int scoree, int clickss)
        {
            double accuracy = 100 - (((double)clickss / (double)scoree) * 100);
            label7.Text = Math.Round(accuracy, 2).ToString() + " %";

        }

        int score = -1;
        int clicks = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(score == -1 && clicks == 0)
            {
                Timer();
                label4.Visible = false;
            }
            
            Random rnd = new Random();
            int xPos = rnd.Next(12, 1112);
            int yPos = rnd.Next(43, 833);

            pictureBox1.Location = new Point(xPos, yPos);
            score++;
            
            label3.Text = score.ToString();
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            clicks++;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            textBox1.Visible = true;
            button2.Text = "Save";
            string saveName = textBox1.Text;
            string saveScore = label3.Text;
            string saveAccuracy = label7.Text;
            int playerScore = Convert.ToInt32(saveScore);

            if (textBox1.Text != "")
            {
                using (StreamWriter w = File.AppendText("leaderboard.txt"))
                {
                    button2.Visible = false;
                    textBox1.Visible = false;
                    label5.Visible = false;
                    label8.Visible = true;

                    w.WriteLine(saveScore + " " + saveAccuracy + " " + saveName);

                }
            }

        }
    }
}
