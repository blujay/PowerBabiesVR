using Normal.Realtime;
using System;
using UnityEngine;

public class PlayerDetails : RealtimeComponent
{
	public string Identifier;

	public PlayerDetailsSyncModel Details;

	private void Start ()
	{
		var realtimeView = GetComponent<RealtimeView> ();

		Identifier = GetInstanceID().ToString();

		PlayerList.DiscoverPlayer (this);

		Details.name = Environment.UserName;
	}

	private void OnDestroy ()
	{
		PlayerList.ForgetPlayer (this);
	}

	private void Update()
	{
		if (realtimeView.isOwnedLocally)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				Details.name += 2;
			}
		}
	}
}
