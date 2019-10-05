using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : RealtimeComponent
{

    public static GameStates instance;

    private GameStateModel _model;

    public enum States
    {
        Loading,
        Lobby,
        Game
    }

    public States CurrentState {
        protected set;
        get;
    }

    void Awake()
    {
        _model._state = States.Lobby;
        instance = this;
    }

    
}
