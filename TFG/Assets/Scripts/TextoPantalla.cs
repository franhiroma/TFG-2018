using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class TextoPantalla : MonoBehaviour
{
    private TextMeshProUGUI textmeshPro;
    private float value;

    private void Start()
    {
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        value = (float)Math.Round(Calculos_script.lambda, 2);
        textmeshPro.text = value.ToString();
    }
}
