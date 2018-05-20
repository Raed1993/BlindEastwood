using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePorra : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
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