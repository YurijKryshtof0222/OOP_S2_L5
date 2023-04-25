using OOP_S2_L5.myClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_S2_L5
{
    public partial class Form1 : Form
    {
        int coloredPointSeriesCount = 0;        
        /*int lineSeriesCount = 0;        
        int coloredLineSeriesCount = 0; */       
        int polyLineSeriesCount = 0;

        double xCoord, yCoord;
        int pointCount;
        byte r, g, b;

        Polyline lastPolyline;

        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*graph.Series["Points"].Points.AddXY(0, 1);
            graph.Series["Points"].Points.AddXY(2, 3);
            graph.Series["Points"].Points.AddXY(4, 5);

            graph.Series["Lines"].Points.AddXY(0, 1);
            graph.Series["Lines"].Points.AddXY(2, 3);
            graph.Series["Lines"].Points.AddXY(4, 5);

            graph.Series["MultiLines"].Points.AddXY(5, 2);
            graph.Series["MultiLines"].Points.AddXY(7, 4);
            graph.Series["MultiLines"].Points.AddXY(9, 10);*/
        }

        private bool readFieldsFromTextBox()
        {
            try
            {
                xCoord = Double.Parse(xCoordTextBox.Text);
                yCoord = Double.Parse(yCoordTextBox.Text);

                pointCount = int.Parse(pointCountLabel.Text);

                string redText = rTextBox.Text;
                r = (byte)(redText != null && redText.Trim() != "" ? byte.Parse(redText.Trim()) : 0);
                string greenText = gTextBox.Text;
                g = (byte)(greenText != null && greenText.Trim() != "" ? byte.Parse(greenText.Trim()) : 0);
                string blueText = bTextBox.Text;
                b = (byte)(blueText != null && blueText.Trim() != "" ? byte.Parse(blueText.Trim()) : 0);
                return true;
            }
            catch (FormatException exc) 
            {
                MessageBox.Show("Make sure that all fields are filled with correct values!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!readFieldsFromTextBox()) return;

            if (pointCount == 0)
            {
                if (r == 0 && b == 0 && g == 0)
                {
                    addPoint(new Point(xCoord, yCoord));
                }
                else
                {
                    addColoredPoint(new ColoredPoint(xCoord, yCoord, new myClasses.Color(r, g, b)));
                }
            }
            else
            {
                lastPolyline.AddPoint(new ColoredPoint(xCoord, yCoord));
                endAddingPolyline(lastPolyline);
                pointCountLabel.Text = "0";
            }

        }

        private void setNextPointBtn_Click(object sender, EventArgs e)
        {
            if (!readFieldsFromTextBox()) return;

            if (pointCount == 0)
            {
                lastPolyline = new Polyline(new myClasses.Color(r, g, b), new Point(xCoord, yCoord));
                startAddingPolyline(lastPolyline);
            }
            else
            {
                lastPolyline.AddPoint(new ColoredPoint(xCoord, yCoord));
                continueAddingPolyline(lastPolyline);
            }
                
            pointCountLabel.Text = $"{pointCount + 1}";
        }

        private void addPoint(Point point)
        {
            graph.Series["Points"].Points.AddXY(point.Xcoord, point.Ycoord);
            graph.Series["Points"].Color = System.Drawing.Color.Black;
        }

        private void addColoredPoint(ColoredPoint point)
        {
            myClasses.Color color = point.Color;

            string series = "coloredPoint" + coloredPointSeriesCount++;
            graph.Series.Add(series);
            graph.Series[series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            graph.Series[series].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            graph.Series[series].MarkerSize = 12;

            graph.Series[series].Points.AddXY(point.Xcoord, point.Ycoord);
            graph.Series[series].Color = System.Drawing.Color.FromArgb(color.Red, color.Green, color.Blue);
        }


        private void startAddingPolyline(Polyline polyLine)
        {
            myClasses.Color color = polyLine.Color;

            string series = "polyLineSeriesCount" + coloredPointSeriesCount;
            graph.Series.Add(series);
            graph.Series[series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            graph.Series[series].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            graph.Series[series].MarkerSize = 10;
            graph.Series[series].BorderWidth = 10;

            rTextBox.Enabled = false;
            gTextBox.Enabled = false;
            bTextBox.Enabled = false;

            graph.Series[series].Points.AddXY(polyLine.Points[0].Xcoord, polyLine.Points[0].Ycoord);
            graph.Series[series].Color = System.Drawing.Color.FromArgb(color.Red, color.Green, color.Blue);

        }

        private void continueAddingPolyline(Polyline polyLine)
        {
            myClasses.Color color = polyLine.Color;

            string series = "polyLineSeriesCount" + coloredPointSeriesCount;
            int pointCount = int.Parse(pointCountLabel.Text);

            graph.Series[series].Points.AddXY(polyLine.Points[polyLine.Points.Count - 1].Xcoord, 
                                              polyLine.Points[polyLine.Points.Count - 1].Ycoord);
        }

        private void endAddingPolyline(Polyline polyLine)
        {
            continueAddingPolyline(polyLine);
            coloredPointSeriesCount++;

            rTextBox.Enabled = true;
            gTextBox.Enabled = true;
            bTextBox.Enabled = true;
        }

        
    }

}
