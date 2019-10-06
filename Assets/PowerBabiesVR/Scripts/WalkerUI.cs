using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class WalkerUI : MonoBehaviour
{
    [SerializeField] HoverButton startButton;
    [SerializeField] PlayerDetails playerDetails;

    private void Awake()
    {
        GameStates.instance.gameStateChanged += OnGameStateChanged;
        startButton.onButtonDown.AddListener( OnStartButtonDown );
    }

    private void OnStartButtonDown(Hand hand)
    {
        playerDetails.model.isReady = true;
    }

    private void OnGameStateChanged(GameStates.States state)
    {
        switch (state) {
            case GameStates.States.Loading:
                break;
            case GameStates.States.Lobby:
                startButton.gameObject.SetActive(true);
                break;
            case GameStates.States.Game:
                startButton.gameObject.SetActive(false);
                break;
        }
    }
}
