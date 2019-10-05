using Normal.Realtime;
using System;
using UnityEngine;

public class PlayerDetails : RealtimeComponent
{
	public string Identifier;

	public PlayerDetailsSyncModel _model;
	bool hasModel = false;
	bool isLocal = false;

	private PlayerDetailsSyncModel model
	{
		set
		{
			_model = value;
			hasModel = true;
			isLocal = realtimeView.isOwnedLocally;

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
		if (hasModel && isLocal)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				_model.score += 2;
			}
		}
	}
}
