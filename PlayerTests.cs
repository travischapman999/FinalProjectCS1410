using PlayerStuff;
using static StaticStuff.MiscellaneousStatic;
namespace FinalProjectCS1410.Tests
{
	public class PlayerTests
	{
		[Fact]
		public void Return_Player_If_Found()
		{
			List<Player> players = new List<Player>
			{
				new Player("Travis"),
				new Player("Bob"),
				new Player("James")
			};
			Player? result = FindPlayerInList(players, "travis");

			Assert.NotNull(result);
		}
		[Fact]
		public void Return_Null_If_Not_Found()
		{
			List<Player> players = new List<Player>
			{
				new Player("Travis"),
				new Player("Bob"),
				new Player("James")
			};
			Player? result = FindPlayerInList(players, "karen");

			Assert.Null(result);
		}
		[Fact]
		public void Test_If_Letter_Casing_Correct()
		{
			string inputName = "JoHN";
			string actualName = FixNameCasing(inputName);
			Assert.Equal("John", actualName);
		}
	}
}
