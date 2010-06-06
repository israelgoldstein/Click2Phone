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
			if (listEventsDisplay.InvokeRequired) {
					dlgWriteLine dlg = new dlgWriteLine(WriteLine);
					listEventsDisplay.Invoke(dlg,text);
			} else {
	    	    listEventsDisplay.Items.Add(text);
	    	    listEventsDisplay.SelectedIndex=listEventsDisplay.Items.Count-1;
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
			
		void ListEventsDisplaySelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void BtnExecuteClick(object sender, EventArgs e)
		{
			//no buono: VoIPServer.eslConnection.ExecuteAsync(txtCommand.Text,"","");
			Server.eslConnection.Bgapi(txtCommand.Text,"");
		}
	}
}
