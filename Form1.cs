using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new Button[] { btnNum01, btnNum02, btnNum03, btnNum04,
            btnNum05,btnNum06,btnNum07,btnNum08,
            btnNum09,btnNum10,btnNum11,btnNum12,
            btnNum13,btnNum14,btnNum15,btnNum16};

            btnNum01.NeighborList = new List<Button>() { btnNum02, btnNum05 };
            btnNum02.NeighborList = new List<Button>() { btnNum01, btnNum03, btnNum06 };
            btnNum03.NeighborList = new List<Button>() { btnNum02, btnNum04, btnNum07 };
            btnNum04.NeighborList = new List<Button>() { btnNum03, btnNum08 };
            btnNum05.NeighborList = new List<Button>() { btnNum06, btnNum09, btnNum01 };
            btnNum06.NeighborList = new List<Button>() { btnNum05, btnNum07, btnNum10, btnNum02 };
            btnNum07.NeighborList = new List<Button>() { btnNum06, btnNum08, btnNum11, btnNum03 };
            btnNum08.NeighborList = new List<Button>() { btnNum07, btnNum04, btnNum12 };
            btnNum09.NeighborList = new List<Button>() { btnNum10, btnNum05, btnNum13 };
            btnNum10.NeighborList = new List<Button>() { btnNum06, btnNum09, btnNum14, btnNum11 };
            btnNum11.NeighborList = new List<Button>() { btnNum07, btnNum10, btnNum12, btnNum15 };
            btnNum12.NeighborList = new List<Button>() { btnNum08, btnNum11, btnNum16 };
            btnNum13.NeighborList = new List<Button>() { btnNum09, btnNum14 };
            btnNum14.NeighborList = new List<Button>() { btnNum10, btnNum13, btnNum15 };
            btnNum15.NeighborList = new List<Button>() { btnNum14, btnNum11, btnNum16 };
            btnNum16.NeighborList = new List<Button>() { btnNum12, btnNum15 };

           
        }


        Button[] buttons;


        bool isContinue = true;

        private void isSucceed()
        {

            if (isContinue)
            {
                bool _isSucceed = true;

                for (int i = 0; i < buttons.Length - 1; i++)
                {
                    Button currentButton = buttons[i];
                    if (currentButton.Text == "")
                    {
                        _isSucceed = false;
                        break;
                    }

                    int textValue = Convert.ToInt32(currentButton.Text);

                    if (textValue != i + 1)
                    {
                        _isSucceed = false;
                        break;
                    }
                }

                if (_isSucceed == true)
                {
                    isContinue = false;
                    btnNum16.Text = "16";

                    double totalTime = (DateTime.Now - startTime).TotalSeconds;
                    MessageBox.Show(string.Format("Game over. Time: {0} seconds", totalTime.ToString("0.00")));
                }
            }


        }


        private void changetxt(Button btn1, Button btn2)
        {
            string temp = btn1.Text;
            btn1.Text = btn2.Text;
            btn2.Text = temp;

        }
        DateTime startTime;
        Random random;

        private void btnStart_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            isContinue = true;

            random = new Random();

            List<int> numbers = new List<int>();

            foreach (Button item in buttons)
            {
                int current = random.Next(1, 17);

                while (true)
                {
                    if (numbers.Contains(current))
                    {
                        current = random.Next(1, 17);
                    }
                    else break;
                }

                numbers.Add(current);

                if (current == 16)
                    item.Text = "";
                else item.Text = current.ToString();
            }
           
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            PuzzleButton current = sender as PuzzleButton;
            foreach (PuzzleButton item in current.NeighborList)
            {
                if (item.Text == "")
                {
                    changetxt(current, item);
                    break;
                }              
            }
            isSucceed();
        }      
    }
} 
