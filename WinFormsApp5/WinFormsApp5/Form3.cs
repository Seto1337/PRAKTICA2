using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double sideA) &&
                double.TryParse(textBox2.Text, out double sideB) &&
                double.TryParse(textBox3.Text, out double angle))
            {
                double angleRadians = angle * Math.PI / 180;

                double area = 0;
                double perimeter = 0;

                CalculateTriangleProperties(sideA, sideB, angleRadians, ref area, ref perimeter);

                label5.Text = $"Площадь:: {area:F2}";
                label6.Text = $"Периметр: {perimeter:F2}";
            }
            else
            {
                MessageBox.Show("Пожалуйста введите действительные числа для сторон и угла.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static unsafe void CalculateTriangleProperties(double sideA, double sideB, double angleRadians, ref double area, ref double perimeter)
        {
            double sideC = Math.Sqrt(sideA * sideA + sideB * sideB - 2 * sideA * sideB * Math.Cos(angleRadians));

            area = 0.5 * sideA * sideB * Math.Sin(angleRadians);

            perimeter = sideA + sideB + sideC;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 secondForm = new Form4();

            secondForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();

            secondForm.Show();
            this.Hide();
        }
    }
}
