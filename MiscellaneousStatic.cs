using System.Numerics;
using PlayerStuff;
namespace StaticStuff
{
	public static class MiscellaneousStatic
	{
		public static string FixNameCasing(string name)
		{
			return char.ToUpper(name[0]) + name.Substring(1).ToLower();
		}
		public static void MovePlayerToFrontOfList(List<Player> players, Player player)
		{
			players.Remove(player);
			players.Insert(0, player);
		}
		public static Player? FindPlayerInList(List<Player> players, string name)
		{
			Player? player = players.FirstOrDefault(n => n.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
			return player;
		}
	}
}
