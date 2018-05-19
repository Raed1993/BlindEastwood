using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class fan : MonoBehaviour {

	public FirstPersonController controller;
    private GameObject player;
	Color c;
	// Use this for initialization
	void Start () {
		c=this.gameObject.GetComponent<MeshRenderer>().material.color ;
		this.GetComponent<Renderer>().material.color= new Color(c.r,c.g,c.b,0.7f);
		player=GameObject.FindWithTag("Player");
		controller=player.GetComponent<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
		c=this.gameObject.GetComponent<MeshRenderer>().material.color ;
		this.GetComponent<Renderer>().material.color= new Color(c.r,c.g,c.b,controller.getPerceptionMultiplier(this.transform.position)*0.8f);
		this.transform.Rotate(0,0,1.5f);
		}
}
