using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anchura_plus : MonoBehaviour
{
    private bool activarPuedes = false;
    public Sprite spriteActivado;
    public Sprite spriteDesactivado;
    public GameObject panel_arriba, panel_abajo, panel_intermedio;

    private void Start()
    {
        panel_arriba = GameObject.Find("panel_1_arriba");
        panel_abajo = GameObject.Find("panel_1_abajo");
        if(SceneManager.GetActiveScene().name != "Rendija_lvl0") panel_intermedio = GameObject.Find("panel_1_intermedio");
    }
    private void Update()
    {
        if (activarPuedes == true && (SceneManager.GetActiveScene().name == "Rendija_lvl0")) // UNA RENDIJA
        {
            if (Input.GetKeyUp(KeyCode.Space)
                && panel_arriba.GetComponent<Transform>().transform.localScale.x < 3.0F
                && panel_abajo.GetComponent<Transform>().transform.localScale.x < 3.0F)
            {
                Calculos_script.anchura_panel += 1;
                Calculos_script.hayQueCalcular = true;
                panel_arriba.GetComponent<Transform>().transform.localScale += new Vector3(0.10f, 0, 0);
                panel_abajo.GetComponent<Transform>().transform.localScale += new Vector3(0.10f, 0, 0);
                GetComponent<SpriteRenderer>().sprite = spriteActivado;
            }
        }
        else if (activarPuedes == true && (SceneManager.GetActiveScene().name != "Rendija_lvl0")) // DOS RENDIJAS
        {
            if (Input.GetKeyUp(KeyCode.Space)
                && panel_arriba.GetComponent<Transform>().transform.localScale.x < 3.0F
                && panel_abajo.GetComponent<Transform>().transform.localScale.x < 3.0F
                && panel_intermedio.GetComponent<Transform>().transform.localScale.x < 3.0F)
            {
                Calculos_script.anchura_panel += 1;
                Calculos_script.hayQueCalcular = true;
                panel_arriba.GetComponent<Transform>().transform.localScale += new Vector3(0.10f, 0, 0);
                panel_abajo.GetComponent<Transform>().transform.localScale += new Vector3(0.10f, 0, 0);
                panel_intermedio.GetComponent<Transform>().transform.localScale += new Vector3(0.10f, 0, 0);
                GetComponent<SpriteRenderer>().sprite = spriteActivado;
            }
        }
        else if (activarPuedes == false)
        {
            GetComponent<SpriteRenderer>().sprite = spriteDesactivado;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            activarPuedes = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            activarPuedes = false;
        }
    }
}

