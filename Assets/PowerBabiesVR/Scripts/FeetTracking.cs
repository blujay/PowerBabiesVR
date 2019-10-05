using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class FeetTracking : MonoBehaviour
{
    [SerializeField] Player player;

    void Update()
    {
        transform.position = player.feetPositionGuess;   
    }
}
