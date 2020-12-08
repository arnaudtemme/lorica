/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace DynamicData
{
	public partial class dynamicPlot : Form
	{
		// Starting time in milliseconds
		int tickStart = 0;
        int PlotType = 0;
  
		public dynamicPlot(int plotType)
		{
			InitializeComponent();
            this.PlotType = plotType;
           
		}

		private void dynamicPlot_Load( object sender, EventArgs e )
		{
			GraphPane myPane = zedGraphControl1.GraphPane;
            if (PlotType == 1)//sediment plot
            {
                myPane.Title.Text = "Sediment Output";
                myPane.XAxis.Title.Text = "Time, days";
                myPane.YAxis.Title.Text = "cubic meters";
            }
            if (PlotType == 2)//discharge plot
            {
                myPane.Title.Text = "Water Discharge";
                myPane.XAxis.Title.Text = "Time, days";
                myPane.YAxis.Title.Text = "cumecs";
            }
           
			// Save 1200 points.  At 50 ms sample rate, this is one minute
			// The RollingPointPairList is an efficient storage class that always
			// keeps a rolling set of point data without needing to shift any data values
			RollingPointPairList list = new RollingPointPairList( 1200 );

			// Initially, a curve is added with no data points (list is empty)
			// Color is blue, and there will be no symbols
            if (PlotType == 1)
            {
                LineItem curve = myPane.AddCurve("", list, Color.Red, SymbolType.None);
            }
            if (PlotType == 2)
            {
                LineItem curve = myPane.AddCurve("", list, Color.Blue, SymbolType.None);
            }
			// Sample at 50ms intervals
			timer1.Interval = 5000;
			timer1.Enabled = true;
			timer1.Start();

			// Just manually control the X axis range so it scrolls continuously
			// instead of discrete step-sized jumps
			myPane.XAxis.Scale.Min = 0;
			myPane.XAxis.Scale.Max = 10;
			//myPane.XAxis.Scale.MinorStep = 1;
			//myPane.XAxis.Scale.MajorStep = 5;

			// Scale the axes
			zedGraphControl1.AxisChange();

			// Save the beginning time for reference
			tickStart = Environment.TickCount;
		}

		private void timer1_Tick( object sender, EventArgs e )
		{
			// Make sure that the curvelist has at least one curve
			if ( zedGraphControl1.GraphPane.CurveList.Count <= 0 )
				return;

			// Get the first CurveItem in the graph
			LineItem curve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
			if ( curve == null )
				return;

			// Get the PointPairList
			IPointListEdit list = curve.Points as IPointListEdit;
			// If this is null, it means the reference at curve.Points does not
			// support IPointListEdit, so we won't be able to modify it
			if ( list == null )
				return;

			// Time is measured in seconds
			//double time = ( Environment.TickCount - tickStart ) / 1000.0;
          
			// 3 seconds per cycle
            if (PlotType == 1)
            {
                //ARTlist.Add(LORICA.Form1.cycle / 1440, LORICA.Form1.sedOut);
            }
            if (PlotType == 2)
            {
                //ART list.Add(LORICA.Form1.cycle / 1440, LORICA.Form1.waterOut);
                
            }
			// Keep the X scale at a rolling 30 second interval, with one
			// major step between the max X value and the end of the axis
			Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            /* ART if (LORICA.Form1.cycle / 1440 > xScale.Max - xScale.MajorStep)
			{
                xScale.Max = LORICA.Form1.cycle / 1440 + xScale.MajorStep;
				xScale.Min = xScale.Max - 30.0;
			}  

			// Make sure the Y axis is rescaled to accommodate actual data
			zedGraphControl1.AxisChange();
			// Force a redraw
			zedGraphControl1.Invalidate();
		}

		private void dynamicPlot_Resize( object sender, EventArgs e )
		{
			SetSize();
		}

		// Set the size and location of the ZedGraphControl
		private void SetSize()
		{
			// Control is always 10 pixels inset from the client rectangle of the form
			Rectangle formRect = this.ClientRectangle;
			formRect.Inflate( -10, -10 );

			if ( zedGraphControl1.Size != formRect.Size )
			{
				zedGraphControl1.Location = formRect.Location;
				zedGraphControl1.Size = formRect.Size;
			}
		}
	}
}
*/