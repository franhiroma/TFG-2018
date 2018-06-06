using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorArriba : MonoBehaviour
{
    private float umbralDerecha = 8.0f;
    private float velDetector = 100.0f;
    private float posX, posX2;
    private Vector2 posActivado;
    private Vector2 posDesactivado;
    private Vector2 posActual;

    // Use this for initialization
    void Start()
    {
        posX = transform.position.x + umbralDerecha;
        posX2 = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        posActual = new Vector2(transform.position.x, transform.position.y);
        posActivado = new Vector2(posX, transform.position.y);
        posDesactivado = new Vector2(posX2, transform.position.y);

        if (detectaArriba_boton.detectar == true)
        {
            transform.position = Vector3.MoveTowards(posActual, posActivado, velDetector * Time.deltaTime);
        }
        else if (detectaArriba_boton.detectar == false)
        {
            transform.position = Vector3.MoveTowards(posActual, posDesactivado, velDetector * Time.deltaTime);
        }


    }
}
