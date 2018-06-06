using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendija_minus : MonoBehaviour
{
    private bool activarPuedes = false;
    public Sprite spriteActivado;
    public Sprite spriteDesactivado;
    public GameObject rendija_1, rendija_2, rendija_intermedia, detector_up, detector_dw;

    private void Start()
    {
        rendija_1 = GameObject.Find("panel_1_abajo");
        rendija_2 = GameObject.Find("panel_1_arriba");
        rendija_intermedia = GameObject.Find("panel_1_intermedio");
        //detector_up = GameObject.Find("detector_up");
        //detector_dw = GameObject.Find("detector_dw");
    }

    private void Update()
    {
        /*Debug.Log("activarPuedes: " + activarPuedes);
        Debug.Log("rendija1_y: " + rendija_1.GetComponent<Transform>().transform.position.y);
        Debug.Log("rendija2_y: " + rendija_2.GetComponent<Transform>().transform.position.y);*/
        if (activarPuedes == true)
        {
            if (Input.GetKeyUp(KeyCode.Space)
            && (rendija_1.GetComponent<Transform>().transform.position.y <= -265.0f)
            && (rendija_2.GetComponent<Transform>().transform.position.y >= 265.0f)
            && (rendija_intermedia.GetComponent<Transform>().transform.localScale.y > 0.16f))
            {
                RenderizadorGrafos.yy -= 4.5f;
                Calculos_script.dist_rendijas -= 1;
                Calculos_script.hayQueCalcular = true;
                rendija_1.GetComponent<Transform>().transform.position += new Vector3(0, 4.5f, 0);
                rendija_2.GetComponent<Transform>().transform.position += new Vector3(0, -4.5f, 0);
                rendija_intermedia.GetComponent<Transform>().transform.localScale -= new Vector3(0, 0.02f, 0);
                detector_up.GetComponent<Transform>().transform.position += new Vector3(0, -4.5f, 0);
                detector_dw.GetComponent<Transform>().transform.position += new Vector3(0, 4.5f, 0);
                GetComponent<SpriteRenderer>().sprite = spriteActivado;
                movDisparoAlt.umbral_y -= 4;
                //movDisparoAlt.up = rendija_2.GetComponent<Transform>().transform.position;
                //movDisparoAlt.down = rendija_1.GetComponent<Transform>().transform.position;
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

