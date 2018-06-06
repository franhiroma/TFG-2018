using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particula_fondo : MonoBehaviour {

    public Sprite fondo1, fondo2, fondo3, fondo4;
    private int choice;

	// Use this for initialization
	void Start ()
    {
        choice = Random.Range(1, 5);
        if (choice == 1) GetComponent<SpriteRenderer>().sprite = fondo1;
        if (choice == 2) GetComponent<SpriteRenderer>().sprite = fondo2;
        if (choice == 3) GetComponent<SpriteRenderer>().sprite = fondo3;
        if (choice == 4) GetComponent<SpriteRenderer>().sprite = fondo4;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.right * 200.0f * Time.deltaTime);
    }
}
