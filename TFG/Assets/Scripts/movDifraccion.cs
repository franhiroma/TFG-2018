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
    private float panel1_x, panel1_y, panel2_height, panel2_x, franjaImpacto;
    private float[] zonaImpacto = new float[6];
    private bool movimiento;

    void Start()
    {
        float y_coord;
        movimiento = true;
        panel1_x = panel1_obj.transform.position.x;
        panel1_y = panel1_obj.transform.position.y;
        panel2_x = panel2_obj.transform.position.x;
        panel2_height = panel2_obj.GetComponent<SpriteRenderer>().bounds.size.y;
        Debug.Log("PANEL2_HEIGHT:= " + panel2_height);
        // Definición de las zonas de impacto //
        franjaImpacto = panel2_height / 5;
        Debug.Log("franjaImpacto:=" + franjaImpacto);
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
        Debug.Log("rangeZona:= " + rangeZona);
        switch (rangeZona)
        {
            case 0:
                y_coord = Random.Range(zonaImpacto[0], zonaImpacto[1]); // 0 - 80
                pointDifraccion = new Vector2(panel2_x, y_coord);
                Debug.Log("y_coord:= " + y_coord);
                break;
            case 1:
                y_coord = Random.Range(zonaImpacto[1], zonaImpacto[2]); // 80 - 160
                pointDifraccion = new Vector2(panel2_x, y_coord);
                Debug.Log("y_coord:= " + y_coord);
                break;
            case 2:
                y_coord = Random.Range(zonaImpacto[2], zonaImpacto[3]); // 160 - 240
                if (y_coord > 200.0f)
                {
                    y_coord = y_coord - 200.0f;
                    pointDifraccion = new Vector2(panel2_x, -y_coord);
                } 
                else pointDifraccion = new Vector2(panel2_x, y_coord);
                Debug.Log("y_coord:= " + y_coord);
                break;
            case 3:
                y_coord = Random.Range(zonaImpacto[3], zonaImpacto[4]) - 200.0f; // 240 - 320
                pointDifraccion = new Vector2(panel2_x, -y_coord);
                Debug.Log("y_coord:= " + -y_coord);
                break;
            case 4:
                y_coord = Random.Range(zonaImpacto[4], zonaImpacto[5]) - 200.0f; // 320 - 400
                pointDifraccion = new Vector2(panel2_x, -y_coord);
                Debug.Log("y_coord:= " + -y_coord);
                break;
            default:
                Debug.Log("Difraccion() -> esto no deberia de pasar...");
                break;
        }
        Debug.Log("PUNTO:= " + pointDifraccion);


    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velDisparo * Time.deltaTime); // Movimiento Derecha.
        if (transform.position.x >= panel1_x && movimiento == true) // Si superamos la rendija...
        {
            Difraccion();
        }

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
        if(collision.gameObject.name == "panel_2")
        {
            movimiento = false;
            //GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            velDisparo = 0;
        }
        
    }
}
