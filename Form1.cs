using System;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace Satellite_Movements
{
    public partial class Form1 : Form
    {
        bool IsPause;
        List<DataSatellite> satellites;
        List<int> angles;
        KeyValuePair<int, int> r_in_px_and_R_in_km;
        List<Color> colors;
        public Form1()
        {
            InitializeComponent();

            satellites = new List<DataSatellite>();
            r_in_px_and_R_in_km = new KeyValuePair<int, int>(50, 6371);
            colors = new List<Color>();
            angles = new List<int>();

            button_reset_simulation.Enabled = false;
            button_pause_simulation.Enabled = false;
            bool IsPause = true;

        }
        private void pictureBox_simulation_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //установка фона: звездное небо
            DrawRepository.SetBackgroung(graphics,pictureBox_simulation.Width,pictureBox_simulation.Height);

            //установка в центре «емли
            DrawRepository.SetEarth(graphics, new Point(pictureBox_simulation.Width / 2, pictureBox_simulation.Height / 2));
            Random random = new Random();
            //отрисовка всех спутников и их орбит
            for (int i = 0; i < satellites.Count; i++)
            {
                //инфа о спутнике
                var data = satellites[i];

                //реальные параметры
                //отрисовка орбиты i - спутника
                float c = data.e * data.a;//фокусное рассто€ние
                float b = (float)Math.Sqrt(data.a * data.a - c * c);//мала€ полуось
                //реальные размеры эллипса
                float width = 2 * data.a;
                float height = 2 * b;

                //мировые размеры
                float widthInWorld = width / r_in_px_and_R_in_km.Value * r_in_px_and_R_in_km.Key;
                float heightInWorld = height / r_in_px_and_R_in_km.Value * r_in_px_and_R_in_km.Key;

                float shift_x = (data.a - c) / r_in_px_and_R_in_km.Value * r_in_px_and_R_in_km.Key;
                float shift_y = b / r_in_px_and_R_in_km.Value * r_in_px_and_R_in_km.Key;

                //отрисовываем орбиту спутника - рандомным цветом
                using (Pen pen = new Pen(colors[i], 4.0f))
                {
                    graphics.DrawEllipse(pen, (float)pictureBox_simulation.Width / 2 - shift_x, (float)pictureBox_simulation.Height / 2 - shift_y, widthInWorld, heightInWorld);
                }
                //отрисовка спутника в виде движущегос€ шарика

                //переносим систему координат в центр «емли
                graphics.TranslateTransform(pictureBox_simulation.Width / 2, pictureBox_simulation.Height / 2);
                //делаем базовую декартовую систему координат
                graphics.ScaleTransform(1.0f, -1.0f);

                //расчет положени€ спутника в реальных координатах
                int alpha = angles[i];
                float p = b * b / data.a;
                float r = p / (1 - data.e * (float)Math.Cos(Math.PI / 180 * alpha));
                float x = r * (float)Math.Cos(Math.PI / 180 * alpha);
                float y = r * (float)Math.Sin(Math.PI / 180 * alpha);

                //перевод координат спутника в мировые 
                float x_world = x / r_in_px_and_R_in_km.Value * r_in_px_and_R_in_km.Key;
                float y_world = y / r_in_px_and_R_in_km.Value * r_in_px_and_R_in_km.Key;


                //перенос системы координат в точку спутника
                graphics.TranslateTransform(x_world, y_world);

                //поворот системы координат спутника дл€ ориентации его всегда на «емлю
                graphics.RotateTransform(-45 + alpha);//на вход идут градусы
                //установка спутника
                DrawRepository.SetSatellite(graphics);
                //сбрасываем все настройки
                graphics.ResetTransform();
            }

            /*int R = 300;
            //отрисовка орбиты
            using (Pen pen = new Pen(Color.Red, 4.0f))
            {
                graphics.DrawEllipse(pen, (float)pictureBox_simulation.Width / 2 - R, (float)pictureBox_simulation.Height / 2 - R, R * 2, R * 2);
            }
            //отрисовка спутника как движущейс€ картинки
            //переносим систему координат в центр и рисуем спутник относительно центра «емли
            graphics.TranslateTransform(pictureBox_simulation.Width / 2, pictureBox_simulation.Height / 2);
            //делаем базовую декартовую систему координат
            graphics.ScaleTransform(1.0f, -1.0f);

            float x = R * (float)Math.Cos(Math.PI / 180 * angle);
            float y = R * (float)Math.Sin(Math.PI / 180 * angle);

            //перенос системы координат в точку спутника
            graphics.TranslateTransform(x, y);

            //поворот системы координат спутника дл€ ориентации его всегда на «емлю
            graphics.RotateTransform(-45 + angle);//на вход идут градусы

            //установка спутника
            DrawRepository.SetSatellite(graphics, angle);*/


            //сбрасываем все настройки
            graphics.ResetTransform();

        }

        private void timer_simulation_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < angles.Count; i++)
            {
                angles[i] += 1;
                angles[i] %= 360;
            }
            pictureBox_simulation.Invalidate();
        }

        private void button_add_satellite_in_system_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            using (Add_Satellite form = new Add_Satellite())
            {
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    satellites.Add(form.satellite);
                    angles.Add((int)form.satellite.true_anomaly);
                    colors.Add(Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
                    pictureBox_simulation.Invalidate();
                }
            }
        }

        private void button_start_simulation_Click(object sender, EventArgs e)
        {
            button_start_simulation.Enabled = false;
            button_pause_simulation.Enabled = true;
            button_reset_simulation.Enabled = true;

            IsPause = false;
            timer_simulation.Start();
        }


        private void button_pause_simulation_Click(object sender, EventArgs e)
        {
            if (!IsPause)
            {
                timer_simulation.Stop();
                IsPause = true;
            }
            else
            {
                timer_simulation.Start();
                IsPause = false;
            }
        }

        private void button_reset_simulation_Click(object sender, EventArgs e)
        {
            timer_simulation.Stop();
            button_start_simulation.Enabled = true;
            button_pause_simulation.Enabled = false;
            button_reset_simulation.Enabled = false;
            //сброс углов каждого спутника
            for (int i = 0; i < angles.Count; i++)
            {
                angles[i] = (int)satellites[i].true_anomaly;
            }
            pictureBox_simulation.Invalidate();
        }

        private void button_delete_satellite_Click(object sender, EventArgs e)
        {

        }

        private void button_satellite_tracks_Click(object sender, EventArgs e)
        {
            using (Satellite_Tracks form = new Satellite_Tracks())
            { 
                DialogResult result=form.ShowDialog();
            }
        }
    }
}
