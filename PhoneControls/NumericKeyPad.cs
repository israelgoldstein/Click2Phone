/*
 * Created by SharpDevelop.
 * User: gz8vnr
 * Date: 16/02/2009
 * Time: 17.14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ContaQ
{
	/// <summary>
	/// Description of NumericKeyPad.
	/// </summary>
	public partial class NumericKeyPad : UserControl
	{
		public delegate void OnKeyPressed(object sender, String keyPressed);
		public event OnKeyPressed KeyPressed;

		public NumericKeyPad()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		
		private void OnKeyClick(String key) {
			KeyPressed(this, key);
		}
				
		void BtnKeyClick(object sender, EventArgs e)
		{
			OnKeyClick(((Button)sender).Text.Trim());
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
		}
	}
}
