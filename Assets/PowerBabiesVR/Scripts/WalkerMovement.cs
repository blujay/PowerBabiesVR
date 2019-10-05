using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerMovement : RealtimeComponent
{
    WalkerSyncModel _model;

    bool isLocal = false;

    Transform feetPosition;
    [SerializeField] Transform target;

    private WalkerSyncModel model {
        set {
            _model = value;
            isLocal = realtimeView.isOwnedLocally;
            if( isLocal ) Configure();
        }
    }

    void Configure() {
        feetPosition = GameObject.FindObjectOfType<FeetTracking>().transform;
    }

    private void Update()
    {
        if (feetPosition) {
            target.position = feetPosition.position;
        }


    }
}
