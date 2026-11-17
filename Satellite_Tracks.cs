using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satellite_Movements
{
    public partial class Satellite_Tracks : Form
    {
        public Satellite_Tracks()
        {
            InitializeComponent();
        }

        private void pictureBox_map_tracks_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //установка мировой карты на фон
            DrawRepositoryForFormSatelliteTracks.SetWorldMap(graphics, pictureBox_map_tracks.Width, pictureBox_map_tracks.Height);

            //отрисовка сетки поверх фона
            DrawRepositoryForFormSatelliteTracks.DrawGridForMap(graphics, pictureBox_map_tracks.Width, pictureBox_map_tracks.Height);
        }
    }
}
