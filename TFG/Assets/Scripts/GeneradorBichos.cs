using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneradorBichos : MonoBehaviour {

    public GameObject bichofeo, bichofeoLvl4;
    private float lapsoTiempo, tiempo;
    Scene scene;
    Vector2 pos;
    public static int bichoCount;

    // Use this for initialization
    void Start()
    {
        lapsoTiempo = 5.0f;
        tiempo = 0.0f;
        scene = SceneManager.GetActiveScene();
        bichoCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if(tiempo > lapsoTiempo)
        {
            if (scene.name == "Rendija_lvl1")
            {
                pos = new Vector2(Random.Range(235.0f, 301.0f), Random.Range(-90.0f, -180.0f));
                Instantiate(bichofeo, pos, transform.rotation);
                bichoCount += 1;
            }
            else if (scene.name == "Rendija_lvl2")
            {
                pos = new Vector2(Random.Range(235.0f, 301.0f), Random.Range(180.0f, 110.0f));
                Instantiate(bichofeo, pos, transform.rotation);
                bichoCount += 1;
            }
            else if (scene.name == "Rendija_lvl3")
            {
                int choice = Random.Range(0, 2);
                if (choice == 0) pos = new Vector2(Random.Range(20.0f, 320.0f), Random.Range(60.0f, 10.0f));
                else if (choice == 1) pos = new Vector2(Random.Range(20.0f, 320.0f), Random.Range(-40.0f, -60.0f));
                Instantiate(bichofeo, pos, transform.rotation);
                bichoCount += 1;
            }
            else if (scene.name == "Rendija_lvl4")
            {
                pos = new Vector2(Random.Range(20.0f, 320.0f), Random.Range(180.0f, -185.0f));
                Instantiate(bichofeoLvl4, pos, transform.rotation);
                bichoCount += 1;
            }

            tiempo = 0.0f;
        }
        //Debug.Log("bichoCount:= " + bichoCount);
    }
}
