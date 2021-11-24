using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject birds;

    private bool triggered = false;
 
    public void OnTriggerEnter(Collider target)
    {
        if (target.transform.gameObject.name == "OVRHandPrefab")
        {
            if (!triggered)
            {
                Instantiate(birds, this.transform);
                triggered = true;
                Debug.Log("birbs");
            }
        }
    }
}