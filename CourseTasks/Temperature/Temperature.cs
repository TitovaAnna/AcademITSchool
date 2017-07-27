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
    public partial class Temperature : Form
    {
        public Temperature()
        {
            InitializeComponent();

            comboBox1.Items.Add(Scales.Scale.Celsium);
            comboBox1.Items.Add(Scales.Scale.Fahrenheit);
            comboBox1.Items.Add(Scales.Scale.Kelvin);
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add(Scales.Scale.Celsium);
            comboBox2.Items.Add(Scales.Scale.Fahrenheit);
            comboBox2.Items.Add(Scales.Scale.Kelvin);
            comboBox2.SelectedIndex = 0;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            double num = 0;
            if (!double.TryParse(textBox1.Text, out num))
            {
                MessageBox.Show("Необходимо ввести числовое значение температуры.");
                return;
            }
            double value = Converter.Convert((Scales.Scale)comboBox1.SelectedItem, (Scales.Scale)comboBox2.SelectedItem, Convert.ToDouble(textBox1.Text));
            textBox2.Text = Math.Round(value, 3).ToString();
        }

    }
}
