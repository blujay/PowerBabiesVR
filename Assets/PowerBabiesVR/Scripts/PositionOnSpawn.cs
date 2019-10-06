using Normal.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOnSpawn : MonoBehaviour
{
    [SerializeField] Realtime realtime;

    private void Awake()
    {
        realtime.didConnectToRoom += OnConnectedToRoom;
        realtime.didDisconnectFromRoom += OnDisconnectedFromRoom;
    }

    private void OnDisconnectedFromRoom(Realtime realtime)
    {
        SpawnPositions.instance.ReturnPosition(realtime.clientID);
    }

    private void OnConnectedToRoom(Realtime realtime)
    {
        SpawnPositions.instance.CheckoutPosition(realtime.clientID);
    }
}
