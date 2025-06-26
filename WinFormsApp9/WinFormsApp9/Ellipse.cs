using oaip22;

public class Ellipse : Figure
{
    protected int Width { get; set; }
    protected int Height { get; set; }

    public override void Create(params string[] parameters)
    {
        if (parameters.Length >= 4 &&
            int.TryParse(parameters[0], out int x) &&
            int.TryParse(parameters[1], out int y) &&
            int.TryParse(parameters[2], out int width) &&
            int.TryParse(parameters[3], out int height))
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            Rectangle bounds = new Rectangle(X, Y, Width, Height);
            if (IsOutOfBounds(bounds))
            {
                MessageBox.Show("Ошибка: эллипс выходит за границы PictureBox.");
                return;
            }
        }
        else
        {
            MessageBox.Show("Ошибка: некорректные параметры для эллипса.");
        }
    }

    public override void Draw(Graphics g)
    {
        g.DrawEllipse(Pens.Black, X, Y, Width, Height);
    }
}