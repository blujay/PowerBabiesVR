using UnityEngine;
using System.Collections;
//using VRTK;


public class Object_Touch_Sound : MonoBehaviour {

	public AudioSource soundEmitter;
	public SoundCollection touchSound;
	public bool PlayOnlyOnce;


//	private VRTK_InteractableObject interactable;


	void Start() {

		interactable = GetComponent<VRTK_InteractableObject> ();
		interactable.InteractableObjectTouched += OnObjectTouched;

	}


	void OnObjectTouched(object obj,InteractableObjectEventArgs args){

		touchSound.Play (soundEmitter);
		if (PlayOnlyOnce)
			interactable.InteractableObjectTouched -= OnObjectTouched;

	}



}
