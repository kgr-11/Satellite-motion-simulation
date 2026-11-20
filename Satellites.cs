using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satellite_Movements
{
    public class Satellites
    {
        public List<Sat> satellites;
        /*public int Count 
        {
            get { return satellites.Count; }
        }
        //св-во возвращающее копии спутников
        public List<Sat> ListSatellites
        {
            get
            {
                List<Sat>copy=new List<Sat>();
                foreach (var s in satellites) {
                    copy.Add(new Sat(s));
                }
                return copy;
            }
        }*/
        public Satellites() 
        {
            satellites = new List<Sat>();
        }

        //добавление спутника в список
        public void Add_Satellite(DataSatellite dataSatellite)
        {
            //создаем объект - спутник
            Sat sat = new Sat(dataSatellite);
            //добавляем объект в список
            satellites.Add(sat);
        }
        //удаление спутника по Id
        public void Remove_Satellite(int Id)
        {
            //ищем индекс спутника с нужным id
            int index = satellites.FindIndex(delegate (Sat s) { return s.Id == Id; });
            if (index!=-1)
            {
                //удаляем спутник из коллекции
                satellites.RemoveAt(index);
            }
        }
        //вычисление положения всех спутников в следующий момент времени
        public void CalcPositionInNextTime(float step_t)
        {
            //Считаем положение всех спутник из списка в следующий момент времени
            for (int i = 0; i < satellites.Count; i++)
            {
                SatellitePossition pos=MathRepository.NextPosition(satellites[i].currPos,step_t);
                //пересчет положения каждого спутника
                satellites[i].currPos = pos;
            }
        }
        public void Reset_Satellite()
        {
            for (int i = 0; i < satellites.Count; i++)
            {
                //сбрасываем текущее положение спутник в начальное
                satellites[i].Reset_Sat();
            }
        }
    }
}
