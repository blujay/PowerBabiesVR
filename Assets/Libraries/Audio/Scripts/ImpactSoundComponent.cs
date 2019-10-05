using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ABertmark

public class ImpactSoundComponent : MonoBehaviour {

	public AudioSource audioSource;
	public SurfaceToSoundCollection objectSoundCollection;

	public void OnCollisionEnter (Collision collision)
	{
		objectSoundCollection.Play (collision.collider.sharedMaterial, audioSource);
        Debug.Log("ImpactSoundComponent script works fine!");
    }

    
}
