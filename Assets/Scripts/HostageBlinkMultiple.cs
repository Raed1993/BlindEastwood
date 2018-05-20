using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageBlinkMultiple : MonoBehaviour {

	public float duration = 0.1f;
    public float transitionIn=0.1f;
    public float transitionOut=0.01f;

    bool isShowing;
	bool isInTransition;
    float alphaFade;
    float transition;
	Material[] thisMaterials;
	// Use this for initialization
    void Start()
    {
		thisMaterials=this.GetComponent<SkinnedMeshRenderer>().materials;
        foreach(Material m in thisMaterials)
		    m.color=new Color(1,1,1,0);
		
	}

	void OnTriggerEnter(Collider e){
        transition = transitionIn;
        alphaFade = 0.6f;
        Debug.Log("hola");
		if(e.gameObject.tag=="Player" || e.gameObject.tag=="Moneda" || e.gameObject.tag=="Stick" || e.gameObject.tag=="Door"){
            InvokeRepeating("Fade", duration, duration);
        }
	}

    void OnTriggerExit(Collider e)
    {
        transition = transitionOut;
        alphaFade = 0;
        Debug.Log("adios");
        if (e.gameObject.tag == "Player"|| e.gameObject.tag=="Moneda" || e.gameObject.tag=="Stick" || e.gameObject.tag=="Door")
        {
            InvokeRepeating("Fade", duration, duration);
        }
    }

    void Fade()
    {   
        foreach(Material m in thisMaterials){
            m.color = Color.Lerp(m.color, new Color(1, 1, 1, alphaFade), transition);
            if (m.color.a == alphaFade)
            {
                CancelInvoke();
            }
        }
    }
}
