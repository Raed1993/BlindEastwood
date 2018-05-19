using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereNoise : MonoBehaviour {


    public float increasePerframe;
    public float maxSize;
    private SphereCollider sphereCollider;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>(); 
    }
    // Use this for initialization
    private void Update()
    {
        if (sphereCollider.radius < maxSize)
        {
            sphereCollider.radius += increasePerframe;
        }
    }

}
