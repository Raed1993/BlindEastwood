using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AtaquePorra : MonoBehaviour {

    public FirstPersonController fps;
	public AudioClip golpePorra;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
	{
        if (collider.tag != "Sound")
        {
            if (collider.tag == "Enemy")
            {
                collider.GetComponent<GetKilledEnemy>().Dead();
            }

            if (collider.tag == "Rehen")
            {
                GameManager.instance.EndGame("YouLose");
            }
        }
	}

    public void Sound()
    {
        audioSource.PlayOneShot(golpePorra, 1.0f);
        fps.InstantiateSound();
    }
}