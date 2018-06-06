using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;

    public float delay;
    public static int ondas = 0;

    public GameObject completeLevelUI, siguiente;

    public void CompleteLevel()
    {
        Debug.Log("Has ganado el nivel");
        completeLevelUI.SetActive(true);
        siguiente.SetActive(true);
        //EndGame();
    }

	// Use this for initialization
	public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Next", delay);
        }
	}

    private void Update()
    {
        if (GeneradorBichos.bichoCount == 0) CompleteLevel();
    }

    void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
