namespace Satellite_Movements
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            pictureBox_simulation = new PictureBox();
            groupBox2 = new GroupBox();
            button_reset_simulation = new Button();
            groupBox3 = new GroupBox();
            label2 = new Label();
            numericUpDown_stepTime = new NumericUpDown();
            label1 = new Label();
            button_pause_simulation = new Button();
            button_start_simulation = new Button();
            button_add_satellite_in_system = new Button();
            timer_simulation = new System.Windows.Forms.Timer(components);
            groupBox4 = new GroupBox();
            dataGridView_list_satellite = new DataGridView();
            button_delete_satellite = new Button();
            button_satellite_tracks = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_simulation).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_stepTime).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_list_satellite).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox_simulation);
            groupBox1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(326, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(913, 934);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Визуализация движения спутников в 2D";
            // 
            // pictureBox_simulation
            // 
            pictureBox_simulation.Location = new Point(6, 26);
            pictureBox_simulation.Name = "pictureBox_simulation";
            pictureBox_simulation.Size = new Size(900, 900);
            pictureBox_simulation.TabIndex = 0;
            pictureBox_simulation.TabStop = false;
            pictureBox_simulation.Paint += pictureBox_simulation_Paint;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button_satellite_tracks);
            groupBox2.Controls.Add(button_reset_simulation);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(button_pause_simulation);
            groupBox2.Controls.Add(button_start_simulation);
            groupBox2.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(308, 926);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Панель управления";
            // 
            // button_reset_simulation
            // 
            button_reset_simulation.Cursor = Cursors.Hand;
            button_reset_simulation.Font = new Font("Times New Roman", 13.8F);
            button_reset_simulation.Location = new Point(6, 328);
            button_reset_simulation.Name = "button_reset_simulation";
            button_reset_simulation.Size = new Size(296, 93);
            button_reset_simulation.TabIndex = 4;
            button_reset_simulation.Text = "Сброс";
            button_reset_simulation.UseVisualStyleBackColor = true;
            button_reset_simulation.Click += button_reset_simulation_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(numericUpDown_stepTime);
            groupBox3.Controls.Add(label1);
            groupBox3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox3.Location = new Point(6, 33);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(296, 91);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Параметры моделирования";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(262, 42);
            label2.Name = "label2";
            label2.Size = new Size(28, 26);
            label2.TabIndex = 2;
            label2.Text = "с.";
            // 
            // numericUpDown_stepTime
            // 
            numericUpDown_stepTime.Location = new Point(51, 40);
            numericUpDown_stepTime.Name = "numericUpDown_stepTime";
            numericUpDown_stepTime.Size = new Size(205, 34);
            numericUpDown_stepTime.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 42);
            label1.Name = "label1";
            label1.Size = new Size(30, 26);
            label1.TabIndex = 0;
            label1.Text = "t: ";
            // 
            // button_pause_simulation
            // 
            button_pause_simulation.Cursor = Cursors.Hand;
            button_pause_simulation.Font = new Font("Times New Roman", 13.8F);
            button_pause_simulation.Location = new Point(6, 229);
            button_pause_simulation.Name = "button_pause_simulation";
            button_pause_simulation.Size = new Size(296, 93);
            button_pause_simulation.TabIndex = 2;
            button_pause_simulation.Text = "Пауза";
            button_pause_simulation.UseVisualStyleBackColor = true;
            button_pause_simulation.Click += button_pause_simulation_Click;
            // 
            // button_start_simulation
            // 
            button_start_simulation.Cursor = Cursors.Hand;
            button_start_simulation.Font = new Font("Times New Roman", 13.8F);
            button_start_simulation.Location = new Point(6, 130);
            button_start_simulation.Name = "button_start_simulation";
            button_start_simulation.Size = new Size(296, 93);
            button_start_simulation.TabIndex = 1;
            button_start_simulation.Text = "Пуск";
            button_start_simulation.UseVisualStyleBackColor = true;
            button_start_simulation.Click += button_start_simulation_Click;
            // 
            // button_add_satellite_in_system
            // 
            button_add_satellite_in_system.Cursor = Cursors.Hand;
            button_add_satellite_in_system.Font = new Font("Times New Roman", 13.8F);
            button_add_satellite_in_system.Location = new Point(6, 834);
            button_add_satellite_in_system.Name = "button_add_satellite_in_system";
            button_add_satellite_in_system.Size = new Size(222, 93);
            button_add_satellite_in_system.TabIndex = 0;
            button_add_satellite_in_system.Text = "Добавить спутник";
            button_add_satellite_in_system.UseVisualStyleBackColor = true;
            button_add_satellite_in_system.Click += button_add_satellite_in_system_Click;
            // 
            // timer_simulation
            // 
            timer_simulation.Interval = 50;
            timer_simulation.Tick += timer_simulation_Tick;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dataGridView_list_satellite);
            groupBox4.Controls.Add(button_delete_satellite);
            groupBox4.Controls.Add(button_add_satellite_in_system);
            groupBox4.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox4.Location = new Point(1245, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(448, 934);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Список спутников";
            // 
            // dataGridView_list_satellite
            // 
            dataGridView_list_satellite.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_list_satellite.Location = new Point(6, 33);
            dataGridView_list_satellite.Name = "dataGridView_list_satellite";
            dataGridView_list_satellite.RowHeadersWidth = 51;
            dataGridView_list_satellite.Size = new Size(436, 794);
            dataGridView_list_satellite.TabIndex = 2;
            // 
            // button_delete_satellite
            // 
            button_delete_satellite.Cursor = Cursors.Hand;
            button_delete_satellite.Font = new Font("Times New Roman", 13.8F);
            button_delete_satellite.Location = new Point(234, 833);
            button_delete_satellite.Name = "button_delete_satellite";
            button_delete_satellite.Size = new Size(208, 93);
            button_delete_satellite.TabIndex = 1;
            button_delete_satellite.Text = "Удалить спутник";
            button_delete_satellite.UseVisualStyleBackColor = true;
            button_delete_satellite.Click += button_delete_satellite_Click;
            // 
            // button_satellite_tracks
            // 
            button_satellite_tracks.Cursor = Cursors.Hand;
            button_satellite_tracks.Font = new Font("Times New Roman", 13.8F);
            button_satellite_tracks.Location = new Point(6, 427);
            button_satellite_tracks.Name = "button_satellite_tracks";
            button_satellite_tracks.Size = new Size(296, 93);
            button_satellite_tracks.TabIndex = 5;
            button_satellite_tracks.Text = "Спутниковые трассы";
            button_satellite_tracks.UseVisualStyleBackColor = true;
            button_satellite_tracks.Click += button_satellite_tracks_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1705, 951);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Моделирование пространственно-временной доспупности спутниковых систем связи";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_simulation).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_stepTime).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_list_satellite).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private PictureBox pictureBox_simulation;
        private GroupBox groupBox2;
        private Button button_pause_simulation;
        private Button button_start_simulation;
        private Button button_add_satellite_in_system;
        private GroupBox groupBox3;
        private NumericUpDown numericUpDown_stepTime;
        private Label label1;
        private Button button_reset_simulation;
        private Label label2;
        private System.Windows.Forms.Timer timer_simulation;
        private GroupBox groupBox4;
        private Button button_delete_satellite;
        private DataGridView dataGridView_list_satellite;
        private Button button_satellite_tracks;
    }
}
