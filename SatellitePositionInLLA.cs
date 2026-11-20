using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoordinateSharp;

namespace Satellite_Movements
{
    //позиция спутника в геодезических координатах
    public struct SatellitePositionInLLA
    {
        public float Latitude;  // широта
        public float Longitude;  // долгота
        public SatellitePositionInLLA(SatellitePossitionInECEF posInECEF)
        {
            //Значения должны быть километрах
            ECEF ecef = new ECEF(posInECEF.X / 1000, posInECEF.Y / 1000, posInECEF.Z / 1000);

            Coordinate c=ECEF.ECEFToLatLong(ecef,new EagerLoad(false));

            // получает широту и долготу
            Latitude = Convert.ToSingle(c.Latitude.DecimalDegree);
            Longitude = Convert.ToSingle(c.Longitude.DecimalDegree);
        }
    }
}
