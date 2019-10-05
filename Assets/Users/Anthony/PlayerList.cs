using System.Collections.Generic;

public static class PlayerList
{
	public static IReadOnlyDictionary<string, PlayerDetails> AllPlayers;

	private static Dictionary<string, PlayerDetails> allPlayers;

	static PlayerList ()
	{
		allPlayers = new Dictionary<string, PlayerDetails> ();
		AllPlayers = allPlayers;
	}

	public static void DiscoverPlayer (PlayerDetails details)
	{
		allPlayers.Add (details.Identifier, details);
	}

	public static void ForgetPlayer (PlayerDetails details)
	{
		allPlayers.Remove (details.Identifier);
	}

	public static void Reset ()
	{
		allPlayers.Clear ();
	}
}
