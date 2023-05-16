using OOP_S2_L5.forms;
using OOP_S2_L5.myClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OOP_S2_L5
{
    public partial class MainForm : Form
    {
        int coloredPointSeriesCount = 0;        
        /*int lineSeriesCount = 0;        
        int coloredLineSeriesCount = 0; */       
        int polylineSeriesCount = 0;

        LineCollection lines = new LineCollection();

        double xCoord, yCoord;
        int pointCount;
        byte r, g, b;

        Polyline lastPolyline;

        public MainForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            taskForLab6();
        }

        private void taskForLab7()
        {
            LineCollection lines = new LineCollection
            {
                new Polyline(new myClasses.Color(255, 255, 0), new Point(5, 5), new Point(6, 7)),
                new Polyline(new myClasses.Color(255, 0, 255),
                    new Point(3, 4), new Point(4, 3), new Point(8, 7)),
                new ColoredLine(new Point(5, 5), new Point(8, 8),
                    new myClasses.Color(255, 128, 128)),
                new ColoredLine(new Point(9, 9), new Point(12, 6),
                    new myClasses.Color(120, 255, 65))
            };

            RetrieveVectorsFromColoredLineList(lines);
        }

        private void taskForLab6()
        {
            List<IVectorComparable> list = new List<IVectorComparable>();

            list.Add(new Polyline(new myClasses.Color(255, 255, 0), new Point(5, 5), new Point(6, 7)));
            list.Add(new Polyline(new myClasses.Color(255, 0, 255),
                    new Point(3, 4), new Point(4, 3), new Point(8, 7)));
            list.Add(new ColoredPoint(2, 3, new Color(132, 128, 128)));
            list.Add(new ColoredPoint(6, 6));

            RetrieveVectorsFromComparableLineList(list);

            int oldLen = list.Count;

            for (int i = 0; i < oldLen; i++)
            {
                list.Add((IVectorComparable)list[i].Clone());
            }

            list.Sort();

            string str = "";

            foreach (var vector in list)
            {
                str += vector + ",\n\n";
            }

            MessageBox.Show($"List:\n {{ {str} }}", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RetrieveVectorsFromColoredLineList(LineCollection list)
        {
            foreach (var vector in list)
            {
                if (vector == null) continue;
                else if (vector is ColoredLine)
                {
                    ColoredLine line = vector as ColoredLine;
                    addPolyline(new Polyline(line.Color, line.FirstPoint, line.SecondPoint));
                }
                else
                {
                    addPolyline(vector as Polyline);
                }

            }
        }


        private void RetrieveVectorsFromComparableLineList(List<IVectorComparable>  list)
        {
            foreach (var vector in list.ToList())
            {
                if (vector == null) continue;
                else if (vector is ColoredPoint)
                {
                    addColoredPoint(vector as ColoredPoint);
                }
                else
                {
                    addPolyline(vector as Polyline);
                }

            }
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
                MessageBox.Show("Make sure that coordination fields are filled with correct number values!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException exc)
            {
                MessageBox.Show("Make sure that RGB/color fields are filled with correct number values!\nThe color range is {0; 255}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void addPolyline(Polyline polyline)
        {
            string series = "polyLineSeriesCount" + polylineSeriesCount++;
            graph.Series.Add(series);
            graph.Series[series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            graph.Series[series].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            graph.Series[series].MarkerSize = 10;
            graph.Series[series].BorderWidth = 10;

            lines.Add(polyline);

            for (int i = 0; i < polyline.Points.Count; i++)
            {
                graph.Series[series].Points.AddXY(polyline.Points[i].Xcoord, polyline.Points[i].Ycoord);
                myClasses.Color color = polyline.Color;
                graph.Series[series].Color = System.Drawing.Color.FromArgb(
                    color.Red, color.Green, color.Blue);
            }
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            readFieldsFromTextBox();

            MoveObjectForm form = new MoveObjectForm();
            form.srcXcoord = xCoordTextBox.Text;
            form.srcYcoord = yCoordTextBox.Text;
            form.graph = graph;
            form.series = findSeriesByCoordOfPoint();

            if (form.series == null)
            {
                MessageBox.Show("Make sure that coordinates march to some point or line!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                /*return*/;
            }

            form.ShowDialog();
        }

        private Series findSeriesByCoordOfPoint()
        {
            foreach (var series in graph.Series)
            {
                foreach (var point in series.Points)
                {
                    if (point.XValue == double.Parse(xCoordTextBox.Text)
                        && point.YValues[0] == double.Parse(yCoordTextBox.Text))
                   return series;
                }
            }
            return null;
        }

        private void xCoordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void graph_Click(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showInfoBtn_Click(object sender, EventArgs e)
        {
            string str = "";

            IEnumerator<IColoredLine> enumerator = lines.GetEnumerator(); 
            while (enumerator.MoveNext())
            {
                str += enumerator.Current.ToString() + ",\n\n";
            }

            MessageBox.Show($"Line collection: {{ {str} }}", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (!readFieldsFromTextBox()) return;

            foreach (var point in graph.Series["Points"].Points)
            {
                if (point.XValue == double.Parse(xCoordTextBox.Text)
                    && point.YValues[0] == double.Parse(yCoordTextBox.Text))
                {
                    graph.Series["Points"].Points.Remove(point);
                    return;
                }
            }

            
            foreach (var series in graph.Series)
            {
                foreach (var point in series.Points)
                {
                    if (point.XValue == double.Parse(xCoordTextBox.Text)
                        && point.YValues[0] == double.Parse(yCoordTextBox.Text))
                    {
                        graph.Series.Remove(series);
                        return;
                    }
                }
            }
            
            graph.Update();

            MessageBox.Show("Make sure that coordinates march to some point or line!", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void startAddingPolyline(Polyline polyLine)
        {
            myClasses.Color color = polyLine.Color;

            string series = "polyLineSeriesCount" + polylineSeriesCount;
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

            string series = "polyLineSeriesCount" + polylineSeriesCount;
            int pointCount = int.Parse(pointCountLabel.Text);

            graph.Series[series].Points.AddXY(polyLine.Points[polyLine.Points.Count - 1].Xcoord, 
                                              polyLine.Points[polyLine.Points.Count - 1].Ycoord);
        }

        private void endAddingPolyline(Polyline polyLine)
        {
            continueAddingPolyline(polyLine);
            polylineSeriesCount++;

            rTextBox.Enabled = true;
            gTextBox.Enabled = true;
            bTextBox.Enabled = true;
        }

        
    }

}
