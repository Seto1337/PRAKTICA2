using oaip22;

public class Circle : Ellipse
{
    public override void Create(params string[] parameters)
    {
        if (parameters.Length >= 3 &&
            int.TryParse(parameters[0], out int x) &&
            int.TryParse(parameters[1], out int y) &&
            int.TryParse(parameters[2], out int radius))
        {
            X = x;
            Y = y;
            Width = radius * 2;
            Height = radius * 2;

            Rectangle bounds = new Rectangle(X - radius, Y - radius, Width, Height);
            if (IsOutOfBounds(bounds))
            {
                MessageBox.Show("Ошибка: круг выходит за границы PictureBox.");
                return;
            }
        }
        else
        {
            MessageBox.Show("Ошибка: некорректные параметры для круга.");
        }
    }

    public void UpdateRadius(int newRadius)
    {
        Rectangle bounds = new Rectangle(X - newRadius, Y - newRadius, newRadius * 2, newRadius * 2);
        if (IsOutOfBounds(bounds))
        {
            MessageBox.Show("Ошибка: новый радиус выводит круг за границы PictureBox.");
            return;
        }
        Width = newRadius * 2;
        Height = newRadius * 2;
    }
}