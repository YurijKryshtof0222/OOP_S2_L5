using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace OOP_S2_L5.forms
{
    public partial class MoveObjectForm : Form
    {
        public string srcXcoord;
        public string srcYcoord;
        public Series series;
        public Chart graph;

        public MoveObjectForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MoveObjectForm_Load(object sender, EventArgs e)
        {
            srcXcoordTxtBox.Text = srcXcoord;
            srcYcoordTxtBox.Text = srcYcoord;
        }

        private void movePoint()
        {
            foreach (var point in graph.Series["Points"].Points)
            {
                if (point.XValue == double.Parse(srcXcoord)
                    && point.YValues[0] == double.Parse(srcYcoord))
                {
                    point.SetValueXY(point.XValue + double.Parse(dstXcoordTxtBox.Text),
                                     point.YValues[0] + double.Parse(dstYcoordTxtBox.Text));
                    graph.Series["Points"].Points.AddXY(point.XValue + double.Parse(dstXcoordTxtBox.Text),
                                                        point.YValues[0] + double.Parse(dstYcoordTxtBox.Text));
                }
                
                graph.Update();
            }
            
        }

        private void moveLines()
        {
            foreach (var point in series.Points)
            {
                point.SetValueXY(point.XValue + double.Parse(dstXcoordTxtBox.Text),
                                 point.YValues[0] + double.Parse(dstYcoordTxtBox.Text));
                series.Points.AddXY(point.XValue + double.Parse(dstXcoordTxtBox.Text),
                                 point.YValues[0] + double.Parse(dstYcoordTxtBox.Text));
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            if (series == graph.Series["Points"])
            {
                movePoint();
            }
            else
            {
                moveLines();
            }
            graph.Update();
            this.Close();
        }

    }
}
