using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion_script : MonoBehaviour {

    public Sprite una_estrella;
    public Sprite dos_estrellas;
    public Sprite tres_estrellas;

	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if()
        if (GameManager.ondas == 2)
        {
            GetComponent<Image>().sprite = tres_estrellas;
        }
        else if (GameManager.ondas > 2 && GameManager.ondas < 6)
        {
            GetComponent<Image>().sprite = dos_estrellas;
        }
        else if (GameManager.ondas > 6)
        {
            GetComponent<Image>().sprite = una_estrella;
        }

    }
}
