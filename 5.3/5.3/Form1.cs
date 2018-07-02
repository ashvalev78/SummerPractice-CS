using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Закрашивание фигур";
            label1.Text = "Введите фигуру";
            comboBox1.Text = "Фигуры";
            string[] figures = new string[3] { "Прямоугольник", "Эллипс", "Окружность" };
            comboBox1.Items.AddRange(figures);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics G = pictureBox1.CreateGraphics();
            Brush fill = new SolidBrush(Color.Orange);
            G.Clear(Color.White);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                G.FillRectangle(fill, 60, 60, 120, 180); break;
                case 1:
                G.FillEllipse(fill, 60, 60, 120, 180); break;
                case 2:
                G.FillEllipse(fill, 60, 60, 120, 120); break;
            }

    }
}
}
