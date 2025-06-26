using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp9
{
    public partial class PolygonInputForm : Form
    {
        public List<Point> Points { get; private set; } = new List<Point>();
        public PolygonInputForm()
        {
            InitializeComponent();
        }
        private void buttonAddPoint_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxX.Text, out int x) && int.TryParse(textBoxY.Text, out int y))
            {
                Points.Add(new Point(x, y));
                listBoxPoints.Items.Add($"({x}, {y})");
                MessageBox.Show($"Точка ({x}, {y}) добавлена!"); // Отладочный вывод
            }
            else
            {
                MessageBox.Show("Ошибка: введите корректные координаты.");
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (Points.Count >= 3)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка: многоугольник должен иметь как минимум 3 точки.");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void PolygonInputForm_Load(object sender, EventArgs e)
        {

        }
    }
}
