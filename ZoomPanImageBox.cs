/* 
 * Developed by Shannon Young.  http://www.smallwisdom.com
 * Copyright 2005
 * 
 * You are welcome to use, edit, and redistribute this code.
 * 
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Smallwisdom.Windows.Forms
{
	/// <summary>
	/// ZoomPanImageBox is a specialized ImageBox with Pan and Zoom control.
	/// </summary>
	public class ZoomPanImageBox : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// The zoom factor for this control.  Currently, it is hardcoded, 
		/// but perhaps a nice addition would be to set this?
		/// </summary>
		private double[] zoomFactor = {.25, .33, .50, .66, .80, 1, 1.25, 1.5, 2.0, 2.5, 3.0};
		private System.Windows.Forms.Panel imagePanel;
		private System.Windows.Forms.PictureBox imgBox;
        // zoom controls

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region Construct, Dispose

		public ZoomPanImageBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Initialize anything not included in the designer
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.imagePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.imagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBox.Location = new System.Drawing.Point(0, 0);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(780, 330);
            this.imgBox.TabIndex = 6;
            this.imgBox.TabStop = false;
            // 
            // imagePanel
            // 
            this.imagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePanel.AutoScroll = true;
            this.imagePanel.Controls.Add(this.imgBox);
            this.imagePanel.Location = new System.Drawing.Point(0, 3);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(780, 330);
            this.imagePanel.TabIndex = 7;
            // 
            // ZoomPanImageBox
            // 
            this.Controls.Add(this.imagePanel);
            this.Name = "ZoomPanImageBox";
            this.Size = new System.Drawing.Size(780, 330);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.imagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Initialization code goes here.
		/// </summary>
		

		/// <summary>
		/// Image loaded into the box.
		/// </summary>
		[Browsable(true),
		Description("Image loaded into the box.")]
		public Image Image
		{
			get
			{
				return imgBox.Image;
			}
			set
			{
				//Set the image value
				imgBox.Image = value;
                if (LORICA4.Mother_form.updateClick == 0)
                {
                    imgBox.Size = imagePanel.Size;
                }
                else
                {
                    if (LORICA4.Mother_form.magnifyValue == 0)
                    {
                        imgBox.Size = value.Size;
                    }
                }  
             
			}
		}

		public void setZoom()
		{
			// The scrollZoom changed so reset the zoom factor
			// based on the scrollZoom TrackBar position.
            double newZoom = LORICA4.Mother_form.magnifyValue;

			// Set the ImageBox width and height to the new zoom
			// factor by multiplying the Image inside the Imagebox
			// by the new zoom factor.
			imgBox.Width = Convert.ToInt32 ( imgBox.Image.Width * newZoom);  //this merely changes the size of the box, not the size of the map shown
			imgBox.Height = Convert.ToInt32 ( imgBox.Image.Height * newZoom );

		}



	}// end class
}// end namespace
