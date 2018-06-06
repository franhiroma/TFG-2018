using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class menu_seleccion : MonoBehaviour
{

    public GameObject rendija_nivel;

    public void Seleccion()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Rendijas()
    {
        rendija_nivel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
