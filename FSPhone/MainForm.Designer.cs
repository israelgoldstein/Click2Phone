/*
 * Creato da SharpDevelop.
 * Utente: OI43839
 * Data: 01/06/2010
 * Ora: 21.36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FSPhone
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this.txtCommand = new System.Windows.Forms.TextBox();
			this.btnExecute = new System.Windows.Forms.Button();
			this.listEventsDisplay = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// txtCommand
			// 
			this.txtCommand.Location = new System.Drawing.Point(12, 322);
			this.txtCommand.Name = "txtCommand";
			this.txtCommand.Size = new System.Drawing.Size(421, 20);
			this.txtCommand.TabIndex = 0;
			// 
			// btnExecute
			// 
			this.btnExecute.Location = new System.Drawing.Point(439, 320);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(75, 23);
			this.btnExecute.TabIndex = 1;
			this.btnExecute.Text = "execute";
			this.btnExecute.UseVisualStyleBackColor = true;
			this.btnExecute.Click += new System.EventHandler(this.BtnExecuteClick);
			// 
			// listEventsDisplay
			// 
			this.listEventsDisplay.FormattingEnabled = true;
			this.listEventsDisplay.Location = new System.Drawing.Point(13, 12);
			this.listEventsDisplay.Name = "listEventsDisplay";
			this.listEventsDisplay.ScrollAlwaysVisible = true;
			this.listEventsDisplay.Size = new System.Drawing.Size(500, 303);
			this.listEventsDisplay.TabIndex = 2;
			this.listEventsDisplay.SelectedIndexChanged += new System.EventHandler(this.ListEventsDisplaySelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnExecute;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(526, 349);
			this.Controls.Add(this.listEventsDisplay);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.txtCommand);
			this.Name = "MainForm";
			this.Text = "FSPhone";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txtCommand;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.ListBox listEventsDisplay;
	}
}
