using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    public float duration = 0.05f;
    public float transitionIn;
    public float transitionOut;

    bool isShowing;
	bool isInTransition;
    float alphaFade;
    float transition;
	Material thisMaterial;
	// Use this for initialization
    void Start()
    {
		thisMaterial=this.GetComponent<MeshRenderer>().material;
		thisMaterial.color=new Color(1,1,1,0);
		
	}

	void OnTriggerEnter(Collider e){
        transition = transitionIn;
        alphaFade = 0.6f;
        Debug.Log("hola");
		if(e.gameObject.tag=="Player" || e.gameObject.tag=="Moneda" || e.gameObject.tag=="Moneda" || e.gameObject.tag=="Door"){
            InvokeRepeating("Fade", duration, duration);
        }
	}

    void OnTriggerExit(Collider e)
    {
        transition = transitionOut;
        alphaFade = 0;
        Debug.Log("adios");
        if (e.gameObject.tag == "Player"|| e.gameObject.tag=="Moneda" || e.gameObject.tag=="Moneda" || e.gameObject.tag=="Door")
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
