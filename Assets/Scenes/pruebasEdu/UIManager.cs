using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject panelNewGame;
    public GameObject panelExit;
    public GameObject panelDialogue;
    public Text textDialogue;
    private int dialogueLength;
    private int i;
    private bool dialogueCompleted = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NEWGAME()
    {
        panelNewGame.SetActive(false);
        SetDialogue("New Game Started");
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
            yield return new WaitForSeconds(0.15f);
            textDialogue.text = dialogueLine.Substring(0, i);
            if (i == dialogueLength)
            {
                dialogueCompleted = true;
            }
            
        }

        if (dialogueCompleted == true)
            {
                yield return new WaitForSeconds(3f);
                panelDialogue.SetActive(false);
            }
    }
}


