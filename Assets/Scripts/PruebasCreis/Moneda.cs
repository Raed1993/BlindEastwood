using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour {

	public float destroyTimeIfHit;
	public float destroyTimeIfNotHit;
	private float timeBeforeHit;
	private float timeWithoutHit;
	private bool beginCountingtime;
	// Use this for initialization
	void Start () {
		beginCountingtime=false;
		//this.gameObject.GetComponent<MeshRenderer>().material.color=Color.red;
		Shader.EnableKeyword("_ALPHATEST_ON");
		this.gameObject.GetComponent<Renderer>().material.color=new Color(255,255,0,1) ;
		print(this.gameObject.GetComponent<Renderer>().material.color);
	}
	
	// Update is called once per frame
	void Update () {
		timeWithoutHit+=Time.deltaTime;
		if(beginCountingtime){
			timeBeforeHit+=Time.deltaTime;
		}else{
			timeBeforeHit=0;
		}

		if(timeBeforeHit>destroyTimeIfHit){
			Destroy(this.gameObject);
		}
		if(timeWithoutHit>destroyTimeIfNotHit){
			Destroy(this.gameObject);
		}
	}
	void OnTriggerExit(){
		beginCountingtime=true;
	}
}
