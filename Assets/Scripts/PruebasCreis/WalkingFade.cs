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
    void FadeWalkLeft()
    {
        InvokeRepeating("FadeLeft", duration, duration);
    }

    void FadeWalkRigth()
    {
        InvokeRepeating("FadeRigth", duration, duration);
    }

    void FadeLeft()
    {
        materialLeft.color = Color.Lerp(materialLeft.color, new Color(1, 1, 1, controller.getPerceptionMultiplier(this.transform.position) * alphaFade), transition);
        if (materialLeft.color.a > 0.8f)
        {
            alphaFade = 0;
        }

        if (materialLeft.color.a < 0.1f)
        {
            materialLeft.color = new Color(1,1,1,0);
            alphaFade = 1;
            CancelInvoke("FadeLeft");
        }
    }

    void FadeRigth()
    {
        materialRigth.color = Color.Lerp(materialRigth.color, new Color(1, 1, 1, controller.getPerceptionMultiplier(this.transform.position) * alphaFade), transition);
        if (materialRigth.color.a > 0.8f)
        {
            alphaFade = 0;
        }

        if (materialRigth.color.a < 0.1f)
        {
            materialRigth.color = new Color(1, 1, 1, 0);
            alphaFade = 1;
            CancelInvoke("FadeRigth");
        }
    }
}
