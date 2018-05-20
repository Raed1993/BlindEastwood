using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKilledEnemy : MonoBehaviour {

	public float alphaFade;
	private float transition;
	public float transitionOut=0.01f;

	public float duration=0.1f; 
	private Material thisMaterial;
	private Animator anim;
	private AudioSource audioSource;

	public AudioClip audioClip;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Animator>();
		audioSource.clip=audioClip;
		thisMaterial=GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnColliderEnter(Collider e){
		if(e.gameObject.tag=="Stick"){
			anim.SetTrigger("Morir");
			audioSource.PlayOneShot(audioClip);
			transition = transitionOut;
        	alphaFade = 0;
        	Debug.Log("adios");
			if (e.gameObject.tag == "Player"|| e.gameObject.tag=="Moneda" || e.gameObject.tag=="Moneda" || e.gameObject.tag=="Door")
			{
				InvokeRepeating("Fade", duration, duration);
			}
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
