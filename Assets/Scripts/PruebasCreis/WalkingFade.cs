using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WalkingFade : MonoBehaviour {

	public float duration = 0.01f;
    public float transition = 0.05f;
    public Material material;
    public int alphaFade;

	public FirstPersonController controller;
    private GameObject player;

	// Use this for initialization
    void Start()
    {	
        material = GetComponent<Renderer>().materials[0];
        Debug.Log(GetComponent<Renderer>().materials[0].name);
		player=GameObject.FindWithTag("Player");
        controller=player.GetComponent<FirstPersonController>();
    }

    public void FadeWalking()
    {
		InvokeRepeating("Fade",duration,duration);
    }
	void Fade(){
		Debug.Log("Llamado");
        material.color = Color.Lerp(material.color, new Color(1, 1, 1,controller.getPerceptionMultiplier(this.transform.position)*alphaFade), transition);
        if (material.color.a > 0.8f)
        {
            alphaFade = 0;
        }

        if (material.color.a < 0.1f)
        {
            alphaFade=1;
			CancelInvoke();
        }
	}
}
