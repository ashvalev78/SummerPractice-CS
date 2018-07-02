using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Фото галерея";
            label1.Text = "";
            Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.Text;
            switch(comboBox1.SelectedIndex)
            {
                case 0: pictureBox1.Image = Image.FromFile("C:/CLR/WindowsFormsApp2/Summer.jpg");
                    break;
                case 1: pictureBox1.Image = Image.FromFile("C:/CLR/WindowsFormsApp2/Sun.jpg");
                    break;
                case 2: pictureBox1.Image = Image.FromFile("C:/CLR/WindowsFormsApp2/Sea.jpg");
                    break;
                case 3: pictureBox1.Image = Image.FromFile("C:/CLR/WindowsFormsApp2/Beach.jpg");
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String text = String.Format("{0}",  textBox1.Text);
            Brush brush = new SolidBrush(Color.LimeGreen);
            Graphics graphics = pictureBox2.CreateGraphics();
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.DrawString(text, Font, brush, 150, 50);
        }
    }
}
