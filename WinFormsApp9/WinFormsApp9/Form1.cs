using oaip22;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Pen pen;
        List<Figure> figures = new List<Figure>(); // ������ ������������ ������

        public Form1()
        {
            InitializeComponent();
            this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            pictureBox1.Image = bitmap;
            this.pen = new Pen(Color.Black, 5);

            Init.bitmap = this.bitmap;
            Init.pictureBox = pictureBox1;
            Init.pen = this.pen;
            Init.comboBox = this.comboBox1;

            //comboBox2.Items.AddRange(new string[] { "Rectangle", "Square", "Ellipse", "Circle", "Polygon", "Triangle" });
            //comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Figure newFigure = null;
            Graphics g = Graphics.FromImage(bitmap);

            if (radioButton1.Checked) // ����
            {
                if (int.TryParse(textBox1.Text, out int x) &&
                    int.TryParse(textBox2.Text, out int y) &&
                    int.TryParse(textBox7.Text, out int radius))
                {
                    if (x - radius < 0 || x + radius > Init.pictureBox.Width ||
                        y - radius < 0 || y + radius > Init.pictureBox.Height)
                    {
                        MessageBox.Show("������: ����� �� �������");
                    }
                    else
                    {
                        newFigure = new Circle();
                        newFigure.Create(textBox1.Text, textBox2.Text, textBox7.Text);
                        comboBox3.Items.Add($"���������� {figures.Count} (R={radius})");
                    }
                }
            }
            else if (radioButton2.Checked) // ������
            {
                if (int.TryParse(textBox1.Text, out int x) &&
                    int.TryParse(textBox2.Text, out int y) &&
                    int.TryParse(textBox7.Text, out int width) &&
                    int.TryParse(textBox8.Text, out int height))
                {
                    if (x < 0 || y < 0 || x + width > Init.pictureBox.Width || y + height > Init.pictureBox.Height)
                    {
                        MessageBox.Show("������: ����� �� �������");
                        return;
                    }
                    else
                    {
                        newFigure = new Ellipse();
                        newFigure.Create(textBox1.Text, textBox2.Text, textBox7.Text, textBox8.Text);
                    }
                }
            }
            else if (radioButton3.Checked) // �������
            {
                if (int.TryParse(textBox1.Text, out int x) &&
                    int.TryParse(textBox2.Text, out int y) &&
                    int.TryParse(textBox7.Text, out int side))
                {
                    if (x < 0 || y < 0 || x + side > Init.pictureBox.Width || y + side > Init.pictureBox.Height)
                    {
                        MessageBox.Show("������: ����� �� �������");
                        return;
                    }
                    else
                    {
                        newFigure = new Square();
                        newFigure.Create(textBox1.Text, textBox2.Text, textBox7.Text);
                    }
                }
            }
            else if (radioButton4.Checked) // �������������
            {
                if (int.TryParse(textBox1.Text, out int x) &&
                    int.TryParse(textBox2.Text, out int y) &&
                    int.TryParse(textBox7.Text, out int width) &&
                    int.TryParse(textBox8.Text, out int height))
                {
                    if (x < 0 || y < 0 || x + width > Init.pictureBox.Width || y + height > Init.pictureBox.Height)
                    {
                        MessageBox.Show("������: ����� �� �������");
                        return;
                    }
                    else
                    {
                        newFigure = new RectangleFigure();
                        newFigure.Create(textBox1.Text, textBox2.Text, textBox7.Text, textBox8.Text);
                    }
                }
            }
            else if (radioButton6.Checked) // �������������
            {
                PolygonInputForm inputForm = new PolygonInputForm();
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    bool isOutOfBounds = false;
                    foreach (var point in inputForm.Points)
                    {
                        if (point.X < 0 || point.Y < 0 || point.X > Init.pictureBox.Width || point.Y > Init.pictureBox.Height)
                        {
                            isOutOfBounds = true;
                            break;
                        }
                    }

                    if (isOutOfBounds)
                    {
                        MessageBox.Show("������: ������������� ������� �� ������� PictureBox.");
                        return;
                    }
                    else
                    {
                        Polygon newPolygon = new Polygon();
                        newPolygon.SetPoints(inputForm.Points);

                        // ��������� ������������� � ������ �����
                        figures.Add(newPolygon);

                        // ��������� ���������� ��� � comboBox1 � comboBox2
                        string uniqueName = $"������������� {figures.Count} (�����={inputForm.Points.Count})";
                        comboBox1.Items.Add(uniqueName);
                        comboBox2.Items.Add(uniqueName);

                        // ���������� �����
                        MessageBox.Show($"���������� �����: {inputForm.Points.Count}");

                        RedrawAllFigures();
                    }
                }
            }
            else if (radioButton5.Checked) // �����������
            {
                if ((int.TryParse(textBox1.Text, out int x1) &&
                    int.TryParse(textBox2.Text, out int y1) &&
                    int.TryParse(textBox3.Text, out int x2) &&
                    int.TryParse(textBox4.Text, out int y2) &&
                    int.TryParse(textBox9.Text, out int x3) &&
                    int.TryParse(textBox10.Text, out int y3)))
                {
                    if (x1 < 0 || y1 < 0 || x2 < 0 || y2 < 0 || x3 < 0 || y3 < 0 ||
                        x1 > Init.pictureBox.Width || y1 > Init.pictureBox.Height ||
                        x2 > Init.pictureBox.Width || y2 > Init.pictureBox.Height ||
                        x3 > Init.pictureBox.Width || y3 > Init.pictureBox.Height)
                    {
                        MessageBox.Show("������: ����� �� �������");
                        return;
                    }
                    else
                    {
                        newFigure = new Triangle();
                        newFigure.Create(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox9.Text, textBox10.Text);
                    }
                }
            }
            else if (radioButton7.Checked) // ������� ������
            {
                if (int.TryParse(textBox1.Text, out int x) &&
                    int.TryParse(textBox2.Text, out int y) &&
                    int.TryParse(textBox7.Text, out int size))
                {
                    if (x < 0 || y < 0 || x + size > Init.pictureBox.Width || y + size > Init.pictureBox.Height)
                    {
                        MessageBox.Show("������: ����� �� �������");
                        return;
                    }
                    else
                    {
                        newFigure = new HumanFigure();
                        newFigure.Create(textBox1.Text, textBox2.Text, textBox7.Text);
                    }
                }
            }

            if (newFigure != null)
            {
                figures.Add(newFigure); // ��������� ������ � ������
                newFigure.Draw(g); // ������ ������

                // ���������� ����� � ��� ������ ������ � ������ + 1 (����� ��������� ���������� � 1)
                int uniqueNumber = figures.Count;

                // ��������� ������ � ���������� ������ � ���������� �������
                comboBox1.Items.Add($"������ {uniqueNumber} ({newFigure.GetType().Name})");
                comboBox2.Items.Add($"������ {uniqueNumber} ({newFigure.GetType().Name})");
            }
            else
            {
                MessageBox.Show("������: ������������ ������");
            }

            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("�������� ������ ��� ��������.");
                return;
            }

            // �������� ������ ��������� ������
            int selectedIndex = comboBox1.SelectedIndex;

            // ������� ������ �� ������
            if (selectedIndex >= 0 && selectedIndex < figures.Count)
            {
                figures.RemoveAt(selectedIndex); // ������� ������
                comboBox1.Items.RemoveAt(selectedIndex); // ������� �� comboBox1
                comboBox2.Items.RemoveAt(selectedIndex); // ������� �� comboBox2
            }

            RedrawAllFigures(); // �������������� ������
        }

        private void RedrawAllFigures()
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White); // ��������� ������� bitmap
                foreach (Figure figure in figures)
                {
                    figure.Draw(g); // �������� ��������� ��� ������ ������
                }
            }
            pictureBox1.Invalidate(); // �������������� pictureBox
            MessageBox.Show("PictureBox �������!"); // ���������� �����
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = comboBox1.SelectedIndex != -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("�������� ������ ��� ���������.");
                return;
            }

            // ������� ������ ��������� ������
            int selectedIndex = comboBox3.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < figures.Count)
            {
                if (figures[selectedIndex] is Circle circle)
                {
                    // ��������� ������� ����������
                    if (int.TryParse(textBox11.Text, out int newRadius) && newRadius > 0)
                    {
                        circle.UpdateRadius(newRadius);
                        comboBox3.Items[selectedIndex] = $"���������� {selectedIndex} (R={newRadius})"; // ��������� ��������
                        RedrawAllFigures();
                    }
                    else
                    {
                        MessageBox.Show("������: ������������ ������.");
                    }
                }
                else if (figures[selectedIndex] is Square square)
                {
                    // ��������� ������� ��������
                    if (int.TryParse(textBox11.Text, out int newSide) && newSide > 0)
                    {
                        square.UpdateSide(newSide);
                        comboBox3.Items[selectedIndex] = $"������� {selectedIndex} (�������={newSide})"; // ��������� ��������
                        RedrawAllFigures();
                    }
                    else
                    {
                        MessageBox.Show("������: ������������ ������ �������.");
                    }
                }
                else
                {
                    MessageBox.Show("��������� ������ �� ������������ ��������� �������.");
                }
            }
            else
            {
                MessageBox.Show("������: ��������� ������ �� �������.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int dx) && int.TryParse(textBox6.Text, out int dy))
            {
                if (comboBox2.SelectedIndex != -1) // ���� ������� ���������� ������
                {
                    int selectedIndex = comboBox2.SelectedIndex;

                    if (selectedIndex >= 0 && selectedIndex < figures.Count)
                    {
                        Figure figureToMove = figures[selectedIndex];
                        figureToMove.Move(dx, dy);
                        RedrawAllFigures();
                    }
                    else
                    {
                        MessageBox.Show("������: ��������� ������ �� �������.");
                    }
                }
                else // ���� ������ �� �������, ������� ���
                {
                    foreach (var figure in figures)
                    {
                        figure.Move(dx, dy);
                    }
                    RedrawAllFigures();
                }
            }
            else
            {
                MessageBox.Show("������: ������� ���������� �������� ��� ��������.");
            }
        }
    }
}
