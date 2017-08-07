using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Temperature
{
    public partial class TemperatureForm : Form
    {
        public TemperatureForm()
        {
            InitializeComponent();
            List<IScale> scaleList = ScaleList.GetListScale();
            foreach (IScale scale in scaleList)
            {
                comboBoxScaleIn.Items.Add(scale);
                comboBoxScaleOut.Items.Add(scale);
            }
            comboBoxScaleIn.SelectedIndex = 0;
            comboBoxScaleOut.SelectedIndex = 0;
        }
        private void buttonConvert_Click(object sender, EventArgs e)
        {
            double num = 0;
            if (!double.TryParse(textValue.Text, out num))
            {
                MessageBox.Show("Необходимо ввести числовое значение температуры.");
                return;
            }
            double value = Converter.Convert((IScale)comboBoxScaleIn.SelectedItem, (IScale)comboBoxScaleOut.SelectedItem, Convert.ToDouble(textValue.Text));
            textBoxResult.Text = Math.Round(value, 3).ToString();
        }
    }
}
