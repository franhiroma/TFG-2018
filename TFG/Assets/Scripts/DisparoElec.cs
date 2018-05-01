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
        /*
        if (Input.GetKey(KeyCode.Space) && CharacterManager.dispAble == true)
        {
            if(energyCharge < limitCharge)
            {
                energyCharge += 1.0f;
            }
            Debug.Log("energyCharge:=" + energyCharge);
        }
        */

        if (ratioDisparo == 0)
        {
            if (Input.GetKeyUp(KeyCode.Space) && CharacterManager.dispAble == true)
            {
                Debug.Log("ESTOY DONDE TENGO QUE ESTAR");
                Disparo();  
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space) && Time.time > coolDown && CharacterManager.dispAble == true)
            {
                Debug.Log("ESTOY DONDE TENGO QUE ESTAR1");
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
        Instantiate(DisparoElectronesObj, firePoint.position, firePoint.rotation);
    }
}
