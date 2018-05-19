using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour {

    public GameObject noise;
    public float radiusSoundToImpact = 30;
    private bool instantiate;

    private void OnCollisionEnter(Collision collision)
    {
        if (instantiate == false)
        {
            GameObject auxNoise = Instantiate(noise, collision.contacts[0].point, noise.transform.rotation);
            auxNoise.GetComponent<SphereNoise>().maxSize = collision.impulse.sqrMagnitude / radiusSoundToImpact;
            instantiate = true;
            Destroy(auxNoise, 3);
        }
        
    }
}
