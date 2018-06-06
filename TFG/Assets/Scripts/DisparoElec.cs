using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoElec : MonoBehaviour {

    public float ratioDisparo = 0;
    public Transform DisparoElectronesObj;

    private float coolDown = 0;
    private Transform firePoint;

    // Use this for initialization
    void Start ()
    {
        firePoint = GameObject.Find("PuntoDisparo").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (ratioDisparo == 0)
        {
            if (Input.GetKeyUp(KeyCode.Space) && CharacterManager.dispAble == true)
            {
                Disparo();  
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space) && Time.time > coolDown && CharacterManager.dispAble == true)
            {
                coolDown = Time.time + (1/ratioDisparo);
                Disparo();               
            }
        }
	}

    void Disparo()
    {
        Vector2 dirDisparo = Vector2.right;
        Particulas();
    }

    void Particulas()
    {
        if (Calculos_script.lambda > 0.0f)
        {
            Instantiate(DisparoElectronesObj, firePoint.position, firePoint.rotation);
            GameManager.ondas++;
        }

    }
}
