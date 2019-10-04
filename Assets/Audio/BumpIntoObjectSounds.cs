using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ABertmark

public class BumpIntoObjectSounds : MonoBehaviour {

	public AudioSource audioSource;
	public SurfaceToSoundCollection objectSoundCollection;

	void OnCollisionEnter (Collision collision)
	{
		objectSoundCollection.Play (collision.collider.sharedMaterial, audioSource);

	}
}
