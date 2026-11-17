using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satellite_Movements
{
    public struct DataSatellite
    {
        public int Id;
        public string name;
        public float a;
        public float e;
        public float i;
        public float longitude;
        public float arg_Pericenter;
        public float true_anomaly;
    }
}
