﻿using Normal.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : RealtimeComponent
{

    public static GameStates instance;

    private GameStateModel _model;

    public event Action<States> gameStateChanged;

    public enum States
    {
        Loading,
        Lobby,
        Game
    }

    public States CurrentState {
        set {
            _model.state = value;
        }
        get {
            return _model.state;
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
        _model.state = States.Lobby;
    }

    private void StateDidChange(GameStateModel model, States value)
    {
        gameStateChanged.Invoke(value);
    }
}
