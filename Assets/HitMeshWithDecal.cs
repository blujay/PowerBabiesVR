using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMeshWithDecal : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other){
        Debug.Log("collided with: " + other.gameObject.name);
    }
}
