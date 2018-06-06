using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderizadorGrafos2 : MonoBehaviour
{
    // Creates a line renderer that follows a Sin() function
    // and animates it.

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    private int lengthOfLineRenderer;

    void Start()
    {

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.widthMultiplier = 5f;
        lengthOfLineRenderer = Calculos_script.distribucion.Length;
        lineRenderer.positionCount = lengthOfLineRenderer;
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;
    }

    void Update()
    {
        if (!detectaArriba_boton.detectar && !detectaAbajo_boton.detectar)
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            var t = Time.time;
            for (int i = 0; i < lengthOfLineRenderer; i++)
            {
                float xx = 330f - ((float)Calculos_script.distribucion[i] * 100f);
                lineRenderer.SetPosition(i, new Vector3(xx, (float)i - 200f, 1.0f));
            }
        }
        else if (detectaAbajo_boton.detectar)
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            var t = Time.time;
            for (int i = 0; i < lengthOfLineRenderer; i++)
            {
                float xx = 330f - ((float)Calculos_script.distribucion[i] * 100f);
                lineRenderer.SetPosition(i, new Vector3(xx, (float)i - 250f, 1.0f));
            }
        }
        else { }
    }
}
