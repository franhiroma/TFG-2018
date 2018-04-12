using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movDisparo : MonoBehaviour {

    public int velDisparo = 230;
    public int umbral_x = 50;
    public int umbral_y = 50;
    public GameObject panel1_obj;
    public Transform DisparoDifraccionObjUp, DisparoDifraccionObjDown;

    private float panel1_x, panel1_y;
    private bool rendija_pasada = false;

    void Start()
    {
        panel1_x = panel1_obj.transform.position.x;
        panel1_y = panel1_obj.transform.position.y;
    }

    // Update is called once per frame
    void Update ()
    {
        Vector2 up = new Vector2(transform.position.x, panel1_y + umbral_y);
        Vector2 down = new Vector2(transform.position.x, panel1_y - umbral_y);
        transform.Translate(Vector2.right * velDisparo * Time.deltaTime);
        Destroy(this.gameObject, 3);
        if (transform.position.x >= panel1_x - umbral_x && !rendija_pasada)
        {
            rendija_pasada = true;
            Instantiate(DisparoDifraccionObjUp, up, transform.rotation);
            Instantiate(DisparoDifraccionObjDown, down, transform.rotation);
            Destroy(this.gameObject);
        }
	}
}
