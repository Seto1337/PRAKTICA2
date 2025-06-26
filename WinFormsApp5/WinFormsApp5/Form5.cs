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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int rows) || rows <= 0 ||
                !int.TryParse(textBox2.Text, out int cols) || cols <= 0)
            {
                MessageBox.Show("Пожалуйста введите действительные положительные целые числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[,] originalMatrix = GenerateRandomMatrix(rows, cols);

            label4.Text = "Исходная:\n" + MatrixToString(originalMatrix);

            int[,] rotatedMatrix = RotateMatrixCounterClockwise(originalMatrix);

            label5.Text = "Повернутая (90):\n" + MatrixToString(rotatedMatrix);
        }

        private int[,] GenerateRandomMatrix(int rows, int cols)
        {
            Random random = new Random();
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(-50, 51);
                }
            }

            return matrix;
        }

        private int[,] RotateMatrixCounterClockwise(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] rotatedMatrix = new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    rotatedMatrix[cols - j - 1, i] = matrix[i, j];
                }
            }1

            return rotatedMatrix;
        }

        private string MatrixToString(int[,] matrix)
        {
            string result = "";
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += matrix[i, j].ToString().PadLeft(5) + " ";
                }
                result += "\n";
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 secondForm = new Form6();

            secondForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 secondForm = new Form4();

            secondForm.Show();
            this.Hide();
        }
    }
}
