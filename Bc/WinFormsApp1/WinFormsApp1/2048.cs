using System.ComponentModel;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int[,] a = new int[4, 4];
        int[,] b = new int[4, 4];
        int score=0;
        int backscore=0;
        int bestscore;
        public Form1()
        {
            InitializeComponent();
            
        }
        public void setup()
        {
            button1.Text = "" + a[0, 0];
            button2.Text = "" + a[0, 1];
            button3.Text = "" + a[0, 2];
            button4.Text = "" + a[0, 3];
            button5.Text = "" + a[1, 0];
            button6.Text = "" + a[1, 1];
            button7.Text = "" + a[1, 2];
            button8.Text = "" + a[1, 3];
            button9.Text = "" + a[2, 0];
            button10.Text = "" + a[2, 1];
            button11.Text = "" + a[2, 2];
            button12.Text = "" + a[2, 3];
            button13.Text = "" + a[3, 0];
            button14.Text = "" + a[3, 1];
            button15.Text = "" + a[3, 2];
            button16.Text = "" + a[3, 3];


            change(button1);
            change(button2);
            change(button3);
            change(button4);
            change(button5);
            change(button6);
            change(button7);
            change(button8);
            change(button9);
            change(button10);
            change(button11);
            change(button12);
            change(button13);
            change(button14);
            change(button15);
            change(button16);
        }
        void back()
        {
            int i, j;
           
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    a[i, j] = b[i, j];
                    
                }
            }
            setup();
            if(score >= bestscore && score!=backscore)
            {
                bestscore = score-(score-backscore);
                label5.Text = "" + bestscore;
            }
            score = backscore;
            label4.Text = "" + score;


        }
        void losecheck()
        {
            int i, j,flag=0;
            for(i=0;i<4;i++)
            {
                for(j=0;j<4;j++)
                {
                    if (a[i,j] == 0)
                        return;
                    if(i<3)
                    {
                        if (a[i, j] == a[i+1,j])
                            flag++;
                    }
                    if (j < 3)
                    {
                        if (a[i, j] == a[i,j+1])
                            flag++;
                    }
                }
            }
            if (flag == 0)
            {
                DialogResult u = MessageBox.Show("You Lose! Play Again?\nYour score: "+score,"2048",MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(u == DialogResult.Yes)
                    NewGame();
            }

                
        }
        void outbestscore()
        {
            if(score>=bestscore)
            {
                bestscore = score;
                label5.Text = "" + bestscore;
            }
        }
        void copy()
        {
            int i, j;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    b[i, j] = a[i, j];
                }
            }
            backscore = score;
        }
        void movecheck()
        {
            int i, j,empty=0;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (a[i, j] == 0)
                    {
                        empty++;
                    }
                }
            }
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (a[i, j] != b[i,j])
                    {
                        if (empty > 0)
                         rd();
                        return;
                    }
                }
            }
            
        }
        void wincheck()
        {
            int i, j;
            for(i=0;i<4;i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (a[i, j] == 2048)
                    {
                        DialogResult N = MessageBox.Show("You Win! Wanna Continue?","2048", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (N == DialogResult.Yes)
                        {

                        }
                        else
                            NewGame();
                    }
                        
                        
                }
            }
        }
        public void change(Button but)
        {
            int x;
            x = Convert.ToInt32(but.Text);
            switch (x)
            {
                case 0:
                    but.Text = "";
                    but.BackColor = (Color.FromArgb(255, 205, 193, 180));
                    break;
                case 2:
                    but.BackColor = (Color.FromArgb(255, 238, 228, 218)); 
                    break;
                case 4:
                    but.BackColor = (Color.FromArgb(255, 238, 225, 201));
                    break;
                case 8:
                    but.BackColor = (Color.FromArgb(255, 243, 178, 122));
                    break;
                case 16:
                    but.BackColor = (Color.FromArgb(255, 246, 150, 100));
                    break;
                case 32:
                    but.BackColor = (Color.FromArgb(255, 246, 124, 95));
                    break;
                case 64:
                    but.BackColor = (Color.FromArgb(255, 246, 94, 59));
                    break;
                case 128:
                    but.BackColor = (Color.FromArgb(255, 237, 207, 114));
                    break;
                case 256:
                    but.BackColor = (Color.FromArgb(255, 237, 204, 97));
                    break;
                case 512:
                    but.BackColor = (Color.FromArgb(255, 237, 200, 80));
                    break;
                case 1024:
                    but.BackColor = (Color.FromArgb(255, 237, 197, 63));
                    break;
                case 2048:
                    but.BackColor = (Color.FromArgb(255, 237, 194, 46));
                    break;
                case >2048:
                    but.BackColor = (Color.FromArgb(255, 62, 57, 51));
                    break;
            }
        }

        public void rd()
        {
            int x, y, i;
            Random r = new Random();           
                 for (i=0;;i++)
                    {
                                x = Convert.ToInt32(r.Next(0, 4));
                                y = Convert.ToInt32(r.Next(0, 4));
                                if (a[x,y]==0)
                                {
                                    a[x, y] = 2;
                                    break;
                   
                                }
                    }
        }
        public void NewGame()
        {
            score = 0;
            label4.Text = "" + score;
            int i, j;
            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                    a[i, j] = 0;
            rd();
            setup();
        }
        public void up()
        {
            int i, j, k;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    for (k = i + 1; k < 4; k++)
                    {
                        if (a[k,j] != 0 && i != 4 - 1)
                        {
                            if (a[k,j] == a[i,j])
                            {
                                a[i,j] += a[k,j];
                                score += a[i, j];
                                a[k,j] = 0;
                            }
                            if (a[i,j] == 0)
                            {
                                a[i, j] += a[k, j];
                                a[k, j] = 0;
                                j--;
                            }
                            break;
                        }
                    }
                }
            }
        }


        public void down()
        {
            int i, j, k;
            for (i = 4 - 1; i > -1; i--)
            {
                for (j = 0; j < 4; j++)
                {
                    for (k = i - 1; k > -1; k--)
                    {
                        if (a[k,j] != 0 && i != 0)
                        {
                            if (a[k,j] == a[i,j])
                            {
                                a[i,j] += a[k,j];
                                score += a[i, j];
                                a[k,j] = 0;
                            }
                            if (a[i,j] == 0)
                            {
                                a[i,j] += a[k,j];
                                a[k,j] = 0;
                                j--;
                            }
                            break;
                        }
                    }
                }
            }
        }


        public void left()
        {
            int i, j, k;
            for (j = 0; j < 4; j++)
            {
                for (i = 0; i < 4; i++)
                {
                    for (k = j + 1; k < 4; k++)
                    {
                        if (a[i,k] != 0 && j != 4 - 1)
                        {
                            if (a[i,k] == a[i,j])
                            {
                                a[i,j] += a[i,k];
                                score += a[i, j];
                                a[i,k] = 0;
                            }
                            if (a[i,j] == 0)
                            {
                                a[i,j] += a[i,k];
                                a[i,k] = 0;
                                i--;
                            }
                            break;
                        }
                    }
                }
            }
        }

        public void right()
        {
            int i, j, k;
            for (j = 4 - 1; j > -1; j--)
            {
                for (i = 0; i < 4; i++)
                {
                    for (k = j - 1; k > -1; k--)
                    {
                        if (a[i, k] != 0 && j != 0)
                        {
                            if (a[i, k] == a[i, j])
                            {
                                a[i, j] += a[i, k];
                                score += a[i, j];
                                a[i, k] = 0;
                            }
                            if (a[i, j] == 0)
                            {
                                a[i, j] += a[i, k];
                                a[i, k] = 0;
                                i--;
                            }
                            break;
                        }
                    }
                }
            }
        }
        private void newgameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult u = MessageBox.Show("Do you want play Newgame?", "2048", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (u == DialogResult.Yes)
            {
               NewGame();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult iExit = MessageBox.Show("Do you want to quit game?", "2048", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            copy();
            switch (e.KeyCode)
            {
                case Keys.Up:
                    up();
                    break;
                case Keys.Down:
                    down();
                    break;
                case Keys.Left:
                    left();
                    break;
                case Keys.Right:
                    right();
                    break;
            }
            losecheck();
            movecheck();
            setup();
            wincheck();
            label4.Text = "" + score;
            outbestscore();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            back();
        }
    }
}