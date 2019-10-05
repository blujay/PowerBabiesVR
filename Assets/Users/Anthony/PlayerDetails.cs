using Normal.Realtime;
using System;
using UnityEngine;

public class PlayerDetails : RealtimeComponent
{
	public string Identifier;

	public PlayerDetailsSyncModel _details;

	private PlayerDetailsSyncModel details
	{
		set
		{
			_details = value;

			_details.name = Environment.UserName;

			PlayerList.DiscoverPlayer (this);
		}
	}

	private void Start ()
	{
		Identifier = GetInstanceID ().ToString ();

		// _details = new PlayerDetailsSyncModel ();
	}

	private void OnDestroy ()
	{
		PlayerList.ForgetPlayer (this);
	}

	private void Update ()
	{
		var view = GetComponent<RealtimeView> ();

		if (view.isOwnedLocally)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				_details.score += 2;
			}
		}
	}
}
