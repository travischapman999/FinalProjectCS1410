using PlayerStuff;
using static StaticStuff.MiscellaneousStatic;

namespace FinalProjectCS1410.Tests
{
	public class ListLogicTests
	{
		[Fact]
		public void Move_Existing_Player_to_Front_Of_List()
		{
			List<Player> players = new List<Player>
			{
				new Player("Bob"),
				new Player("Travis"),
				new Player("James")
			};
			Player player = players.First(p => p.Name == "Travis");
			MovePlayerToFrontOfList(players, player);
			Assert.Equal("Travis", players[0].Name);
		}
		[Fact]
		public void Add_New_Player_To_Front_Of_List()
		{
			List<Player> players = new List<Player>
			{
				new Player("Travis"),
				new Player("Bob"),
				new Player("James")
			};
			players.Insert(0, new Player("John"));
			Assert.Equal("John", players[0].Name);
		}
	}
}
