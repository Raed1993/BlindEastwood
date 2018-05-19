using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingFade : MonoBehaviour {

	public float duration = 0.01f;
    public float transition = 0.05f;
    public Material material;
    public int alphaFade;



	// Use this for initialization
    void Start()
    {	
        material = GetComponent<Renderer>().materials[0];
        //InvokeRepeating("Fade", duration, duration);
        Debug.Log(GetComponent<Renderer>().materials[0].name);
    }

    public void FadeWalking()
    {
		InvokeRepeating("Fade",duration,duration);
    }
	void Fade(){
		Debug.Log("Llamado");
        material.color = Color.Lerp(material.color, new Color(1, 1, 1, alphaFade), transition);
        if (material.color.a > 0.9f)
        {
            alphaFade = 0;
        }

        if (material.color.a < 0.2f)
        {
            alphaFade=1;
			CancelInvoke();
        }
	}
}
