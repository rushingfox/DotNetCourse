using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManager;

namespace Order_WinForm
{
    public partial class Form1 : Form
    {
        static public OrderService orderService = new OrderService();
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = orderService.orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = orderService.SearchOrder(comboBox1.SelectedIndex + 1, textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            orderService.DeleteOrder(Convert.ToInt32(textBox1.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            orderService.Import();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            orderService.Export();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_pop form_Pop = new Form_pop();
            form_Pop.ShowDialog();
            form_Pop.radioButton1.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_pop form_Pop = new Form_pop();
            form_Pop.ShowDialog();
            form_Pop.radioButton2.Checked = true;
        }

        private void button7_Click(object sender, EventArgs e)// I don' t know why it doesn' t work after adding the order, conversely it works after search orders.
        {
            bindingSource1.DataSource = orderService.orders;
            dataGridView1.Refresh();
        }
    }
}
