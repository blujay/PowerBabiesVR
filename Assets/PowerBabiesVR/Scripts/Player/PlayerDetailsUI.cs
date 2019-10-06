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
			if (CurrentlyFollowing.model != null)
			{
				CurrentlyFollowing.model.nameDidChange -= UpdateName;
				CurrentlyFollowing.model.scoreDidChange -= UpdateScore;
			}
		}

		CurrentlyFollowing = details;

		if (CurrentlyFollowing != null)
		{
			UpdateName (details.model, details.model?.name ?? "-");
			UpdateScore (details.model, details.model?.score ?? 0);

			if (details.model != null)
			{
				details.model.nameDidChange += UpdateName;
				details.model.scoreDidChange += UpdateScore;
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
