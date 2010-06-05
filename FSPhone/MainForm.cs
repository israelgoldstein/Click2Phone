/*
 * Creato da SharpDevelop.
 * Utente: OI43839
 * Data: 01/06/2010
 * Ora: 21.36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FSPhone.Common;

namespace FSPhone
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public VoIPServer Server;
		
		delegate void dlgWriteLine(String text);

		public void WriteLine(String text) {
			if (listBox1.InvokeRequired) {
					dlgWriteLine dlg = new dlgWriteLine(WriteLine);
					listBox1.Invoke(dlg,text);
			} else {
	    	    listBox1.Items.Add(text);
			}
		}
		delegate void onDataReceived(object Sender, DataReceivedEventArgs e);
		// Called asynchronously with a line of data
		private void OnDataReceived(object Sender, DataReceivedEventArgs e)
		{
			if (listBox1.InvokeRequired) {
				if (e != null && Sender != null && e.Data != null) {
					onDataReceived dlg = new onDataReceived(OnDataReceived);
					listBox1.Invoke(dlg,Sender, e);
				}
			} else {
	    	    listBox1.Items.Add(e.Data);
			}
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			String uniqueID = "testtest";
			VoIPServer.eslConnection.Bgapi(textBox1.Text,"");
			
			/*
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.EnableRaisingEvents=true;
			proc.StartInfo.UseShellExecute=false;
			proc.StartInfo.FileName="c:\\temp\\test.bat";
			proc.StartInfo.CreateNoWindow=true;
			proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.OutputDataReceived += new DataReceivedEventHandler(OnDataReceived);
			proc.Start();
			proc.BeginOutputReadLine();
			*/
		}
	}
}
