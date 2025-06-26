using oaip22;
using WinFormsApp9;

public class Polygon : Figure
{
    protected List<Point> Points { get; set; } = new List<Point>();

    public void SetPoints(List<Point> points)
    {
        Points = points;
        Rectangle bounds = GetBounds();
        if (IsOutOfBounds(bounds))
        {
            MessageBox.Show("Ошибка: многоугольник выходит за границы PictureBox.");
            Points.Clear();
            return;
        }
    }

    public override void Create(params string[] parameters)
    {
        if (parameters.Length % 2 != 0 || parameters.Length < 6)
        {
            MessageBox.Show("Ошибка: некорректные параметры для многоугольника.");
            return;
        }

        Points.Clear();
        for (int i = 0; i < parameters.Length; i += 2)
        {
            if (int.TryParse(parameters[i], out int x) && int.TryParse(parameters[i + 1], out int y))
            {
                Points.Add(new Point(x, y));
            }
            else
            {
                MessageBox.Show("Ошибка: некорректные координаты точки многоугольника.");
                return;
            }
        }

        Rectangle bounds = GetBounds();
        if (IsOutOfBounds(bounds))
        {
            MessageBox.Show("Ошибка: многоугольник выходит за границы PictureBox.");
            Points.Clear();
            return;
        }
    }

    public override void Draw(Graphics g)
    {
        if (Points.Count >= 3)
        {
            g.DrawPolygon(Pens.Black, Points.ToArray());
        }
        else
        {
            MessageBox.Show("Ошибка: недостаточно точек для отрисовки многоугольника.");
        }
    }

    protected Rectangle GetBounds()
    {
        if (Points.Count == 0)
            return Rectangle.Empty;

        int minX = Points.Min(p => p.X);
        int minY = Points.Min(p => p.Y);
        int maxX = Points.Max(p => p.X);
        int maxY = Points.Max(p => p.Y);
        return new Rectangle(minX, minY, maxX - minX, maxY - minY);
    }
}