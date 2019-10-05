using Normal.Realtime;
using System;
using UnityEngine;

public class PlayerDetails : RealtimeComponent
{
	public string Identifier;

	public PlayerDetailsSyncModel _model;

	private PlayerDetailsSyncModel model
	{
		set
		{
			_model = value;

			_model.name = Environment.UserName;

			PlayerList.DiscoverPlayer (this);
		}
	}

	private void Start ()
	{
		Identifier = Guid.NewGuid ().ToString ();

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
				_model.score += 2;
			}
		}
	}
}
