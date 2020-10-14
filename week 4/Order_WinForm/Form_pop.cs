using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_WinForm
{
    public partial class Form_pop : Form
    {
        private int choice = 1;//edit function needs to make sure the para：property you wanna change!
        public Form_pop()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text)&&radioButton2.Checked)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                choice = 1;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && radioButton2.Checked)
            {
                textBox1.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                choice = 2;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text) && radioButton2.Checked)
            {
                textBox2.ReadOnly = true;
                textBox1.ReadOnly = true;
                textBox4.ReadOnly = true;
                choice = 3;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) && radioButton2.Checked)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox1.ReadOnly = true;
                choice = 4;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form1.orderService.AddOrder(Convert.ToInt32(textBox1.Text), Convert.ToString(textBox2.Text), Convert.ToString(textBox3.Text), Convert.ToInt32(textBox4.Text));
            }
            else if (radioButton2.Checked)
            {
                Form1.orderService.ChangeOrder(choice, Convert.ToInt32(textBox5.Text), choice == 1 ? Convert.ToInt32(textBox1.Text) : Convert.ToInt32(textBox4.Text), choice == 2 ? Convert.ToString(textBox2.Text) : Convert.ToString(textBox3.Text));
            }
            this.Close();//close the window and dispose it!
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox5.Visible = true;
            }
            else
            {
                textBox5.Visible = false;
            }
        }
    }
}
