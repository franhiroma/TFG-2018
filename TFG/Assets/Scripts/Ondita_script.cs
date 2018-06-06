using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ondita_script : MonoBehaviour {

    public float velDisparo;
    private float lambda;

    // Use this for initialization
    void Start ()
    {
        velDisparo = 200.0f;
        lambda = (float) Calculos_script.lambda / 100;
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Transform>().transform.localScale += new Vector3(0.01f, lambda + 0.03f, 0.0f);
        transform.Translate(Vector2.right * velDisparo * Time.deltaTime);
        if (transform.position.x > 400.0f) Destroy(this.gameObject);
    }
}
