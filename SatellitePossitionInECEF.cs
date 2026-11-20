using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Satellite_Movements
{
    //позиция спутника в НеИСК
    public struct SatellitePossitionInECEF
    {
        public float X;
        public float Y;
        public float Z;
        public SatellitePossitionInECEF(float longitude,float arg_Pericenter, float i, SatellitePossitionInECI pos)
        {
            //здесь преобразование координат от ИСК к НеИСК
            // 1. составляем матрицу прецессии и нутации как произведение 3-х матриц

            //Поворот на долготу восходящего узла (учёт прецессии и нутации по долготе
            var R3_minus_longitude = Matrix<float>.Build.Dense(3, 3);

            R3_minus_longitude[0, 0] = (float)(Math.Cos(Math.PI / 180 * longitude));
            R3_minus_longitude[0, 1] = (float)(Math.Sin(Math.PI / 180 * longitude));
            R3_minus_longitude[0, 2] = 0;
            R3_minus_longitude[1, 0] = (float)(-Math.Sin(Math.PI / 180 * longitude));
            R3_minus_longitude[1, 1] = (float)(Math.Cos(Math.PI / 180 * longitude));
            R3_minus_longitude[1, 2] = 0;
            R3_minus_longitude[2, 0] = 0;
            R3_minus_longitude[2, 1] = 0;
            R3_minus_longitude[2, 2] = 1;

            //Поворот на наклонение(учёт нутации в наклонении)
            var R1_minus_i = Matrix<float>.Build.Dense(3, 3);

            R1_minus_i[0, 0] = 1;
            R1_minus_i[0, 1] = 0;
            R1_minus_i[0, 2] = 0;
            R1_minus_i[1, 0] = 0;
            R1_minus_i[1, 1] = (float)(Math.Cos(Math.PI / 180 * i));
            R1_minus_i[1, 2] = (float)(Math.Sin(Math.PI / 180 * i));
            R1_minus_i[2, 0] = 0;
            R1_minus_i[2, 1] = (float)(-Math.Sin(Math.PI / 180 * i));
            R1_minus_i[2, 2] = (float)(Math.Cos(Math.PI / 180 * i));

            //3.Поворот на аргумент перигея (учёт прецессии по экватору):
            var R3_minus_argPericenter = Matrix<float>.Build.Dense(3, 3);

            R3_minus_argPericenter[0, 0] = (float)(Math.Cos(Math.PI / 180 * arg_Pericenter));
            R3_minus_argPericenter[0, 1] = (float)(Math.Sin(Math.PI / 180 * arg_Pericenter));
            R3_minus_argPericenter[0, 2] = 0;
            R3_minus_argPericenter[1, 0] = (float)(-Math.Sin(Math.PI / 180 * arg_Pericenter));
            R3_minus_argPericenter[1, 1] = (float)(Math.Cos(Math.PI / 180 * arg_Pericenter));
            R3_minus_argPericenter[1, 2] = 0;
            R3_minus_argPericenter[2, 0] = 0;
            R3_minus_argPericenter[2, 1] = 0;
            R3_minus_argPericenter[2, 2] = 1;

            //Матрица перехода от неинерциальной системы к инерциальной 
            var Q = R3_minus_longitude * R1_minus_i * R3_minus_argPericenter;

            // 2. Для перехода от инерциальной системы к неинерциальной нужна обратная матрица перехода
            var Q_Inverse = Q.Inverse();

            // 3. Нахождение положения спутника в НеИСК

            //  вектор положения спутника в инерциальной системе
            var r_GCRS = Matrix<float>.Build.Dense(3, 3);
            r_GCRS[0, 0] = pos.X;
            r_GCRS[1, 0] = pos.Y;
            r_GCRS[2, 0] = pos.Z;
            //  вектор положения спутника в неинерциальной системе
            var r_ITRS = Q_Inverse * r_GCRS;

            //достаем значение координат в неинерциальной системе
            X = r_ITRS[0, 0];
            Y= r_ITRS[1, 0];
            Z= r_ITRS[2, 0];
        }
    }
}
