namespace Satellite_Movements
{
    partial class Satellite_Tracks
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
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            button_OffSatellite = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            button_OnSatellite = new Button();
            groupBox3 = new GroupBox();
            pictureBox_map_tracks = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_map_tracks).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Font = new Font("Times New Roman", 13.8F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(381, 760);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Активные спутники";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(369, 721);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button_OffSatellite);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(button_OnSatellite);
            groupBox2.Font = new Font("Times New Roman", 13.8F);
            groupBox2.Location = new Point(12, 778);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(381, 154);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Управление спутником";
            // 
            // button_OffSatellite
            // 
            button_OffSatellite.Cursor = Cursors.Hand;
            button_OffSatellite.Location = new Point(195, 73);
            button_OffSatellite.Name = "button_OffSatellite";
            button_OffSatellite.Size = new Size(180, 70);
            button_OffSatellite.TabIndex = 3;
            button_OffSatellite.Text = "Отключить";
            button_OffSatellite.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(113, 33);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(262, 34);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(101, 26);
            label1.TabIndex = 0;
            label1.Text = "Cпутник:";
            // 
            // button_OnSatellite
            // 
            button_OnSatellite.Cursor = Cursors.Hand;
            button_OnSatellite.Location = new Point(6, 73);
            button_OnSatellite.Name = "button_OnSatellite";
            button_OnSatellite.Size = new Size(180, 70);
            button_OnSatellite.TabIndex = 2;
            button_OnSatellite.Text = "Включить";
            button_OnSatellite.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pictureBox_map_tracks);
            groupBox3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox3.Location = new Point(399, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1467, 920);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Карта трасс";
            // 
            // pictureBox_map_tracks
            // 
            pictureBox_map_tracks.Location = new Point(6, 33);
            pictureBox_map_tracks.Name = "pictureBox_map_tracks";
            pictureBox_map_tracks.Size = new Size(1455, 881);
            pictureBox_map_tracks.TabIndex = 0;
            pictureBox_map_tracks.TabStop = false;
            pictureBox_map_tracks.Paint += pictureBox_map_tracks_Paint;
            // 
            // Satellite_Tracks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1878, 944);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Satellite_Tracks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Спутниковые трассы";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_map_tracks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private Button button_OffSatellite;
        private Button button_OnSatellite;
        private ComboBox comboBox1;
        private Label label1;
        private GroupBox groupBox3;
        private PictureBox pictureBox_map_tracks;
    }
}