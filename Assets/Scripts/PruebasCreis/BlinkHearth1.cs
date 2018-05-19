using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkHearth1 : MonoBehaviour {

    public float duration = 0.1f;
    public float transition = 0.1f;
    public Material thisMaterial;

    bool isShowing;
	bool isInTransition;
    public int alphaFade;
    private Color color;


	// Use this for initialization
    void Start()
    {
        //this.GetComponent<MeshRenderer>().material.color=new Color(color.r,color.g,color.b,0);
        //Material thisMaterial=GetComponent<Renderer>().material;
        //color= thisMaterial.color;
        print(this.gameObject.GetComponent<Renderer>().material.color.a);
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color",new Color(255,255,255,1)) ;
        print(this.gameObject.GetComponent<Renderer>().material.GetColor("_Color").a);
        
        //print(this.gameObject.GetComponent<MeshRenderer>().ToString());
       InvokeRepeating("Fade", duration, duration);
    }

    void Fade()
    {
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.Lerp(this.gameObject.GetComponent<Renderer>().material.GetColor("_Color"), new Color(1, 1, 1, alphaFade), transition));
        if (this.gameObject.GetComponent<Renderer>().material.GetColor("_Color").a > 0.8f)
        {
            alphaFade = 0;
        }

        if (this.gameObject.GetComponent<Renderer>().material.GetColor("_Color").a < 0.2f)
        {
            alphaFade = 1;
        }
    }

    void OnApplicationQuit(){
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color",new Color(255,255,255,0));
    }
}
