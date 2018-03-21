using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("AnimState", 0);
        anim.SetBool("isMoving", false);

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("AnimState", 0);
            anim.SetBool("isMoving", true);

        }
        else if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("AnimState", 1);
            anim.SetBool("isMoving", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("AnimState", 2);
            anim.SetBool("isMoving", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("AnimState", 3);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
