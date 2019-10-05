using UnityEngine;

public class PlayerListUI : MonoBehaviour
{
	public PlayerDetailsUIPool PlayerDetailsPool;

	private void Awake ()
	{
		UpdatePlayerList ();

		PlayerList.OnPlayerChanges += UpdatePlayerList;
	}

	private void UpdatePlayerList ()
	{
		PlayerDetailsPool.Flush ();

		foreach (var player in PlayerList.AllPlayers.Values)
		{
			var playerUI = PlayerDetailsPool.Grab (transform);

			playerUI.gameObject.SetActive (true);

			playerUI.StartFollowing (player);
		}
	}
}
