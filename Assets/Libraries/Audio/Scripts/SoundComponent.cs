using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ABertmark

public class SoundComponent : MonoBehaviour {

	public AudioSource audioSource;
	public SoundCollection objectSoundCollection;

	public void Play ()
	{
		objectSoundCollection.Play (audioSource);

	}
}
