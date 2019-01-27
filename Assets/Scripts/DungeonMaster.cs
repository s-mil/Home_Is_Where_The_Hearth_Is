using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonMaster : MonoBehaviour
{
    /// <summary>
    /// The number of key Items retrieved
    /// </summary>
    public int progress = 0;
    /// <summary>
    /// The Index the next scene to load
    /// </summary>
    public int level = 2;

    public bool isCollected = false;

    /// <summary>
    /// THe order of the scenes to load
    /// </summary>
    /// <value>The index of the scene to load</value>
    Dictionary<int, int> LevelList = new Dictionary<int, int>
    {
        { 1 , 1 },
        { 2 , 2 },
        { 3 , 3 },
        { 4 , 2 },
        { 5 , 4 },
        { 6 , 2 },
        { 7 , 5 },
        { 8 , 6 },
        { 9 , 2 },
        { 10, 7 },
        { 11, 8 },
        { 12, 9 },
        { 13, 2 },
        { 14, 10},
        { 15, 11},
        { 16, 12},
        { 17, 13},
        { 18, 14},
        { 19, 2},
        { 20, 15},
        { 21, 17},
        { 22, 18},
        { 23, 19},
        { 24, 2 },
        { 25, 20}
    };
    /// <summary>
    /// Dont destroy this object
    /// </summary>
    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

    }

    /// <summary>
    /// Loads the next level and adds 1 to the level counter.
    /// </summary>
    public void Warp()
    {
        Debug.Log("Attempting to Load Scene: " + level);
        isCollected = false;
        SceneManager.LoadScene(LevelList[level++]);
        Debug.Log("isCollected:" + isCollected);

    }

    /// <summary>
    /// Icrement the progress counter
    /// </summary>
    public void ProgressUp()
    {
        progress++;
        isCollected = true;
        Debug.Log("Progress Increased to: " + progress);
        Debug.Log("isCollected:" + isCollected);
    }

    /// <summary>
    /// Decrement the level counter when the player dies so that they are returned to the level they died on
    /// </summary>
    public void Death()
    {
        level--;
        if(isCollected)
        {
            progress--;
            isCollected=false;
        }
        Debug.Log("Level Decremented to: " + level);
    }

    public int GetProgress()
    {
        return progress;
    }

}
