using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Текстовый редактор";
            //openFileDialog1.FileName = "C:/CLR/WindowsFormsApp3/Riba.txt";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == null) return;
            if (!openFileDialog1.CheckFileExists) return;
            try
            {
                String text = String.Format("{0}", System.IO.File.ReadAllText(openFileDialog1.FileName));
                textBox1.Text = text;
            }
            catch (System.IO.FileNotFoundException fail)
            {
                MessageBox.Show(fail.Message + "\nФайл не найден", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save();
            }
        }

        void Save()
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            try
            {
                StreamWriter myStream = new StreamWriter(openFileDialog1.FileName);
                myStream.Write(textBox1.Text);
                myStream.Close();
                textBox1.Modified = false;
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) 
        {
            if (textBox1.Modified == false) return;
            DialogResult res = MessageBox.Show("Текст был изменен! \nЖелаете сохранить изменения?", "Простой редактор",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (res == DialogResult.No) return;
            if (res == DialogResult.Cancel) e.Cancel = true;
            if (res == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Save();
                    return;
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }
    }
}
