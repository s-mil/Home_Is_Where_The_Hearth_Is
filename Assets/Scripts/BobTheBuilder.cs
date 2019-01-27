using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// On load of the Home Scene determines which pieces of the house should be enabled/disabled
/// </summary>
public class BobTheBuilder : MonoBehaviour
{
    public GameObject FloorL, FloorR, WallL, WallR, Roof, door, window1, Fillers, Bonfire = null;

    public GameObject WP1, WP2, WP3, WP4, WP5, WP6, WP7, Chim = null;
    // Start is called before the first frame update

    void Awake()
    {

        int pieces = FindObjectOfType<DungeonMaster>().GetProgress();
        Debug.Log("Disabling House Objects");
        FloorL.GetComponent<Renderer>().enabled = false;
        FloorR.GetComponent<Renderer>().enabled = false;
        WallL.GetComponent<Renderer>().enabled = false;
        WallR.GetComponent<Renderer>().enabled = false;
        fillerDisable();
        Roof.GetComponent<Renderer>().enabled = false;
        door.GetComponent<Renderer>().enabled = false;
        window1.GetComponent<Renderer>().enabled = false;
        Bonfire.GetComponent<Renderer>().enabled = false;
        Debug.Log("Case : " + pieces);
        switch (pieces)
        {
            case 0:

                //Nothing Enabled
                break;
            case 1:
                FloorL.GetComponent<Renderer>().enabled = true;
                FloorR.GetComponent<Renderer>().enabled = true;
                break;
            case 2:
                FloorL.GetComponent<Renderer>().enabled = true;
                FloorR.GetComponent<Renderer>().enabled = true;
                WallL.GetComponent<Renderer>().enabled = true;
                WallR.GetComponent<Renderer>().enabled = true;
                break;
            case 3:
                FloorL.GetComponent<Renderer>().enabled = true;
                FloorR.GetComponent<Renderer>().enabled = true;
                WallL.GetComponent<Renderer>().enabled = true;
                WallR.GetComponent<Renderer>().enabled = true;
                fillerEnable();
                door.GetComponent<Renderer>().enabled = true;
                break;
            case 4:
                FloorL.GetComponent<Renderer>().enabled = true;
                FloorR.GetComponent<Renderer>().enabled = true;
                WallL.GetComponent<Renderer>().enabled = true;
                WallR.GetComponent<Renderer>().enabled = true;
                fillerEnable();
                door.GetComponent<Renderer>().enabled = true;
                window1.GetComponent<Renderer>().enabled = true;
                break;
            case 5:
                FloorL.GetComponent<Renderer>().enabled = true;
                FloorR.GetComponent<Renderer>().enabled = true;
                WallL.GetComponent<Renderer>().enabled = true;
                WallR.GetComponent<Renderer>().enabled = true;
                fillerEnable();
                door.GetComponent<Renderer>().enabled = true;
                window1.GetComponent<Renderer>().enabled = true;
                 Roof.GetComponent<Renderer>().enabled = true;
                break;
            default:
                FloorL.GetComponent<Renderer>().enabled = true;
                FloorR.GetComponent<Renderer>().enabled = true;
                WallL.GetComponent<Renderer>().enabled = true;
                WallR.GetComponent<Renderer>().enabled = true;
                fillerEnable();
                door.GetComponent<Renderer>().enabled = true;
                window1.GetComponent<Renderer>().enabled = true;
                Bonfire.GetComponent<Renderer>().enabled = true;
                break;
        }

    }

    void fillerDisable()
    {
        WP1.GetComponent<Renderer>().enabled = false;
        WP2.GetComponent<Renderer>().enabled = false;
        WP3.GetComponent<Renderer>().enabled = false;
        WP4.GetComponent<Renderer>().enabled = false;
        WP5.GetComponent<Renderer>().enabled = false;
        WP6.GetComponent<Renderer>().enabled = false;
        WP7.GetComponent<Renderer>().enabled = false;
        Chim.GetComponent<Renderer>().enabled = false;

    }

    void fillerEnable()
    {
        WP1.GetComponent<Renderer>().enabled = true;
        WP2.GetComponent<Renderer>().enabled = true;
        WP3.GetComponent<Renderer>().enabled = true;
        WP4.GetComponent<Renderer>().enabled = true;
        WP5.GetComponent<Renderer>().enabled = true;
        WP6.GetComponent<Renderer>().enabled = true;
        WP7.GetComponent<Renderer>().enabled = true;
        Chim.GetComponent<Renderer>().enabled = true;
    }

}
