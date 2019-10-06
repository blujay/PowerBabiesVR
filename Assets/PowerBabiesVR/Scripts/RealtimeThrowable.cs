﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using Normal.Realtime;

public class RealtimeThrowable : MonoBehaviour
{

    private RealtimeTransform bob;
    private RealtimeView bill;

    // Start is called before the first frame update
    void Awake()
    {
        bob = gameObject.GetComponent<RealtimeTransform>();
        bill = gameObject.GetComponent<RealtimeView>();
    }

    void Update()
    {
        if (bill.model == null)
            return;

        if (bill.isOwnedLocally)
        {
            gameObject.layer = 12;
        }
        else
        {
            gameObject.layer = 11;
        }
    }

    public void Grabbed()
    {
        bob.RequestOwnership();
        bill.RequestOwnership();
    }

}

