using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public bool isColliding;
    public bool isDead;

    Animator anim;

    private AudioSource audio;

    public AudioSource Audio { get => audio; set => audio = value; }

    // Start is called before the first frame update
    void Start()
    {
        isColliding = false;
        isDead = false;
        anim = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();

    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // /// <summary>
        // /// Detects a Trigger entered by the player
        // /// </summary>
        // /// <param name="other"></param>
        // void OnTriggerEnter(Collider other)
        // {
        //     /// <summary>
        //     /// if the collision is with a entity that kills
        //   /// </summary>  
        //     if (other.GetComponent<Collider>().CompareTag("INSERT_TAG"))
        //     {
        //         Respawn();
        //     }
        // }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        if (!isDead)
        {
            if (collision.gameObject.tag == "spike")
            {
                anim.SetTrigger("DeathHappened");

                if (isDead == false)
                {
                    Audio.Play();
                }
                FindObjectOfType<DungeonMaster>().Death();
                //Destroy(gameObject); 
                FindObjectOfType<GameManager>().GameOver();
                // or whatever kill script you want

                isDead = true;
            }
        }

        if (collision.gameObject.tag == "Warp")
        {
            Debug.Log("Warp COlision");
            FindObjectOfType<DungeonMaster>().isCollected = false;
            FindObjectOfType<DungeonMaster>().Warp();


        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "keyitem")
        {
            if (!FindObjectOfType<DungeonMaster>().isCollected)
            {
                Debug.Log("KEY ITEM TRIGGER");
                FindObjectOfType<DungeonMaster>().ProgressUp();
            }
            
        }

    }


    // /// <summary>
    // /// The method that respawns the player at Home
    // /// </summary>
    // void Respawn()
    // {
    //     SceneManager.LoadScene("<HOME_Scene>");
    //     // Add any kind of acknoledgement of Death 

    // }

}
