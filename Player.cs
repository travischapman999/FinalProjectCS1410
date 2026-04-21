using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Savables;
using SavingStuff;

namespace PlayerStuff
{
	public class Player : ISavable
	{
		[JsonInclude]
		public string Name { get;  private set; }
		[JsonInclude]
		public double Money { get;  private set; }
		[JsonIgnore]
		public string HorseBet { get; private set; }
		[JsonIgnore]
		public double BetPlaced { get; private set; }
		public Player() { }
		public Player(string name)
		{
			Name = name;
			Money = 1000;
		}
		public void PlaceBet(double amount, string horse)
		{
			Money -= amount;
			HorseBet = horse;
			BetPlaced = amount;
		}
		public void ClaimPrize(double amount)
		{
			Money += amount;
		}
		public void PrintMoney()
		{
			Console.WriteLine($"You have ${Money}");
		}
		public void ResetMoney()
		{
			Money = 1000;
		}
		public void Save()
		{
			SaveManager.Save(this);
		}
	}
}
