using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class EnvironmentSwitch : MonoBehaviour
{
    private XRController controller = null;

    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<XRController>();
    }

    // Update is called once per frame
    void Update()
    {
        CommonInput();
    }

    private void CommonInput()
    {
        if(controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed))
        {
            if (pressed)
            {
                foreach (GameObject item in items)
                {
                    item.transform.position = -new Vector3(0f, -0.01f, 0f);
                    if(item.transform.position.y < 0)
                    {
                        item.SetActive(false);
                    }
                }
            }
        }
    }
}
