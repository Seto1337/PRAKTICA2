using System;
using System.Drawing;
using WinFormsApp9;

namespace oaip22
{
    public abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void Create(params string[] parameters);
        public abstract void Draw(Graphics g);
        public virtual void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        protected bool IsOutOfBounds(Rectangle bounds)
        {
            return bounds.Left < 0 || bounds.Top < 0 || bounds.Right > Init.pictureBox.Width || bounds.Bottom > Init.pictureBox.Height;
        }
    }
}