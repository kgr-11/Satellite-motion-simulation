namespace Satellite_Movements
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox_simulation_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);

            //установка фона: звездное небо
            DrawRepository.SetBackgroung(graphics);

            //установка в центре Земли
            DrawRepository.DrawEarth(graphics,new Point(pictureBox_simulation.Width/2, pictureBox_simulation.Height / 2));
        }
    }
}
