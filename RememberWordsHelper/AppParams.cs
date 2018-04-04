using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberWordsHelper
{
	public class AppParams
	{
		public int HowLongShow { get; set; }
		public int Max1 { get; set; }
		public int Max2 { get; set; }
		public int Max3 { get; set; }
		public int Freq1 { get; set; }
		public int Freq2 { get; set; }
		public int Freq3 { get; set; }
		public AppParams()
		{
			SetDefault();
		}
		public void SetDefault()
		{
			HowLongShow = 10;
			Max1 = 48;
			Max2 = 7;
			Max3 = 30;
			Freq1 = 1;
			Freq2 = 12;
			Freq3 = 4; 
		}

	}
}
