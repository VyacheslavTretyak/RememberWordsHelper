namespace RememberWordsHelper
{
	partial class RememberWordsForm
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
			this.components = new System.ComponentModel.Container();
			this.tbEng = new System.Windows.Forms.TextBox();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.tbUkr = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnParam = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbEng
			// 
			this.tbEng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.tbEng.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbEng.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbEng.Location = new System.Drawing.Point(13, 13);
			this.tbEng.Name = "tbEng";
			this.tbEng.Size = new System.Drawing.Size(309, 40);
			this.tbEng.TabIndex = 0;
			this.tbEng.Text = "En";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "Remember Word Helper";
			this.notifyIcon1.Visible = true;
			// 
			// tbUkr
			// 
			this.tbUkr.BackColor = System.Drawing.Color.Silver;
			this.tbUkr.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbUkr.Location = new System.Drawing.Point(13, 59);
			this.tbUkr.Name = "tbUkr";
			this.tbUkr.Size = new System.Drawing.Size(310, 40);
			this.tbUkr.TabIndex = 1;
			this.tbUkr.Text = "Ua";
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnAdd.ForeColor = System.Drawing.Color.Teal;
			this.btnAdd.Location = new System.Drawing.Point(12, 105);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(250, 50);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = false;
			// 
			// btnParam
			// 
			this.btnParam.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnParam.BackgroundImage = global::RememberWordsHelper.Properties.Resources.paramImg;
			this.btnParam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnParam.ForeColor = System.Drawing.Color.Teal;
			this.btnParam.Location = new System.Drawing.Point(272, 105);
			this.btnParam.Name = "btnParam";
			this.btnParam.Size = new System.Drawing.Size(50, 50);
			this.btnParam.TabIndex = 3;
			this.btnParam.UseVisualStyleBackColor = false;
			// 
			// RemeberWordsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(334, 161);
			this.Controls.Add(this.btnParam);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.tbUkr);
			this.Controls.Add(this.tbEng);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RemeberWordsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Remember Words Helper";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbEng;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.TextBox tbUkr;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnParam;
	}
}

