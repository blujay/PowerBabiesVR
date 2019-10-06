using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
{
	public Text Countdown;

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
				(GameStates.instance.stateEnterTime + GameStates.instance.gameLength)
				- Time.realtimeSinceStartup;

			float seconds = (int)(remainingTime % 60);
			int minutes = (int)(remainingTime / 60);

			Countdown.text = $"{minutes}:{seconds:00}";
		}
	}
}
