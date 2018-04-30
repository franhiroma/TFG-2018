using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movDisparo : MonoBehaviour {

    public int velDisparo = 230;
    public int umbral_x = 50;
    public int umbral_y = 50;
    private int upordown = 0;
    public GameObject panel1_obj;
    public Transform DisparoDifraccionObjUp, DisparoDifraccionObjDown;
    private float panel1_x, panel1_y;
    private bool rendija_pasada = false;

    void Start()
    {
        panel1_x = panel1_obj.transform.position.x;
        panel1_y = panel1_obj.transform.position.y;
        //Random.InitState(System.DateTime.Now.Millisecond);
        upordown = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update ()
    {
        checkDetector();
        Vector2 up = new Vector2(transform.position.x, panel1_y + umbral_y);
        Vector2 down = new Vector2(transform.position.x, panel1_y - umbral_y);
        transform.Translate(Vector2.right * velDisparo * Time.deltaTime);
        Destroy(this.gameObject, 3);
        if (transform.position.x >= panel1_x - umbral_x && !rendija_pasada)
        {
            rendija_pasada = true;
            //Debug.Log("upordown:= " + upordown);
            if(upordown == 0) Instantiate(DisparoDifraccionObjUp, up, transform.rotation);
            else if(upordown == 1) Instantiate(DisparoDifraccionObjDown, down, transform.rotation);
            Destroy(this.gameObject);
        }
	}

    private void checkDetector()
    {
        if (detectaArriba_boton.detectar && !detectaAbajo_boton.detectar)
        {
            upordown = 0;
        }
        else if (!detectaArriba_boton.detectar && detectaAbajo_boton.detectar)
        {
            upordown = 1;
        }
    }
}
