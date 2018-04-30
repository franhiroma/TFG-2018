using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorArriba : MonoBehaviour
{
    private Vector2 posActivado, posDesactivado;
    public float umbralArriba = 35.0f;
    public float velDetector = 100.0f;

    // Use this for initialization
    void Start()
    {
        posActivado = new Vector2(transform.position.x, transform.position.y + umbralArriba);
        posDesactivado = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posActual = new Vector2(transform.position.x, transform.position.y);
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
