using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectaAbajo_boton : MonoBehaviour {

    public static bool detectar;

	// Use this for initialization
	void Start ()
    {
        detectar = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            detectar = true;
        }
    }

}
