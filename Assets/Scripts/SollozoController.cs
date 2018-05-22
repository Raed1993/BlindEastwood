using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class SollozoController : MonoBehaviour {

	public FirstPersonController controller;
	private AudioSource audioSource;
	private GameObject player;
	private Color c;
    public float volumeSound=0.1f;
	void Start(){
		audioSource=this.GetComponent<AudioSource>();
		c=this.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color;
		player=GameObject.FindWithTag("Player");
        controller=player.GetComponent<FirstPersonController>();
        
	}

	void Update(){
		this.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color=new Color(c.r,c.g,c.b,controller.getPerceptionMultiplier(this.transform.position)*0.6f);
        if (controller.getPerceptionMultiplier(this.transform.position) > 0.5f)
        {
            audioSource.volume = controller.getPerceptionMultiplier(this.transform.position)* volumeSound;
        }
        else
        {
            audioSource.volume = 0;
        }
	}
}
