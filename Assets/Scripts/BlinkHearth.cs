using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkHearth : MonoBehaviour {

    public float duration = 0.1f;
    float transition = 0.1f;
    public Material material;

    bool isShowing;
	bool isInTransition;
    public int alphaFade;
    private Color color;


	// Use this for initialization
    void Start()
    {
        color = material.GetColor("Tint Color");
        InvokeRepeating("Fade", duration, duration);
    }

    void Fade()
    {
        color = Color.Lerp(color, new Color(1, 1, 1, alphaFade), transition);
        if (color.a > 0.8f)
        {
            alphaFade = 0;
        }

        if (color.a < 0.2f)
        {
            alphaFade = 1;
        }
    }
}
