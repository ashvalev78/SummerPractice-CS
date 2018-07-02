using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynGO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double InitT = 0, LastT = 6.3; // оборот в 360 градусов (6,28 радиан)
        double Step = 0.1, angle = 0;
        double x, y, x1, y1;
        int cX = 120, cY = 120; // центр большой окружности
        int R2 = 90; // радиус большой окружности
        int k = 20; // число областей на траектории
        int R1; // радиус меньшей (движущейся) окружности
        int i = 0; // количество точек прорисовки
        //Point[] p = new Point[64];


        private void Form1_Load(object sender, EventArgs e)
        {
            InitT = 0; LastT = 6.3; // оборот в 360 градусов (6,28 радиан)
            Step = 0.1; angle = 0;
            cX = 120; cY = 120; // центр большой окружности
            R2 = 90; // радиус большой окружности
            k = 20; // число областей на траектории
            R1 = (R2 / k); // радиус меньшей (движущейся) окружности
            i = 0; // количество точек прорисовки
            while (angle <= LastT)
            {
                x = R1 * (k - 1) * (Math.Cos(angle) + Math.Cos((k - 1) * angle) / (k - 1));
                y = R1 * (k - 1) * (Math.Sin(angle) - Math.Sin((k - 1) * angle) / (k - 1));
                //p[i] = System.Drawing.Point(cX + (int)x, cY + (int)y); // расчет очередной точки траектории
                Paint_Graphic(cX, cY, R2, (int)x, (int)y);
                x1 = (R2 - R1) * Math.Sin(angle + 1.57);
                y1 = (R2 - R1) * Math.Cos(angle + 1.57);
                Paint_Circle(cX, cY, (int)x1, (int)y1, R1, (int)x, (int)y);
                angle += Step;
                System.Threading.Thread.Sleep(50); //время приостановки прорисовки
                i++;
            }

        

        void Paint_Circle(int cX, int cY, int centX, int centY, int radius, int x, int y)
        {
            Graphics Графика = pictureBox1.CreateGraphics();
            Графика.DrawEllipse(Pens.Black, centX + cX - radius, cY - radius - centY, radius * 2, radius * 2);
            Графика.DrawLine(Pens.Black, centX + cX, cY - centY, cX + x, cY + y);
            // прорисовка радиуса большей окружности
        }
        void Paint_Graphic(int cX, int cY, int r2, int x, int y)
        {
            Graphics Графика = pictureBox1.CreateGraphics();
            Графика.Clear(BackColor);
            Paint_Circle(cX, cY, 0, 0, r2, x, y);
            Графика.DrawLines(Pens.Red); // траектория
        }
    }
}
