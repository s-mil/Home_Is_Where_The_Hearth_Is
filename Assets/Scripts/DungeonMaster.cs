using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonMaster : MonoBehaviour
{

    public static int progress = 0;
    public static int level = 2;

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

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

    }

    /// <summary>
    /// Loads the next level and adds 1 to the level counter.
    /// </summary>
    public void Warp()
    {
        Debug.Log("Attempting to Load Scene: "+level);
        SceneManager.LoadScene(LevelList[level++]);

    }


    public void ProgressUp()
    {
        progress++;
        Debug.Log("Progress Increased to: "+progress);
    }

    public void Death()
    {
        level--;
        Debug.Log("Level Decremented to: "+ level);
    }


}
