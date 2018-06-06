using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movDifraccionAlt : MonoBehaviour
{
    private float velDisparo;
    private int rangePunto;
    public GameObject panel1_obj;
    public GameObject panel2_obj;
    private Vector2 pointDifraccion;
    private float panel1_x, panel2_height, panel2_x;
    private bool movimiento;
    public bool impactado;

    void Start()
    {
        movimiento = true;
        impactado = false;
        velDisparo = 200.0f;
        panel1_x = panel1_obj.transform.position.x;
        panel2_x = panel2_obj.transform.position.x;

        CheckPath();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= panel1_x && movimiento == true) // Si superamos la rendija...
        {
            Difraccion();
        }

    }
    private void Difraccion()
    {
        Vector2 posActual = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector3.MoveTowards(posActual, pointDifraccion, velDisparo * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name == "panel_2") // Colision con el panel 2
           || (collision.gameObject.name == "electron_down") // Colision con las propias particulas
           || (collision.gameObject.name == "electron_up")) // Esto evita el apelotonamiento loco
        {
            movimiento = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().isKinematic = false;
            velDisparo = 0;
            impactado = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }

        if ((collision.gameObject.name == "bichofeo" || collision.gameObject.name == "bichofeo(Clone)"
            || collision.gameObject.name == "bichofeoLvl4" || collision.gameObject.name == "bichofeoLvl4(Clone)"))
        {
            if (!impactado)
            {
                Destroy(collision.gameObject);
                GeneradorBichos.bichoCount -= 1;
            }
            else Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());

        }
        if (collision.gameObject.tag == "Invisible")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

    }

    private void CheckPath()
    {
        if ((detectaArriba_boton.detectar && !detectaAbajo_boton.detectar) && (SceneManager.GetActiveScene().name != "Rendija_lvl0"))
        {
            float y = Choose(Calculos_script.probabilidades);
            pointDifraccion = new Vector2(panel2_x, y - 150 + RenderizadorGrafos.yy);
        }
        else if ((!detectaArriba_boton.detectar && detectaAbajo_boton.detectar) && (SceneManager.GetActiveScene().name != "Rendija_lvl0"))
        {
            float y = Choose(Calculos_script.probabilidades);
            pointDifraccion = new Vector2(panel2_x, y - 250 - RenderizadorGrafos.yy);
        }
        else if ((!detectaArriba_boton.detectar && !detectaAbajo_boton.detectar) && (SceneManager.GetActiveScene().name != "Rendija_lvl0"))
        {
            float y = Choose(Calculos_script.probabilidades);
            pointDifraccion = new Vector2(panel2_x, y - 200);
        }
        else if ((detectaArriba_boton.detectar && detectaAbajo_boton.detectar) && (SceneManager.GetActiveScene().name != "Rendija_lvl0"))
        {
            Debug.Log("hey majisimo");
            if (gameObject.name == "electron_up(Clone)")
            {
                float y = Choose(Calculos_script.probabilidades);
                pointDifraccion = new Vector2(panel2_x, y - 150 + RenderizadorGrafos.yy);
            }
            if (gameObject.name == "electron_down(Clone)")
            {
                float y = Choose(Calculos_script.probabilidades);
                pointDifraccion = new Vector2(panel2_x, y - 250 - RenderizadorGrafos.yy);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Rendija_lvl0")
        {
            float y = Choose(Calculos_script.probabilidades);
            pointDifraccion = new Vector2(panel2_x, y - 200);
        }
    }

    float Choose(double[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        double randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
