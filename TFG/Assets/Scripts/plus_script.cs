using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plus_script : MonoBehaviour
{

    private double lambda_value;
    public double ratioPlus;
    public double limit;

    // Use this for initialization
    void Start()
    {
        ratioPlus = 0.1;
        limit = 40.00000000;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character" && Calculos_script.lambda < limit)
        {
            Calculos_script.hayQueCalcular = true;
            Calculos_script.lambda += ratioPlus;
        }
    }

}
