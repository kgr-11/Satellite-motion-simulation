using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satellite_Movements
{
    public partial class Satellite_Tracks : Form
    {
        List<Sat> satellites;
        public Satellite_Tracks(List<Sat> data)
        {
            InitializeComponent();

            satellites = data;
            //заполнение таблицы
            FillDataGridView(data);

            //установка св-в таблицы
            SetSettingsDataGridView();
        }
        private void SetSettingsDataGridView()
        {
            //разрешаем только читать, без возможности редактирования
            dataGridView_list_active_satellites.ReadOnly = true;
            //нельзя добавлять строки
            dataGridView_list_active_satellites.AllowUserToAddRows = false;
            //нельзя удалять строки
            dataGridView_list_active_satellites.AllowUserToDeleteRows = false;
            //стиль самих ячеек
            dataGridView_list_active_satellites.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            //стиль заголовков
            dataGridView_list_active_satellites.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView_list_active_satellites.RowHeadersVisible = false;
            //столбцы занимают всю ширину таблицы
            dataGridView_list_active_satellites.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //задаем ширину каждого столбца
            dataGridView_list_active_satellites.Columns["ID"].FillWeight = 15;
            dataGridView_list_active_satellites.Columns["Название спутника"].FillWeight = 40;
            dataGridView_list_active_satellites.Columns["Географические координаты"].FillWeight = 45;
            //запрет на изменение ширины
            dataGridView_list_active_satellites.Columns["ID"].Resizable = DataGridViewTriState.False;
            dataGridView_list_active_satellites.Columns["Название спутника"].Resizable = DataGridViewTriState.False;
            dataGridView_list_active_satellites.Columns["Географические координаты"].Resizable = DataGridViewTriState.False;
        }
        private void FillDataGridView(List<Sat> data)
        {
            //очистка
            dataGridView_list_active_satellites.DataSource = null;
            dataGridView_list_active_satellites.Rows.Clear();
            dataGridView_list_active_satellites.Columns.Clear();

            //создаем DataTable
            DataTable table = new DataTable();

            //создаем столбцы
            table.Columns.Add("ID", typeof(int));  //  id спутника
            table.Columns.Add("Название спутника", typeof(string));  //  название спутника
            table.Columns.Add("Географические координаты", typeof(string));  //  Географическая координата спутника

            //заполняем таблицу
            foreach (var sat in data)
            { 
                //создаем строку таблицы
                DataRow row = table.NewRow();

                //заполняем строку данными
                row["ID"] = sat.Id;
                row["Название спутника"] = sat.name;
                row["Географические координаты"] = "(" + 0.ToString() + ";" + 0.ToString() + ")";
                //добавляем строку в таблицу
                table.Rows.Add(row);
            }
            //выводим таблицу
            dataGridView_list_active_satellites.DataSource = table;
        }
        
        private void pictureBox_map_tracks_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //установка мировой карты на фон
            DrawRepositoryForFormSatelliteTracks.SetWorldMap(graphics, pictureBox_map_tracks.Width, pictureBox_map_tracks.Height);

            //отрисовка сетки поверх фона
            DrawRepositoryForFormSatelliteTracks.DrawGridForMap(graphics, pictureBox_map_tracks.Width, pictureBox_map_tracks.Height);

            //перенос системы координат в (0,0)
            graphics.TranslateTransform((float)pictureBox_map_tracks.Width/2,(float) pictureBox_map_tracks.Height/2);

            
            using (Pen penForPath = new Pen(Color.Red, 3.0f))
            {
                foreach (var sat in satellites)
                {
                    /*for (int i = 0; i < sat.all_pos.Count - 1; i++)
                    {
                        var st_ECI = sat.all_pos[i];
                        var st_ECEF = new SatellitePossitionInECEF(sat.longitude, sat.arg_Pericenter, sat.i, st_ECI);
                        var st_LLA = new SatellitePositionInLLA(st_ECEF);
                        PointF st = DrawRepositoryForFormSatelliteTracks.RealCoordToWorld(st_LLA.Longitude, st_LLA.Latitude, pictureBox_map_tracks.Width, pictureBox_map_tracks.Height);

                        var fn_ECI = sat.all_pos[i + 1];
                        var fn_ECEF = new SatellitePossitionInECEF(sat.longitude, sat.arg_Pericenter, sat.i, fn_ECI);
                        var fn_LLA = new SatellitePositionInLLA(fn_ECEF);
                        PointF fn = DrawRepositoryForFormSatelliteTracks.RealCoordToWorld(fn_LLA.Longitude, fn_LLA.Latitude, pictureBox_map_tracks.Width, pictureBox_map_tracks.Height);

                        graphics.DrawLine(penForPath, st, fn);
                    }*/
                    Random random = new Random();   
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(255,random.Next(0,256), random.Next(0, 256), random.Next(0, 256))))
                    {
                        for (int i = 0; i < sat.all_pos.Count; i++)
                        {
                            var st_ECI = sat.all_pos[i];
                            var st_ECEF = new SatellitePossitionInECEF(sat.longitude, sat.arg_Pericenter, sat.i, st_ECI);
                            var st_LLA = new SatellitePositionInLLA(st_ECEF);
                            PointF st = DrawRepositoryForFormSatelliteTracks.RealCoordToWorld(st_LLA.Longitude, st_LLA.Latitude, pictureBox_map_tracks.Width, pictureBox_map_tracks.Height);
                            graphics.FillEllipse(brush, st.X - 5, st.Y - 5, 10, 10);
                        }
                    }
               
                }
            }

        }
    }
}
