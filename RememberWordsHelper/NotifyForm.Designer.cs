namespace RememberWordsHelper
{
	partial class NotifyForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lWord = new System.Windows.Forms.Label();
			this.lTranslate = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lWord
			// 
			this.lWord.AutoSize = true;
			this.lWord.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lWord.Location = new System.Drawing.Point(13, 13);
			this.lWord.Name = "lWord";
			this.lWord.Size = new System.Drawing.Size(72, 28);
			this.lWord.TabIndex = 0;
			this.lWord.Text = "label1";
			// 
			// lTranslate
			// 
			this.lTranslate.AutoSize = true;
			this.lTranslate.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lTranslate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lTranslate.Location = new System.Drawing.Point(13, 41);
			this.lTranslate.Name = "lTranslate";
			this.lTranslate.Size = new System.Drawing.Size(106, 28);
			this.lTranslate.TabIndex = 1;
			this.lTranslate.Text = "lTranslate";
			// 
			// NotifyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(130)))));
			this.ClientSize = new System.Drawing.Size(184, 80);
			this.ControlBox = false;
			this.Controls.Add(this.lTranslate);
			this.Controls.Add(this.lWord);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NotifyForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "NotifyForm";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lWord;
		private System.Windows.Forms.Label lTranslate;
	}
}