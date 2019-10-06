﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
{
    [SerializeField] Text Countdown;

    [SerializeField] float stateEnterTime;

    [SerializeField] float gameLength = 60 * 5;

    private void Awake()
    {
        GameStates.instance.gameStateChanged += OnGameStateChanged;

    }

    private void OnGameStateChanged(GameStates.States state)
    {
        stateEnterTime = Time.realtimeSinceStartup;
    }

    public float GetTimeElapsed() {
        return (Time.realtimeSinceStartup - stateEnterTime);
    }

    public float GetTimeElapsedNormalized() {
        return Mathf.Clamp01( GetTimeElapsed() / gameLength );
    }

    private void Update ()
	{
		if (GameStates.instance == null || GameStates.instance.CurrentState != GameStates.States.Game)
		{
			if(Countdown) Countdown.gameObject.SetActive (false);
			return;
		}

        
		if (Countdown != null)
		{
            Countdown.gameObject.SetActive(true);

            float remainingTime = 
				(stateEnterTime + gameLength)
				- Time.realtimeSinceStartup;

			float seconds = (int)(remainingTime % 60);
			int minutes = (int)(remainingTime / 60);

			Countdown.text = $"{minutes}:{seconds:00}";
		}

        if (GameStates.instance.CurrentState == GameStates.States.Game)
        {
            if (Time.realtimeSinceStartup > stateEnterTime + gameLength)
            {
                // Every player is going to set the state to lobby,
                // so this will fire multiple times. That should be fine, right?
                GameStates.instance.CurrentState = GameStates.States.Lobby;
            }
        }
    }


}
