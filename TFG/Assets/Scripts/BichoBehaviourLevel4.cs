using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BichoBehaviourLevel4 : MonoBehaviour {

    private Transform bicho;
    private Vector2 velocidad;
    int choice;

    // Use this for initialization
    void Start ()
    {
        choice = Random.Range(0, 2);
        if (choice == 0) velocidad.y = 10 * 10 * Random.value;
        else if (choice == 1) velocidad.y = -10 * 10 * Random.value;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = velocidad;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "pared_abajo")
        {
            velocidad.y = 10 * 10 * Random.value;
        }
        if (collision.gameObject.name == "pared")
        {
            velocidad.y = -10 * 10 * Random.value;
        }
        if (collision.gameObject.name == "bichofeoLvl4" || collision.gameObject.name == "bichofeoLvl4(Clone)")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
