using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            сохранитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double r = Convert.ToDouble(textBox1.Text);
                double h = Convert.ToDouble(textBox2.Text);
                if (radioButton1.Checked)
                {
                    double v = Math.PI * r * r * h;
                    v = Math.Round(v, 3);
                    label3.Text = v.ToString();
                }
                if (radioButton2.Checked)
                {
                    double s;
                    double sosn = Math.PI * r * r;
                    double sbok = 2 * Math.PI * r * h;
                    s = sbok + 2 * sosn;
                    s = Math.Round(s, 3);
                    label3.Text = s.ToString();
                }

            }
            catch (FormatException)
            {
            }

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
                    {
                        string vstr ="";
                        string sstr="";
                        try
                        {
                            double r = Convert.ToDouble(textBox1.Text);
                            double h = Convert.ToDouble(textBox2.Text);
                            
                                double v = Math.PI * r * r * h;
                                v = Math.Round(v, 3);
                                vstr = v.ToString();
                                double s;
                                double sosn = Math.PI * r * r;
                                double sbok = 2 * Math.PI * r * h;
                                s = sbok + 2 * sosn;
                                s = Math.Round(s, 3);
                                sstr = s.ToString();
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show($"Ошибка при сохранении данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        writer.WriteLine(textBox1.Text);
                        writer.WriteLine(textBox2.Text);
                        writer.WriteLine(vstr);
                        writer.WriteLine(sstr);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void показатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vstr = "";
            string sstr = "";
            try
            {
                double r = Convert.ToDouble(textBox1.Text);
                double h = Convert.ToDouble(textBox2.Text);
                double v = Math.PI * r * r * h;
                v = Math.Round(v, 3);
                vstr = v.ToString();
                double s;
                    double sosn = Math.PI * r * r;
                    double sbok = 2 * Math.PI * r * h;
                    s = sbok + 2 * sosn;
                    s = Math.Round(s, 3);
                    sstr= s.ToString();
            }
            catch (FormatException)
            {
            }
            if (vstr != "" && sstr != "")
            {
                MessageBox.Show($"r=:{textBox1.Text}\n" +
                                $"h=:{textBox2.Text}\n" +
                                $"v=:{vstr}\n" +
                                $"s=:{sstr}\n"
                                , "Результаты", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void условиеЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вариант 4. Приложение для расчёта параметров цилиндра. Главная форма содержит: элементы для ввода значений радиуса основания и высоты; группу элементов для выбора вычислений объёма и площади поверхности цилиндра."
                                , "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Лабораторная работа №9. Разработка Windows-приложений с помощью архитектуры Windows Forms \nАвтор:Максим Жоголь"
                               , "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
