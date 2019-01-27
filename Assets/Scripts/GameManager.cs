using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool Alive = true;
    public float respawnDelay = 1f;

    private void Start()
    {
    
        if ((SceneManager.GetActiveScene()).name == "Dream")
        {
            Invoke("Respawn", respawnDelay);

        }
    }


    public void GameOver()
    {
        if (Alive == true)
        {
            Alive = false;
            Debug.Log("GAME OVER");
            Invoke("PlayerDeath", respawnDelay);
        }
    }

    void PlayerDeath()
    {
        SceneManager.LoadScene(21);
    }

    void Respawn()
    {
        SceneManager.LoadScene(2);
    }
}
