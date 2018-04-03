using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RememberWordsHelper
{

	public partial class NotifyForm : Form
	{
		private Timer timer;
		private WordStruct word;
		public NotifyForm()
		{
			InitializeComponent();
			Size scr = Screen.PrimaryScreen.WorkingArea.Size;
			Size = new Size(250, 100);
			StartPosition = FormStartPosition.Manual;
			Location = new Point(scr.Width - Size.Width, scr.Height - Size.Height);

			Click += NotifyForm_Click;			

			timer = new Timer();
			timer.Interval = 5000;
			timer.Tick += Timer_Tick;
		}

		private void NotifyForm_Click(object sender, EventArgs e)
		{
			lTranslate.Text = word.Ukr;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{			
			timer.Stop();
			Hide();
		}

		public DialogResult Show(WordStruct _word)
		{
			word = _word;
			Size scr = Screen.PrimaryScreen.WorkingArea.Size;
			Location = new Point(scr.Width - Size.Width, scr.Height - Size.Height);
			timer.Start();
			lWord.Text = word.Eng;
			lTranslate.Text = "";
			Show();
			return DialogResult.OK;
		}
	}
}
