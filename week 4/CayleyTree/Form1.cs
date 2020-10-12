using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            graphics.Clip = new Region(new Rectangle(10, 10, 1000, 2000));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(vScrollBar1.Value, 300, 500, the_leng, -Math.PI / 2);
        }

        private Graphics graphics ;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        double k = 0.8;//有道是"位置系数"
        double the_leng=100;
        Color color = Color.Black;//default_color:black

        void drawCayleyTree(int n,
                double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            double x2 = x0 + k*leng * Math.Cos(th);
            double y2 = y0 + k*leng * Math.Sin(th);   //按照题目要求新增了x2y2点

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }
        Random colorrnd = new Random();
        void drawLine(double x0, double y0, double x1, double y1)
        {
            //the following is designed to show random color for the tree
            /*
            int colornum = (int)colorrnd.Next(5);
            Pen thepen=Pens.Black;
            switch (colornum)                     //颜色随机五彩中的一个，营造缤纷效果
            {
                case 0:  thepen = Pens.Yellow;break;
                case 1:  thepen = Pens.Blue; break;
                case 2:  thepen = Pens.Red; break;
                case 3:  thepen = Pens.Green; break;
                case 4:  thepen = Pens.Pink; break;
                default:
                    break;
            }
            graphics.DrawLine(
                thepen,
                (int)x0, (int)y0, (int)x1, (int)y1);
             */
            Pen pen = new Pen(color);
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }


        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            th1 = (30+60*(double)hScrollBar1.Value/(double)91) * Math.PI / 180 ;            //之所以用91是因为滚动条的最大值只能到maximum+1-largechange
            label5.Text = ((30 + 60 * (double)hScrollBar1.Value / (double)91)/180).ToString("f2")+"pi";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (graphics!=null)
            {
                graphics.Clear(this.BackColor);
            }
        }

        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            th2 = (20 + 70 * (double)hScrollBar2.Value / (double)91) * Math.PI / 180;
            label6.Text = ((20 + 70 * (double)hScrollBar2.Value / (double)91) / 180).ToString("f2") + "pi";
        }

        private void hScrollBar3_ValueChanged(object sender, EventArgs e)
        {
            per1 =(double)hScrollBar3.Value / 91;
            label7.Text = per1.ToString("f2");
        }

        private void hScrollBar4_ValueChanged(object sender, EventArgs e)
        {
            per2 = (double)hScrollBar4.Value / 91;
            label8.Text = per2.ToString("f2");
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            k = (double)trackBar1.Value / 10;
            label9.Text = "位置系数："+k.ToString("f2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                color = MyDialog.Color;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            label10.Text = "递归深度："+vScrollBar1.Value;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            the_leng = trackBar2.Value;
            label11.Text = "主干长度：" + trackBar2.Value;
        }
    }
}
