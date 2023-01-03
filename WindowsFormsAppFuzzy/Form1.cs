using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsAppFuzzy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Temp;
            if (textBox1.Text == "")
                return;

            Temp = Convert.ToDouble(textBox1.Text);
            //label1.Text = Temp.ToString();

            TeaCold(Temp);
            TeaWarm(Temp);
            TeaHot(Temp);
        }

        public void TeaCold(double T)
        {
            if (T < Convert.ToDouble(chart1.Series[0].Points[1].XValue))
            {
                label1.Text = "В комнате холодно " + chart1.Series[0].Points[1].YValues[0].ToString();
            }
            else if ((T >= Convert.ToDouble(chart1.Series[0].Points[1].XValue)) &&
                     (T <= Convert.ToDouble(chart1.Series[0].Points[2].XValue)))
            {
                label1.Text = "В комнате холодно " + ((chart1.Series[0].Points[2].XValue - T) * chart1.Series[0].Points[1].YValues[0] / 
                    (chart1.Series[0].Points[2].XValue - chart1.Series[0].Points[1].XValue)).ToString();
            }
            else if (T > Convert.ToDouble(chart1.Series[0].Points[2].XValue))
            {
                label1.Text = "В комнате холодно " + chart1.Series[0].Points[2].YValues[0].ToString();
            }
            return;
        }

        public void TeaWarm(double T)
        {
            if (T < Convert.ToDouble(chart1.Series[1].Points[0].XValue))
            {
                label2.Text = "В комнате нормальная температура " + chart1.Series[1].Points[0].YValues[0].ToString();
            }

            else if ((T >= Convert.ToDouble(chart1.Series[1].Points[0].XValue)) &&
                     (T <= Convert.ToDouble(chart1.Series[1].Points[1].XValue)))
            {
                label2.Text = "В комнате нормальная температура " + ((T - chart1.Series[1].Points[0].XValue) * chart1.Series[1].Points[1].YValues[0] /
                    (chart1.Series[1].Points[1].XValue - chart1.Series[1].Points[0].XValue)).ToString();
            }

            else if ((T >= Convert.ToDouble(chart1.Series[1].Points[1].XValue)) &&
                     (T <= Convert.ToDouble(chart1.Series[1].Points[2].XValue)))
            {
                label2.Text = "В комнате нормальная температура " + ((chart1.Series[1].Points[2].XValue - T) * chart1.Series[1].Points[1].YValues[0] /
                    (chart1.Series[1].Points[2].XValue - chart1.Series[1].Points[1].XValue)).ToString();
            }

            else if (T > Convert.ToDouble(chart1.Series[1].Points[2].XValue))
            {
                label2.Text = "В комнате нормальная температура " + chart1.Series[1].Points[2].YValues[0].ToString();
            }

            return;
        }

        public void TeaHot(double T)
        {
            if (T < Convert.ToDouble(chart1.Series[2].Points[0].XValue))
            {
                label3.Text = "В комнате жарко " + chart1.Series[2].Points[0].YValues[0].ToString();
            }
            else if ((T >= Convert.ToDouble(chart1.Series[2].Points[0].XValue)) &&
                     (T <= Convert.ToDouble(chart1.Series[2].Points[1].XValue)))
            {
                label3.Text = "В комнате жарко " + ((T - chart1.Series[2].Points[0].XValue ) * chart1.Series[2].Points[1].YValues[0] /
                    (chart1.Series[2].Points[1].XValue - chart1.Series[2].Points[0].XValue)).ToString();
            }
            else if (T > Convert.ToDouble(chart1.Series[2].Points[1].XValue))
            {
                label3.Text = "В комнате жарко " + chart1.Series[2].Points[1].YValues[0].ToString();
            }

            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.Lime;

            chart1.ChartAreas[0].BackColor = Color.White;
             
            // Series
            chart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            chart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            chart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());            

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // Series Color
            chart1.Series[0].Color = Color.DarkGreen;
            chart1.Series[1].Color = Color.Red;
            chart1.Series[2].Color = Color.DarkBlue;

            // LegendText
            chart1.Series[0].LegendText = "Холодно";
            chart1.Series[1].LegendText = "Комнатная температура";
            chart1.Series[2].LegendText = "Жарко";

            // Axis
            chart1.ChartAreas[0].AxisY.Minimum = -5;
            chart1.ChartAreas[0].AxisY.Maximum = 105;
            chart1.ChartAreas[0].AxisY.Interval = 10;
            chart1.ChartAreas[0].AxisY.IntervalOffset = 5;

            chart1.ChartAreas[0].AxisX.Minimum = -10;
            chart1.ChartAreas[0].AxisX.Maximum = 50;
            chart1.ChartAreas[0].AxisX.Interval = 10;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 10;

            // Points
            chart1.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint());
            chart1.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint());
            chart1.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint());

            chart1.Series[0].Points[0].XValue = 0;
            chart1.Series[0].Points[0].YValues[0] = 100;

            chart1.Series[0].Points[1].XValue = 10;
            chart1.Series[0].Points[1].YValues[0] = 100;

            chart1.Series[0].Points[2].XValue = 18;
            chart1.Series[0].Points[2].YValues[0] = 0;

            chart1.Series[1].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint());
            chart1.Series[1].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint());
            chart1.Series[1].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint());

            chart1.Series[1].Points[0].XValue = 16;
            chart1.Series[1].Points[0].YValues[0] = 0;

            chart1.Series[1].Points[1].XValue = 21;
            chart1.Series[1].Points[1].YValues[0] = 100;

            chart1.Series[1].Points[2].XValue = 25;
            chart1.Series[1].Points[2].YValues[0] = 0;

            chart1.Series[2].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint());
            chart1.Series[2].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint());
            chart1.Series[2].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint());

            chart1.Series[2].Points[0].XValue = 23;
            chart1.Series[2].Points[0].YValues[0] = 0;

            chart1.Series[2].Points[1].XValue = 30;
            chart1.Series[2].Points[1].YValues[0] = 100;

            chart1.Series[2].Points[2].XValue = 40;
            chart1.Series[2].Points[2].YValues[0] = 100;
        }

        /*http://www.cyberguru.ru/algorithms/algorithms-theory/algorithms-fuzzy-logic-system.html?showall=&start=0
          http://www.cyberguru.ru/algorithms/algorithms-theory/algorithms-fuzzy-logic-system.html?showall=&start=1
        */
    }
}
