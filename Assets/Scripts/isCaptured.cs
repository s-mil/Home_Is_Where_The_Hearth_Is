using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCaptured : MonoBehaviour
{
    Animator anim;
    GameObject Portal;

    void Start()
    {
        anim = GetComponent<Animator>();
        Portal = GameObject.FindGameObjectWithTag("Warp");
        Portal.SetActive(false);
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "Player");
        {
            Debug.Log("capture collision detected!");
            anim.SetTrigger("isCaptured");
            Portal.SetActive(true);
        }
    }
}
