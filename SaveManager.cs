using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using PlayerStuff;
using HorseStuff;

namespace SavingStuff
{
	public static class SaveManager
	{
		public static string PlayerPath = @"C:\Users\trach\source\repos\FinalProjectCS1410\PlayerData.json";
		public static string HorsePath = @"C:\Users\trach\source\repos\FinalProjectCS1410\HorseData.json";
		public static void Save(Player player)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			string objectToJson = JsonSerializer.Serialize(player, options);
			File.WriteAllText(PlayerPath, objectToJson);
		}
		public static void Save(Horse horse)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			string objectToJson = JsonSerializer.Serialize(horse, options);
			File.WriteAllText(HorsePath, objectToJson);
		}
		public static void Save(List<Horse> horses)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			string objectToJson = JsonSerializer.Serialize(horses, options);
			File.WriteAllText(HorsePath, objectToJson);
		}
		public static void Save(List<Player> players)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			string objectToJson = JsonSerializer.Serialize(players, options);
			File.WriteAllText(PlayerPath, objectToJson);
		}
		public static List<Player> LoadPlayers()
		{
			string playerData = File.ReadAllText(PlayerPath);
			if (playerData != "\r\n")
			{
				List<Player> players = JsonSerializer.Deserialize<List<Player>>(playerData);
				return players;
			}
			else
			{
				List<Player> players = new List<Player> { new Player("Test_player") };
				return players;
			}
		}
		public static List<Horse> LoadHorses()
		{
			string HorseData = File.ReadAllText(HorsePath);
			List<Horse> test = JsonSerializer.Deserialize<List<Horse>>(HorseData);
			return test;
		}
		public static void ResetPlayers(List<Player> players)
		{
			foreach (Player player in players)
			{
				player.ResetMoney();
			}
			Save(players);
		}
		public static void ResetHorses(List<Horse> stable)
		{
			foreach (Horse horse in stable)
			{
				horse.ResetWins();
			}
			Save(stable);
		}
	}
}
