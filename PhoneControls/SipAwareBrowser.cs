/*
 * Created by SharpDevelop.
 * User: gz8vnr
 * Date: 04/11/2008
 * Time: 16.03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace ContaQ
{
	
	public class SipRequestArgs: EventArgs
	{
		public const string cmdTEST = "test";
		public const string cmdCALL = "call";
		public const string cmdANSWER = "answer";
		public const string cmdHANGUP = "hangup";
		public const string cmdREGISTER = "register";
		public const string cmdUNREGISTER = "unregister";
		public const string cmdSETCALLBACK = "setcallback";
		public const string cmdRECORDSESSION = "recordsession";
		public const string cmdTRANSFER = "transfer";
		public const string cmdHOLD = "hold";
		public const string cmdRETRIEVE = "retrieve";
		public const string cmdOPEN = "open";
		public const string cmdHOME = "home";
		public const string cmdSETAUTOROUTING = "setautorouting";
		public const string cmdSHELL = "shell";
		
		private string command = null;
		public string Command
	    {
	      	get {
	        	return command;
	      	} 
			set {
				command = value;
	      	}
	    }
		private Hashtable arguments = new Hashtable();
		
		public Hashtable Arguments {
			get { return arguments; }
			set { arguments = value; }
		}
		private Boolean cancel;
		public Boolean Cancel {
			get { return cancel; }
			set { cancel = value; }
		}
	}
	
	public class TextChangedArgs: EventArgs
	{
		public TextChangedArgs (string Text) {
			this.text = Text;
		}
		private string text;
		
		public string Text {
			get { return text; }
			set { text = value; }
		}
	}
	
	#region public events
	
	public delegate void SipRequest(object sender, SipRequestArgs e);
	public delegate void TitleChanged(object sender, TextChangedArgs e);
	public delegate void StatusChanged(object sender, TextChangedArgs e);
	//public delegate void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e);
	//public delegate void Navigating(object sender, WebBrowserNavigatingEventArgs e);
	#endregion public events
	
	/// <summary>
	/// Description of PhoneEnabledBrowser.
	/// </summary>
	public partial class SipAwareBrowser : UserControl
	{
		public event SipRequest MySipRequest;
		public event TitleChanged MyTitleChanged;
		public event StatusChanged MyStatusChanged;
		
		protected virtual void OnSipRequest(WebBrowserNavigatingEventArgs e)
		{
			SipRequestArgs srArgs = new SipRequestArgs();
			srArgs.Command = e.Url.Host.ToString();

			string original = e.Url.PathAndQuery.ToString();
			original = original.Replace("&hash;", "#");
			string[] swp = original.Split('?');
			if (swp.Length == 1) {
				//no arguments
				srArgs.Command = original;
			} else {
				srArgs.Command = swp[0];
				foreach (string kvpair in swp[1].Split('&')) {
					swp = kvpair.Split('=');
					string key = swp[0].ToLower();
					string val="";
					if (swp.Length > 1) {
						//argument with no value
						val = Uri.UnescapeDataString(swp[1]);
					} 
					srArgs.Arguments.Add(key, val);
				}
			}						
			MySipRequest(this, srArgs);
			e.Cancel = srArgs.Cancel;
		}
  		public SipAwareBrowser()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public void Open(string url) {
			browser.Navigate(url);
		}
		
		void BrowserNewWindow(object sender, CancelEventArgs e)
		{
			
		}
		
		void BrowserNavigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			String protocol = e.Url.Scheme.ToLower();
			switch (protocol) {
				case "sip": 
					OnSipRequest(e);
					break;
				case "contaq":
					OnSipRequest(e);
					break;
				default:
					MyStatusChanged(sender, new TextChangedArgs("opening: " + e.Url.ToString() + "..."));
					break;
			}
		}
		
		void BrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			MyTitleChanged(sender, new TextChangedArgs(browser.Document.Title));
			MyStatusChanged(sender, new TextChangedArgs("Browser ready"));
		}
	}
}
