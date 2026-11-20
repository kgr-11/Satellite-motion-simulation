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
            dataGridView_list_active_satellites = new DataGridView();
            groupBox3 = new GroupBox();
            pictureBox_map_tracks = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_list_active_satellites).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_map_tracks).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView_list_active_satellites);
            groupBox1.Font = new Font("Times New Roman", 13.8F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(381, 914);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Список спутников";
            // 
            // dataGridView_list_active_satellites
            // 
            dataGridView_list_active_satellites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_list_active_satellites.Location = new Point(6, 33);
            dataGridView_list_active_satellites.Name = "dataGridView_list_active_satellites";
            dataGridView_list_active_satellites.RowHeadersWidth = 51;
            dataGridView_list_active_satellites.Size = new Size(369, 875);
            dataGridView_list_active_satellites.TabIndex = 0;
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
            Controls.Add(groupBox1);
            Name = "Satellite_Tracks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Спутниковые трассы";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_list_active_satellites).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_map_tracks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView_list_active_satellites;
        private GroupBox groupBox3;
        private PictureBox pictureBox_map_tracks;
    }
}