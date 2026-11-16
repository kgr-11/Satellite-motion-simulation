using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Satellite_Movements
{
    static class DrawRepository
    {
        // Функция уcтановки Земли в центре контролла
        public static void SetEarth(Graphics g, Point CenterControll)
        {
            //преобразуем потока байт из ресурсов в картинку, делаем копию, устанавливаем в контролле
            using (MemoryStream ms = new MemoryStream(Properties.Resources.Earth))
            {
                Image img = new Bitmap(ms);
                g.DrawImage(img, CenterControll.X-200, CenterControll.Y - 200, 400, 400);
            }
        }

        //Функция установки фона системе
        public static void SetBackgroung(Graphics g)
        {
            //преобразуем потока байт из ресурсов в картинку, делаем копию, устанавливаем в контролле
            using (MemoryStream ms = new MemoryStream(Properties.Resources.backgroundForProjectSimulationMovementsSatellite))
            {
                Image img = new Bitmap(ms);
                g.DrawImage(img, 0, 0, img.Width, img.Height);
            }
        }
        //Функция установки спутника
        public static void SetSatellite(Graphics g,float angle)
        {
            //преобразуем потока байт из ресурсов в картинку, делаем копию, устанавливаем в контролле
            using (MemoryStream ms = new MemoryStream(Properties.Resources.satellite))
            {
                Image img = new Bitmap(ms);
                g.DrawImage(img, -25, -25, 50,50);
            }
        }
    }

}
