using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudioScript : MonoBehaviour {

	private AudioSource source;
	public AudioClip woosh;
	public AudioClip clinck;

	private bool touched;

	bool throwed;
	// Use this for initialization
	void Start () {
		touched=false;
		throwed=false;
	}
	
	// Update is called once per frame
	void Update () {
		if((this.GetComponent<Rigidbody>().velocity.x>0 || this.GetComponent<Rigidbody>().velocity.y>0 || this.GetComponent<Rigidbody>().velocity.z>0 )&& !throwed){
				source.clip=woosh;
				source.PlayOneShot(woosh);
				throwed=true;
		}
		if((this.GetComponent<Rigidbody>().velocity.x>0 || this.GetComponent<Rigidbody>().velocity.y>0 || this.GetComponent<Rigidbody>().velocity.z>0 )&& !throwed && !touched){
				source.clip=woosh;
				touched=true;
		}
	}

	void OnTriggerEnter(Collider e){
		if(e.gameObject.tag=="Ground" ){
			source.clip=clinck;
		}
		source.PlayOneShot(clinck);
	}
}
