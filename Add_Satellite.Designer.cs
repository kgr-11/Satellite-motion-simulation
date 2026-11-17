namespace Satellite_Movements
{
    partial class Add_Satellite
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
            groupBox1 = new GroupBox();
            textBox_name_satellite = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label11 = new Label();
            textBox_true_anomaly = new TextBox();
            label12 = new Label();
            label9 = new Label();
            textBox_argPericenter = new TextBox();
            label10 = new Label();
            label4 = new Label();
            textBox_longitude = new TextBox();
            label8 = new Label();
            label6 = new Label();
            textBox_i = new TextBox();
            label7 = new Label();
            textBox_e = new TextBox();
            label5 = new Label();
            label3 = new Label();
            textBox_a = new TextBox();
            label2 = new Label();
            button_reset = new Button();
            button_add = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox_name_satellite);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(406, 432);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Данные о спутнике";
            // 
            // textBox_name_satellite
            // 
            textBox_name_satellite.Location = new Point(213, 40);
            textBox_name_satellite.Name = "textBox_name_satellite";
            textBox_name_satellite.Size = new Size(165, 34);
            textBox_name_satellite.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 43);
            label1.Name = "label1";
            label1.Size = new Size(201, 26);
            label1.TabIndex = 1;
            label1.Text = "Название спутника:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(textBox_true_anomaly);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(textBox_argPericenter);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox_longitude);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBox_i);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBox_e);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox_a);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(6, 80);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(392, 346);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Параметры орбиты";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(291, 301);
            label11.Name = "label11";
            label11.Size = new Size(21, 26);
            label11.TabIndex = 20;
            label11.Text = "°";
            // 
            // textBox_true_anomaly
            // 
            textBox_true_anomaly.Location = new Point(120, 298);
            textBox_true_anomaly.Name = "textBox_true_anomaly";
            textBox_true_anomaly.Size = new Size(165, 34);
            textBox_true_anomaly.TabIndex = 19;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(67, 301);
            label12.Name = "label12";
            label12.Size = new Size(47, 26);
            label12.TabIndex = 18;
            label12.Text = "ν = ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(291, 250);
            label9.Name = "label9";
            label9.Size = new Size(21, 26);
            label9.TabIndex = 17;
            label9.Text = "°";
            // 
            // textBox_argPericenter
            // 
            textBox_argPericenter.Location = new Point(120, 247);
            textBox_argPericenter.Name = "textBox_argPericenter";
            textBox_argPericenter.Size = new Size(165, 34);
            textBox_argPericenter.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(67, 250);
            label10.Name = "label10";
            label10.Size = new Size(52, 26);
            label10.TabIndex = 15;
            label10.Text = "ω = ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(291, 199);
            label4.Name = "label4";
            label4.Size = new Size(21, 26);
            label4.TabIndex = 14;
            label4.Text = "°";
            // 
            // textBox_longitude
            // 
            textBox_longitude.Location = new Point(120, 196);
            textBox_longitude.Name = "textBox_longitude";
            textBox_longitude.Size = new Size(165, 34);
            textBox_longitude.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(60, 199);
            label8.Name = "label8";
            label8.Size = new Size(54, 26);
            label8.TabIndex = 12;
            label8.Text = "Ω = ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(291, 150);
            label6.Name = "label6";
            label6.Size = new Size(21, 26);
            label6.TabIndex = 11;
            label6.Text = "°";
            // 
            // textBox_i
            // 
            textBox_i.Location = new Point(120, 147);
            textBox_i.Name = "textBox_i";
            textBox_i.Size = new Size(165, 34);
            textBox_i.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(71, 150);
            label7.Name = "label7";
            label7.Size = new Size(43, 26);
            label7.TabIndex = 9;
            label7.Text = "i = ";
            // 
            // textBox_e
            // 
            textBox_e.Location = new Point(120, 98);
            textBox_e.Name = "textBox_e";
            textBox_e.Size = new Size(165, 34);
            textBox_e.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 101);
            label5.Name = "label5";
            label5.Size = new Size(47, 26);
            label5.TabIndex = 6;
            label5.Text = "e = ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(291, 51);
            label3.Name = "label3";
            label3.Size = new Size(38, 26);
            label3.TabIndex = 5;
            label3.Text = "км";
            // 
            // textBox_a
            // 
            textBox_a.Location = new Point(120, 48);
            textBox_a.Name = "textBox_a";
            textBox_a.Size = new Size(165, 34);
            textBox_a.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 51);
            label2.Name = "label2";
            label2.Size = new Size(47, 26);
            label2.TabIndex = 3;
            label2.Text = "a = ";
            // 
            // button_reset
            // 
            button_reset.Cursor = Cursors.Hand;
            button_reset.Font = new Font("Times New Roman", 13.8F);
            button_reset.Location = new Point(12, 450);
            button_reset.Name = "button_reset";
            button_reset.Size = new Size(200, 100);
            button_reset.TabIndex = 1;
            button_reset.Text = "Отмена";
            button_reset.UseVisualStyleBackColor = true;
            button_reset.Click += button_reset_Click;
            // 
            // button_add
            // 
            button_add.Cursor = Cursors.Hand;
            button_add.Font = new Font("Times New Roman", 13.8F);
            button_add.Location = new Point(218, 450);
            button_add.Name = "button_add";
            button_add.Size = new Size(200, 100);
            button_add.TabIndex = 2;
            button_add.Text = "Добавить";
            button_add.UseVisualStyleBackColor = true;
            button_add.Click += button_add_Click;
            // 
            // Add_Satellite
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 560);
            Controls.Add(button_add);
            Controls.Add(button_reset);
            Controls.Add(groupBox1);
            Name = "Add_Satellite";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление спутника";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox_name_satellite;
        private Label label1;
        private GroupBox groupBox2;
        private Button button_reset;
        private Button button_add;
        private Label label3;
        private TextBox textBox_a;
        private Label label2;
        private Label label6;
        private TextBox textBox_i;
        private Label label7;
        private TextBox textBox_e;
        private Label label5;
        private Label label11;
        private TextBox textBox_true_anomaly;
        private Label label12;
        private Label label9;
        private TextBox textBox_argPericenter;
        private Label label10;
        private Label label4;
        private TextBox textBox_longitude;
        private Label label8;
    }
}