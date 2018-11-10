using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public static GameControl instance = null;
    public bool isGameOver;

	void Awake () {
        if (instance == null)
        {
            instance = this;
        }else if (instance == this)
        {
            Destroy(gameObject);
        }
	}

    public void Lose()
    {
        isGameOver = true;
    }
	
}
