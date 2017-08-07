using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temperature
{
    public partial class TemperatureForm : Form
    {
        public TemperatureForm()
        {
            InitializeComponent();
            List<IScales> scaleList = ScaleList.GetListScale();
            foreach (IScales scale in scaleList)
            {
                comboBoxScaleIn.Items.Add(scale);
                comboBoxScaleOut.Items.Add(scale);
            }
        }
        private void buttonConvert_Click(object sender, EventArgs e)
        {
            double num = 0;
            if (!double.TryParse(textValue.Text, out num))
            {
                MessageBox.Show("Необходимо ввести числовое значение температуры.");
                return;
            }
            double value = Converter.Convert((IScales)comboBoxScaleIn.SelectedItem, (IScales)comboBoxScaleOut.SelectedItem, Convert.ToDouble(textValue.Text));
            textBoxResult.Text = Math.Round(value, 3).ToString();
        }

        private void comboBoxScaleIn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
