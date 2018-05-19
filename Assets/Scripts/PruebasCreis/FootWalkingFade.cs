using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootWalkingFade : MonoBehaviour {

	// Use this for initialization
	public GameObject body;

	

	void OnTriggerEnter(Collider e){
		
		
		if (e.gameObject.transform.tag == "Ground")
        {
			Debug.Log("pie");
			body.BroadcastMessage("FadeWalking");
		}
	}
}
