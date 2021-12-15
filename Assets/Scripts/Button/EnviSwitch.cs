using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviSwitch : MonoBehaviour
{
    public float duration = 0.25f; // seconds
    private Vector3 bushesOffPosition;
    private Vector3 catwalkOffPosition;
    public Vector3 bushesOnPosition = new Vector3(0.55f, 0.11f, -0.18f);
    public Vector3 catwalkOnPosition = new Vector3(1, -3, 1);
    private Coroutine ascent;
    private Coroutine descent;
    [SerializeField]
    private GameObject bushes, catwalk;

    [SerializeField]
    private int clicked = 0;

    [SerializeField]
    private int amountOfClicksBush = 2;


    void Start()
    {
        bushesOffPosition = bushes.transform.localPosition;
        catwalkOffPosition = catwalk.transform.localPosition;
        catwalk = null;
    }

    public void Switch()
    {
        if (ascent != null)
        {
            StopCoroutine(ascent);
        }
        //if (descent != null)
        //{
        //    StopCoroutine(descent);
        //}

        if (clicked == amountOfClicksBush)
        {
            bushes.SetActive(true);
            ascent = StartCoroutine(AnimateAscent(bushesOffPosition, bushesOnPosition));
            //descent = StartCoroutine(AnimateDescent(catwalkOffPosition, catwalkOnPosition));
        }

        clicked++;
    }

    private IEnumerator AnimateAscent(Vector3 bushFromPosition, Vector3 bushToPosition)
    {
        float t = 0;
        while (t < duration)
        {
            bushes.transform.position = Vector3.Lerp(bushFromPosition, bushToPosition, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
    }

    //private IEnumerator AnimateDescent(Vector3 catwalkFromPos, Vector3 catwalkToPos)
    //{
    //    float t = 0;
    //    while (t < duration)
    //    {
    //        catwalk.transform.position = Vector3.Lerp(catwalkFromPos, catwalkToPos, t / duration);
    //        t += Time.deltaTime;
    //        yield return null;
    //    }
    //    catwalk.SetActive(false);
    //}
}
