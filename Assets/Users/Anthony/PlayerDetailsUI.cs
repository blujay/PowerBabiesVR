﻿using UnityEngine;
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
			if (CurrentlyFollowing.Details != null)
			{
				CurrentlyFollowing.Details.nameDidChange -= UpdateName;
				CurrentlyFollowing.Details.scoreDidChange -= UpdateScore;
			}
		}

		CurrentlyFollowing = details;

		if (CurrentlyFollowing != null)
		{
			UpdateName (CurrentlyFollowing.Details, CurrentlyFollowing.Details?.name ?? "-");
			UpdateScore (CurrentlyFollowing.Details, CurrentlyFollowing.Details?.score ?? 0);

			if (CurrentlyFollowing.Details != null)
			{
				CurrentlyFollowing.Details.nameDidChange += UpdateName;
				CurrentlyFollowing.Details.scoreDidChange += UpdateScore;
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
