using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satellite_Movements
{
    //позиция спутника в ИСК
    public struct SatellitePossitionInECI
    {
        public float X;
        public float Y;
        public float Z;
        public float Vx;
        public float Vy;
        public float Vz;
        public SatellitePossitionInECI(float X, float Y, float Z, float Vx, float Vy, float Vz)
        { 
            this.X = X;
            this.Y = Y;
            this.Z = Z; 
            this.Vx = Vx;
            this.Vy = Vy;
            this.Vz = Vz;
        }
    }
}
