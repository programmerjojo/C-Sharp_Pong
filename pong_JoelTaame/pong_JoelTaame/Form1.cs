//Name: Joel Taame
//Date: 22/12/2017
//Title: pong_JoelTaame
//Purpose: to create the well known game, pong

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pong_JoelTaame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Global Variables
        double Speed = 18;  
        int intAngle = 45;
        int intXMove = 0;
        int intYMove = 0;
        int intDirection = 3;

        int intLeftBounds = 51;
        int intRightBounds = 911;

        int intCompScore = 0;
        int intPlayerScore = 0;

        Random rndNum = new Random();

        ////Paddle Movement
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //paddles moves Top and Bottom         
            if (e.KeyData == Keys.W && this.pbPaddle.Top > 0)   //up
            {
                this.pbPaddle.Top -= 10;
            }
            else if (e.KeyData == Keys.S && this.pbPaddle.Top + this.pbPaddle.Height < this.Height - 30)    //down
            { 
                this.pbPaddle.Top += 10;
            }
        }

        //function for x and y
        public int horizontalVal(double intHyp, int intDegree)
        {
            return (int)(intHyp * Math.Cos((double)intDegree * Math.PI / 180));
        }
        public int verticalVal(double intHyp, int intDegree)
        {
            return (int)(intHyp * Math.Sin((double)intDegree * Math.PI / 180));
        }

        //Buttons
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.btnStart.Visible = false;
            this.btnInstructions.Visible = false;

            this.timer.Enabled = true;
        }
        private void btnInstructions_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Welecome to PONG!\n Use the \'W\' key to move your paddle UP and \'S\' key to move your paddle DOWN.\n You want the ball to hit the computer's wall in order to win.\n The game ends when either you or the computer gets to 5 and whoever that may be is the winner.\n GOOD LUCK!");
        }
        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //method for if someone loses or wins
        public void someoneWon()
        {
            this.timer.Enabled = false;

            if (intPlayerScore == 5)
            {
                MessageBox.Show("GREAT JOB! YOU WON! :)");
            }
            else if(intCompScore == 5)
            {
                MessageBox.Show("You Lost :( \nDon't worry about it... life only gets worse");
            }

            btnPlayAgain.Visible = true;
            btnQuit.Visible = true;
        }

        //Timer
        private void timer_Tick(object sender, EventArgs e)
        {
            intXMove = horizontalVal(Speed, intAngle);
            intYMove = verticalVal(Speed, intAngle);



            //set direction
            if (intDirection == 1)          //      UP /
            {
                intXMove = Math.Abs(intXMove);
                intYMove = Math.Abs(intYMove) * -1;
            }
            else if (intDirection == 2)     //      UP \
            {
                intXMove = Math.Abs(intXMove) * -1;
                intYMove = Math.Abs(intYMove) * -1;
            }
            else if (intDirection == 3)      //      DOWN /
            {
                intXMove = Math.Abs(intXMove) * -1;
                intYMove = Math.Abs(intYMove);
            }
            else if (intDirection == 4)     //      DOWN \
            {
                intXMove = Math.Abs(intXMove);
                intYMove = Math.Abs(intYMove);
            }



            



            //ball hits CPU paddle
            if (this.pbEnemyPaddle.Bounds.IntersectsWith(this.pbBall.Bounds))
            {
                if (this.pbBall.Top > this.pbEnemyPaddle.Top && this.pbBall.Top < (this.pbEnemyPaddle.Top + this.pbEnemyPaddle.Height * 0.167))
                {
                    intDirection = 2;
                    intAngle = 65;
                }
                else if (this.pbBall.Top > this.pbEnemyPaddle.Top && this.pbBall.Top < (this.pbEnemyPaddle.Top + this.pbEnemyPaddle.Height * 0.333))
                {
                    intDirection = 2;
                    intAngle = 45;
                }
                else if (this.pbBall.Top > this.pbEnemyPaddle.Top && this.pbBall.Top < (this.pbEnemyPaddle.Top + this.pbEnemyPaddle.Height * 0.50))
                {
                    intDirection = 2;
                    intAngle = 35;
                }
                else if (this.pbBall.Top > this.pbEnemyPaddle.Top && this.pbBall.Top < (this.pbEnemyPaddle.Top + this.pbEnemyPaddle.Height * 0.667))
                {
                    intDirection = 3;
                    intAngle = 35;
                }
                else if (this.pbBall.Top > this.pbEnemyPaddle.Top && this.pbBall.Top < (this.pbEnemyPaddle.Top + this.pbEnemyPaddle.Height * 83.333))
                {
                    intDirection = 3;
                    intAngle = 45;
                }
                else if (this.pbBall.Top > this.pbEnemyPaddle.Top && this.pbBall.Top < (this.pbEnemyPaddle.Top + this.pbEnemyPaddle.Height))
                {
                    intDirection = 3;
                    intAngle = 65;
                }
            }

            //ball hits user paddle
            if (this.pbPaddle.Bounds.IntersectsWith(this.pbBall.Bounds))
            {
                if (this.pbBall.Top > this.pbPaddle.Top && this.pbBall.Top < (this.pbPaddle.Top + this.pbPaddle.Height * 0.167))
                {
                    intDirection = 1;
                    intAngle = 65;
                    Speed = Speed + 1.5;
                }
                else if (this.pbBall.Top > this.pbPaddle.Top && this.pbBall.Top < (this.pbPaddle.Top + this.pbPaddle.Height * 0.333))
                {
                    intDirection = 1;
                    intAngle = 50;
                    Speed = Speed + 1.5;
                }
                else if (this.pbBall.Top > this.pbPaddle.Top && this.pbBall.Top < (this.pbPaddle.Top + this.pbPaddle.Height * 0.50))
                {
                    intDirection = 1;
                    intAngle = 35;
                    Speed = Speed + 1.5;
                }
                else if (this.pbBall.Top > this.pbPaddle.Top && this.pbBall.Top < (this.pbPaddle.Top + this.pbPaddle.Height * 0.667))
                {
                    intDirection = 4;
                    intAngle = 35;
                    Speed = Speed + 1.5;
                }
                else if (this.pbBall.Top > this.pbPaddle.Top && this.pbBall.Top < (this.pbPaddle.Top + this.pbPaddle.Height * 83.333))
                {
                    intDirection = 4;
                    intAngle = 50;
                    Speed = Speed + 1.5;
                }
                else if (this.pbBall.Top > this.pbPaddle.Top && this.pbBall.Top < (this.pbPaddle.Top + this.pbPaddle.Height))
                {
                    intDirection = 4;
                    intAngle = 65;
                    Speed = Speed + 1.5;
                }
            }


            
            //set boundaries and direction (counter clockwise)
            if (intDirection == 1 && this.pbBall.Left > intRightBounds)    //right
            {
                pbBall.Location = new Point(550, 315);
                intDirection = rndNum.Next(2,4);    // direction 2 or 3

                if (intPlayerScore > 1 || intCompScore > 1)
                {
                    Speed = 26;
                }
                else
                {
                    Speed = 18;
                }
                intAngle = rndNum.Next(10, 65);

                intPlayerScore++;
                lblPlayerScore.Text = intPlayerScore.ToString();

                if (intPlayerScore == 5 || intCompScore == 5)
                {
                    someoneWon();
                }
            }
            else if (intDirection == 2 && this.pbBall.Top < 0 + 60)  //top
            {
                intDirection = 3;
            }
            else if (intDirection == 3 && this.pbBall.Left < intLeftBounds)    //left
            {
                int intRandomNumber;
                pbBall.Location = new Point(410, 315);

                intRandomNumber = rndNum.Next(1, 3);    // 1 and 2 cuz there isnt a way to get a random number thats either 1 or 4
                if (intRandomNumber == 1)
                {
                    intDirection = 1;
                }
                else if (intRandomNumber == 2)
                {
                    intDirection = 4;
                }

                if (intPlayerScore > 1 || intCompScore > 1)
                {
                    Speed = 26;
                }
                else
                {
                    Speed = 18;
                }
                intAngle = rndNum.Next(10, 65);

                intCompScore++;
                lblCpuScore.Text = intCompScore.ToString();

                if (intPlayerScore == 5 || intCompScore == 5)
                {
                    someoneWon();
                }
            }
            else if (intDirection == 4 && this.pbBall.Top > this.Height - 85) //bottom
            {
                intDirection = 1;
            }

            //set boundaries and direction (clockwise)
            if (intDirection == 2 && this.pbBall.Left < intLeftBounds)     //left
            {
                int intRandomNumber;
                pbBall.Location = new Point(410, 315);

                intRandomNumber = rndNum.Next(1, 3);    // 1 and 2 cuz there isnt a way to get a random number thats either 1 or 4
                if (intRandomNumber == 1)
                {
                    intDirection = 1;
                }
                else if (intRandomNumber == 2)
                {
                    intDirection = 4;
                }

                if (intPlayerScore > 1 || intCompScore > 1)
                {
                    Speed = 26;
                }
                else
                {
                    Speed = 18;
                }
                intAngle = rndNum.Next(10, 65);

                intCompScore++;
                lblCpuScore.Text = intCompScore.ToString();

                if (intPlayerScore == 5 || intCompScore == 5)
                {
                    someoneWon();
                }
            }
            else if (intDirection == 1 && this.pbBall.Top < 0 + 50)      //top
            {
                intDirection = 4;
            }
            else if (intDirection == 4 && this.pbBall.Left > intRightBounds)       //right
            {
                pbBall.Location = new Point(550, 315);
                intDirection = rndNum.Next(2, 4);    // direction 2 or 3

                if (intPlayerScore > 1 || intCompScore > 1)
                {
                    Speed = 26;
                }
                else
                {
                    Speed = 18;
                }
                intAngle = rndNum.Next(10, 65);

                intPlayerScore++;
                lblPlayerScore.Text = intPlayerScore.ToString();

                if (intPlayerScore == 5 || intCompScore == 5)
                {
                    someoneWon();
                }
            }
            else if (intDirection == 3 && this.pbBall.Top > this.Height - 85)     //bottom
            {
                intDirection = 2;
            }








            //move CPU paddle
            if (pbEnemyPaddle.Top + 78 > pbBall.Top && pbEnemyPaddle.Top > 0)
            {
                //make game harder depending on the socre
                if (intDirection == 1 || intDirection == 4)
                {
                    if (intCompScore >= 3 || intPlayerScore >= 3)
                    {
                        pbEnemyPaddle.Top -= 20;
                    }
                    else if (intCompScore < 3 || intPlayerScore < 3)
                    {
                        pbEnemyPaddle.Top -= 15;
                    }
                }
                else
                {
                    pbEnemyPaddle.Top -= 5;
                }
            }
            else if (pbEnemyPaddle.Top - 78 < pbBall.Top && pbEnemyPaddle.Top < this.Height)
            {
                //make game harder depending on the socre
                if (intDirection == 1 || intDirection == 4)
                {
                    if (intCompScore >= 3 || intPlayerScore >= 3)
                    {
                        pbEnemyPaddle.Top += 20;
                    }
                    else if (intCompScore < 3 || intPlayerScore < 3)
                    {
                        pbEnemyPaddle.Top += 15;
                    }
                }
                else
                {
                    pbEnemyPaddle.Top += 5;
                }
            }




            






            //move ball
            this.pbBall.Left += intXMove;
            this.pbBall.Top += intYMove;
        }
    }
}