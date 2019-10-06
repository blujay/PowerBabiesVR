using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : RealtimeComponent
{
    [SerializeField] Transform[] spawnPosition;

    Dictionary<int, int> checkedOutPositions = new Dictionary<int, int>();
    //int usedSlots = 0;

    SpawnSlotsModel _model;

    public static SpawnPositions instance {
        protected set;
        get;
    }

    void Awake()
    {
        instance = this;
    }


    public Transform CheckoutPosition(int clientID)
    {
        int freeIndex = -1;
        for (int i = 0; i < spawnPosition.Length; i++) {
            bool free = ( (_model.slotsUsed >> i) & 1 ) == 1;
            if (free) {
                freeIndex = i;
                break;
            }
        }

        if (freeIndex == -1) {
            Debug.LogError("Failed to get spawn position");
            return transform;
        }

        checkedOutPositions[clientID] = freeIndex;
        _model.slotsUsed |= ( 1 << freeIndex ) ;

        return spawnPosition[freeIndex];
    }

    public void ReturnPosition(int clientID) 
    {
        int slot = checkedOutPositions[clientID];
        _model.slotsUsed &= ~(1 << slot);
    }

    
}
