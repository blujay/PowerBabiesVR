using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Sound/SoundCollection")]
public class SoundCollection : ScriptableObject
{
	public AudioClip[] clips;

	public float volumeMinValue=1;
	public float volumeMaxValue=1;
	public float pitchMinValue=1;
	public float pitchMaxValue=1;
	int index;

	public void Play(AudioSource source)
	{
		if (clips.Length == 0) return;

		//source.clip = clips[Random.Range(0, clips.Length)];
		source.clip = GetRandomDontRepeat ();
		source.volume = Random.Range(volumeMinValue, volumeMaxValue);
		source.pitch = Random.Range(pitchMinValue, pitchMaxValue);
		source.Play();
		//Debug.LogFormat ("playing file {0}", source.clip.name);
	}
		
	/* this selects from the sound collection based on an input power level, between 0-1 */
	public void Play(AudioSource source, float power)
	{
		source.clip = GetClamped(power);
		source.volume = Random.Range(volumeMinValue, volumeMaxValue);
		source.pitch = Random.Range(pitchMinValue, pitchMaxValue);
		source.Play();

	}

	public AudioClip GetRandom()
	{
		return clips[Random.Range(0,clips.Length)];
	}

	public AudioClip GetClamped(float t)
	{
		return clips[Mathf.Clamp(Mathf.FloorToInt(t*clips.Length),0,clips.Length-1)];
	}

	public AudioClip GetWrapped(float t)
	{
		return clips[Mathf.FloorToInt(t*(clips.Length-Mathf.Epsilon))%clips.Length];
	}

	public AudioClip GetRandomDontRepeat(){
		index = ( Random.Range (1, clips.Length - 1) + index ) % clips.Length;
		return clips[ index ];
	}

	public AudioClip GetNext(){

		int i = index;
		index++;
		if( index >= clips.Length )
			index = 0;
		return clips[i];
	}
}
