using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//cosas gestionadas por el Game manager
	static public GameManager instance;
	public int enemies;
	private int totalEnemies;
	public UIManagerScene02 uiManager;
    public float timeToEnd;
	// Use this for initialization
	void Awake () 
	{
		instance = this;

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

	void Start()
	{
		totalEnemies = enemies;
		Time.timeScale=1;
		uiManager = GetComponent<UIManagerScene02> ();
	}

    // Update is called once per frame
    void Update ()
	{
        timeToEnd += Time.deltaTime;
	}

	public void EnemyDie(){
		enemies -= 1;
		if (totalEnemies / 2 >= enemies) 
		{
			//mando string
		}
		if (enemies <= 0)
		{
			Invoke ("win", 2f);

		}
	}

	public void EndGame(string text)
	{
		uiManager.EndGame (text);

	}

	void win()
	{
        float minutes = Mathf.Floor(timeToEnd / 60);
        float seconds = timeToEnd % 60;

        string mode;


        if (PlayerPrefs.GetInt("dificil") == 0)
        {

            mode = "Original Mode";
        }
        else
        {
            mode = "Easy Mode";
        }
        EndGame("YOU WIN in " + minutes.ToString() + ":" + Mathf.RoundToInt(seconds).ToString() + "\n" +  mode);
	}
}
