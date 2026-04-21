using CustomExceptions;
using HorseStuff;
using PlayerStuff;
using SavingStuff;
using static RacingStuff.Races;
using CustomEnums;
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
				if (answer.ToLower() == "y")
				{
					Console.WriteLine("What is your name?");
					string? inputName = Console.ReadLine();
					if (!string.IsNullOrEmpty(inputName))
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
				MyEnums Continue = (MyEnums)int.Parse(Console.ReadLine());
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
