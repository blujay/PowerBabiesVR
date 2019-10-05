using Normal.Realtime;
using System;
using UnityEngine;

public class PlayerDetails : RealtimeComponent
{
	public string Identifier;

	public PlayerDetailsSyncModel Details;

	private void Start ()
	{
		Identifier = GetInstanceID().ToString();

		Details = new PlayerDetailsSyncModel ();

		Details.name = Environment.UserName;

		PlayerList.DiscoverPlayer (this);
	}

	private void OnDestroy ()
	{
		PlayerList.ForgetPlayer (this);
	}

	private void Update()
	{
		var view = GetComponent<RealtimeView> ();

		if (view.isOwnedLocally)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				Details.score += 2;
			}
		}
	}
}
