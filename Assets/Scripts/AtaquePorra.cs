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
            if (golpePorra != null)
            {
                Invoke("Sound", 0.5f);
                audioSource.PlayOneShot(golpePorra, 1.0f);
                //reproducido = true;
            }
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

    private void Sound()
    {
        fps.InstantiateSound();
    }
}