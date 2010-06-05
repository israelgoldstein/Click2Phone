/*
 * Created by SharpDevelop.
 * User: gz8vnr
 * Date: 04/11/2008
 * Time: 16.03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ContaQ
{
	partial class SipAwareBrowser
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.browser = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// browser
			// 
			this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browser.Location = new System.Drawing.Point(0, 0);
			this.browser.MinimumSize = new System.Drawing.Size(20, 20);
			this.browser.Name = "browser";
			this.browser.Size = new System.Drawing.Size(735, 385);
			this.browser.TabIndex = 0;
			this.browser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.BrowserNavigating);
			this.browser.NewWindow += new System.ComponentModel.CancelEventHandler(this.BrowserNewWindow);
			this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.BrowserDocumentCompleted);
			// 
			// SipAwareBrowser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.browser);
			this.Name = "SipAwareBrowser";
			this.Size = new System.Drawing.Size(735, 385);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.WebBrowser browser;
	}
}
