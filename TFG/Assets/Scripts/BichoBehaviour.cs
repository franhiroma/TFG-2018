using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BichoBehaviour : MonoBehaviour {
    // Atributos

    private float movimiento;
    private Transform bicho;
    private Vector2 velocidad;
    private float cambioDir = 3.0f;
    private float curTime = 0.0f;

	// Use this for initialization
	void Start ()
    {
        GeneradorBichos.bichoCount += 1;
        //movimiento = Random.Range(0.0f, 1.0f);
        //CheckDireccion(movimiento);
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*if (curTime < cambioDir)
        {
            curTime += 1 * Time.deltaTime;
        }
        else
        {
            movimiento = Random.Range(0.0f, 1.0f);
            CheckDireccion(movimiento);
            if (movimiento > 0.5f)
            {
                cambioDir += Random.value;
            }
            else cambioDir -= Random.value;
            if (cambioDir < 1.0f)
            {
                cambioDir = 1 + Random.value;
            }
            curTime = 0;
        }*/
	}

    void FixedUpdate()
    {
       GetComponent<Rigidbody2D>().velocity = velocidad;    
    }

    private void CheckDireccion(float movimiento)
    {
        if (movimiento > 0.5f)
        {
            velocidad.x = 10 * 10 * Random.value;
            velocidad.y = 10 * 10 * Random.value;
        }
        else
        {
            velocidad.x = -10 * 10 * Random.value;
            velocidad.y = -10 * 10 * Random.value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "paredInvisible")
        {
            velocidad.y = -10 * 10 * Random.value;
        }
        if (collision.gameObject.name == "panel_2")
        {
            velocidad.x = -10 * 10 * Random.value;
        }
        if (collision.gameObject.name == "panel_1")
        {
            velocidad.x = 10 * 10 * Random.value;
        }
        if (collision.gameObject.name == "pared_abajo")
        {
            velocidad.y = 10 * 10 * Random.value;
        }
        if (collision.gameObject.name == "bichofeo" || collision.gameObject.name == "bichofeo(Clone)")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }

    }

}
