using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCaptured : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "Player");
        {
            Debug.Log("capture collision detected!");
            anim.SetTrigger("isCaptured");
        }
    }
}
