using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movDifraccion : MonoBehaviour
{
    public int velDisparo = 100;
    public int umbral_x = 50;
    public int umbral_y = 50;
    private int rangeZona = 0;
    public GameObject panel1_obj;
    public GameObject panel2_obj;
    private Vector2 pointDifraccion;
    private float panel1_x, panel2_height, panel2_x, franjaImpacto;
    private float[] zonaImpacto = new float[6];
    private bool movimiento, impactado;

    void Start()
    {
        float y_coord;
        movimiento = true;
        impactado = false;
        panel1_x = panel1_obj.transform.position.x;
        panel2_x = panel2_obj.transform.position.x;
        panel2_height = panel2_obj.GetComponent<SpriteRenderer>().bounds.size.y;
        //Debug.Log("PANEL2_HEIGHT:= " + panel2_height);
        // Definición de las zonas de impacto //
        franjaImpacto = panel2_height / 5;
        //Debug.Log("franjaImpacto:=" + franjaImpacto);
        for (int i = 0; i < zonaImpacto.Length; i++)
        {
            if (i == 0) zonaImpacto[i] = 0.0f;
            else if (i == 5) zonaImpacto[i] = panel2_height;
            else
            {
                zonaImpacto[i] = zonaImpacto[i - 1] + franjaImpacto;
            }
        }

        rangeZona = Random.Range(0, 5);
        CheckPath();
        
        //Debug.Log("rangeZona:= " + rangeZona);
        switch (rangeZona)
        {
            case 0:
                y_coord = Random.Range(zonaImpacto[0], zonaImpacto[1]); // 0 - 80
                pointDifraccion = new Vector2(panel2_x, y_coord);
                //Debug.Log("y_coord:= " + y_coord);
                break;
            case 1:
                y_coord = Random.Range(zonaImpacto[1], zonaImpacto[2]); // 80 - 160
                pointDifraccion = new Vector2(panel2_x, y_coord);
                //Debug.Log("y_coord:= " + y_coord);
                break;
            case 2:
                y_coord = Random.Range(zonaImpacto[2], zonaImpacto[3]); // 160 - 240
                if (y_coord > 200.0f)
                {
                    y_coord = y_coord - 200.0f;
                    pointDifraccion = new Vector2(panel2_x, -y_coord);
                } 
                else pointDifraccion = new Vector2(panel2_x, y_coord);
                //Debug.Log("y_coord:= " + y_coord);
                break;
            case 3:
                y_coord = Random.Range(zonaImpacto[3], zonaImpacto[4]) - 200.0f; // 240 - 320
                pointDifraccion = new Vector2(panel2_x, -y_coord);
                //Debug.Log("y_coord:= " + -y_coord);
                break;
            case 4:
                y_coord = Random.Range(zonaImpacto[4], zonaImpacto[5]) - 200.0f; // 320 - 400
                pointDifraccion = new Vector2(panel2_x, -y_coord);
                //Debug.Log("y_coord:= " + -y_coord);
                break;
            case 5:
                pointDifraccion = new Vector2(panel2_x, Random.Range(transform.position.y - 10.0f, transform.position.y + 10.0f));
                break;
            default:
                Debug.Log("Difraccion() -> esto no deberia de pasar...");
                break;
        }
        //Debug.Log("PUNTO:= " + pointDifraccion);


    }
    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x >= panel1_x && movimiento == true) // Si superamos la rendija...
        {
            Difraccion();
        }
        else if (transform.position.x < panel1_x) transform.Translate(Vector2.right * velDisparo * Time.deltaTime); // Movimiento Derecha.

    }
    private void Difraccion()
    {
        //Debug.Log("VECTOR X:= " + vectorDifraccion.x);
        //Debug.Log("VECTOR Y:= " + vectorDifraccion.y);
        Vector2 posActual = new Vector2(transform.position.x, transform.position.y);
        //Debug.Log("posActual:= " + posActual);
        //transform.Translate(vectorDifraccion * velDisparo * Time.deltaTime);
        transform.position = Vector3.MoveTowards(posActual, pointDifraccion, velDisparo * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.name == "panel_2") // Colision con el panel 2
           || (collision.gameObject.name == "electron_down") // Colision con las propias particulas
           || (collision.gameObject.name == "electron_up")) // Esto evita el apelotonamiento loco
        {
            movimiento = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            velDisparo = 0;
            impactado = true;
        }

        if ((collision.gameObject.name == "bichofeo" || collision.gameObject.name == "bichofeo(Clone)"
            || collision.gameObject.name == "bichofeoLvl4" || collision.gameObject.name == "bichofeoLvl4(Clone)") 
            && !impactado)
        {
            Destroy(collision.gameObject);
            GeneradorBichos.bichoCount -= 1;
        }
        if (collision.gameObject.tag == "Invisible")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        
    }

    private void CheckPath()
    {
        if (detectaArriba_boton.detectar && !detectaAbajo_boton.detectar) rangeZona = Random.Range(0, 3);
        if (detectaAbajo_boton.detectar && !detectaArriba_boton.detectar) rangeZona = Random.Range(3, 5);
        //if(!detectaArriba_boton.detectar && !detectaAbajo_boton.detectar) rangeZona = Random.Range(0, 5);
        if (detectaArriba_boton.detectar && detectaAbajo_boton.detectar)
        {
            if (this.name == "electron_up(Clone)")
            {
                Debug.Log("ELECTRON_UPASD");
                rangeZona = 5;
            }
            else if (this.name == "electron_down(Clone)")
            {
                Debug.Log("ELECTRON_DOWNASD");
                rangeZona = 5;
            }
        }

    }
}
