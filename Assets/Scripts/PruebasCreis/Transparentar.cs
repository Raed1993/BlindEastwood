using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparentar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Color aux=this.GetComponent<MeshRenderer>().material.color;
		this.GetComponent<MeshRenderer>().material.color=new Color(aux.r,aux.g,aux.b,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
