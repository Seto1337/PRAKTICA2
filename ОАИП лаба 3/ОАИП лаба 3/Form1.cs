using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ОАИП_лаба_3
{
    public partial class Form1 : Form
    {
        private List<HumanFigure> shapes = new List<HumanFigure>();
        private HashSet<string> shapeNames = new HashSet<string>();
        private Stack<string> commandHistoryStack = new Stack<string>();

        public Form1()
        {
            InitializeComponent();
            textBox1.KeyDown += textBox1_KeyDown;
        }

        private void textBox1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string command = textBox1.Text.Trim();
                if (!string.IsNullOrEmpty(command))
                {
                    bool success = ProcessCommand(command);
                    AddToHistory(command, success);
                    textBox1.Clear();
                    pictureBox1.Invalidate();
                }
                e.SuppressKeyPress = true;
            }
        }

        private bool ProcessCommand(string command)
        {
            commandHistoryStack.Push(command);

            string[] parts = command.Split(' ');
            if (parts.Length == 0) return false;

            string lastPart = parts.Last();
            if (lastPart == "F")
                return CreateShape(parts);
            else if (lastPart == "M")
                return MoveShape(parts);
            else if (lastPart == "D")
                return DeleteShape(parts);
            else
                return false;
        }

        private bool CreateShape(string[] parts)
        {
            if (parts.Length != 6)
            {
                MessageBox.Show($"Ошибка: Ожидалось 6 параметров, получено {parts.Length}");
                return false;
            }

            string widthStr = parts[0].Trim();
            string heightStr = parts[1].Trim();
            string name = parts[2].Trim();
            string xStr = parts[3].Trim();
            string yStr = parts[4].Trim();

            if (!int.TryParse(widthStr, out int width) ||
                !int.TryParse(heightStr, out int height) ||
                !int.TryParse(xStr, out int x) ||
                !int.TryParse(yStr, out int y))
            {
                MessageBox.Show("Ошибка: Не удалось преобразовать числа.");
                return false;
            }

            if (shapeNames.Contains(name))
            {
                MessageBox.Show($"Ошибка: Фигура с именем '{name}' уже существует.");
                return false;
            }

            HumanFigure tempFigure = new HumanFigure();
            tempFigure.Create(x.ToString(), y.ToString(), width.ToString(), "temp");

            Rectangle bounds = tempFigure.GetBounds();

            if (bounds.Left < 0 || bounds.Top < 0 ||
                bounds.Right > pictureBox1.Width || bounds.Bottom > pictureBox1.Height)
            {
                MessageBox.Show("Ошибка: Фигура выходит за пределы PictureBox.");
                return false;
            }

            if (width < 20 || height < 20)
            {
                MessageBox.Show("Ошибка: Слишком маленький размер фигуры (минимум 20x20).");
                return false;
            }

            MessageBox.Show($"Создание фигуры: {name}, X={x}, Y={y}, W={width}, H={height}");

            HumanFigure figure = new HumanFigure();
            figure.Create(x.ToString(), y.ToString(), width.ToString(), name);
            shapes.Add(figure);
            shapeNames.Add(name);

            pictureBox1.Refresh();
            return true;
        }

        private bool MoveShape(string[] parts)
        {
            if (parts.Length != 4) return false;

            string name = parts[0].Trim();
            if (!int.TryParse(parts[1], out int dy) || !int.TryParse(parts[2], out int dx))
                return false;

            HumanFigure shape = shapes.FirstOrDefault(f => f.Name == name);
            if (shape == null)
            {
                MessageBox.Show($"Фигура с именем '{name}' не найдена.");
                return false;
            }

            Rectangle bounds = shape.GetBounds();
            bounds.Offset(dx, dy);

            if (bounds.Left < 0 || bounds.Top < 0 ||
                bounds.Right > pictureBox1.Width || bounds.Bottom > pictureBox1.Height)
            {
                MessageBox.Show("Нельзя переместить фигуру за границу PictureBox.");
                return false;
            }

            shape.Move(dx, dy);
            return true;
        }

        private bool DeleteShape(string[] parts)
        {
            if (parts.Length != 2) return false;

            string name = parts[0].Trim();
            string command = parts[1].Trim();

            if (command != "D") return false;

            HumanFigure shape = shapes.FirstOrDefault(f => f.Name == name);
            if (shape == null)
            {
                MessageBox.Show($"Фигура с именем '{name}' не найдена.");
                return false;
            }

            shapes.Remove(shape);
            shapeNames.Remove(name);
            pictureBox1.Invalidate();
            return true;
        }

        private void AddToHistory(string command, bool success)
        {
            string result = success ? "[OK] " : "[ERROR] ";
            result += command;

            listBox1.Items.Add(result);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (shapes.Count == 0)
            {
                MessageBox.Show("Нет фигур для отрисовки.");
                return;
            }

            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }
        }
    }
}