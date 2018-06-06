using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorAbajo : MonoBehaviour
{
    private Vector2 posActivado, posDesactivado, posActual;
    private float umbralDerecha = 8.0f;
    private float posX, posX2;
    private float velDetector = 100.0f;

    // Use this for initialization
    void Start ()
    {
        posX = transform.position.x + umbralDerecha;
        posX2 = transform.position.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        posActual = new Vector2(transform.position.x, transform.position.y);
        posActivado = new Vector2(posX, transform.position.y);
        posDesactivado = new Vector2(posX2, transform.position.y);

        if (detectaAbajo_boton.detectar == true)
        {
            transform.position = Vector3.MoveTowards(posActual, posActivado, velDetector * Time.deltaTime);
        }
        else if (detectaAbajo_boton.detectar == false)
        {
            transform.position = Vector3.MoveTowards(posActual, posDesactivado, velDetector * Time.deltaTime);
        }

        

    }
}
