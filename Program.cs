using System.Xml.Linq;
using CustomEnums;
using CustomExceptions;
using HorseStuff;
using PlayerStuff;
using SavingStuff;
using static RacingStuff.Races;
using static StaticStuff.MiscellaneousStatic;
namespace program
{
	public class Program
	{
		public static void Main()
		{
			List<Horse> Stable = SaveManager.LoadHorses();
			List<Player> Players = SaveManager.LoadPlayers();
			Console.WriteLine("Are you a new better? y/n");
			string answer = Console.ReadLine();
			while (true)
			{
				Player? testPlayer = Players.FirstOrDefault(n => n.Name.Equals("Test_player", StringComparison.OrdinalIgnoreCase));
				if (testPlayer != null)
				{
					Players.Remove(testPlayer);
				}
				if (answer.ToLower() == "y")
				{
					Console.WriteLine("What is your name?");
					string? inputName = Console.ReadLine();
					if (!string.IsNullOrEmpty(inputName) && !Players.Contains(FindPlayerInList(Players, inputName)))
					{
						string Name = FixNameCasing(inputName);
						Players.Insert(0, new Player(Name));
						break;
					}
					else
					{
						try
						{
							throw new InvalidInputException();
						}
						catch (InvalidInputException exception)
						{
							Console.WriteLine(exception.Message);
						}
						Console.WriteLine("Are you a new better? y/n");
						answer = Console.ReadLine();
					}
				}
				else if (answer.ToLower() == "n")
				{
					Console.WriteLine("What is your name?");
					string name = Console.ReadLine();
					Player? player = FindPlayerInList(Players, name);
					if (player != null)
					{
						MovePlayerToFrontOfList(Players, player);
						Console.WriteLine($"Welcome back {player.Name}.");
						break;
					}
					else
					{
						try
						{
							throw new PlayerNotFoundException();
						}
						catch (PlayerNotFoundException exception)
						{
							Console.WriteLine(exception.Message);
						}
						Console.WriteLine("Are you a new better? y/n");
						answer = Console.ReadLine();
					}
				}
				else
				{
					try
					{
						throw new InvalidInputException();
					}
					catch (InvalidInputException exception)
					{
						Console.WriteLine(exception.Message);
					}
					Console.WriteLine("Are you a new better? y/n");
					answer = Console.ReadLine();
				}
			}
			bool running = true;
			while (running)
			{
				Console.WriteLine("Would you like to place a bet? (Type number not word)");
				foreach (var option in Enum.GetValues(typeof(MyEnums)))
				{
					Console.WriteLine($"{(int)option}: {option}");
				}
				int.TryParse(Console.ReadLine(), out int Selection);
				MyEnums Continue = (MyEnums)Selection;
				switch (Continue)
				{
					case MyEnums.PlaceBet:
						{
							Race(Stable, Players);
							break;
						}
					case MyEnums.EndBetting:
						{
							running = false;
							break;
						}
					case MyEnums.Reset:
						{
							SaveManager.ResetPlayers(Players);
							SaveManager.ResetHorses(Stable);
							Console.WriteLine("Data Reset...");
							break;
						}
					default:
						{
							try
							{
								throw new InvalidInputException();
							}
							catch (InvalidInputException exception)
							{
								Console.WriteLine(exception.Message);
							}
							break;
						}
				}
			}
			SaveManager.Save(Players);
			SaveManager.Save(Stable);
		}
	}
}
