using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satellite_Movements
{
    //класс для установки параметров по умолчанию
    public static class PullDefaultParameters
    {
        public static List<DataSatellite> pull;
        static PullDefaultParameters()
        { 
            pull = new List<DataSatellite>();
            //задаем параметры по умолчанию
            pull.Add(new DataSatellite("Sat1",10000,0,0,0,0,0));
            pull.Add(new DataSatellite("Sat2", 25000, (float)0.8,30, 0, 0, 0));
            pull.Add(new DataSatellite("Sat3", 20000, (float)0.8, 45, -165, 0, -90));
            pull.Add(new DataSatellite("Sat4", 2000, (float)0.8, 0, 0, 0, -60));
            pull.Add(new DataSatellite("Sat5", 30000, (float)0.6, -30, 30, 0, 0));
            pull.Add(new DataSatellite("Sat6", 30000, (float)0.6, 60, -30, 0, 0));
        }
    }
}
