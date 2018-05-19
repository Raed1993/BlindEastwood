using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portazo : MonoBehaviour {

	bool opened;
	bool free;
	// Use this for initialization
	void Start () {
		opened=false;
		free=false;
	}
	
	// Update is called once per frame
	public void Opened(){
		opened=true;
	}
	void Update(){
		if(opened && !free){
			Color c=this.GetComponent<MeshRenderer>().material.color;
			this.GetComponent<MeshRenderer>().material.color=new Color(c.r,c.b,c.g,0.6f);
			this.transform.Rotate(0,3,0);
			this.gameObject.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeRotationY;
				
		}else{
			this.gameObject.GetComponent<Rigidbody>().velocity=Vector3.zero;
			this.gameObject.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.None;
			this.gameObject.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePosition;
		}
		if(free){
			
		}
	}

	void OnCollisionEnter(Collision e){
		if(e.gameObject.name=="filing-cabinet-empty (3)"){
			free=true;
		}
	}
	
}
