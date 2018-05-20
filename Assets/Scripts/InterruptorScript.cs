using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorScript : MonoBehaviour {


	private bool rotated;
	private bool activated;
	//private bool reproducido = false;
	public AudioClip cortocircuito;
	// Use this for initialization
	void Start () {
		rotated=false;
		activated=false;
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyUp(KeyCode.E)){ //BORRAR ESTE IF
			activated=true;
			AudioSource audio = gameObject.AddComponent<AudioSource >();
			
			if (cortocircuito != null) {
				audio.PlayOneShot(cortocircuito,1.0f);
				//reproducido = true;
			} 
		}*/
		
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

	void OnTriggerEnter(Collider e){
		if(e.gameObject.tag=="Stick"){
			Debug.Log("SDfsdf");
			activate();
			AudioSource audio = gameObject.AddComponent<AudioSource >();
			
			if (cortocircuito != null) {
				audio.PlayOneShot(cortocircuito,1.0f);
				//reproducido = true;
			} 
		}
	}
	public void activate(){
		activated=true;
	}
}
