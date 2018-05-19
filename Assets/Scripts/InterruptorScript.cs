using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorScript : MonoBehaviour {


	private bool rotated;
	private bool activated;
	// Use this for initialization
	void Start () {
		rotated=false;
		activated=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.E)){
			activated=true;
		}
		
		if(activated && !rotated){
			foreach(Collider c in GetComponents<Collider>())
				c.enabled=false;
			if(this.transform.rotation.eulerAngles.x<180){
				
				this.transform.Rotate(3,0,0);
				
			}else{
				rotated=true;
				GameObject.FindWithTag("Door").gameObject.GetComponent<Portazo>().Opened();
			}
		}
	}

	void OnCollisionEnter(Collision e){
		if(e.gameObject.tag=="Stick"){
			activate();
		}
	}
	public void activate(){
		activated=true;
	}
}
