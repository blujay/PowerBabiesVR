using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ABertmark

public class ObjectBulletImpactSound : MonoBehaviour {

	public SoundCollection objectSoundCollection;

	public AudioSource audioSource;           // Reference to the sound collection.


	public void TakeDamage ()
	{
		objectSoundCollection.Play(audioSource); 
	}
}