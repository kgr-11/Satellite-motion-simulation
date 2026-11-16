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
        // Функция утсановки Земли в центре контролла
        public static void DrawEarth(Graphics g, Point CenterControll)
        {
            using (MemoryStream ms = new MemoryStream(Properties.Resources.Earth))
            {
                Image img = new Bitmap(ms);
                g.DrawImage(img, CenterControll.X-200, CenterControll.Y - 200, 400, 400);
            }
        }

        //Функция установки фона системе
        public static void SetBackgroung(Graphics g)
        {
            using (MemoryStream ms = new MemoryStream(Properties.Resources.backgroundForProjectSimulationMovementsSatellite))
            {
                Image img = new Bitmap(ms);
                g.DrawImage(img, 0, 0, img.Width, img.Height);
            }
        }
    }

}
