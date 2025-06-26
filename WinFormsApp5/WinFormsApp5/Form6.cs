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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int caloriesPer100g) && caloriesPer100g > 0 &&
                double.TryParse(textBox2.Text, out double weightInKg) && weightInKg > 0)
            {
                double totalCalories = Power(caloriesPer100g, weightInKg);

                label4.Text = $"Общая калорийность: {totalCalories:F2} kcal";
            }
            else
            {
                MessageBox.Show("Пожалуйста введите действительные положительные числа для колорий и веса.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double Power(int caloriesPer100g, double weightInKg)
        {
            double weightInGrams = weightInKg * 1000;

            return (caloriesPer100g * weightInGrams) / 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1();

            secondForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 secondForm = new Form5();

            secondForm.Show();
            this.Hide();
        }
    }
}
