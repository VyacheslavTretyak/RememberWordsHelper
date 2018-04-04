using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RememberWordsHelper
{
	
	public partial class RememberWordsForm : Form
	{
		private Color nonTextColor;
		private Color textColor;
		private WordReminder wordReminder;
		private bool isShow = false;
		private Timer timer;
		private NotifyForm notifyForm;
		private ParamsForm paramsForm;		
		public AppParams Params { get; set; }
		public RememberWordsForm()
		{
			InitializeComponent();
			notifyForm = new NotifyForm();
			paramsForm = new ParamsForm();

			try
			{
				Params = paramsForm.LoadParam();
				wordReminder = new WordReminder(Params);				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			Load += RemeberWordsForm_Load;
			FormClosing += RemeberWordsForm_FormClosing;
			Resize += RemeberWordsForm_Resize;
			Shown += RemeberWordsForm_Shown;
			LoadTexBoxs();
			LoadTimer();

			btnAdd.Click += BtnAdd_Click;
			btnParam.Click += BtnParam_Click;
			notifyIcon1.Click += NotifyIcon1_Click;
		}

		private void BtnParam_Click(object sender, EventArgs e)
		{
			Size scr = Screen.PrimaryScreen.WorkingArea.Size;
			paramsForm.Location = new Point(scr.Width - paramsForm.Size.Width, scr.Height - paramsForm.Size.Height);
			paramsForm.ShowDialog(Params);
		}

		private void RemeberWordsForm_Shown(object sender, EventArgs e)
		{			
			Visible = false;
			WindowState = FormWindowState.Minimized; ;
		}

		private void RemeberWordsForm_Resize(object sender, EventArgs e)
		{
			if(WindowState == FormWindowState.Minimized)
			{
				Hide();
			}			
		}
		
		private void RemeberWordsForm_Load(object sender, EventArgs e)
		{
			BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			StartPosition = FormStartPosition.Manual;
			Size scr = Screen.PrimaryScreen.WorkingArea.Size;
			Location = new Point(scr.Width - Size.Width, scr.Height - Size.Height);

			Icon = Properties.Resources.translate;
			notifyIcon1.Icon = Icon;
			WindowState = FormWindowState.Minimized;		
		}
		private void LoadTimer()
		{
			timer = new Timer();
			timer.Interval = 10000;
			timer.Start();
			timer.Tick += Timer_Tick;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			WordStruct word = wordReminder.Next();
			if (word != null)
			{
				notifyForm.Show(word);
			}
		}

		private void NotifyIcon1_Click(object sender, EventArgs e)
		{			
			isShow = !isShow;
			if (isShow)
			{
				Show();
				WindowState = FormWindowState.Normal;					
			}
			else
			{
				WindowState = FormWindowState.Minimized;				
			}
		}

		private void RemeberWordsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				paramsForm.SaveParam(Params);
				wordReminder.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			if(tbEng.Text.Length > 0 && tbUkr.Text.Length > 0)
			{
				wordReminder.AddWord(tbEng.Text, tbUkr.Text);
				LoadTexBoxs();
			}
		}

		private void LoadTexBoxs()
		{
			nonTextColor = System.Drawing.SystemColors.ControlDark;
			textColor = System.Drawing.SystemColors.ControlText;
			tbEng.Text = "EN";
			tbEng.Tag = tbEng.Text;
			tbEng.ForeColor = nonTextColor;
			tbEng.Enter += Tb_Enter;
			tbEng.Leave += Tb_Leave;
			tbUkr.Text = "UA";
			tbUkr.Tag = tbUkr.Text;
			tbUkr.ForeColor = nonTextColor;
			tbUkr.Enter += Tb_Enter;
			tbUkr.Leave += Tb_Leave;
		}
		private void Tb_Leave(object sender, EventArgs e)
		{
			TextBox tb = sender as TextBox;
			if(tb.Text == "")
			{
				tb.Text = tb.Tag.ToString();
				tb.ForeColor = nonTextColor;
			}
		}
		private void Tb_Enter(object sender, EventArgs e)
		{
			TextBox tb = sender as TextBox;
			tb.Text = "";
			tb.ForeColor = textColor;
		}		

		private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
