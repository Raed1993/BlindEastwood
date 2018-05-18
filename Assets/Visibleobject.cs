using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibleobject : MonoBehaviour {

    public int timeToFade;
    MeshRenderer meshRenderer;
    WaitForSeconds waitToFade;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        waitToFade = new WaitForSeconds(timeToFade);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Renderer());
    }

    private IEnumerator Renderer()
    {
        meshRenderer.enabled = true;

        yield return waitToFade;

        meshRenderer.enabled = false;
    }
}
