using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GUISkillsDemo2
{
    public partial class Hangman_Form : Form
    {
        //Initialise form
        public Hangman_Form()
        {
            InitializeComponent();
        }

        //Public variables
        string[] words = new string[20];
        string[] hints = new string[20];
        int i = 0;
        int count = 0;
        int guessCount = 0;
        string guessWord;
        string displayWord;

        //Form load
        private void Hangman_Form_Load(object sender, EventArgs e)
        { 
            //Connection to database
            string str= "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = HangmanDatabase_1.accdb";
            OleDbConnection connect = new OleDbConnection(str);
            try
            {
                connect.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Does not Connect to Database");
            }
            OleDbCommand command = new OleDbCommand();
            command.Connection = connect; 
            command.CommandText="SELECT Word, Hint FROM HangmanTable";

            OleDbDataReader reader = command.ExecuteReader();

            //Reading in hints and words from database
            while (reader.Read())
            {
                words[i] = reader[0].ToString();
                hints[i] = reader[1].ToString();
                i++;
            }

        }

        //Method to return list of letter buttons
        private List<Button> LetterButtonList()
        {
            List<Button> letterButtons = new List<Button>{
                btnA, btnB, btnC, btnD, btnE,
                btnF, btnG, btnH, btnI, btnJ,
                btnK, btnL, btnM, btnN, btnO,
                btnP, btnQ, btnR, btnS, btnT,
                btnU, btnV, btnW, btnX, btnY, btnZ
            };

            return letterButtons;
        }

    
        //Method to handle a guess
        private void HandleGuess(char guessedLetter)
        {
            char lowerGuessedLetter = char.ToLower(guessedLetter);
            string lowerGuessWord = guessWord.ToLower();
            char[] chrWord = lowerGuessWord.ToCharArray();
            int letterFound = 0;
            int winCheck = 0;


            // Check if the guessed letter is in the word and update the displayWord
            for (int i = 0; i < chrWord.Length; i++)
            {
                if (lowerGuessedLetter == chrWord[i])
                {
                    displayWord = displayWord.Remove(i, 1).Insert(i, guessedLetter.ToString());
                    letterFound++;
                    tbWord.Text = displayWord;
                }
                //Check if player has won
                if (tbWord.Text.ToCharArray()[i] != '*')
                {
                    winCheck++;
                }
            }

            //Add guessed letter to list box
            guessListBox.Items.Add(guessedLetter.ToString().ToUpper());

            //Find button
            foreach (Control control in Controls)
            {
                if (control is Button button && button.Name == "btn" + guessedLetter.ToString().ToUpper())
                {
                    if(button != null)
                    {
                        button.Enabled = false;
                    }
                }
            }

            //Increment guesscount if letter not found
            if (letterFound == 0)
            {
                guessCount++;
            }

            //Show losing message if out of guesses
            if(guessCount >= 6)
            {
                MessageBox.Show("You Lose!, Press generate word to play again.");
                foreach (Button button in LetterButtonList())
                {
                    button.Enabled = false;
                }
            }

            if (winCheck >= chrWord.Length)
            {
                MessageBox.Show("You Win!, Press generate word to play again.");
                foreach (Button button in LetterButtonList())
                {
                    button.Enabled = false;
                }
            }
        }

        //Method to update hangman display
        private void UpdateHangmanDisplay()
        {
            switch (guessCount)
            {
                case 1:
                    pbHangmanHead.Visible = true;
                    break;
                case 2:
                    pbHangmanBody.Visible = true;
                    break;
                case 3:
                    pbHangmanArmLeft.Visible = true;
                    break;
                case 4:
                    pbHangmanArmRight.Visible = true;
                    break;
                case 5:
                    pbHangmanLegLeft.Visible = true;
                    break;
                case 6:
                    pbHangmanLegRight.Visible = true;
                    break;
            }
        }


        //Button to generate new word
        private void btnNewWord_Click(object sender, EventArgs e)
        {
            //Change word to asterisks for display in text box
            StringBuilder sb = new StringBuilder();
            guessWord = words[count];
            for (int i = 0; i < guessWord.Length; i++)
            {
                sb.Append("*");
            }
            displayWord = sb.ToString();

            //Load word and hint into textboxes
            tbWord.Text = displayWord;
            tbHint.Text = (hints[count]);
            count++;

            //Clear items in guessListBox
            guessListBox.Items.Clear();

            //Reset guesscount to zero
            guessCount = 0;

            //Reset hangman parts to invisible
            pbHangmanHead.Visible = false;
            pbHangmanBody.Visible = false;
            pbHangmanArmLeft.Visible = false;
            pbHangmanArmRight.Visible = false;
            pbHangmanLegLeft.Visible = false;
            pbHangmanLegRight.Visible = false;

            //Re-enable Letter buttons
            foreach (Button button in LetterButtonList())
            {
                button.Enabled = true;
            }
        }

        //Letter A button
        private void btnA_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'a';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter B button
        private void btnB_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'b';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter C button
        private void btnC_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'c';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter D button
        private void btnD_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'd';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter E button
        private void btnE_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'e';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter F button
        private void btnF_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'f';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter G button
        private void btnG_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'g';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter H button
        private void btnH_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'h';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter I button
        private void btnI_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'i';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter J button
        private void btnJ_Click(object sender, EventArgs e)
        {  
            //Local variables for button
            char guessedLetter = 'j';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter K button
        private void btnK_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'k';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter L button
        private void btnL_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'l';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

            //Letter M button
            private void btnM_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'm';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter N button
        private void btnN_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'n';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter O button
        private void btnO_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'o';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter P button
        private void btnP_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'p';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter Q button
        private void btnQ_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'q';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter R button
        private void btnR_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'r';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter S button
        private void btnS_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 's';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter T button
        private void btnT_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 't';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter U button
        private void btnU_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'u';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter V button
        private void btnV_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'v';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter W button
        private void btnW_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'w';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter X button
        private void btnX_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'x';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter Y button
        private void btnY_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'y';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

        //Letter Z button
        private void btnZ_Click(object sender, EventArgs e)
        {
            //Local variables for button
            char guessedLetter = 'z';
            HandleGuess(guessedLetter);
            UpdateHangmanDisplay();
        }

    }
}
