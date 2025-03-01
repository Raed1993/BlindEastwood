﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portazo : MonoBehaviour {

	bool opened;
	bool free;
	bool done;
	bool reproducido = false;
	public AudioClip openDoor;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
		opened=false;
		free=false;
		done=false;
        audioSource = GetComponent<AudioSource>();		
	}
	
	// Update is called once per frame
	public void Opened(){
		opened=true;
	}
	void Update(){
		if(opened && !free && !done){
			Color c=this.GetComponent<MeshRenderer>().material.color;
			this.GetComponent<MeshRenderer>().material.color=new Color(c.r,c.b,c.g,0.6f);
			this.transform.Rotate(0,3,0);
			
			if (openDoor != null && reproducido == false) {
                audioSource.PlayOneShot(openDoor,1.0f);
				reproducido = true;
			} 
				
		}else if(!opened && free){
			this.gameObject.GetComponent<Rigidbody>().velocity=Vector3.zero;
			done=true;
			free=false;
			this.transform.Rotate(0,-30,0);
			
		}
		if(done ){

			this.GetComponent<MeshRenderer>().material.color=GameObject.Find("filing-cabinet-empty (3)").GetComponent<MeshRenderer>().material.color;
			if(this.GetComponent<MeshRenderer>().material.color.a<0.1f){
				done=false;
			}
		}
	}

	void OnCollisionEnter(Collision e){
		if(e.gameObject.name=="filing-cabinet-empty (3)"){
			free=true;
			opened=false;
		}
	}
	
}
