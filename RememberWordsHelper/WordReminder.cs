using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace RememberWordsHelper
{
	class WordReminder
	{
		private List<WordStruct> words;
		private string fileName;
		private Random rnd;
		public WordReminder()
		{
			words = new List<WordStruct>();
			rnd = new Random();
			fileName = "words.txt";
			LoadWords();
		}
		public WordStruct Next()
		{
			bool show = false;
			WordStruct word = null;
			while (!show)
			{
				word = words[rnd.Next(0, words.Count)];
				TimeSpan addSpan = DateTime.Now - word.Time;
				TimeSpan lastSpan = DateTime.Now - word.LastShow;
				if (addSpan.Days < 2 && lastSpan.Hours > 1)
				{
					show = true;
				}
				else if (addSpan.Days < 7 && lastSpan.Hours > 24)
				{
					show = true;
				}
				else if (addSpan.Days < 30 && lastSpan.Days > 7)
				{
					show = true;
				}
			}
			word.LastShow = DateTime.Now;
			return word;
		}
		public void Close()
		{
			SaveWords();			
		}
		private void LoadWords()
		{
			StreamReader sr = null;
			try
			{
				sr = new StreamReader(fileName);
				while (!sr.EndOfStream)
				{
					string[] str = sr.ReadLine().Split(";".ToArray());
					WordStruct wordStruct = new WordStruct
					{
						Eng = str[0],
						Ukr = str[1],
						Time = DateTime.ParseExact(str[2], "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture)
					};
					words.Add(wordStruct);
				}
			}
			catch(Exception ex)
			{
				throw new FileLoadException(ex.Message);
			}
			finally
			{
				if (sr != null)
				{
					sr.Close();
				}
			}
		}
		private void SaveWords()
		{
			StreamWriter sw = null;
			try
			{
				sw = new StreamWriter(fileName);
				foreach(WordStruct ws in words)
				{
					sw.WriteLine($"{ws.Eng};{ws.Ukr};{ws.Time.ToString()}");
				}
			}
			catch (Exception ex)
			{
				throw new FileLoadException(ex.Message);
			}
			finally
			{
				if (sw != null)
				{
					sw.Close();
				}
			}
		}
		public void AddWord(string en, string ua)
		{
			WordStruct wordStruct = new WordStruct()
			{
				Eng = en,
				Ukr = ua,
				Time = DateTime.Now,
				LastShow = DateTime.Now,
				CountShow = 0
			};
			words.Add(wordStruct);
		}
	}
}
