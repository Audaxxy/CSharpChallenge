using System;
using System.IO;
namespace CSharpChallenge
{
	
	class globals
	{
		
		public static int[] fileContentIntegers;
		public static string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\src\","*.txt");
		
	}
	static class Program
	{
		static void LoadFile(string file)
		{
			string[] fileContents = File.ReadAllLines(file);

			globals.fileContentIntegers = new int[fileContents.Length];
			int iterator = 0;
			foreach (string line in fileContents)
			{
				int lineInt = Convert.ToInt32(line);


				globals.fileContentIntegers[iterator] = lineInt;
				iterator++;
			}
			Array.Sort(globals.fileContentIntegers);
		}

		static void Main()
		{
			
			for (int i = 0; i < globals.files.Length ; i++)
			{
				LoadFile(globals.files[i]);

				int[] fileContentIntegers = globals.fileContentIntegers;
				int timesOccurred = 0;
				int currentInt = fileContentIntegers[0];
				int occuranceRecord = int.MaxValue;
				int leastPopular = int.MaxValue;
				
				for (int j = 0; j < fileContentIntegers.Length - 1; j++)
				{
					if (fileContentIntegers[j] == currentInt)
					{
						timesOccurred++;
					}
					else
					{
						if (timesOccurred < occuranceRecord)
						{
							occuranceRecord = timesOccurred;
							leastPopular = fileContentIntegers[j - 1];
						}
						currentInt = fileContentIntegers[j];
						timesOccurred = 0;
						timesOccurred++;
					}
				}
				Console.WriteLine((i+1)+": File: "+globals.files[i] + " Number: " + leastPopular + ", Repeated " + occuranceRecord + " time(s)");
				
			}
			Console.Read();
		}
	}
}
