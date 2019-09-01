using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Numbers
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int addNum1;
        int addNum2;
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartTheQuiz()
        {
            addNum1 = random.Next(51);
            addNum1 = random.Next(51);

            plusRightLabelTop.Text = addNum1.ToString();
            plusRightLeftTop.Text = addNum2.ToString();

            sum.Value = 0;
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        private bool CheckTheAnswer()
        {
            if (addNum1 + addNum2 == sum.Value)
                return true;
            else
                return false;
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if(timeLeft>0)
            {
                timeLeft -= 1;
                timeLabel.Text = timeLeft.ToString();
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addNum1 + addNum2;
                startButton.Enabled = true;
            }

        }
    }
}
