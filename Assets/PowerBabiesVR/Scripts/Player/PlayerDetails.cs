using Normal.Realtime;
using System;
using UnityEngine;

public class PlayerDetails : RealtimeComponent
{
    private PlayerDetailsSyncModel _model;
    bool hasModel = false;
    bool isLocal = false;

	public PlayerDetailsSyncModel model
	{
        private set
        {
			_model = value;
			hasModel = true;
			isLocal = realtimeView.isOwnedLocally;
            if (isLocal)
            {
                _model.name = Environment.UserName;

				if (GameStates.instance != null)
				{
					GameStates.instance.gameStateChanged += state =>
					{
						if (state == GameStates.States.Lobby)
						{
							_model.score = 0;
						}
					};
				}
				else
				{
					Debug.LogError ("<b>Anthony:</b> GameState singleton is null!");
				}
            }
    		PlayerList.DiscoverPlayer (this);
            OnModelSet();
		}
        get
        {
            return _model;
        }
    }

    private void OnModelSet()
    {
        _model.isReadyDidChange += OnPlayerReady;
    }

    private void OnPlayerReady(PlayerDetailsSyncModel model, bool value)
    {
        Debug.LogFormat("Checking if all players are ready state={0}", GameStates.instance.CurrentState);
        if (PlayerList.AllReady() && GameStates.instance) {
            GameStates.instance.CurrentState = GameStates.States.Game;
            Debug.LogFormat("GameState state={0}", GameStates.instance.CurrentState);
        }
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
