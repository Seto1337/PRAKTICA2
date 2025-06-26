namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int a) && int.TryParse(textBox2.Text, out int b) && int.TryParse(textBox3.Text, out int c))
            {
                if (a > 0 && b > 0 && c > 0)
                {
                    double average = (a + b + c) / 3.0;
                    label6.Text = $"Все числа положительные. Среднее арифметическое: {average:F2}";
                }
                else
                {
                    double product = a * b * c;
                    label6.Text = $"Не все числа положительные. Произведение: {product}";
                }
            }
            else
            {
                label6.Text = "Ошибка: Введите корректные целые числа во все поля.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 secondForm = new Form7();

            secondForm.Show();
            this.Hide();
        }
    }
}