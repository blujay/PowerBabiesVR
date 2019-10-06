using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockView : MonoBehaviour
{
    [SerializeField] GameCountdown countdown;
    [SerializeField] Transform clockHand;

    void Update()
    {
        float time = GameStates.instance.CurrentState == GameStates.States.Game ? countdown.GetTimeElapsedNormalized() : 0;
        clockHand.rotation = Quaternion.Euler(0, 0, 360f * time);
    }
}
