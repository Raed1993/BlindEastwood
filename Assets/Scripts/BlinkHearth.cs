using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class BlinkHearth : MonoBehaviour {

    public float duration = 0.1f;
    float transition = 0.5f;
    public Material material;
    public int alphaFade;

    public FirstPersonController controller;
    private GameObject player;
	// Use this for initialization
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        InvokeRepeating("Fade", duration, duration);
        player=GameObject.FindWithTag("Player");
        controller=player.GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    void Fade()
    {
        if(controller.getPerceptionMultiplier(this.transform.position)>0.05){
            material.color = Color.Lerp(material.color, new Color(1, 1, 1, alphaFade), transition);
            if (material.color.a > 0.8f)
            {
                alphaFade = 0;
            }

            if (material.color.a < 0.2f)
            {
                alphaFade = 1;
            }
        }else{
            material.color =new Color(material.color.r,material.color.g,material.color.b,0f);
        }
    }
}
