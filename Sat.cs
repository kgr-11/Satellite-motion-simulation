using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Satellite_Movements
{
    //класс хранит информацию по 1 спутнику
    public class Sat
    {
        public static int LastId = 0;
        //  данные о спутнике
        public int Id;  // id спутника
        public string name;  //  имя спутника
        // начальные параметры орбиты спутника
        public float a;  //  большая полуось
        public float e;  // эксцентриситет орбиты
        public float i;  // наклонение орбиты
        public float longitude;  //  угол восходящего узла
        public float arg_Pericenter;  //  аргумент перицентра
        public float true_anomaly;  //  истинная аномалия - начальное положение спутника на орбите

        public SatellitePossition currPos;//текущая позиция спутника
        public Sat(DataSatellite dataSatellite) 
        {
            this.Id = dataSatellite.Id;
            this.name = dataSatellite.name;
            this.a = dataSatellite.a;
            this.e = dataSatellite.e;
            this.i = dataSatellite.i;
            this.longitude = dataSatellite.longitude;
            this.arg_Pericenter = dataSatellite.arg_Pericenter;
            this.true_anomaly = dataSatellite.true_anomaly;
            //расчет начальной позиции спутника в декартовой системе координат
            currPos = KeplerToDescartes();
        }
        public Sat(Sat other)
        {
            this.Id = other.Id;
            this.name = other.name;
            this.a = other.a;
            this.e = other.e;
            this.i = other.i;
            this.longitude = other.longitude;
            this.arg_Pericenter = other.arg_Pericenter;
            this.true_anomaly = other.true_anomaly;
            this.currPos = other.currPos;
        }
        private SatellitePossition KeplerToDescartes()
        {
            //гравитационный параметр -  GM
            const float mu = (float)(6.67) * (float)(5.9722) * (float)1e13;

            //вычисляем расстояние до центра масc,
            //в знаменателе +- зависит в каком фокусе Земля, если в отрицательном, то минус
            float r = a * (1 - e * e) / (1 - e * (float)Math.Cos(Math.PI / 180 * true_anomaly));

            //координаты  и скорости в орбитальной плоскости
            float x_orb = r * (float)Math.Cos(Math.PI / 180 * true_anomaly);
            float y_orb = r * (float)Math.Sin(Math.PI / 180 * true_anomaly);
            float Vx_orb = -(float)(Math.Sqrt(mu/(a*(1-e*e)))*Math.Sin(Math.PI / 180 * true_anomaly));
            float Vy_orb = (float)(Math.Sqrt(mu / (a * (1 - e * e))) *(e+ Math.Cos(Math.PI / 180 * true_anomaly)));

            //Переход в инерциальную систему координат:
            //матрица перехода
            var A = Matrix<float>.Build.Dense(3, 3);
            A[0, 0] = (float)(Math.Cos(Math.PI / 180 * longitude) * Math.Cos(Math.PI / 180 * arg_Pericenter)
                - Math.Sin(Math.PI / 180 * longitude) * Math.Sin(Math.PI / 180 * arg_Pericenter) * Math.Cos(Math.PI / 180 * i));

            A[0, 1] = (float)(-Math.Cos(Math.PI / 180 * longitude) * Math.Sin(Math.PI / 180 * arg_Pericenter)
                - Math.Sin(Math.PI / 180 * longitude) * Math.Cos(Math.PI / 180 * arg_Pericenter) * Math.Cos(Math.PI / 180 * i));

            A[0, 2] = (float)(Math.Sin(Math.PI / 180*longitude)* Math.Sin(Math.PI / 180 * i));

            A[1, 0] = (float)(Math.Sin(Math.PI / 180 * arg_Pericenter) * Math.Cos(Math.PI / 180 * arg_Pericenter)
                + Math.Cos(Math.PI / 180 * longitude) * Math.Sin(Math.PI / 180 * arg_Pericenter) * Math.Cos(Math.PI / 180 * i));

            A[1, 1] = (float)(-Math.Sin(Math.PI / 180 * longitude) * Math.Sin(Math.PI / 180 * arg_Pericenter)
                + Math.Cos(Math.PI / 180 * longitude) * Math.Cos(Math.PI / 180 * arg_Pericenter) * Math.Cos(Math.PI / 180 * i));

            A[1, 2] = (float)(-Math.Cos(Math.PI / 180 * longitude) * Math.Sin(Math.PI / 180 * i));

            A[2, 0] = (float)(Math.Sin(Math.PI / 180 * arg_Pericenter) * Math.Sin(Math.PI / 180 * i));

            A[2, 1] = (float)(Math.Cos(Math.PI / 180 * arg_Pericenter) * Math.Sin(Math.PI / 180 * i));

            A[2, 2] = (float)(Math.Cos(Math.PI / 180 * i));

            //Сам переход
            var Coord_ord=Matrix<float>.Build.Dense(3, 1);
            Coord_ord[0, 0] = x_orb;
            Coord_ord[1, 0] = y_orb;
            Coord_ord[2, 0] = 0;

            var Coord = A * Coord_ord;

            var Speed_ord = Matrix<float>.Build.Dense(3, 1);
            Speed_ord[0, 0] = Vx_orb;
            Speed_ord[1, 0] = Vy_orb;
            Speed_ord[2, 0] = 0;

            var Speed = A * Speed_ord;

            return new SatellitePossition(Coord[0, 0], Coord[1, 0], Coord[2, 0], Speed[0, 0], Speed[1, 0], Speed[2, 0]);
        }
        public void Reset_Sat()
        {
            //расчет начальной позиции спутника в декартовой системе координат
            currPos = KeplerToDescartes();
            
        }
    }
}
