namespace WinFormsApp5
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            labelBinary = new Label();
            buttonConvert = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 35);
            label1.Name = "label1";
            label1.Size = new Size(807, 20);
            label1.TabIndex = 0;
            label1.Text = "Сформировать матрицу из чисел от 0 до 999, вывести ее на экран. Посчитать количество двузначных чисел в ней.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(502, 170);
            label2.Name = "label2";
            label2.Size = new Size(230, 20);
            label2.TabIndex = 2;
            label2.Text = "Количество двухзначных чисел:";
            // 
            // labelBinary
            // 
            labelBinary.AutoSize = true;
            labelBinary.Location = new Point(34, 170);
            labelBinary.Name = "labelBinary";
            labelBinary.Size = new Size(56, 20);
            labelBinary.TabIndex = 3;
            labelBinary.Text = "output:";
            // 
            // buttonConvert
            // 
            buttonConvert.Location = new Point(344, 90);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(94, 29);
            buttonConvert.TabIndex = 4;
            buttonConvert.Text = "enter";
            buttonConvert.UseVisualStyleBackColor = true;
            buttonConvert.Click += buttonConvert_Click;
            // 
            // button1
            // 
            button1.Location = new Point(738, 431);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 431);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 472);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonConvert);
            Controls.Add(labelBinary);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label labelBinary;
        private Button buttonConvert;
        private Button button1;
        private Button button2;
    }
}