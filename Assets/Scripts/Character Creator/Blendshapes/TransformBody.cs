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

    public void SaveShapes() {

    }

    IEnumerator ScaleBody(Blendshape shape, bool buttonRight, float scaleScaleStep) {
        isBusy = true;

        int blendshapeIndex = 0;
        float currentSize;
        float sizeToBe = 0;

        if(shape.isMin) {
            currentSize = skinnedMeshRenderer.GetBlendShapeWeight(shape.minIndex);

            if(!buttonRight && currentSize != maxSize) {
                blendshapeIndex = shape.minIndex;
                sizeToBe = currentSize + scaleStep;
            } else if(buttonRight && currentSize != middleSize) {
                blendshapeIndex = shape.minIndex;
                sizeToBe = currentSize - scaleStep;
            } else if(buttonRight && currentSize == middleSize) {
                shape.flipMinMax();
                blendshapeIndex = shape.maxIndex;
                sizeToBe = currentSize + scaleStep;
            }
        } else {
            currentSize = skinnedMeshRenderer.GetBlendShapeWeight(shape.maxIndex);

            if(buttonRight && currentSize != maxSize) {
                blendshapeIndex = shape.maxIndex;
                sizeToBe = currentSize + scaleStep;
            } else if(!buttonRight && currentSize != middleSize) {
                blendshapeIndex = shape.maxIndex;
                sizeToBe = currentSize - scaleStep;
            } else if(!buttonRight && currentSize == middleSize) {
                shape.flipMinMax();
                blendshapeIndex = shape.minIndex;
                sizeToBe = currentSize - scaleStep;
            }
        }

        Debug.Log("to be: " + sizeToBe);

        skinnedMeshRenderer.SetBlendShapeWeight(blendshapeIndex, Mathf.Lerp(currentSize, sizeToBe, scaleScaleStep));

        isBusy = false;

        yield return null;
    }
}