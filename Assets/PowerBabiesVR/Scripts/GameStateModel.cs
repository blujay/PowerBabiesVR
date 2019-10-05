using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;

[RealtimeModel]
public class GameStateModel
{
    [RealtimeProperty(1, true, true)]
    public GameStates.States _state;

}

