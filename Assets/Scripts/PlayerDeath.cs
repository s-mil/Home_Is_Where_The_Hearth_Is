using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /// <summary>
        /// Detects a Trigger entered by the player
        /// </summary>
        /// <param name="other"></param>
        void OnTriggerEnter(Collider other)
        {
            /// <summary>
            /// if the collision is with a entity that kills
          /// </summary>  
            if (other.GetComponent<Collider>().CompareTag("INSERT_TAG"))
            {
                Respawn();
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == “spikes”) {
            Destroy(gameObject); 
            // or whatever kill script you want
        }
    }    

    /// <summary>
    /// The method that respawns the player at Home
    /// </summary>
    void Respawn()
    {
        SceneManager.LoadScene("<HOME_Scene>");
        // Add any kind of acknoledgement of Death 

    }

}
