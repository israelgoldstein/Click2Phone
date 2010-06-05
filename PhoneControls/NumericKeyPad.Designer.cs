/*
 * Created by SharpDevelop.
 * User: gz8vnr
 * Date: 16/02/2009
 * Time: 17.14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ContaQ
{
	partial class NumericKeyPad
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
			this.table = new System.Windows.Forms.TableLayoutPanel();
			this.button11 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnKey = new System.Windows.Forms.Button();
			this.table.SuspendLayout();
			this.SuspendLayout();
			// 
			// table
			// 
			this.table.AutoSize = true;
			this.table.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.table.ColumnCount = 3;
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.table.Controls.Add(this.button11, 2, 3);
			this.table.Controls.Add(this.button10, 1, 3);
			this.table.Controls.Add(this.button9, 0, 3);
			this.table.Controls.Add(this.button8, 2, 2);
			this.table.Controls.Add(this.button7, 1, 2);
			this.table.Controls.Add(this.button6, 0, 2);
			this.table.Controls.Add(this.button5, 2, 1);
			this.table.Controls.Add(this.button4, 1, 1);
			this.table.Controls.Add(this.button3, 0, 1);
			this.table.Controls.Add(this.button2, 2, 0);
			this.table.Controls.Add(this.button1, 1, 0);
			this.table.Controls.Add(this.btnKey, 0, 0);
			this.table.Dock = System.Windows.Forms.DockStyle.Fill;
			this.table.Location = new System.Drawing.Point(0, 0);
			this.table.Margin = new System.Windows.Forms.Padding(0);
			this.table.Name = "table";
			this.table.RowCount = 4;
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.table.Size = new System.Drawing.Size(146, 150);
			this.table.TabIndex = 1;
			// 
			// button11
			// 
			this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button11.Location = new System.Drawing.Point(98, 113);
			this.button11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(46, 35);
			this.button11.TabIndex = 11;
			this.button11.Text = "#";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// button10
			// 
			this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button10.Location = new System.Drawing.Point(50, 113);
			this.button10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(44, 35);
			this.button10.TabIndex = 10;
			this.button10.Text = "0";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// button9
			// 
			this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button9.Location = new System.Drawing.Point(2, 113);
			this.button9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(44, 35);
			this.button9.TabIndex = 9;
			this.button9.Text = "*";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// button8
			// 
			this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button8.Location = new System.Drawing.Point(98, 76);
			this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(46, 33);
			this.button8.TabIndex = 8;
			this.button8.Text = "9";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// button7
			// 
			this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button7.Location = new System.Drawing.Point(50, 76);
			this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(44, 33);
			this.button7.TabIndex = 7;
			this.button7.Text = "8";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// button6
			// 
			this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button6.Location = new System.Drawing.Point(2, 76);
			this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(44, 33);
			this.button6.TabIndex = 6;
			this.button6.Text = "7";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// button5
			// 
			this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button5.Location = new System.Drawing.Point(98, 39);
			this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(46, 33);
			this.button5.TabIndex = 5;
			this.button5.Text = "6";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// button4
			// 
			this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button4.Location = new System.Drawing.Point(50, 39);
			this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(44, 33);
			this.button4.TabIndex = 4;
			this.button4.Text = "5";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// button3
			// 
			this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button3.Location = new System.Drawing.Point(2, 39);
			this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(44, 33);
			this.button3.TabIndex = 3;
			this.button3.Text = "4";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// button2
			// 
			this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button2.Location = new System.Drawing.Point(98, 2);
			this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(46, 33);
			this.button2.TabIndex = 2;
			this.button2.Text = "3";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.Location = new System.Drawing.Point(50, 2);
			this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(44, 33);
			this.button1.TabIndex = 1;
			this.button1.Text = "2";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// btnKey
			// 
			this.btnKey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnKey.Location = new System.Drawing.Point(2, 2);
			this.btnKey.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnKey.Name = "btnKey";
			this.btnKey.Size = new System.Drawing.Size(44, 33);
			this.btnKey.TabIndex = 0;
			this.btnKey.Text = "1";
			this.btnKey.UseVisualStyleBackColor = true;
			this.btnKey.Click += new System.EventHandler(this.BtnKeyClick);
			// 
			// NumericKeyPad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.table);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "NumericKeyPad";
			this.Size = new System.Drawing.Size(146, 150);
			this.table.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.TableLayoutPanel table;
		private System.Windows.Forms.Button btnKey;
	}
}
