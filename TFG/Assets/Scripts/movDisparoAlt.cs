using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics;
using UnityEngine.SceneManagement;

public class movDisparoAlt : MonoBehaviour
{
    public float velDisparo;
    public int umbral_x;
    public static int umbral_y = 50;
    public static int upordown = 0;
    public GameObject panel1_obj;
    public Transform DisparoDifraccionObjUp, DisparoDifraccionObjDown, Ondita_obj;
    private float panel1_x, panel1_y;
    private bool rendija_pasada = false;
    private Vector2 up;
    private Vector2 down;
    private float lambda;

    void Start()
    {
        panel1_x = panel1_obj.transform.position.x;
        panel1_y = panel1_obj.transform.position.y;
        if (SceneManager.GetActiveScene().name != "Rendija_lvl0")
        {
            if (detectaArriba_boton.detectar && !detectaAbajo_boton.detectar) upordown = 0;
            else if (detectaAbajo_boton.detectar && !detectaArriba_boton.detectar) upordown = 1;
            else upordown = Random.Range(0, 2);
        }
        umbral_x = 50;
        velDisparo = 200.0f;

        lambda = (float)Calculos_script.lambda / 100;


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velDisparo * Time.deltaTime);
        gameObject.GetComponent<Transform>().transform.localScale += new Vector3(0.01f, 0.03f + lambda, 0.0f);

        if (SceneManager.GetActiveScene().name != "Rendija_lvl0")
        {
            up = new Vector2(transform.position.x + umbral_x, panel1_y + umbral_y);
            Debug.Log("up " + up);
            down = new Vector2(transform.position.x + umbral_x, panel1_y - umbral_y);
        }
        else if (SceneManager.GetActiveScene().name == "Rendija_lvl0")
        {
            up = new Vector2(transform.position.x + umbral_x, panel1_y);
            down = new Vector2(transform.position.x + umbral_x, panel1_y);
        }
        if (transform.position.x >= (panel1_x - umbral_x) && !rendija_pasada)
        {
            rendija_pasada = true;

            if (upordown == 0)
            {
                Instantiate(DisparoDifraccionObjUp, up, transform.rotation);
                
            }
            else if (upordown == 1)
            {
                Instantiate(DisparoDifraccionObjDown, down, transform.rotation);
                
            }
            Instantiate(Ondita_obj, up, transform.rotation);
            Instantiate(Ondita_obj, down, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
