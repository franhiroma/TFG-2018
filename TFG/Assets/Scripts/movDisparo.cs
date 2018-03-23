using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movDisparo : MonoBehaviour {

    public int velDisparo = 230;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.right * velDisparo * Time.deltaTime);
        Destroy(this.gameObject, 3);
	}
}
