using System;
using System.Collections.Generic;
using System.Text;
using HorseStuff;
using PlayerStuff;
using static BettingStuff.Betting;

namespace RacingStuff
{
	public static class Races
	{
		public static async Task Race(List<Horse> stable, Player player)
		{
			Console.WriteLine($"Welcome to the Horse Track {player.Name}.");
			var (horseName, betPlaced) = await PlaceBet(stable, player);
			player.PlaceBet(betPlaced, horseName);
			player.PrintMoney();
			Console.WriteLine("Welcome to today's race");
			Console.WriteLine($"Today is {DateTime.Now.DayOfWeek}");
			var tasks = stable.Select(h => h.StartRace()).ToList();
			var WinningHorse = await Task.WhenAny(tasks).Result;
			Console.WriteLine($"{WinningHorse} won the race");
			Horse HorseWinner = stable.FirstOrDefault(h => h.Name == WinningHorse);

			if (player.HorseBet == WinningHorse)
			{
				Console.WriteLine($"{player.Name} won the bet.");
				player.ClaimPrize(player.BetPlaced * HorseWinner.BetMultiplyer);
				player.PrintMoney();
			}
			else
			{
				Console.WriteLine($"{player.Name} lost the bet");
			}


		}
		public static async Task Race(List<Horse> stable, List<Player> players)
		{
			foreach (Player player in players)
			{
				Console.WriteLine($"Welcome to the Horse Track {player.Name}.");
				var (horseName, betPlaced) = await PlaceBet(stable, player);
				player.PlaceBet(betPlaced, horseName);
				player.PrintMoney();
			}
			Console.WriteLine("Welcome to today's race");
			Console.WriteLine($"Today is {DateTime.Now.DayOfWeek}");
			var tasks = stable.Select(h => h.StartRace()).ToList();
			string WinningHorse = await Task.WhenAny(tasks).Result;
			Console.WriteLine($"{WinningHorse} won the race");
			Horse HorseWinner = stable.FirstOrDefault(h => h.Name == WinningHorse);
			HorseWinner.Wins += 1;
			foreach (Player player in players)
			{
				if (player.HorseBet.ToLower() == WinningHorse.ToLower())
				{
					Console.WriteLine($"{player.Name} won the bet.");
					player.ClaimPrize(player.BetPlaced * HorseWinner.BetMultiplyer);
					player.PrintMoney();
				}
				else
				{
					Console.WriteLine($"{player.Name} lost the bet");
				}
			}
		}
	}
}
