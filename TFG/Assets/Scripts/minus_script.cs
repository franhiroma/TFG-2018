using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minus_script : MonoBehaviour
{

    private double lambda_value;
    public double ratioMinus;

    // Use this for initialization
    void Start()
    {
        ratioMinus = 0.100000000000;
    }

    private void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.gameObject.name == "Character" && Calculos_script.lambda > 0.0000000000000000)
        {
            Calculos_script.hayQueCalcular = true;
            Calculos_script.lambda -= ratioMinus;
        }
    }

}
