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

        
    }

    // Update is called once per frame
    void Update()
    {
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
		Debug.Log("RESETEO");
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


