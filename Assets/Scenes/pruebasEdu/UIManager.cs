using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject panelNewGame;
    public GameObject panelExit;
    public GameObject panelDialogue;
    public GameObject panelTitle;
	public GameObject endGameCanvas;
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
        firstPersonController.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SetDialogue("New Game Started");
        InvokeRepeating("FadeIntro", 0.025f, 0.025f);
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
}


