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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int size) || size <= 0)
            {
                MessageBox.Show("Пожалуйста введите допустимый размер массива.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] elements = textBox2.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (elements.Length != size)
            {
                MessageBox.Show($"Пожалуйста введите точно {size} элементы разделеные запятыми.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                if (!int.TryParse(elements[i], out array[i]))
                {
                    MessageBox.Show("Пожалуйста введите допустимые целые числа для элементов массива.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            unsafe
            {
                fixed (int* ptr = array)
                {
                    int minValue;
                    int* minAddress = FindMinElement(ptr, size, out minValue);

                    label4.Text = $"Минимальный элемент: {minValue}, Адресс: {(long)minAddress:X}";
                }
            }
        }

        private unsafe int* FindMinElement(int* array, int size, out int minValue)
        {
            int* minPtr = array;
            minValue = *array;

            for (int i = 1; i < size; i++)
            {
                if (*(array + i) < minValue)
                {
                    minValue = *(array + i);
                    minPtr = array + i;
                }
            }

            return minPtr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 secondForm = new Form5();

            secondForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 secondForm = new Form3();

            secondForm.Show();
            this.Hide();
        }
    }
}
