using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootWalkingFade : MonoBehaviour {

	// Use this for initialization
	public GameObject body;
    public string footString;

	

	void OnTriggerEnter(Collider e){
		
		
		if (e.gameObject.transform.tag == "Ground")
        {
			body.BroadcastMessage(footString);
		}
	}
}
