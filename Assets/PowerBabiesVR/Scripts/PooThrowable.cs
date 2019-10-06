using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PooThrowable : Throwable
{
    public void AttachToHand(Hand hand)
    {
        transform.position = hand.transform.position;
        OnAttachedToHand(hand);
    }
}
