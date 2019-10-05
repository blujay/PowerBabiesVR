using System;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerList
{
	public static event Action OnPlayerChanges;

	public static IReadOnlyDictionary<string, PlayerDetails> AllPlayers;

	private static Dictionary<string, PlayerDetails> allPlayers;

	static PlayerList ()
	{
		allPlayers = new Dictionary<string, PlayerDetails> ();
		AllPlayers = allPlayers;
	}

	public static void DiscoverPlayer (PlayerDetails details)
	{
		Debug.Log ("Discovering a " + details.Identifier);

		allPlayers.Add (details.Identifier, details);

		if (OnPlayerChanges != null)
		{
			OnPlayerChanges ();
		}
	}

	public static void ForgetPlayer (PlayerDetails details)
	{
		allPlayers.Remove (details.Identifier);

		if (OnPlayerChanges != null)
		{
			OnPlayerChanges ();
		}
	}

	public static void Reset ()
	{
		allPlayers.Clear ();

		if (OnPlayerChanges != null)
		{
			OnPlayerChanges ();
		}
	}
}
