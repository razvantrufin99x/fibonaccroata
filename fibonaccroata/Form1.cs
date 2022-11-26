using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace fibonaccroata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Graphics g;
        public Font f;
        public Pen p = new Pen(Color.Black, 1);
        public Brush b = new SolidBrush(Color.Black);

        
        public float MOVE_SPEED = 3.0f;
        public float rad = 180.0f / 3.140f;

        public float px, cx, py, cy;

        public List<int> fibonaccinumberslist = new List<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            fibonacci(46);
            fibonaccilisttotextbox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printfibonacciroata();
        }

        public void printfibonacciroata()
        {
            float j = 1.0f;
            for (int i = 0; i < fibonaccinumberslist.Count; i++)
            {
                try
                {
                    cx = (float)((100+j) * (Math.Cos(fibonaccinumberslist[i] / rad)) + 200);
                    cy = (float)((100+j) * (Math.Sin(fibonaccinumberslist[i] / rad)) + 200);
                    g.DrawLine(p, cx, cy, px, py);
                    g.DrawEllipse(p, cx, cy, 3, 3);
                    px = cx;
                    py = cy;
                    Thread.Sleep(1);
                }
                catch { }
                j+=1.0f;

            }
        }

        public void fibonacci(int number)
        {
            int n1 = 0, n2 = 1, n3, i;

            fibonaccinumberslist.Add(n1);
            fibonaccinumberslist.Add(n2);
              
            for (i = 2; i < number; ++i) //loop starts from 2 because 0 and 1 are already printed    
            {
                n3 = n1 + n2;
                fibonaccinumberslist.Add(n3);
                 n1 = n2;
                n2 = n3;
            }
        }

        public void fibonaccilisttotextbox()
        {
            for (int i = 0; i < fibonaccinumberslist.Count; ++i)
            {
                this.textBox1.Text += "\r\n";
                this.textBox1.Text += fibonaccinumberslist[i];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            f = this.Font;
          

        }
    }
}
