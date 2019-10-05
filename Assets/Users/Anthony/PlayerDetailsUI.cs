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
			if (CurrentlyFollowing._details != null)
			{
				CurrentlyFollowing._details.nameDidChange -= UpdateName;
				CurrentlyFollowing._details.scoreDidChange -= UpdateScore;
			}
		}

		CurrentlyFollowing = details;

		if (CurrentlyFollowing != null)
		{
			UpdateName (details._details, details._details?.name ?? "-");
			UpdateScore (details._details, details._details?.score ?? 0);

			if (details._details != null)
			{
				details._details.nameDidChange += UpdateName;
				details._details.scoreDidChange += UpdateScore;
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
