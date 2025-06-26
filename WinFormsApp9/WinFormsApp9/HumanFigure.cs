using oaip22;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Добавляем для MessageBox

namespace WinFormsApp9
{
    public class HumanFigure : Figure
    {
        public int Size { get; set; }

        public override void Create(params string[] parameters)
        {
            if (parameters.Length < 3) return;
            if (int.TryParse(parameters[0], out int x) &&
                int.TryParse(parameters[1], out int y) &&
                int.TryParse(parameters[2], out int size))
            {
                X = x;
                Y = y;
                Size = size;

                // Проверка границ при создании
                Rectangle bounds = GetBounds();
                if (IsOutOfBounds(bounds))
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы PictureBox.");
                    return; // Прерываем создание фигуры
                }
            }
            else
            {
                MessageBox.Show("Ошибка: некорректные параметры для HumanFigure.");
            }
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        public override void Move(int dx, int dy)
        {
            // Проверка границ при перемещении
            Rectangle newBounds = GetBounds();
            newBounds.Offset(dx - X, dy - Y); // Смещаем границы на новое положение
            if (IsOutOfBounds(newBounds))
            {
                MessageBox.Show("Ошибка: перемещение фигуры выводит её за границы PictureBox.");
                return; // Прерываем перемещение
            }

            X = dx;
            Y = dy;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);

            // Равнобедренный треугольник (верхний)
            Point top = new Point(X + Size / 2, Y); // Вершина
            Point left = new Point(X, Y + Size); // Левый угол
            Point right = new Point(X + Size, Y + Size); // Правый угол
            Point[] headTriangle = { top, left, right };
            g.DrawPolygon(pen, headTriangle);

            // Голова (круг) вписанный в треугольник
            double sideLength = Distance(left, right); // Длина стороны треугольника
            int headSize = (int)(sideLength / Math.Sqrt(3)); // Высота вписанной окружности
            int headX = X + (Size / 2) - (headSize / 2);
            int headY = Y + (Size / 3);
            g.DrawEllipse(pen, headX, headY, headSize, headSize);

            // Глаза (маленькие круги)
            int eyeSize = headSize / 8;
            g.DrawEllipse(pen, headX + headSize / 4, headY + headSize / 3, eyeSize, eyeSize);
            g.DrawEllipse(pen, headX + headSize / 2, headY + headSize / 3, eyeSize, eyeSize);

            // Тело (равнобедренный треугольник)
            Point bodyTop = new Point(X + Size / 2, Y + Size); // Вершина тела
            Point bodyLeft = new Point(X - Size / 3, Y + 2 * Size); // Левый угол
            Point bodyRight = new Point(X + Size + Size / 3, Y + 2 * Size); // Правый угол
            Point[] bodyTriangle = { bodyTop, bodyLeft, bodyRight };
            g.DrawPolygon(pen, bodyTriangle);

            // Ноги (два прямоугольника)
            int legWidth = headSize / 2;
            int legHeight = Size / 2;
            g.DrawRectangle(pen, X + Size / 3, Y + 2 * Size, legWidth, legHeight);
            g.DrawRectangle(pen, X + Size / 2, Y + 2 * Size, legWidth, legHeight);
        }

        // Метод для получения границ фигуры
        private Rectangle GetBounds()
        {
            int minX = X - Size / 3; // Левый край тела
            int minY = Y; // Верхняя точка головы
            int maxX = X + Size + Size / 3; // Правый край тела
            int maxY = Y + 2 * Size + Size / 2; // Нижняя точка ног

            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }
    }
}