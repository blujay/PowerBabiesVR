using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    [SerializeField] Transform[] spawnPosition;

    public SpawnPositions instance {
        protected set;
        get;
    }

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
