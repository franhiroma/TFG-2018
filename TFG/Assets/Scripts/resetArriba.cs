using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetArriba : MonoBehaviour
{
    private bool activarPuedes = false;
    public Sprite spriteActivado;
    public Sprite spriteDesactivado;
    private void Update()
    {
        if (activarPuedes == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                detectaArriba_boton.detectar = false;
                GetComponent<SpriteRenderer>().sprite = spriteActivado;
                Calculos_script.hayQueCalcular = true;
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

