namespace WinFormsApp9
{
    partial class PolygonInputForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Button buttonAddPoint;
        private System.Windows.Forms.ListBox listBoxPoints;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.buttonAddPoint = new System.Windows.Forms.Button();
            this.listBoxPoints = new System.Windows.Forms.ListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // textBoxX
            this.textBoxX.Location = new System.Drawing.Point(20, 20);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxX.TabIndex = 0;

            // textBoxY
            this.textBoxY.Location = new System.Drawing.Point(140, 20);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 20);
            this.textBoxY.TabIndex = 1;

            // buttonAddPoint
            this.buttonAddPoint.Location = new System.Drawing.Point(260, 20);
            this.buttonAddPoint.Name = "buttonAddPoint";
            this.buttonAddPoint.Size = new System.Drawing.Size(100, 23);
            this.buttonAddPoint.TabIndex = 2;
            this.buttonAddPoint.Text = "Добавить точку";
            this.buttonAddPoint.Click += new System.EventHandler(this.buttonAddPoint_Click);

            // listBoxPoints
            this.listBoxPoints.FormattingEnabled = true;
            this.listBoxPoints.Location = new System.Drawing.Point(20, 60);
            this.listBoxPoints.Name = "listBoxPoints";
            this.listBoxPoints.Size = new System.Drawing.Size(340, 160);
            this.listBoxPoints.TabIndex = 3;

            // buttonOK
            this.buttonOK.Location = new System.Drawing.Point(20, 240);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);

            // buttonCancel
            this.buttonCancel.Location = new System.Drawing.Point(140, 240);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

            // PolygonInputForm
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listBoxPoints);
            this.Controls.Add(this.buttonAddPoint);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Name = "PolygonInputForm";
            this.Text = "Ввод точек многоугольника";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}