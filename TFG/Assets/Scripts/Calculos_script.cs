using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MathNet.Numerics;
using UnityEngine.SceneManagement;

public class Calculos_script : MonoBehaviour {
    // PARAMETROS A CAMBIAR //
    public static double lambda;
    public static double dist_rendijas;
    public static double anchura_panel;
    // PARAMETROS A CAMBIAR //
    private double[] y;
    private double dist_panel;
    private int num_puntos;

    public static double[] distribucion;
    private double sum_distribucion;
    public static double[] probabilidades;
    private double sum_probabilidades;
    public GameObject GrafoRenderer;
    public static bool hayQueCalcular;


    // Use this for initialization

    private void Start()
    {
        hayQueCalcular = true;
        num_puntos = 400;
        distribucion = new double[num_puntos];
        probabilidades = new double[num_puntos];
        dist_panel = 10.0;
        anchura_panel = 5;
        dist_rendijas = 20.0;
        lambda = 2;
        Instantiate(GrafoRenderer, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (hayQueCalcular == true) Operaciones();
    }

    void Operaciones ()
    {

        if (SceneManager.GetActiveScene().name == "Rendija_lvl0") // Para una rendija
        {

            y = Generate.LinearSpaced(num_puntos, -10, 10);
            for (int i = 0; i < y.Length; i++)
            {
                distribucion[i] = distribucion1rendija(y[i]);
                sum_distribucion += distribucion[i];
            }
            for (int j = 0; j < distribucion.Length; j++)
            {
                probabilidades[j] = (1 / sum_distribucion) * distribucion[j];
                sum_probabilidades += probabilidades[j];
                
            }

        }
        else
        {
            if (!detectaArriba_boton.detectar && !detectaAbajo_boton.detectar)
            {
                y = Generate.LinearSpaced(num_puntos, -10, 10);
                //Debug.Log("DISTRIBUCION");
                for (int i = 0; i < y.Length; i++)
                {
                    distribucion[i] = distribucion2rendijas(y[i]);
                    sum_distribucion += distribucion[i];
                    //Debug.Log(distribucion[i]);
                }
                for (int j = 0; j < distribucion.Length; j++)
                {
                    probabilidades[j] = (1 / sum_distribucion) * distribucion[j];
                    sum_probabilidades += probabilidades[j];

                    //Debug.Log("PROBABILIDADES:  " + probabilidades[j]);
                }
            }
            else if (detectaArriba_boton.detectar || detectaAbajo_boton.detectar)
            {
                y = Generate.LinearSpaced(num_puntos, -10, 10);
                for (int i = 0; i < y.Length; i++)
                {
                    distribucion[i] = distribucion1rendija(y[i]);
                    sum_distribucion += distribucion[i];
                }
                for (int j = 0; j < distribucion.Length; j++)
                {
                    probabilidades[j] = (1 / sum_distribucion) * distribucion[j];
                    sum_probabilidades += probabilidades[j];
                }
            }
        }

        hayQueCalcular = false;

    }
    private double Sinc(double d)
    {
        return Math.Sin(d) / d;
    }

    private double distribucion1rendija(double s)
    {
        return Math.Pow(Sinc((anchura_panel * Math.PI * s) / (dist_panel * lambda)), 2);
    }

    private double distribucion2rendijas(double s)
    {
        return Math.Pow(Math.Cos( (dist_rendijas * Math.PI * s) / (dist_panel * lambda) ), 2) * distribucion1rendija(s);
    }






}
