using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformBody : MonoBehaviour {
    bool isBusy = false;

    [SerializeField]
    private float timeForScaling = 20f;

    [SerializeField]
    private int scaleStep = 10;

    [SerializeField]
    private int middleSize = 0;

    [SerializeField]
    private float maxSize = 100f;

    [SerializeField]
    private List<Blendshape> blendshapes = null;

    private SkinnedMeshRenderer skinnedMeshRenderer;

    int clicked = 0;

    // Start is called before the first frame update
    void Start() {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public void ScaleStart(bool isThisButtonRight) {
        clicked++;
        Debug.Log("blend shape click amount: " + clicked);
        if(!isBusy) {
            Debug.Log("GO, not busy");
            foreach(Blendshape shape in blendshapes) {
                if(shape.isSelected) {
                    StartCoroutine(ScaleBody(shape, isThisButtonRight, timeForScaling));
                    //break;
                }
            }
        }
    }

    IEnumerator ScaleBody(Blendshape shape, bool buttonRight, float scaleScaleStep) {
        isBusy = true;

        int blendshapeIndex = 0;
        float currentSize = shape.currentBlendValue;
        float sizeToBe = 0;

        if(currentSize == middleSize) {
            shape.flipMinMax();
        } else if(currentSize == maxSize) {
            yield return null;
            //HIER STOP DING MAKEN
        }

        if(shape.isMin) {
            blendshapeIndex = shape.minIndex;

            if(!buttonRight /*&& currentSize != maxSize*/) {
                sizeToBe = currentSize + scaleStep;
                Debug.Log("state 1");
            } else {
                sizeToBe = currentSize - scaleStep;
                Debug.Log("state 2");
            }
        } else {
            blendshapeIndex = shape.maxIndex;

            if(buttonRight /*&& currentSize != maxSize*/) {
                sizeToBe = currentSize + scaleStep;
                Debug.Log("state 3");
            } else {
                sizeToBe = currentSize - scaleStep;
                Debug.Log("state 4");
            }
        }

        Debug.Log("to be: " + sizeToBe);

        skinnedMeshRenderer.SetBlendShapeWeight(blendshapeIndex, Mathf.Lerp(currentSize, sizeToBe, scaleScaleStep));

        shape.currentBlendValue = skinnedMeshRenderer.GetBlendShapeWeight(blendshapeIndex);

        isBusy = false;

        yield return null;
    }
}