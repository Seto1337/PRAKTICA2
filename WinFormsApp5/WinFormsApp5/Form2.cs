using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                int[,] matrix = new int[10, 10];
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        matrix[i, j] = random.Next(0, 1000);
                    }
                }

                string matrixString = "Matrix:\n";
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        matrixString += matrix[i, j].ToString().PadLeft(4) + " ";
                    }
                    matrixString += "\n";
                }

                int twoDigitCount = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (matrix[i, j] >= 10 && matrix[i, j] <= 99)
                        {
                            twoDigitCount++;
                        }
                    }
                }

                if (labelBinary != null)
                {
                    labelBinary.Text = matrixString;
                }
                if (label2 != null)
                {
                    label2.Text = $"Количество двузначных чисел: {twoDigitCount}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 secondForm = new Form3();
                secondForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form7 secondForm = new Form7();
                secondForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}