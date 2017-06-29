using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class TicTacToe : Form
    {

        private bool player1Turn = true; // true = x turn; false= y turn
        private bool against_computer = false;
        private int turn_count = 0;
        // private static string player1, player2;

        public TicTacToe()

        {
            InitializeComponent();
        }

        /*
        public static void setPlayerNames(string n1, string n2)
        {
            player1 = n1;
            player2 = n2;
        }
        */

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by:David Goodin", "Tic Tac Toe about");

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((p1.Text == "Player1") || (p2.Text == "Player2"))
            {
                MessageBox.Show("You must specify player names before you can ");
            }
            Button b = (Button) sender;

            if (player1Turn)
                b.Text = "X";
            else
                b.Text = "O";

            player1Turn = !player1Turn;

            

            b.Enabled = false;
            turn_count++;

            if (!isWinnerOrDraw())
            {
                computer_make_move();
            }
            
           

        }

        private void computer_make_move()
        {
            Button move = null;

            if (player1Turn || !against_computer)
            {
                return;
            }

            {
                move = look_for_win_or_block("O");
                if (move == null)
                {
                    move = look_for_win_or_block("X");
                    if (move == null)
                    {
                        move = look_for_corner();
                        if (move == null)
                        {
                            move = look_for_open_space();
                            if (move == null) ;

                        }
                    }
                }

                move.PerformClick();


            }
        }

        private Button look_for_corner()
        {
            Console.WriteLine("Looking for coner");
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }
            if (A3.Text == "O")
            {
                if (A1.Text == "O")
                    return A1;
                if (C3.Text == "O")
                    return C3;
                if (C1.Text == "O")
                    return C1;
            }
            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }
            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;

        }

        private Button look_for_open_space()

        {
            Console.WriteLine(("Looking for open space"));
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }
            }
            return null;
        }

       

        private Button look_for_win_or_block(string mark)
        {
            Console.WriteLine("Looking for win or block:   " + mark);
            // Horizontal Tests

            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            // Vertical Test

            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //Diagonal Tests

            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;

        }
        private bool isWinnerOrDraw()
        {
            bool there_is_a_winner = false;
            bool there_is_a_draw = false;



            
            //Horizontal Check

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;

            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;

            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            //Vertical Check
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;

            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;

            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            //Diagonal checks
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;

            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;



            if (there_is_a_winner)
            {
                disableButtons();

                string winner = " ";
                if (player1Turn)
                {

                    winner = p2.Text;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                    MessageBox.Show(winner + "  Wins!", "YaY!");
                }
                else
                {
                    winner = p1.Text;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                    MessageBox.Show(winner + "  Wins!", "YaY!");

                }

                NewGame();
            }

            else
            {
                if (turn_count == 9)
                {
                    there_is_a_draw = true;
                    disableButtons();

                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("DRAWWWWW!");

                    NewGame();
                }
                else
                {
                    
                    {
                        
                    }
                }
            }

            if (!there_is_a_winner && turn_count == 9)
                there_is_a_draw = true;
            return there_is_a_draw || there_is_a_winner;

        }
        
       

     

        private void disableButtons()

        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button) c;
                    b.Enabled = false;

                }
            }
            catch
            {
            }

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();


        }

        private void NewGame()
        {
            player1Turn = true;
            turn_count = 0;


            foreach (Control c in Controls)
            {
                try
                {

                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }

                catch
                {
                }
            }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            if (b.Enabled)
            {


                if (player1Turn)

                    b.Text = "X";

                else

                    b.Text = "O";
            }
        }


        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            if (b.Enabled)
            {
                b.Text = "";

            }
        
            
        }

        private void resetCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Form f2 = new Form2();
            f2.ShowDialog();
            p1.Text = player1;
            p2.Text = player2;
            */

            setPlayerDefaultsToolStripMenuItem.PerformClick();
        }

        private void p2_TextChanged(object sender, EventArgs e)
        {
            if (p2.Text.ToUpper() == "COMPUTER")
                against_computer = true;
            else
            
                against_computer = false;

         }

        private void setPlayerDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1.Text = "David";
            p2.Text = "COMPUTER";

        }
    }
}



                
            
      