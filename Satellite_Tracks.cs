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
        public Satellite_Tracks(List<DataSatellite>data)
        {
            InitializeComponent();

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
        private void FillDataGridView(List<DataSatellite> data)
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
                row["Географические координаты"] = "(" + sat.Geog_latitude.ToString() + ";" + sat.Geog_longitude.ToString() + ")";
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
        }
    }
}
