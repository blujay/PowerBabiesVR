using Normal.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : RealtimeComponent
{

    public static GameStates instance;

    private GameStateModel _model;

    public event Action<States> gameStateChanged;

	public float stateEnterTime;

	public float gameLength = 60 * 5;

	public enum States
    {
        Loading,
        Lobby,
        Game
    }

    public States CurrentState {
        set {
            this.realtimeView.RequestOwnership();
            _model.state = value;
        }
        get {
            return ( _model != null ) ? _model.state : States.Loading;
        }
    }

    void Awake()
    {
        
        instance = this;
    }

    private GameStateModel model
    {
        set
        {
            if (_model != null)
            {
                // Unregister from events
                _model.stateDidChange -= StateDidChange;
            }

            // Store the model
            _model = value;

            if (_model != null)
            {
                // Update the mesh render to match the new model
                OnModelAttached();

                // Register for events so we'll know if the color changes later
                _model.stateDidChange += StateDidChange;
            }
        }
    }

    private void OnModelAttached()
    {
    }

    private void StateDidChange(GameStateModel model, States value)
    {
        gameStateChanged.Invoke(value);
		stateEnterTime = Time.realtimeSinceStartup;

	}

	private void Update()
	{
		if (CurrentState == States.Game)
		{
			if (Time.realtimeSinceStartup > stateEnterTime + gameLength)
			{
				// Every player is going to set the state to lobby,
				// so this will fire multiple times. That should be fine, right?
				CurrentState = States.Lobby;
			}
		}
	}

    public void PlayerReady() 
    {
       
    }
}
