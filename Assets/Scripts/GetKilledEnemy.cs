using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetKilledEnemy : MonoBehaviour {

	public float alphaFade;
	private float transition;
	public float transitionOut=0.01f;
	public GameObject colorEnemy;

	public float duration=0.1f; 
	private Material thisMaterial;
	private Animator anim;
	private AudioSource audioSource;
	private Enemy enemy;
	public AudioClip audioClip;
	private NavMeshAgent navMeshAgent;

	private bool isAlive = true;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		anim = this.gameObject.GetComponent<Animator>();
		audioSource.clip=audioClip;
		thisMaterial = colorEnemy.GetComponent<Renderer>().material;
		enemy = GetComponent<Enemy> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Dead(){
		if(isAlive){
			this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.active=false;
			enemy.CancelInvoke ();
			Destroy (navMeshAgent);
			Destroy (enemy);
            Destroy(GetComponent<CapsuleCollider>());
			anim.SetTrigger("Morir");
			audioSource.PlayOneShot(audioClip);
			transition = transitionOut;
			alphaFade = 0;
			InvokeRepeating("Fade", duration, duration);
			GameManager.instance.EnemyDie ();
			isAlive=false;
		}
		
	}

	void Fade()
    {
        thisMaterial.color = Color.Lerp(thisMaterial.color, new Color(1, 1, 1, alphaFade), transition);
        if (thisMaterial.color.a == alphaFade)
        {
            CancelInvoke();
        }
    }
}