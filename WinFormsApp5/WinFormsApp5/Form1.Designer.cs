namespace WinFormsApp5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            label6 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 24);
            label1.Name = "label1";
            label1.Size = new Size(842, 20);
            label1.TabIndex = 0;
            label1.Text = "Даны три действительные числа. Если все числа положительны, найти среднее арифметическое, иначе произведение.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 91);
            label2.Name = "label2";
            label2.Size = new Size(253, 20);
            label2.TabIndex = 1;
            label2.Text = "Введите три действительных числа";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(91, 141);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(91, 200);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(91, 257);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 141);
            label3.Name = "label3";
            label3.Size = new Size(22, 20);
            label3.TabIndex = 5;
            label3.Text = "1)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 200);
            label4.Name = "label4";
            label4.Size = new Size(22, 20);
            label4.TabIndex = 6;
            label4.Text = "2)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(63, 257);
            label5.Name = "label5";
            label5.Size = new Size(22, 20);
            label5.TabIndex = 7;
            label5.Text = "3)";
            // 
            // button1
            // 
            button1.Location = new Point(106, 318);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "enter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(332, 214);
            label6.Name = "label6";
            label6.Size = new Size(56, 20);
            label6.TabIndex = 9;
            label6.Text = "output:";
            // 
            // button2
            // 
            button2.Location = new Point(820, 430);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 10;
            button2.Text = "next\r\n";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 471);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Label label6;
        private Button button2;
    }
}
