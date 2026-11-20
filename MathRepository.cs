using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satellite_Movements
{
    static class MathRepository
    {
        const float G = (float)(6.67 *1e-11);
        const float M = (float)(5.9722 * 1e24);
        public static SatellitePossitionInECI NextPosition(SatellitePossitionInECI currentPosition, float step_t)
        {
            //эта функция вызывает рк-4
            return RK4(currentPosition, step_t);
        }

        static SatellitePossitionInECI RK4(SatellitePossitionInECI currentPosition, float step_t)
        {
            //расчет кф-тов k

            // 1. считаем k1_i
            float k1_x = a_x(currentPosition.X, currentPosition.Y, currentPosition.Z)* step_t;
            float k1_y = a_y(currentPosition.X, currentPosition.Y, currentPosition.Z) * step_t;
            float k1_z = a_z(currentPosition.X, currentPosition.Y, currentPosition.Z) * step_t;
            // 2. считаем k2_i
            float k2_x = a_x(
                currentPosition.X+currentPosition.Vx*step_t/2,
                currentPosition.Y + currentPosition.Vy * step_t / 2,
                currentPosition.Z + currentPosition.Vz * step_t / 2)* step_t;
            float k2_y = a_y(
                currentPosition.X + currentPosition.Vx * step_t / 2,
                currentPosition.Y + currentPosition.Vy * step_t / 2,
                currentPosition.Z + currentPosition.Vz * step_t / 2) * step_t;
            float k2_z = a_z(
                currentPosition.X + currentPosition.Vx * step_t / 2,
                currentPosition.Y + currentPosition.Vy * step_t / 2,
                currentPosition.Z + currentPosition.Vz * step_t / 2) * step_t;
            // 3. считаем k3_i
            float k3_x= a_x(
                currentPosition.X + currentPosition.Vx * step_t / 2+k1_x*step_t/4,
                currentPosition.Y + currentPosition.Vy * step_t / 2 + k1_y * step_t / 4,
                currentPosition.Z + currentPosition.Vz * step_t / 2 + k1_z * step_t / 4) * step_t;
            float k3_y = a_y(
                currentPosition.X + currentPosition.Vx * step_t / 2 + k1_x * step_t / 4,
                currentPosition.Y + currentPosition.Vy * step_t / 2 + k1_y * step_t / 4,
                currentPosition.Z + currentPosition.Vz * step_t / 2 + k1_z * step_t / 4) * step_t;
            float k3_z = a_z(
                currentPosition.X + currentPosition.Vx * step_t / 2 + k1_x * step_t / 4,
                currentPosition.Y + currentPosition.Vy * step_t / 2 + k1_y * step_t / 4,
                currentPosition.Z + currentPosition.Vz * step_t / 2 + k1_z * step_t / 4) * step_t;
            // 4. считаем k4_i
            float k4_x= a_x(
                currentPosition.X + currentPosition.Vx * step_t + k2_x * step_t / 2,
                currentPosition.Y + currentPosition.Vy * step_t + k2_y * step_t / 2,
                currentPosition.Z + currentPosition.Vz * step_t + k2_z * step_t / 2) * step_t;
            float k4_y = a_y(
                currentPosition.X + currentPosition.Vx * step_t + k2_x * step_t / 2,
                currentPosition.Y + currentPosition.Vy * step_t + k2_y * step_t / 2,
                currentPosition.Z + currentPosition.Vz * step_t + k2_z * step_t / 2) * step_t;
            float k4_z = a_z(
                currentPosition.X + currentPosition.Vx * step_t + k2_x * step_t / 2,
                currentPosition.Y + currentPosition.Vy * step_t + k2_y * step_t / 2,
                currentPosition.Z + currentPosition.Vz * step_t + k2_z * step_t / 2) * step_t;

            // Расчет координат в следующий момент времени
            float new_X = currentPosition.X + currentPosition.Vx * step_t + (k1_x + k2_x + k3_x) / 6 * step_t;
            float new_Vx = currentPosition.Vx + (k1_x + 2 * k2_x + 2 * k3_x + k4_x) / 6;

            float new_Y = currentPosition.Y + currentPosition.Vy * step_t + (k1_y + k2_y + k3_y) / 6 * step_t;
            float new_Vy = currentPosition.Vy + (k1_y + 2 * k2_y + 2 * k3_y+ k4_y) / 6;

            float new_Z = currentPosition.Z + currentPosition.Vz * step_t + (k1_z + k2_z + k3_z) / 6 * step_t;
            float new_Vz = currentPosition.Vz + (k1_z + 2 * k2_z + 2 * k3_z + k4_z) / 6;

            return new SatellitePossitionInECI(new_X, new_Y, new_Z, new_Vx, new_Vy, new_Vz);
        }
        //функция ускорения по X
        static float a_x(float X,float Y,float Z) 
        {
            return -G * M * X / (float)Math.Pow(X * X + Y * Y + Z * Z, 1.5);
        }
        //функция ускорения по Y
        static float a_y(float X, float Y, float Z)
        {
            return -G * M * Y / (float)Math.Pow(X * X + Y * Y + Z * Z, 1.5);
        }
        //функция ускорения по Z
        static float a_z(float X, float Y, float Z)
        {
            return -G * M * Z / (float)Math.Pow(X * X + Y * Y + Z * Z, 1.5);
        }
    }
}
