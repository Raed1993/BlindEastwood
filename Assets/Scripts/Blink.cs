using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {


	bool isShowing;
	bool isInTransition;
	float duration;
	float transition;
	Material thisMaterial;
	// Use this for initialization
void Start(){
		thisMaterial=this.GetComponent<MeshRenderer>().material;
		thisMaterial.color=new Color(1,1,1,0);
		
	}
	public void doFadeWhenGetHit(){
		Fade(true,0.4f);
	}
	public void Fade(bool showing,float duration){
		isShowing=showing;
		isInTransition=true;
		this.duration=duration;
		transition=(isShowing) ? 0 : 1;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.E)){
			doFadeWhenGetHit();
		}
		if(!isInTransition){
			thisMaterial.color=new Color(1,1,1,0);
			return;
		}
		
		transition+= (isShowing) ? Time.deltaTime*(1/duration) : -Time.deltaTime*(1/duration);
		thisMaterial.color=Color.Lerp(thisMaterial.color,new Color(1,1,1,1),transition);

		if(transition>1 || transition<0){
			isInTransition=false;
			isShowing=false;
		}
	}
}
