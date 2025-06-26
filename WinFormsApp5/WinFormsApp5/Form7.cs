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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int decimalNumber))
            {
                string binaryNumber = DecimalToBinary(decimalNumber);

                label2.Text = $"Двоичное представление: {binaryNumber}";
            }
            else
            {
                label2.Text = "Ошибка: введите целое число!";
            }
        }

        static string DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0)
            {
                return "0";
            }

            string binary = "";

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % 2;
                binary = remainder + binary;
                decimalNumber = decimalNumber / 2;
            }

            return binary;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1();

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
