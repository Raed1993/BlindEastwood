using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//cosas gestionadas por el Game manager
	static public GameManager instance;
	public int enemies;
	private int totalEnemies;
	private UIManagerScene02 uiManager;
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
		EndGame ("YOU WIN!!!");
	}
}
