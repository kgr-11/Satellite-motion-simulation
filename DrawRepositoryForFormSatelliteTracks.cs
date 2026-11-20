using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satellite_Movements
{
    static class DrawRepositoryForFormSatelliteTracks
    {
        //отрисовка сетки
        public static void DrawGridForMap(Graphics g, int width, int height)
        {
            using (Font font=new Font("Times New Roman", 16, FontStyle.Bold))
            using (SolidBrush brushForX=new SolidBrush(Color.Black))
            using (SolidBrush brushForY = new SolidBrush(Color.White))
            using (Pen pen = new Pen(Color.FromArgb(150, Color.Silver), 1.5f))
            {
                //настраиваем тип линии на пунктирную
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                //цикл по x
                float step_x = (float)width / 12;
                int a = -180;
                for (int i = 0; i < 13; i++)
                {
                    float x = i * step_x;
                    g.DrawLine(pen, x, 0, x, height-10);
                    //добавляем подписи сетке
                    if (i > 0 && i < 12)
                    {
                        string text = a.ToString();
                        g.DrawString(text, font, brushForX, x,height-35);
                    }
                    a += 30;
                }

                //цикл по y
                float step_y = (float)height / 6;
                a = 90;
                for (int i = 0; i < 7; i++)
                {
                    float y = i * step_y;
                    g.DrawLine(pen, 0, y, width, y);
                    //добавляем подписи сетке
                    if (i > 0 && i < 6)
                    {
                        string text = a.ToString();
                        g.DrawString(text, font, brushForY, 2, y-30);
                    }
                    a -= 30;
                }
            }

        }

        public static void SetWorldMap(Graphics g, int width, int height)
        {
            //преобразуем потока байт из ресурсов в картинку, делаем копию, устанавливаем в контролле
            using (MemoryStream ms = new MemoryStream(Properties.Resources.WorldMap))
            {
                Image img = new Bitmap(ms);
                g.DrawImage(img, 0, 0, width, height);
            }
        }
        public static PointF RealCoordToWorld(float Longitude, float Latitude, int width, int height)
        {
            float x_Longitude = (float)width / 360 * Longitude;
            float y_Latitude = (float)height /180 * Latitude;
            return new PointF(x_Longitude, y_Latitude);

        }
    }
}
