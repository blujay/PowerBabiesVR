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
    [SerializeField] RealtimeView targetRealtimeView;

    private WalkerSyncModel model {
        set {
            _model = value;
            isLocal = realtimeView.isOwnedLocally;
            if( isLocal ) Configure();
        }
    }

    void Configure() {
        feetPosition = GameObject.FindObjectOfType<FeetTracking>().transform;
        StartCoroutine( SetOwnershipAtEndOfFrame() );
    }

    IEnumerator SetOwnershipAtEndOfFrame() {
        yield return new WaitForEndOfFrame();
        targetRealtimeView.RequestOwnership();
    }

    private void Update()
    {
        if (feetPosition) {
            target.position = feetPosition.position;
        }


    }
}
