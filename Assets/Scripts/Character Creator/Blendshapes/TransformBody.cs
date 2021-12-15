using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformBody : MonoBehaviour {
    bool isBusy = false;
    bool stop = false;

    [SerializeField]
    private float timeForScaling = 20f;

    [SerializeField]
    private List<Blendshape> blendshapes = null;

    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Mesh skinnedMesh;

    //private int blendShapeCount;
    // Start is called before the first frame update
    void Start() {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        skinnedMesh = skinnedMeshRenderer.sharedMesh;
        //blendShapeCount = skinnedMesh.blendShapeCount;
    }

    // Update is called once per frame
    void Update() {

    }

    public void ScaleStart(int blendNumber) {
        if(!isBusy) {
            StartCoroutine(ScaleBody(blendNumber, timeForScaling, 100f));
        }
    }

    public void StopScaling() {
        stop = true;
    }

    public void ResetScaling() {
        skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
        skinnedMeshRenderer.SetBlendShapeWeight(1, 0);
    }

    IEnumerator ScaleBody(int index, float duration, float maxSize) {
        isBusy = true;
        float initialSize = skinnedMeshRenderer.GetBlendShapeWeight(index);
        float currentSize = initialSize;

        //for(float time = 0; time < duration; time += Time.deltaTime) {
        while(currentSize < maxSize) {
            currentSize = skinnedMeshRenderer.GetBlendShapeWeight(index);

            skinnedMeshRenderer.SetBlendShapeWeight(index, currentSize + (maxSize / duration));

            if(stop) {
                Debug.Log("max size bereikt");
                //time = duration;
                break;
            }

            
            yield return null;
        }

        isBusy = false;
    }



}