using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    [SerializeField] Transform[] spawnPosition;

    Dictionary<int, int> checkedOutPositions = new Dictionary<int, int>();
    int usedSlots = 0;

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
            bool free = ( (usedSlots >> i) & 1 ) == 1;
            if (free) {
                freeIndex = i;
                break;
            }
        }
        checkedOutPositions[clientID] = freeIndex;
        usedSlots |= ( 1 << freeIndex ) ;

        return spawnPosition[freeIndex];
    }

    public void ReturnPosition(int clientID) 
    {
        int slot = checkedOutPositions[clientID];
        //usedSlots = usedSlots 
    }

    
}
