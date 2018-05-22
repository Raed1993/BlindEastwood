using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    NavMeshAgent navMeshAgent;
    Animator animator;
    bool isWalk = true;
    public int maxDistance;
    private bool isShotable = false;
    public int waitForMove = 5;
    private Vector3 zero = new Vector3(0, 0, 0);
    public AudioClip Disparo;
    public AudioClip sonidoMoneda;
    public AudioSource audioSource;
    

    // Use this for initialization
    void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        InvokeRepeating("Move", 0, waitForMove);
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (navMeshAgent.velocity.magnitude == 0 && isWalk)
        {
            animator.SetBool("isWalk", false);
            isWalk = false;
        }
        else if (navMeshAgent.velocity.magnitude > 0 && !isWalk)
        {
            animator.SetBool("isWalk", true);
            isWalk = true;
        }
	}



    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            transform.LookAt(other.transform);
            CancelInvoke();
            navMeshAgent.isStopped = true;
            Attack();
        }

        if (other.tag == "Sound")
        {
            transform.LookAt(other.transform);
            CancelInvoke();
            if(navMeshAgent.isActiveAndEnabled==true)
            navMeshAgent.isStopped = true;
            MoveToPosition(other.transform.GetChild(0).position);
			
			if (sonidoMoneda != null) {
				audioSource.PlayOneShot(sonidoMoneda,1.0f);
				//reproducido = true;
			} 

        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            CancelInvoke();
            navMeshAgent.isStopped = false;

            InvokeRepeating("Move", 0, waitForMove);
        }
    }

    void Move()
    {
        if (navMeshAgent.remainingDistance < 0.1f)
        {
            NavMeshHit hit;
            Vector3 position = transform.position + Random.insideUnitSphere * maxDistance;
            do
            {
                position = transform.position + Random.insideUnitSphere * maxDistance;

            } while (!NavMesh.SamplePosition(position, out hit, 1, NavMesh.AllAreas));
            navMeshAgent.destination = hit.position;
        }
    }

    void MoveToPosition(Vector3 position)
    {
        if (navMeshAgent.isActiveAndEnabled == true )
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = position;
            InvokeRepeating("Move", 0, waitForMove);
        }
    }
    void Attack()
    {
		GameManager.instance.EndGame("YOU DIED!");
			
		if (Disparo != null) {
			audioSource.PlayOneShot(Disparo,1.0f);
			//reproducido = true;
		} 
    }
}
