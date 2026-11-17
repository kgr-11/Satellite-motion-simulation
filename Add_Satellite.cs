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
    public partial class Add_Satellite : Form
    {
        //параметры спутника
        public DataSatellite satellite;
        public Add_Satellite()
        {
            InitializeComponent();
        }
        

        private void button_reset_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            //обработка данных
            satellite.name = textBox_name_satellite.Text;
            satellite.a=Convert.ToSingle(textBox_a.Text);
            satellite.e=Convert.ToSingle(textBox_e.Text);
            satellite.i=Convert.ToSingle(textBox_i.Text);
            satellite.longitude=Convert.ToSingle(textBox_longitude.Text);
            satellite.arg_Pericenter=Convert.ToSingle(textBox_argPericenter.Text);
            satellite.true_anomaly = Convert.ToSingle(textBox_true_anomaly.Text);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
