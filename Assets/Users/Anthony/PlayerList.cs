using System;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerList
{
	public static event Action OnPlayerChanges;

	public static IReadOnlyDictionary<int, PlayerDetails> AllPlayers;

	private static Dictionary<int, PlayerDetails> allPlayers;

	static PlayerList ()
	{
		allPlayers = new Dictionary<int, PlayerDetails> ();
		AllPlayers = allPlayers;
	}

	public static void DiscoverPlayer (PlayerDetails details)
	{
		Debug.Log ("Discovering a " + details.realtimeView.ownerID);

		allPlayers[details.realtimeView.ownerID] = details;

		if (OnPlayerChanges != null)
		{
			OnPlayerChanges ();
		}
	}

	public static void ForgetPlayer (PlayerDetails details)
	{
		allPlayers.Remove (details.realtimeView.ownerID);

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

    public static bool AllReady() 
    {
        bool result = true;
        /*
        foreach (var player in allPlayers.Values) {
            if (!player._model.isReady) {
                result = false;
                break;
            }
        }
        */
        return result;
    }
}
