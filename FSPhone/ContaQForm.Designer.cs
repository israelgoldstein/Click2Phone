/*
 * Created by SharpDevelop.
 * User: gz8vnr
 * Date: 03/11/2008
 * Time: 14.43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ContaQ
{
	partial class ContaQForm
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
			this.components = new System.ComponentModel.Container();
			this.btnCall = new System.Windows.Forms.Button();
			this.txtNumber = new System.Windows.Forms.TextBox();
			this.btnRelease = new System.Windows.Forms.Button();
			this.btnAnswer = new System.Windows.Forms.Button();
			this.btnShowMainform = new System.Windows.Forms.Button();
			this.topPanel = new System.Windows.Forms.Panel();
			this.picLogo = new System.Windows.Forms.PictureBox();
			this.panelAdvanced = new System.Windows.Forms.Panel();
			this.btnHome = new System.Windows.Forms.Button();
			this.btnTransfer = new System.Windows.Forms.Button();
			this.btnMute = new System.Windows.Forms.Button();
			this.btnOpenUrl = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnShowKeypad = new System.Windows.Forms.Button();
			this.keyPad = new ContaQ.NumericKeyPad();
			this.comboProvider = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnRecord = new System.Windows.Forms.Button();
			this.btnHold = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblOperator = new System.Windows.Forms.Label();
			this.lblAccount = new System.Windows.Forms.Label();
			this.phoBrow = new ContaQ.SipAwareBrowser();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.sipStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.browserStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.timerBlink = new System.Windows.Forms.Timer(this.components);
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.topPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
			this.panelAdvanced.SuspendLayout();
			this.panel1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCall
			// 
			this.btnCall.Location = new System.Drawing.Point(22, 194);
			this.btnCall.Margin = new System.Windows.Forms.Padding(2);
			this.btnCall.Name = "btnCall";
			this.btnCall.Size = new System.Drawing.Size(92, 31);
			this.btnCall.TabIndex = 1;
			this.btnCall.Text = "&chiama";
			this.btnCall.UseVisualStyleBackColor = true;
			this.btnCall.Click += new System.EventHandler(this.BtnCallClick);
			// 
			// txtNumber
			// 
			this.txtNumber.Location = new System.Drawing.Point(4, 159);
			this.txtNumber.Margin = new System.Windows.Forms.Padding(2);
			this.txtNumber.Name = "txtNumber";
			this.txtNumber.Size = new System.Drawing.Size(125, 20);
			this.txtNumber.TabIndex = 0;
			// 
			// btnRelease
			// 
			this.btnRelease.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnRelease.Location = new System.Drawing.Point(22, 225);
			this.btnRelease.Margin = new System.Windows.Forms.Padding(2);
			this.btnRelease.Name = "btnRelease";
			this.btnRelease.Size = new System.Drawing.Size(92, 31);
			this.btnRelease.TabIndex = 3;
			this.btnRelease.Text = "&attacca";
			this.btnRelease.UseVisualStyleBackColor = true;
			this.btnRelease.Click += new System.EventHandler(this.BtnReleaseClick);
			// 
			// btnAnswer
			// 
			this.btnAnswer.Location = new System.Drawing.Point(22, 300);
			this.btnAnswer.Margin = new System.Windows.Forms.Padding(2);
			this.btnAnswer.Name = "btnAnswer";
			this.btnAnswer.Size = new System.Drawing.Size(92, 33);
			this.btnAnswer.TabIndex = 5;
			this.btnAnswer.Text = "r&ispondi";
			this.btnAnswer.UseVisualStyleBackColor = true;
			this.btnAnswer.Click += new System.EventHandler(this.BtnAnswerClick);
			// 
			// btnShowMainform
			// 
			this.btnShowMainform.Location = new System.Drawing.Point(4, 28);
			this.btnShowMainform.Margin = new System.Windows.Forms.Padding(2);
			this.btnShowMainform.Name = "btnShowMainform";
			this.btnShowMainform.Size = new System.Drawing.Size(60, 24);
			this.btnShowMainform.TabIndex = 4;
			this.btnShowMainform.Text = "&config";
			this.btnShowMainform.UseVisualStyleBackColor = true;
			this.btnShowMainform.Click += new System.EventHandler(this.BtnShowMainformClick);
			// 
			// topPanel
			// 
			this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(81)))), ((int)(((byte)(102)))));
			this.topPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.topPanel.Controls.Add(this.picLogo);
			this.topPanel.Controls.Add(this.panelAdvanced);
			this.topPanel.Controls.Add(this.panel1);
			this.topPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.topPanel.Location = new System.Drawing.Point(363, 0);
			this.topPanel.Margin = new System.Windows.Forms.Padding(2);
			this.topPanel.Name = "topPanel";
			this.topPanel.Size = new System.Drawing.Size(131, 602);
			this.topPanel.TabIndex = 3;
			// 
			// picLogo
			// 
			this.picLogo.BackColor = System.Drawing.Color.White;
			this.picLogo.ImageLocation = "";
			this.picLogo.Location = new System.Drawing.Point(2, 3);
			this.picLogo.Margin = new System.Windows.Forms.Padding(2);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(128, 32);
			this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picLogo.TabIndex = 5;
			this.picLogo.TabStop = false;
			this.picLogo.WaitOnLoad = true;
			this.picLogo.Click += new System.EventHandler(this.PicLogoClick);
			// 
			// panelAdvanced
			// 
			this.panelAdvanced.Controls.Add(this.btnHome);
			this.panelAdvanced.Controls.Add(this.btnTransfer);
			this.panelAdvanced.Controls.Add(this.btnMute);
			this.panelAdvanced.Controls.Add(this.btnShowMainform);
			this.panelAdvanced.Controls.Add(this.btnOpenUrl);
			this.panelAdvanced.Location = new System.Drawing.Point(4, 560);
			this.panelAdvanced.Margin = new System.Windows.Forms.Padding(2);
			this.panelAdvanced.Name = "panelAdvanced";
			this.panelAdvanced.Size = new System.Drawing.Size(129, 79);
			this.panelAdvanced.TabIndex = 10;
			this.panelAdvanced.Visible = false;
			// 
			// btnHome
			// 
			this.btnHome.Location = new System.Drawing.Point(4, 2);
			this.btnHome.Margin = new System.Windows.Forms.Padding(2);
			this.btnHome.Name = "btnHome";
			this.btnHome.Size = new System.Drawing.Size(60, 24);
			this.btnHome.TabIndex = 11;
			this.btnHome.Text = "h&ome";
			this.btnHome.UseVisualStyleBackColor = true;
			this.btnHome.Click += new System.EventHandler(this.BtnHomeClick);
			// 
			// btnTransfer
			// 
			this.btnTransfer.Location = new System.Drawing.Point(65, 2);
			this.btnTransfer.Margin = new System.Windows.Forms.Padding(2);
			this.btnTransfer.Name = "btnTransfer";
			this.btnTransfer.Size = new System.Drawing.Size(60, 24);
			this.btnTransfer.TabIndex = 4;
			this.btnTransfer.Text = "&trasferisci";
			this.btnTransfer.UseVisualStyleBackColor = true;
			this.btnTransfer.Click += new System.EventHandler(this.BtnTransferClick);
			// 
			// btnMute
			// 
			this.btnMute.Location = new System.Drawing.Point(36, 58);
			this.btnMute.Margin = new System.Windows.Forms.Padding(2);
			this.btnMute.Name = "btnMute";
			this.btnMute.Size = new System.Drawing.Size(60, 24);
			this.btnMute.TabIndex = 4;
			this.btnMute.Text = "&mute";
			this.btnMute.UseVisualStyleBackColor = true;
			this.btnMute.Click += new System.EventHandler(this.BtnMuteClick);
			// 
			// btnOpenUrl
			// 
			this.btnOpenUrl.Location = new System.Drawing.Point(65, 28);
			this.btnOpenUrl.Margin = new System.Windows.Forms.Padding(2);
			this.btnOpenUrl.Name = "btnOpenUrl";
			this.btnOpenUrl.Size = new System.Drawing.Size(60, 24);
			this.btnOpenUrl.TabIndex = 2;
			this.btnOpenUrl.Text = "apri &url";
			this.btnOpenUrl.UseVisualStyleBackColor = true;
			this.btnOpenUrl.Click += new System.EventHandler(this.BtnOpenUrlClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(81)))), ((int)(((byte)(102)))));
			this.panel1.Controls.Add(this.btnShowKeypad);
			this.panel1.Controls.Add(this.keyPad);
			this.panel1.Controls.Add(this.comboProvider);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.btnRecord);
			this.panel1.Controls.Add(this.btnHold);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.btnAnswer);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lblOperator);
			this.panel1.Controls.Add(this.lblAccount);
			this.panel1.Controls.Add(this.btnRelease);
			this.panel1.Controls.Add(this.btnCall);
			this.panel1.Controls.Add(this.txtNumber);
			this.panel1.Location = new System.Drawing.Point(0, 40);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(131, 516);
			this.panel1.TabIndex = 3;
			// 
			// btnShowKeypad
			// 
			this.btnShowKeypad.Location = new System.Drawing.Point(11, 376);
			this.btnShowKeypad.Margin = new System.Windows.Forms.Padding(2);
			this.btnShowKeypad.Name = "btnShowKeypad";
			this.btnShowKeypad.Size = new System.Drawing.Size(111, 21);
			this.btnShowKeypad.TabIndex = 12;
			this.btnShowKeypad.Text = "tastierino";
			this.btnShowKeypad.UseVisualStyleBackColor = true;
			this.btnShowKeypad.Click += new System.EventHandler(this.BtnShowKeypadClick);
			// 
			// keyPad
			// 
			this.keyPad.Location = new System.Drawing.Point(9, 398);
			this.keyPad.Margin = new System.Windows.Forms.Padding(2);
			this.keyPad.Name = "keyPad";
			this.keyPad.Size = new System.Drawing.Size(115, 116);
			this.keyPad.TabIndex = 6;
			this.keyPad.Visible = false;
			this.keyPad.Load += new System.EventHandler(this.KeyPadLoad);
			this.keyPad.KeyPressed += new ContaQ.NumericKeyPad.OnKeyPressed(this.KeyPadKeyPressed);
			// 
			// comboProvider
			// 
			this.comboProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboProvider.FormattingEnabled = true;
			this.comboProvider.Location = new System.Drawing.Point(4, 112);
			this.comboProvider.Name = "comboProvider";
			this.comboProvider.Size = new System.Drawing.Size(121, 21);
			this.comboProvider.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.PaleTurquoise;
			this.label4.Location = new System.Drawing.Point(3, 92);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 19);
			this.label4.TabIndex = 10;
			this.label4.Text = "provider";
			// 
			// btnRecord
			// 
			this.btnRecord.BackColor = System.Drawing.Color.Lime;
			this.btnRecord.Location = new System.Drawing.Point(22, 257);
			this.btnRecord.Margin = new System.Windows.Forms.Padding(2);
			this.btnRecord.Name = "btnRecord";
			this.btnRecord.Size = new System.Drawing.Size(92, 31);
			this.btnRecord.TabIndex = 9;
			this.btnRecord.Text = "&registra";
			this.btnRecord.UseVisualStyleBackColor = false;
			this.btnRecord.Click += new System.EventHandler(this.BtnRecordClick);
			// 
			// btnHold
			// 
			this.btnHold.Location = new System.Drawing.Point(22, 338);
			this.btnHold.Margin = new System.Windows.Forms.Padding(2);
			this.btnHold.Name = "btnHold";
			this.btnHold.Size = new System.Drawing.Size(92, 31);
			this.btnHold.TabIndex = 8;
			this.btnHold.Text = "&pausa";
			this.btnHold.UseVisualStyleBackColor = true;
			this.btnHold.Click += new System.EventHandler(this.BtnHoldClick);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.PaleTurquoise;
			this.label3.Location = new System.Drawing.Point(2, 140);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 19);
			this.label3.TabIndex = 7;
			this.label3.Text = "numero";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.PaleTurquoise;
			this.label2.Location = new System.Drawing.Point(2, 51);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 19);
			this.label2.TabIndex = 6;
			this.label2.Text = "nome operatore";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.PaleTurquoise;
			this.label1.Location = new System.Drawing.Point(2, 8);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 19);
			this.label1.TabIndex = 5;
			this.label1.Text = "configurazione";
			// 
			// lblOperator
			// 
			this.lblOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOperator.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lblOperator.Location = new System.Drawing.Point(2, 69);
			this.lblOperator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblOperator.Name = "lblOperator";
			this.lblOperator.Size = new System.Drawing.Size(119, 19);
			this.lblOperator.TabIndex = 6;
			this.lblOperator.Text = "{none}";
			// 
			// lblAccount
			// 
			this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAccount.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lblAccount.Location = new System.Drawing.Point(2, 27);
			this.lblAccount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblAccount.Name = "lblAccount";
			this.lblAccount.Size = new System.Drawing.Size(119, 32);
			this.lblAccount.TabIndex = 5;
			this.lblAccount.Text = "{none}";
			// 
			// phoBrow
			// 
			this.phoBrow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.phoBrow.Location = new System.Drawing.Point(0, 0);
			this.phoBrow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.phoBrow.Name = "phoBrow";
			this.phoBrow.Size = new System.Drawing.Size(363, 602);
			this.phoBrow.TabIndex = 4;
			this.phoBrow.Load += new System.EventHandler(this.PhoBrowLoad);
			this.phoBrow.MyTitleChanged += new ContaQ.TitleChanged(this.PhoBrowTitleChanged);
			this.phoBrow.MySipRequest += new ContaQ.SipRequest(this.PhoBrowSipRequest);
			this.phoBrow.MyStatusChanged += new ContaQ.StatusChanged(this.PhoBrowStatusChanged);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.sipStatusLabel,
									this.browserStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 580);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
			this.statusStrip.Size = new System.Drawing.Size(363, 22);
			this.statusStrip.TabIndex = 5;
			this.statusStrip.Text = "statusStrip1";
			// 
			// sipStatusLabel
			// 
			this.sipStatusLabel.Name = "sipStatusLabel";
			this.sipStatusLabel.Size = new System.Drawing.Size(87, 17);
			this.sipStatusLabel.Text = "Phone not ready";
			// 
			// browserStatusLabel
			// 
			this.browserStatusLabel.Name = "browserStatusLabel";
			this.browserStatusLabel.Size = new System.Drawing.Size(77, 17);
			this.browserStatusLabel.Text = "Browser ready";
			// 
			// timerBlink
			// 
			this.timerBlink.Interval = 1000;
			this.timerBlink.Tick += new System.EventHandler(this.TimerBlinkTick);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ContaQForm
			// 
			this.AcceptButton = this.btnCall;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnRelease;
			this.ClientSize = new System.Drawing.Size(494, 602);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.phoBrow);
			this.Controls.Add(this.topPanel);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ContaQForm";
			this.Text = "contaQ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.ContaQFormLoad);
			this.topPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
			this.panelAdvanced.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnShowKeypad;
		private System.Windows.Forms.ComboBox comboProvider;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btnMute;
		private ContaQ.NumericKeyPad keyPad;
		private System.Windows.Forms.Timer timerBlink;
		private System.Windows.Forms.Button btnHome;
		private System.Windows.Forms.Panel panelAdvanced;
		private System.Windows.Forms.PictureBox picLogo;
		private System.Windows.Forms.Button btnRecord;
		private System.Windows.Forms.Button btnHold;
		private System.Windows.Forms.Button btnTransfer;
		private System.Windows.Forms.Button btnOpenUrl;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblAccount;
		private System.Windows.Forms.Label lblOperator;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripStatusLabel browserStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel sipStatusLabel;
		private System.Windows.Forms.StatusStrip statusStrip;
		private ContaQ.SipAwareBrowser phoBrow;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Button btnShowMainform;
		private System.Windows.Forms.Button btnAnswer;
		private System.Windows.Forms.Button btnRelease;
		private System.Windows.Forms.TextBox txtNumber;
		private System.Windows.Forms.Button btnCall;
		
		void PicLogoDoubleClick(object sender, System.EventArgs e)
		{
			
		}
	}
}
