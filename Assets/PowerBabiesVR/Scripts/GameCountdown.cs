using System;
using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
{
	public Text Countdown;

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

    private void Update ()
	{
		if (GameStates.instance == null || GameStates.instance.CurrentState != GameStates.States.Game)
		{
			Countdown.gameObject.SetActive (false);
			return;
		}

		Countdown.gameObject.SetActive (true);

		if (Countdown != null)
		{
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
