using Normal.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameStates : RealtimeComponent
{

    public static GameStates instance;

    private GameStateModel _model;
    private TextMeshPro debugText;

    public event Action<States> gameStateChanged;

    [SerializeField] UnityEvent StartGameEvent;
    [SerializeField] UnityEvent StartLobbyEvent;

	public enum States
    {
        Loading,
        Lobby,
        Game
    }

    void Update() {
        var players = string.Join(", ", PlayerList.AllPlayers.Values.Select(item => $"{item.model.name}: {item.model.score}"));
        debugText.text = $"{CurrentState} {players}";
    }

    public States CurrentState {
        set {
            realtimeView.RequestOwnership();
			_model.state = value;
            realtimeView.ClearOwnership();
		}
        get {
            return _model?.state ?? States.Loading;
        }
	}

	public static void ResetGameForLobby ()
	{
		// Reset the decals
	}

	void Awake()
    {
        
        instance = this;
        debugText = gameObject.GetComponentInChildren<TextMeshPro>();
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
        if (_model.state == States.Loading) {
            _model.state = States.Lobby;
        }
        StateDidChange(_model, _model.state);
    }

    private void StateDidChange(GameStateModel model, States value)
    {
        Debug.LogFormat("State changes {0}",value);
        gameStateChanged.Invoke(value);
        if (value == States.Lobby)
        {
            ResetGameForLobby();
            StartLobbyEvent.Invoke();
        }
        else if (value == States.Game) {
            StartGameEvent.Invoke();
        }

	}

    public void PlayerReady() 
    {
       
    }
}
