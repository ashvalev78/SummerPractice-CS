using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Форма приветствия";
            toolTip1.SetToolTip(textBox2, "Введите ваше имя");
            toolTip1.IsBalloon = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здравствуй, " + textBox2.Text + "!", "Приветствие");
        }

    }
}
