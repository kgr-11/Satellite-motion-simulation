using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satellite_Movements
{
    public struct DataSatellite
    {
        //  данные о спутнике
        public int Id;  // id спутника
        public string name;  //  имя спутника
        //  параметры орбиты спутника
        public float a;  //  большая полуось
        public float e;  // эксцентриситет орбиты
        public float i;  // наклонение орбиты
        public float longitude;  //  угол восходящего узла
        public float arg_Pericenter;  //  аргумент перицентра
        public float true_anomaly;  //  истинная аномалия - начальное положение спутника на орбите

        public DataSatellite(string name,float a,float e, float i, float longitude,float arg_Pericenter,float true_anomaly) 
        {
            this.name = name;
            this.a = a;
            this.e = e;
            this.i = i;
            this.longitude = longitude;
            this.arg_Pericenter = arg_Pericenter;
            this.true_anomaly = true_anomaly;
        }

    }
}
