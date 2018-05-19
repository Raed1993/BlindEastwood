using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class BlinkHearth : MonoBehaviour {

    public float duration = 0.1f;
    float transition = 0.1f;
    public Material material;
    public int alphaFade;

    public FirstPersonController controller;
    private GameObject player;
	// Use this for initialization
    void Start()
    {
        material = GetComponent<Renderer>().materials[1];
        InvokeRepeating("Fade", duration, duration);
        Debug.Log(GetComponent<Renderer>().materials[1].name);
        player=GameObject.FindWithTag("Player");
        controller=player.GetComponent<FirstPersonController>();
    }

    void Fade()
    {
        material.color = Color.Lerp(material.color, new Color(1, 1, 1, controller.getPerceptionMultiplier(this.transform.position)*alphaFade), transition);
        if (material.color.a > 0.8f)
        {
            alphaFade = 0;
        }

        if (material.color.a < 0.2f)
        {
            alphaFade = 1;
        }
    }
}
