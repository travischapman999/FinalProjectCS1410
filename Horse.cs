using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Savables;
using SavingStuff;

namespace HorseStuff
{
	public class Horse : ISavable
	{
		[JsonIgnore]
		private Random random = new Random();
		[JsonInclude]
		public string Name { get; private set; }
		[JsonIgnore]
		public double BetMultiplyer { get; private set; }
		[JsonInclude]
		public int Wins { get; set; }
		public Horse(string name)
		{
			double min = 1.5;
			double max = 3.5;
			Name = name;
			BetMultiplyer = Math.Round(random.NextDouble() * (max - min) + min,2);
		}
		public async Task<string> StartRace()
		{
			int speed = random.Next(1000, 5000);
			await Task.Delay(speed);
			return Name;
		}
		public void Save()
		{
			SaveManager.Save(this);
		}
		public void ResetWins()
		{
			Wins = 0;
		}
	}
}
