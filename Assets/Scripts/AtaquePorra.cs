using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePorra : MonoBehaviour {
	
	public AudioClip golpePorra;

	void OnTriggerEnter(Collider collider)
	{
		AudioSource audio = gameObject.AddComponent<AudioSource >();

		if (golpePorra != null) {
			audio.PlayOneShot(golpePorra,1.0f);
			//reproducido = true;
		} 
		if(collider.tag == "Enemy")
		{
			collider.GetComponent<GetKilledEnemy> ().Dead ();	
		}

		if(collider.tag == "Rehen")
		{
			GameManager.instance.EndGame("YouLose");
		}
	}
}