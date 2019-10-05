using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Sound/SurfaceToSoundCollection")]
public class SurfaceToSoundCollection : ScriptableObject {

	[Header("AudioSurfaces")]
	public PhysicsMaterialSoundCollectionPairing[] surfaceCollection;

	public void Play (PhysicMaterial physicMaterial, AudioSource source)
	{

		foreach (PhysicsMaterialSoundCollectionPairing surface in surfaceCollection) {
			//Debug.LogFormat ("{0}, {1}" , surface.physicMaterial, physicMaterial);
			if (surface.physicMaterial == physicMaterial)
			{
				source.outputAudioMixerGroup = surface.audioMixerOutput;
				surface.audio.Play (source);
				//Debug.Log ("found matching material");
			}
		}

	}

}
	