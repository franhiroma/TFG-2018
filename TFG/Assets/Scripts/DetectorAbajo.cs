using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorAbajo : MonoBehaviour
{
    private Vector2 posActivado, posDesactivado;
    public float umbralAbajo = 35.0f;
    public float velDetector = 100.0f;

    // Use this for initialization
    void Start ()
    {
        posActivado = new Vector2(transform.position.x, transform.position.y + umbralAbajo);
        posDesactivado = new Vector2(transform.position.x, transform.position.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 posActual = new Vector2(transform.position.x, transform.position.y);
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
