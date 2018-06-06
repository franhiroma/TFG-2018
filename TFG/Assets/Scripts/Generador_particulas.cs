using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador_particulas : MonoBehaviour {

    public GameObject particula;
    private float lapsoTiempo, tiempo;
    Vector2 pos;
    public static int bichoCount;

    // Use this for initialization
    void Start()
    {
        lapsoTiempo = 0.5f;
        tiempo = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
            tiempo += Time.deltaTime;
            if (tiempo > lapsoTiempo)
            {
                pos = new Vector2(-10.0f, Random.Range(-5.0f, 5.0f));
                Instantiate(particula, pos, transform.rotation);
            }
    }
}
