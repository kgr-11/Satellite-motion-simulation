namespace Satellite_Movements
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            angle = 0;
            timer_simulation.Start();
        }
        float angle;
        private void pictureBox_simulation_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //установка фона: звездное небо
            DrawRepository.SetBackgroung(graphics);

            //установка в центре Земли
            DrawRepository.SetEarth(graphics, new Point(pictureBox_simulation.Width / 2, pictureBox_simulation.Height / 2));

            int R = 300;
            //отрисовка орбиты
            using (Pen pen = new Pen(Color.Red, 4.0f))
            {
                graphics.DrawEllipse(pen, (float)pictureBox_simulation.Width / 2 - R, (float)pictureBox_simulation.Height / 2 - R, R * 2, R * 2);
            }
            //отрисовка спутника как движущейся картинки
            //переносим систему координат в центр и рисуем спутник относительно центра Земли
            graphics.TranslateTransform(pictureBox_simulation.Width / 2, pictureBox_simulation.Height / 2);
            //делаем базовую декартовую систему координат
            graphics.ScaleTransform(1.0f, -1.0f);

            float x = R * (float)Math.Cos(Math.PI / 180 * angle);
            float y = R * (float)Math.Sin(Math.PI / 180 * angle);

            //перенос системы координат в точку спутника
            graphics.TranslateTransform(x, y);

            //поворот системы координат спутника для ориентации его всегда на Землю
            graphics.RotateTransform(-45 + angle);//на вход идут градусы

            //установка спутника
            DrawRepository.SetSatellite(graphics,angle);


            //Отрисовка сектора, который покрывает спутник
            using (SolidBrush brush=new SolidBrush(Color.FromArgb(100,68,193,190)))
            using (Pen pen = new Pen(Color.FromArgb(100, Color.Lime), 3.0f))
            {
                int alpha = 15 - 45;//палки идут по наклоном в 15 градусов, плюс надо учитывать, что система изначально уже повернута
                int len = R - 165;

                PointF[] PointTreangle = { new PointF(0,0),
                    new PointF(-(len * (float)Math.Cos(Math.PI / 180 * alpha)), len * (float)Math.Sin(Math.PI / 180 * alpha)),
                    new PointF((len * (float)Math.Cos(Math.PI / 180 * (alpha - 90))), len * (float)Math.Sin(Math.PI / 180 * (alpha - 90))) };

                graphics.FillPolygon(brush, PointTreangle);
                graphics.DrawPolygon(pen, PointTreangle);
            }

            //сбрасываем все настройки
            graphics.ResetTransform();

        }

        private void timer_simulation_Tick(object sender, EventArgs e)
        {
            angle += 1;
            angle %= 360;
            pictureBox_simulation.Invalidate();
        }
    }
}
