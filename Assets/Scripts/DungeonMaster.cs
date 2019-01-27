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
        { 4 , 4 },
        { 5 , 2 },
        { 6 , 5 },
        { 7 , 6 },
        { 8 , 2 },
        { 9 , 7 },
        { 10, 8 },
        { 11, 9 },
        { 12, 2 },
        { 13, 10},
        { 14, 11},
        { 15, 12},
        { 16, 13},
        { 17, 14},
        { 18, 2 },
        { 19, 15},
        { 20, 16},
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


}
