using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : RealtimeComponent
{

    public static GameState instance;

    private GameStateModel _model;

    public enum State
    {
        Loading,
        Lobby,
        Game
    }

    public State CurrentState {
        protected set;
        get;
    }

    void Awake()
    {
        _model._state = State.Lobby;
        instance = this;
    }

    
}
