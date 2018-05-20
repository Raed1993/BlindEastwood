using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class UIManager : MonoBehaviour
{

    public GameObject panelNewGame;
    public GameObject panelExit;
    public GameObject panelDialogue;
    public GameObject panelTitle;
	public GameObject endGameCanvas;
	public GameObject fadeOutCinematic;

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject waypoint1;
	public GameObject waypoint2;
	public GameObject waypoint3;
	public GameObject waypoint4;

	public Animator animatorMale1;
	public Animator animatorMale2;
	public Animator animatorMale3;
	public Animator animatorMale4;
	public Animator animatorMale5;
	public Animator animatorMale6;
	public Animator animatorFemale1;
	public Animator animatorFemale2;
	public Animator animatorFemale3;
	public Animator animatorFemale4;

    public Text textDialogue;
    public Canvas canvasIntro;
	public Text textEndGame;
    private CanvasGroup canvasGroupIntro;
    private CanvasGroup canvasGroupDialogue;
    private GameObject player;
    private FirstPersonController firstPersonController;
    private int dialogueLength;
    private int i;
    private bool dialogueCompleted = false;
    private bool gameStarted = false;
	private bool endGameFading = false;
	public AudioClip ambiente;

    // Use this for initialization
    void Start()
    {
		enemy1.GetComponent<NavMeshAgent> ().speed = 0;
		enemy2.GetComponent<NavMeshAgent> ().speed = 0;
		enemy3.GetComponent<NavMeshAgent> ().speed = 0;
		enemy4.GetComponent<NavMeshAgent> ().speed = 0;



        player = GameObject.FindWithTag("Player");
        firstPersonController = player.GetComponent<FirstPersonController>();
        firstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        canvasGroupIntro = canvasIntro.GetComponent<CanvasGroup>();
        canvasGroupDialogue = panelDialogue.GetComponent<CanvasGroup>();

        
    }

    // Update is called once per frame
    void Update()
    {
		AudioSource audio = gameObject.AddComponent<AudioSource >();

		if (ambiente != null) {
			audio.PlayOneShot(ambiente,1.0f);
			//reproducido = true;
		} 
    }

    public void NEWGAME()
    {
		gameStarted = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SetDialogue("When you try to cross a blind man");
        InvokeRepeating("FadeIntro", 0.025f, 0.025f);
		Cinematic ();
        /*panelNewGame.SetActive(false);
        panelTitle.SetActive(false);
        panelExit.SetActive(false);*/
    }

    private void FadeIntro()
    {
        canvasGroupIntro.alpha -= Mathf.Lerp(1, 0, 0.9f);
    }

    public void EXITGAME()
    {
        panelExit.SetActive(false);
        Application.Quit();
    }

    public void SetDialogue(string dialogueLine)
    {
        textDialogue.text = "";
        panelDialogue.SetActive(true);
        //textDialogue.text = dialogueLine;
        dialogueLength = dialogueLine.Length;
        StartCoroutine(FadingDialogue(dialogueLine));

        /*for (i = 0; i <= dialogueLength; i++)
        { 
            textDialogue.text = dialogueLine.Substring(0, i);
            if (i <= dialogueLength - 1) textDialogue.text = dialogueLine + dialogueLine.Substring(i);
            Debug.Log(dialogueLine.Substring(i));
            if (i <= dialogueLength - 2) textDialogue.text = dialogueLine + dialogueLine.Substring(i + 1);
            Debug.Log(dialogueLine.Substring(i+1));

            if (i <= dialogueLength - 3) textDialogue.text = dialogueLine + dialogueLine.Substring(i+2);
            Debug.Log(dialogueLine.Substring(i+2));

            if (i <= dialogueLength - 4) textDialogue.text = dialogueLine + dialogueLine.Substring(i + 3);
        }
        Invoke("offDialogue", 5f);*/
    }


    
    IEnumerator FadingDialogue(string dialogueLine)
    {
        for (i = 0; i <= dialogueLength; i++)
        {
            yield return new WaitForSeconds(0.05f);
            textDialogue.text = dialogueLine.Substring(0, i);
            if (i == dialogueLength)
            {
                dialogueCompleted = true;
            }
            
        }

        if (dialogueCompleted == true)
        {
            yield return new WaitForSeconds(3f);
            InvokeRepeating("FadeDialogue", 0.05f, 0.05f);
        }
    }

    private void FadeDialogue()
    {
        canvasGroupDialogue.alpha -= Mathf.Lerp(1, 0, 0.9f);
        if (canvasGroupDialogue.alpha == 0) panelDialogue.SetActive(true);
    }

	public void EndGame(string text)
	{
		if (endGameFading == false)
		{
			firstPersonController.enabled = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			endGameCanvas.SetActive (true);
			textEndGame.text = text;
			Time.timeScale = 0.01f;
			InvokeRepeating ("FadeEndgame", 0.0005f, 0.0005f);
		}
	}

	private void FadeEndgame()
	{
		endGameFading = true;
		endGameCanvas.GetComponent<CanvasGroup> ().alpha += Mathf.Lerp (1, 0, 0.9f);
	}

	public void Reset()
	{
		Debug.Log("RESETEO");
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	private void Cinematic()
	{
		enemy1.GetComponent<NavMeshAgent> ().speed = 3;
		enemy2.GetComponent<NavMeshAgent> ().speed = 3;
		enemy3.GetComponent<NavMeshAgent> ().speed = 3;
		enemy4.GetComponent<NavMeshAgent> ().speed = 3;

		animatorMale1.SetBool("gameStarted", true);
		animatorMale2.SetBool("gameStarted", true);
		animatorMale3.SetBool("gameStarted", true);
		animatorMale4.SetBool("gameStarted", true);
		animatorMale5.SetBool("gameStarted", true);
		animatorMale6.SetBool("gameStarted", true);


		animatorFemale1.SetBool("gameStarted", true);
		animatorFemale2.SetBool("gameStarted", true);
		animatorFemale3.SetBool("gameStarted", true);
		animatorFemale4.SetBool("gameStarted", true);


		enemy1.GetComponent<NavMeshAgent> ().destination = waypoint1.transform.position;
		enemy2.GetComponent<NavMeshAgent> ().destination = waypoint2.transform.position;
		enemy3.GetComponent<NavMeshAgent> ().destination = waypoint3.transform.position;
		enemy4.GetComponent<NavMeshAgent> ().destination = waypoint4.transform.position;


		if (enemy1.GetComponent<NavMeshAgent> ().remainingDistance <= 1f) 
		{
			InvokeRepeating ("LookAtPlayer", 0.1f, 0.1f);
			enemy1.GetComponent<NavMeshAgent> ().isStopped = true;
		}
		if (enemy2.GetComponent<NavMeshAgent> ().remainingDistance <= 1f) 
		{
			InvokeRepeating ("LookAtPlayer", 0.1f, 0.1f);
			enemy2.GetComponent<NavMeshAgent> ().isStopped = true;
		}
		if (enemy3.GetComponent<NavMeshAgent> ().remainingDistance <= 1f) 
		{
			InvokeRepeating ("LookAtPlayer", 0.1f, 0.1f);
			enemy3.GetComponent<NavMeshAgent> ().isStopped = true;
		}
		if (enemy4.GetComponent<NavMeshAgent> ().remainingDistance <= 1f) 
		{
			InvokeRepeating ("LookAtPlayer", 0.1f, 0.1f);
			enemy4.GetComponent<NavMeshAgent> ().isStopped = true;
		}

		InvokeRepeating("FadeCinematic", 10f, 0.025f);


		Invoke ("StartGameplay", 15f);
	}

	private void FadeCinematic()
	{
		if (fadeOutCinematic.activeSelf == false) fadeOutCinematic.SetActive (true);
		{
			SetDialogue("Time to show these punks a lesson");
			fadeOutCinematic.GetComponent<CanvasGroup> ().alpha += Mathf.Lerp (1, 0, 0.9f);
		}
	}

	private void LookAtPlayer1()
	{
		enemy1.transform.LookAt(transform.position + player.transform.rotation * Vector3.left, player.transform.rotation * Vector3.up);
	}

	private void LookAtPlayer2()
	{
		enemy2.transform.LookAt(transform.position + player.transform.rotation * Vector3.left, player.transform.rotation * Vector3.up);
	}

	private void LookAtPlayer3()
	{
		enemy3.transform.LookAt(transform.position + player.transform.rotation * Vector3.left, player.transform.rotation * Vector3.up);
	}

	private void LookAtPlayer4()
	{
		enemy4.transform.LookAt(transform.position + player.transform.rotation * Vector3.left, player.transform.rotation * Vector3.up);
	}

	private void StartGameplay()
	{
		firstPersonController.enabled = true;
		SceneManager.LoadScene ("EscenaFinal");

	}
}


