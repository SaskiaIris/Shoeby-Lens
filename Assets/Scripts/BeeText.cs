using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeText : MonoBehaviour
{
    public Text beeText;

    void Start()
    {
        beeText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Textchange(Text text)
    {
        yield return text;
    }
}
