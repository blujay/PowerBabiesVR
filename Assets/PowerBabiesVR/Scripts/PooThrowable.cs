using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PooThrowable : Throwable
{
    RealtimeThrowable RealtimeThrowable;

    protected override void Awake()
    {
        base.Awake();
        RealtimeThrowable = GetComponent<RealtimeThrowable>();
    }

    public void AttachToHand(Hand passedInhand)
    {
        if (passedInhand == null)
        {
            return;
        }

        //GameObject prefabObject = Instantiate(prefab) as GameObject;
        
        //OnAttachedToHand(passedInhand);
        RealtimeThrowable.Grabbed();
    }
}