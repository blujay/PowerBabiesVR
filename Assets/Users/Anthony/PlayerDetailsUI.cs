using UnityEngine;
using UnityEngine.UI;

public class PlayerDetailsUI : MonoBehaviour
{
	public PlayerDetails FollowOnStart;

	[Space]
	public Text Name;
	public Text Score;

	[Header ("Readonly")]
	public PlayerDetails CurrentlyFollowing;

	private void Start ()
	{
		if (FollowOnStart != null)
		{
			StartFollowing (FollowOnStart);
		}
	}

	public void StartFollowing (PlayerDetails details)
	{
		if (CurrentlyFollowing != null)
		{
			if (CurrentlyFollowing._model != null)
			{
				CurrentlyFollowing._model.nameDidChange -= UpdateName;
				CurrentlyFollowing._model.scoreDidChange -= UpdateScore;
			}
		}

		CurrentlyFollowing = details;

		if (CurrentlyFollowing != null)
		{
			UpdateName (details._model, details._model?.name ?? "-");
			UpdateScore (details._model, details._model?.score ?? 0);

			if (details._model != null)
			{
				details._model.nameDidChange += UpdateName;
				details._model.scoreDidChange += UpdateScore;
			}
		}
		else
		{
			if (Name != null)
			{
				Name.text = "No Player";
			}
			if (Score != null)
			{
				Score.text = "0";
			}
		}
	}

	private void UpdateName (PlayerDetailsSyncModel model, string value)
	{
		if (Name != null)
		{
			Name.text = value ?? "-";
		}
	}

	private void UpdateScore (PlayerDetailsSyncModel model, int value)
	{
		if (Score != null)
		{
			Score.text = value.ToString();
		}
	}
}
