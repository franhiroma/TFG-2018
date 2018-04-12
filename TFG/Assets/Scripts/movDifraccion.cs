using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movDifraccion : MonoBehaviour
{
    public int velDisparo = 230;
    public int umbral_x = 50;
    public int umbral_y = 50;
    public GameObject panel1_obj;

    private float panel1_x, panel1_y;

    void Start()
    {
        panel1_x = panel1_obj.transform.position.x;
        panel1_y = panel1_obj.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velDisparo * Time.deltaTime);
        if (transform.position.x >= panel1_x)
        {
            Destroy(this.gameObject);
        }

        //Destroy(this.gameObject, 3);

    }
}
