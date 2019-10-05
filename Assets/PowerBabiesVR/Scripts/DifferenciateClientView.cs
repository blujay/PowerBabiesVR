using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferenciateClientView : RealtimeComponent
{
    DifferenciateClientModel _model;

    [SerializeField] GameObject[] localClientElements;
    [SerializeField] GameObject[] remoteClientElements;

    private DifferenciateClientModel model {
        set {
            _model = value;
            UpdateElements( realtimeView.isOwnedLocally );
        }
    }

    void UpdateElements(bool local) {
        foreach (var element in localClientElements) {
            element.SetActive(local);
        }
        foreach (var element in remoteClientElements)
        {
            element.SetActive(!local);
        }


    }
}
