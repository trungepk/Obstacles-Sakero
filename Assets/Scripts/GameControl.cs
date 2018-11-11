using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    [SerializeField] float slowness = 10f;
    [SerializeField] GameObject loseImage;
    [SerializeField] AudioClip loseSFX;
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
        StartCoroutine(RestartLevel());
    }
    
    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime /= slowness;
        loseImage.SetActive(true);
        AudioSource.PlayClipAtPoint(loseSFX, Camera.main.transform.position);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        Time.fixedDeltaTime *= slowness;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
