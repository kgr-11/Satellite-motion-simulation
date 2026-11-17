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
    }
}
