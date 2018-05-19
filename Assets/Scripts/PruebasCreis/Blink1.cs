using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink1 : MonoBehaviour {

    public float duration = 0.4f;
    public float transitionIn;
    public float transitionOut;

    bool isShowing;
	bool isInTransition;
    int alphaFade;
    float transition;
	Material thisMaterial;
	// Use this for initialization
    void Start()
    {
		thisMaterial=this.GetComponent<MeshRenderer>().material;
		thisMaterial.color=new Color(1,1,1,0);
        alphaFade=1;
		
	}

	void OnTriggerEnter(Collider e){
        transition = transitionIn;
        alphaFade = 1;
        Debug.Log("hola soy: "+this.name);
		if(e.gameObject.tag=="Player"|| e.gameObject.tag=="Moneda"){
         InvokeRepeating("Fade", duration, duration);
        }
        
	}
    void OnCollisionEnter(Collision e){
        transition = transitionIn;
        alphaFade = 1;
        Debug.Log("hola soy: "+this.name);
		if(e.gameObject.tag=="Player"|| e.gameObject.tag=="Moneda"){
           InvokeRepeating("Fade", duration, duration);
        }
	}
    void OnTriggerExit(Collider e)
    {
        transition = transitionOut;
        alphaFade = 0;
        Debug.Log("adios");
        if (e.gameObject.tag == "Player"|| e.gameObject.tag=="Moneda")
        {
           InvokeRepeating("Fade", duration, duration);
        }
    }
    

    void Fade()
    {
        
        thisMaterial.color = Color.Lerp(thisMaterial.color, new Color(1, 1, 1, alphaFade), transition);
        if (thisMaterial.color.a == alphaFade)
        {
            CancelInvoke();
        }
    }
}
