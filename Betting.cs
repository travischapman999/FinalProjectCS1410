using System;
using System.Collections.Generic;
using System.Text;
using HorseStuff;
using PlayerStuff;

namespace BettingStuff
{
	public static class Betting
	{
		public static async Task<(string HorseName, double BetPlaced)> PlaceBet(List<Horse> stable, Player player)
		{
			int Bet = 0;
			Console.WriteLine("What horse would you like to bet on?");
			foreach (var horse in stable)
			{
				Console.Write($"{horse.Name}: ");
				Console.WriteLine($"{horse.BetMultiplyer} to 1");
			}
			string BetOnHorse = Console.ReadLine();
			while (!stable.Any(h => h.Name.ToLower() == BetOnHorse.ToLower()))
			{
				//Change this to be a throw exception try catch instead of just a cw
				Console.WriteLine("Invalid horse. Try again:");
				BetOnHorse = Console.ReadLine();
			}
			Console.WriteLine("How much would you like to bet?");
			int AttemptedBet;
			while (!int.TryParse(Console.ReadLine(), out AttemptedBet) || AttemptedBet <= 0 || AttemptedBet > player.Money)
			{
				//Change this to be a throw exception try catch instead of just a cw
				Console.WriteLine("Invalid bet. Try again:");
			}
			Bet = AttemptedBet;
			return (BetOnHorse, Bet);
		}
	}
}
