using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetAbajo : MonoBehaviour
{
    private bool activarPuedes = false;
    public Sprite spriteDesactivado;
    public Sprite spriteActivado;

    private void Update()
    {
        if (activarPuedes == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                detectaAbajo_boton.detectar = false;
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
