using System;
using System.Data;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace Satellite_Movements
{
    public partial class Form1 : Form
    {
        bool IsPause;
        Satellites satellites;
        public Form1()
        {
            InitializeComponent();

            //создаем объект хранящий, работающий со спутниками
            satellites = new Satellites();

            button_reset_simulation.Enabled = false;
            button_pause_simulation.Enabled = false;
            bool IsPause = true;

            //устанавливаем параметры по умолчанию
            foreach (var data in PullDefaultParameters.pull)
            {
                AddSat(data);
            }
            //обновление информации на таблице
            UpdateDataGridView(satellites.satellites);
            //настройка таблицы
            SetSettingsDataGridView();
        }

        private void UpdateDataGridView(List<Sat> data)
        {
            //очистка
            dataGridView_list_satellite.DataSource = null;
            dataGridView_list_satellite.Rows.Clear();
            dataGridView_list_satellite.Columns.Clear();

            //создаем DataTable
            DataTable table = new DataTable();

            //создаем столбцы
            table.Columns.Add("ID", typeof(int));  //  id спутника
            table.Columns.Add("Название спутника", typeof(string));  //  название спутника

            //заполняем таблицу
            foreach (var sat in data)
            {
                //создаем строку таблицы
                DataRow row = table.NewRow();

                //заполняем строку данными
                row["ID"] = sat.Id;
                row["Название спутника"] = sat.name;
                //добавляем строку в таблицу
                table.Rows.Add(row);
            }
            //выводим таблицу
            dataGridView_list_satellite.DataSource = table;
        }

        private void SetSettingsDataGridView()
        {
            //разрешаем только читать, без возможности редактирования
            dataGridView_list_satellite.ReadOnly = true;
            //нельзя добавлять строки
            dataGridView_list_satellite.AllowUserToAddRows = false;
            //нельзя удалять строки
            dataGridView_list_satellite.AllowUserToDeleteRows = false;
            //стиль самих ячеек
            dataGridView_list_satellite.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            //стиль заголовков
            dataGridView_list_satellite.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            //убираем самый левый столбец
            dataGridView_list_satellite.RowHeadersVisible = false;
            //столбцы занимают всю ширину таблицы
            dataGridView_list_satellite.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private PointF RealCoordToWorld(SatellitePossitionInECI pos)
        {
            int Real_R_Earth = 6371;
            int World_R_Earth = 50;

            //перевод координат спутника в мировые 
            float x_world = pos.X / 1000 / Real_R_Earth * World_R_Earth;
            float y_world = pos.Y / 1000 / Real_R_Earth * World_R_Earth;

            return new PointF(x_world, y_world);

        }
        private void pictureBox_simulation_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //установка фона: звездное небо
            DrawRepository.SetBackgroung(graphics, pictureBox_simulation.Width, pictureBox_simulation.Height);

            //установка в центре Земли
            DrawRepository.SetEarth(graphics, new Point(pictureBox_simulation.Width / 2, pictureBox_simulation.Height / 2));
            var sats = satellites.satellites;
            //отрисовка всех спутников
            for (int i = 0; i < sats.Count; i++)
            {
                //инфа о спутнике
                var data = sats[i];

                //переносим систему координат в центр Земли
                graphics.TranslateTransform(pictureBox_simulation.Width / 2, pictureBox_simulation.Height / 2);
                //делаем базовую декартовую систему координат
                graphics.ScaleTransform(1.0f, -1.0f);

                PointF posSatInWorld = RealCoordToWorld(data.currPos);

                using (Pen pen = new Pen(Color.FromArgb(100, 255, 57, 0), 2.0f))
                {
                    PointF curr = posSatInWorld;
                    for (int k = data.all_pos.Count-1; k > 0; k--)
                    {
                        PointF lastPos = RealCoordToWorld(data.all_pos[k-1]);
                        graphics.DrawLine(pen, curr, lastPos);
                        curr = lastPos;
                    }
                }

                //перенос системы координат в точку спутника
                graphics.TranslateTransform(posSatInWorld.X, posSatInWorld.Y);

                // alpha в градусах
                float alpha = (float)(Math.Atan2(data.currPos.Y, data.currPos.X) / Math.PI * 180);

                //поворот системы координат спутника для постоянной ориентации спутника на Земля
                graphics.RotateTransform(-45 + alpha);//на вход идут градусы


                //установка спутника
                DrawRepository.SetSatellite(graphics);
                graphics.ResetTransform();

            }

        }

        private void timer_simulation_Tick(object sender, EventArgs e)
        {
            //считываем временной шаг
            float step_t = Convert.ToSingle(numericUpDown_stepTime.Value);
            //расчет спутников в следующий момент времени
            satellites.CalcPositionInNextTime(step_t);
            //отрисовка спутников в следующий момент времени 
            pictureBox_simulation.Invalidate();
        }

        private void button_add_satellite_in_system_Click(object sender, EventArgs e)
        {
            using (Add_Satellite form = new Add_Satellite())
            {
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    AddSat(form.satellite);
                    //обновление информации на таблице
                    UpdateDataGridView(satellites.satellites);
                    //отрисовка
                    pictureBox_simulation.Invalidate();
                }
            }
        }
        void AddSat(DataSatellite sat)
        {
            sat.a += 6371;//расстояние указано от поверхности Земли
            sat.a *= 1000;//приводим к метрам в СИ
            sat.Id = ++Sat.LastId;
            if (sat.true_anomaly < 0)
            {
                sat.true_anomaly += 360;
                sat.true_anomaly %= 360;
            }
            //добавляем спутник в сет спутников
            satellites.Add_Satellite(sat);
        }

        private void button_start_simulation_Click(object sender, EventArgs e)
        {
            button_start_simulation.Enabled = false;
            button_pause_simulation.Enabled = true;
            button_reset_simulation.Enabled = true;

            IsPause = false;
            timer_simulation.Start();
        }


        private void button_pause_simulation_Click(object sender, EventArgs e)
        {
            if (!IsPause)
            {
                timer_simulation.Stop();
                IsPause = true;
            }
            else
            {
                timer_simulation.Start();
                IsPause = false;
            }
        }

        private void button_reset_simulation_Click(object sender, EventArgs e)
        {
            timer_simulation.Stop();
            button_start_simulation.Enabled = true;
            button_pause_simulation.Enabled = false;
            button_reset_simulation.Enabled = false;
            satellites.Reset_Satellite();
            pictureBox_simulation.Invalidate();
        }

        private void button_delete_satellite_Click(object sender, EventArgs e)
        {
            if (textBox_sat_id.Text != "" && textBox_sat_name.Text != "")
            {
                satellites.Remove_Satellite(Convert.ToInt32(textBox_sat_id.Text));
                textBox_sat_id.Text = "";
                textBox_sat_name.Text = "";
                //обновление информации на таблице
                UpdateDataGridView(satellites.satellites);
                //отрисовка
                pictureBox_simulation.Invalidate();
            }
        }

        private void button_satellite_tracks_Click(object sender, EventArgs e)
        {
            using (Satellite_Tracks form = new Satellite_Tracks(satellites.satellites))
            {
                DialogResult res = form.ShowDialog();
            }
        }

        private void dataGridView_list_satellite_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.RowIndex - индекс строки, по которой кликнули
            // e.ColumnIndex - индекс колонки, по которой кликнули

            if (e.RowIndex >= 0)  // Проверка, что кликнут не по заголовку
            {
                DataGridViewRow row = dataGridView_list_satellite.Rows[e.RowIndex];
                textBox_sat_id.Text = row.Cells["ID"].Value.ToString();
                textBox_sat_name.Text=row.Cells["Название спутника"].Value.ToString();
            }
        }
    }
}
