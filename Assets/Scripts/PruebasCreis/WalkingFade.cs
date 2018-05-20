using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WalkingFade : MonoBehaviour
{

    public float duration = 0.01f;
    public float transition = 0.5f;
    public Material material;
    public int alphaFade;

    public FirstPersonController controller;
    private GameObject player;
    private Material materialLeft;
    private Material materialRigth;

    // Use this for initialization
    void Start()
    {
        material = GetComponent<Renderer>().materials[0];
        materialLeft = GetComponent<Renderer>().materials[1];
        materialRigth = GetComponent<Renderer>().materials[2];
        player = GameObject.FindWithTag("Player");
        controller = player.GetComponent<FirstPersonController>();
    }

    public void FadeWalking()
    {
        InvokeRepeating("Fade", duration, duration);
    }

	void Fade()
	{
		material.color = Color.Lerp(materialRigth.color, new Color(1, 1, 1, controller.getPerceptionMultiplier(this.transform.position) * alphaFade), transition);
		materialRigth.color= material.color;
		materialLeft.color = material.color;
		if (material.color.a > 0.8f)
		{
			alphaFade = 0;
		}

		if (material.color.a < 0.1f)
		{
			material.color = new Color(1, 1, 1, 0);
			materialRigth.color= new Color(1, 1, 1, 0);
			materialLeft.color = new Color(1, 1, 1, 0);
			alphaFade = 1;
			CancelInvoke("Fade");
		}
	}
}
