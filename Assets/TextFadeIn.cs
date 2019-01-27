using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToFade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitToFade()
    {
        yield return new WaitForSeconds(2f);
        Color.Lerp (Color.clear, Color.white, 1 * Time.deltaTime);
    }}
