using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviSwitch : MonoBehaviour
{
    public Vector3 descentSpeed = new Vector3(1, 5, 1);
    public float descentDuration = 0.25f; // seconds
    private Vector3 offPosition;
    public Vector3 onPosition = new Vector3(1, 3, 1);
    private Coroutine descent;
    [SerializeField]
    private GameObject bushes;

    private bool used = false;

    void Start()
    {
        offPosition = bushes.transform.position;
        //onPosition = Vector3.Scale(descentSpeed, offPosition);
    }

    public void Switch()
    {
        if (descent != null)
        {
            StopCoroutine(descent);
        }
        if (!used)
        {
            bushes.SetActive(true);
            descent = StartCoroutine(AnimateDescent(offPosition, onPosition));
            used = true;
        }
    }

    private IEnumerator AnimateDescent(Vector3 fromPosition, Vector3 toPosition)
    {
        float t = 0;
        while (t < descentDuration)
        {
            transform.position = Vector3.Lerp(fromPosition, toPosition, t / descentDuration);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
