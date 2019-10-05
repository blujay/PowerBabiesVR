using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatesDemo : MonoBehaviour
{
    [SerializeField] GameStates gameStates;

    // Start is called before the first frame update
    void Start()
    {
        gameStates.gameStateChanged += OnStateChanged;
    }

    private void OnStateChanged(GameStates.States obj)
    {
        Debug.Log(obj.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            gameStates.CurrentState = GameStates.States.Game;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            gameStates.CurrentState = GameStates.States.Loading;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameStates.CurrentState = GameStates.States.Lobby;
        }
    }
}
