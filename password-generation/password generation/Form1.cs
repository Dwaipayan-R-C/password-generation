using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace password_generation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please mention the password length");
            }
            else
            {
                var rand = new Random();
                var lowCase = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i",
                "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z" };
                var upperCase = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
                "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z" };
                var number = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                var specialChar = new List<string> { "£", "$", "&", "(", ")", "*", "+", "[", "]", "@", "#", "^", "-", "_", "!", "?" };
                var randomIndex = new List<int> { 1, 2, 3, 4 };

                // Define password length
                int passLength = Int32.Parse(textBox1.Text);

                // Initialize password
                string password = "";

                //loop the variables that contain varieties
                //always add various character sets to increase password strength

                for (int i = 0; i < passLength; i++)
                {
                    int chooseCharGroup = rand.Next(randomIndex.Count);
                    int index;
                    int indexCases;
                    index = (rand.Next(randomIndex.Count));

                    switch (randomIndex[index])
                    {
                        case 1:
                            indexCases = (rand.Next(lowCase.Count));
                            password = password + lowCase[indexCases];
                            break;

                        case 2:
                            indexCases = (rand.Next(upperCase.Count));
                            password = password + upperCase[indexCases];
                            break;
                        case 3:
                            indexCases = (rand.Next(number.Count));
                            password = password + number[indexCases];
                            break;
                        case 4:
                            indexCases = (rand.Next(specialChar.Count));
                            password = password + specialChar[indexCases];
                            break;

                        default:
                            break;
                    }
                }
                textBox2.Text = password;
            }                
        }

        //checks if only integers are put in the first textbox as the length has to be in integer

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // This copies the textbox2 and shows the message
        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
            MessageBox.Show("Copied to Clipboard");
        }
    }
}
