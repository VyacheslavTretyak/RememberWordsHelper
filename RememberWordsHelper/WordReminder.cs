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
		private List<WordStruct> archive;
		private string dataFileName;
		private string archiveFileName;
		private Random rnd;
		private int next;
		private AppParams param;
		public WordReminder(AppParams _param)
		{
			param = _param;
			words = new List<WordStruct>();
			archive = new List<WordStruct>();
			dataFileName = "words.txt";
			archiveFileName = "archive.txt";
			rnd = new Random();
			LoadWords();
			
		}
		public WordStruct Next()
		{
			WordStruct word = null;
			bool isShow = false;
			while (!isShow)
			{				
				if(next >= words.Count)
				{
					break;
				}
				word = words[next++];
				TimeSpan lastShow = DateTime.Now - word.LastShow;
				TimeSpan added = DateTime.Now - word.Time;
				if (added.TotalHours < param.Max1 && lastShow.TotalHours > param.Freq1)
				{
					isShow = true;
				}
				else if (added.TotalDays < param.Max2 && lastShow.TotalHours > param.Freq2)
				{
					isShow = true;
				}
				else if (added.TotalDays < param.Max3 && lastShow.TotalDays > param.Freq3)
				{
					isShow = true;
				}
				else
				{
					words.Remove(word);
					archive.Add(word);
				}
			}			
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
				sr = new StreamReader(dataFileName);
				while (!sr.EndOfStream)
				{
					string[] str = sr.ReadLine().Split(";".ToArray());
					WordStruct wordStruct = new WordStruct
					{
						Eng = str[0],
						Ukr = str[1],
						Time = DateTime.ParseExact(str[2], "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture),
						LastShow = DateTime.ParseExact(str[3], "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture)
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
		private void Shuffle()
		{
			List<WordStruct> newList = new List<WordStruct>();
			Random rnd = new Random();
			while(words.Count > 0)
			{
				int r = rnd.Next(0, words.Count);
				newList.Add(words[r]);
				words.RemoveAt(r);
			}
			words = newList;
		}
		private void SaveWords()
		{
			StreamWriter swWords = null;
			StreamWriter swArchive = null;
			try
			{				
				swWords = new StreamWriter(dataFileName);
				foreach (WordStruct ws in words)
				{
					swWords.WriteLine($"{ws.Eng};{ws.Ukr};{ws.Time.ToString()};{ws.LastShow.ToString()}");
				}
				swArchive = new StreamWriter(archiveFileName, true);
				foreach (WordStruct ws in archive)
				{
					swArchive.WriteLine($"{ws.Eng};{ws.Ukr};{ws.Time.ToString()};{ws.LastShow.ToString()}");					
				}
			}
			catch (Exception ex)
			{
				throw new FileLoadException(ex.Message);
			}
			finally
			{
				if (swWords != null)
				{
					swWords.Close();
				}
				if (swArchive != null) ;
				{
					swArchive.Close();
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
				LastShow = DateTime.Now
			};
			words.Add(wordStruct);
		}
	}
}
