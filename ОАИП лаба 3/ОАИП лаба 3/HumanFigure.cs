using System;
using System.Drawing;
using System.Windows.Forms;

namespace ОАИП_лаба_3
{
    public class HumanFigure
    {
        public string Name { get; set; }  // Имя фигуры
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }

        public void Create(string xStr, string yStr, string sizeStr, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Ошибка: Имя фигуры не может быть пустым.");
                return;
            }

            if (!int.TryParse(xStr, out int x) ||
                !int.TryParse(yStr, out int y) ||
                !int.TryParse(sizeStr, out int size))
            {
                MessageBox.Show($"Ошибка: Не удалось преобразовать числа.\nX: {xStr}, Y: {yStr}, Size: {sizeStr}");
                return;
            }

            Name = name;
            X = x;
            Y = y;
            Size = size;

            MessageBox.Show($"Фигура создана: Name={Name}, X={X}, Y={Y}, Size={Size}");
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public Rectangle GetBounds()
        {
            // Рассчитываем границы всей фигуры
            int left = X - Size / 3; // Самая левая точка (тело выходит за пределы головы)
            int top = Y;              // Самая верхняя точка (вершина головы)
            int right = X + Size + Size / 3; // Самая правая точка (тело выходит за пределы головы)
            int bottom = Y + 2 * Size + Size / 2; // Самая нижняя точка (ноги)

            int width = right - left;
            int height = bottom - top;

            return new Rectangle(left, top, width, height);
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
        

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);

            // Голова (треугольник)
            Point top = new Point(X + Size / 2, Y);
            Point left = new Point(X, Y + Size);
            Point right = new Point(X + Size, Y + Size);
            Point[] headTriangle = { top, left, right };
            g.DrawPolygon(pen, headTriangle);

            // Голова (круг)
            double sideLength = Distance(left, right);
            int headSize = (int)(sideLength / Math.Sqrt(3));
            int headX = X + (Size / 2) - (headSize / 2);
            int headY = Y + (Size / 3);
            g.DrawEllipse(pen, headX, headY, headSize, headSize);

            // Глаза
            int eyeSize = headSize / 8;
            g.DrawEllipse(pen, headX + headSize / 4, headY + headSize / 3, eyeSize, eyeSize);
            g.DrawEllipse(pen, headX + headSize / 2, headY + headSize / 3, eyeSize, eyeSize);

            // Тело (треугольник)
            Point bodyTop = new Point(X + Size / 2, Y + Size);
            Point bodyLeft = new Point(X - Size / 3, Y + 2 * Size);
            Point bodyRight = new Point(X + Size + Size / 3, Y + 2 * Size);
            Point[] bodyTriangle = { bodyTop, bodyLeft, bodyRight };
            g.DrawPolygon(pen, bodyTriangle);

            // Ноги
            int legWidth = headSize / 2;
            int legHeight = Size / 2;
            g.DrawRectangle(pen, X + Size / 3, Y + 2 * Size, legWidth, legHeight);
            g.DrawRectangle(pen, X + Size / 2, Y + 2 * Size, legWidth, legHeight);
        }
    }
}