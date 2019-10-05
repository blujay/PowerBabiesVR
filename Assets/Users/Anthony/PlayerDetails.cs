using Normal.Realtime;
using System;

public class PlayerDetails : RealtimeComponent
{
	public string Identifier;

	public PlayerDetailsSyncModel Details;

	private void Start ()
	{
		var realtimeView = GetComponent<RealtimeView> ();

		Identifier = Convert.ToBase64String (realtimeView.sceneViewUUID);

		PlayerList.DiscoverPlayer (this);
	}

	private void OnDestroy ()
	{
		PlayerList.ForgetPlayer (this);
	}
}
