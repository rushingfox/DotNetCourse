using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator_WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double number1 = Convert.ToDouble(textBox1.Text);
            double number2 = Convert.ToDouble(textBox2.Text);
            string result="error!";
            if (radioButton1.Checked)
            {
                result = Convert.ToString(number1 + number2);
            }
            else if (radioButton2.Checked)
            {
                result = Convert.ToString(number1 - number2);
            }
            else if (radioButton3.Checked)
            {
                result = Convert.ToString(number1 * number2);
            }
            else if (radioButton4.Checked)
            {
                if (number2==0)
                {
                    MessageBox.Show("0 can not be the number 2 when the operator is /");
                }
                else
                {
                    result = Convert.ToString(number1 / number2);
                }
            }
            else
            {
                MessageBox.Show("you have not chosen the operator!");
            }

            label4.Text = result;
        }
    }
}
