using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RememberWordsHelper
{
	public partial class ParamsForm : Form
	{
		private AppParams param;
		private string paramFileName;
		public ParamsForm()
		{
			paramFileName = "param.ini";
			InitializeComponent();			
			Load += ParamsForm_Load;
			btnOk.Click += BtnOk_Click;
			btnSetDefault.Click += BtnSetDefault_Click;
			nudFreq1.ValueChanged += Nud_ValueChanged;
			nudFreq2.ValueChanged += Nud_ValueChanged;
			nudFreq3.ValueChanged += Nud_ValueChanged;
			nudMax1.ValueChanged += Nud_ValueChanged;
			nudMax2.ValueChanged += Nud_ValueChanged;
			nudMax3.ValueChanged += Nud_ValueChanged;
			nudHowLong.ValueChanged += Nud_ValueChanged;
		}

		private void Nud_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown nud = sender as NumericUpDown;
			if(nud.Value < 1)
			{
				nud.Value = 1;
			}
		}

		private void BtnSetDefault_Click(object sender, EventArgs e)
		{
			param.SetDefault();
			SetValue();
		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			param.HowLongShow = (int)nudHowLong.Value;
			param.Max1 = (int)nudMax1.Value;
			param.Max2 = (int)nudMax2.Value;
			param.Max3 = (int)nudMax3.Value;
			param.Freq1 = (int)nudFreq1.Value;
			param.Freq2 = (int)nudFreq2.Value;
			param.Freq3 = (int)nudFreq3.Value;		
			DialogResult = DialogResult.OK;
		}
		private void SetValue()
		{
			nudHowLong.Value = param.HowLongShow;
			nudMax1.Value = param.Max1;
			nudMax2.Value = param.Max2;
			nudMax3.Value = param.Max3;
			nudFreq1.Value = param.Freq1;
			nudFreq2.Value = param.Freq2;
			nudFreq3.Value = param.Freq3;
		}

		private void ParamsForm_Load(object sender, EventArgs e)
		{
			Icon = Properties.Resources.param;
		}
		public DialogResult ShowDialog(AppParams _param)
		{
			param = _param;
			SetValue();
			return ShowDialog();
		}
		public AppParams LoadParam()
		{
			StreamReader loader = null;
			param = new AppParams();
			try
			{
				loader = new StreamReader(paramFileName);
				string[] str = loader.ReadLine().Split("=".ToArray());
				param.HowLongShow = int.Parse(str[1]);

				str = loader.ReadLine().Split("=".ToArray());
				param.Max1 = int.Parse(str[1]);

				str = loader.ReadLine().Split("=".ToArray());
				param.Freq1 = int.Parse(str[1]);

				str = loader.ReadLine().Split("=".ToArray());
				param.Max2 = int.Parse(str[1]);

				str = loader.ReadLine().Split("=".ToArray());
				param.Freq2 = int.Parse(str[1]);

				str = loader.ReadLine().Split("=".ToArray());
				param.Max3 = int.Parse(str[1]);

				str = loader.ReadLine().Split("=".ToArray());
				param.Freq3 = int.Parse(str[1]);				
			}
			catch
			{
				param = new AppParams();
			}
			finally
			{
				if (loader != null)
				{
					loader.Close();
				}
			}
			return param;
		}
		public void SaveParam(AppParams _param)
		{
			StreamWriter saver = null;
			try
			{
				saver= new StreamWriter(paramFileName);
				saver.WriteLine($"HowLongShow={_param.HowLongShow}");
				saver.WriteLine($"Max1={_param.Max1}");
				saver.WriteLine($"Freq1={_param.Freq1}");
				saver.WriteLine($"Max2={_param.Max2}");
				saver.WriteLine($"Freq2={_param.Freq2}");
				saver.WriteLine($"Max3={_param.Max3}");
				saver.WriteLine($"Freq3={_param.Freq3}");
			}
			catch (Exception ex)
			{
				throw new FileLoadException(ex.Message);
			}
			finally
			{
				if (saver != null)
				{
					saver.Close();
				}
			}
		}
	}
}

