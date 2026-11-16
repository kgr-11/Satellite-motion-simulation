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

            //установка спутника
            DrawRepository.SetSatellite(graphics);

            int R = 300;
            //отрисовка орбиты
            using (Pen pen = new Pen(Color.Red, 4.0f))
            {
                graphics.DrawEllipse(pen, (float)pictureBox_simulation.Width / 2 - R, (float)pictureBox_simulation.Height / 2 - R, R * 2, R * 2);
            }
            //отрисовка спутника как кружка
            using (SolidBrush sb = new SolidBrush(Color.DarkBlue))
            {
                //переносим систему координат в центр и рисуем спутник относительно центра Земли
                graphics.TranslateTransform(pictureBox_simulation.Width / 2, pictureBox_simulation.Height / 2);
                //делаем базовую декартовую систему координат
                graphics.ScaleTransform(1.0f, -1.0f);

                //ширина спутника - шарика
                int widthSatellite = 20;

                graphics.FillEllipse(sb, R * (float)Math.Cos(Math.PI / 180 * angle) - widthSatellite, R * (float)Math.Sin(Math.PI / 180 * angle) - widthSatellite, widthSatellite * 2, widthSatellite * 2);

                //сбрасываем все настройки
                graphics.ResetTransform();
            }

        }

        private void timer_simulation_Tick(object sender, EventArgs e)
        {
            angle += 1;
            angle %= 360;
            pictureBox_simulation.Invalidate();
        }
    }
}
