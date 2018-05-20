using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//cosas gestionadas por el Game manager
	static public GameManager instance;
	public int enemies;
	private int totalEnemies;
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
			EndGame ("\"You WIN!!!!\"");

		}
	}

	public void EndGame(string text)
	{
		Debug.Log(text);
		Time.timeScale = 0;
	}
	
}
