using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour {

    public GameObject noise;
    public float radiusSoundToImpact = 30;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject auxNoise = Instantiate(noise, collision.contacts[0].point, noise.transform.rotation);
        auxNoise.GetComponent<SphereNoise>().maxSize = collision.impulse.sqrMagnitude / radiusSoundToImpact;
    }
}
