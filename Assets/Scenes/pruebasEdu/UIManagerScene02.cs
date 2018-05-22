using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class UIManagerScene02 : MonoBehaviour
{

	public GameObject endGameCanvas;
	
    public Text textEndGame;
    private GameObject player;
    private FirstPersonController firstPersonController;
    private bool gameStarted = false;
	private bool endGameFading = false;
	public AudioClip ambiente;
    private int dialogueLength;
    private bool dialogueCompleted;
    public Text textDialogue;
    public CanvasGroup canvasGroupDialogue;
    public GameObject panelDialogue;

    // Use this for initialization
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        firstPersonController = player.GetComponent<FirstPersonController>();
		if (SceneManager.GetActiveScene().name != "EscenaFinal") 
        {firstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        }
        else
        CancelInvoke();
        Invoke("MensajeInicio", 1f);        
    }

    void MensajeInicio()
    {
        Mensaje("I'll turn off the lights\n and teach them a lesson...");
    }

    public void Mensaje(string mensaje)
    {
        textDialogue.text = "";
        canvasGroupDialogue.alpha = 1;
        panelDialogue.SetActive(true);
        dialogueLength = mensaje.Length;
        StartCoroutine(FadingDialogue(mensaje));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator FadingDialogue(string dialogueLine)
    {
        for (int i = 0; i <= dialogueLength; i++)
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
        if (canvasGroupDialogue.alpha == 0)
        {
            panelDialogue.SetActive(true);
            CancelInvoke("FadeDialogue");
        }
    }


    public void EndGame(string text)
	{
		if (endGameFading == false)
		{
			GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
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
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
	

	private void StartGameplay()
	{
		firstPersonController.enabled = true;
        CancelInvoke();
		SceneManager.LoadScene ("EscenaFinal");

	}
}


