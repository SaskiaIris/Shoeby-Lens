using System.Collections.Generic;
using UnityEngine;

public class AvatarDressing : MonoBehaviour
{
    [SerializeField]
    private string clothingLayerName = "Grab";
    [SerializeField]
    private int clothingLayerNumber = 3;

    [SerializeField]
    private string hairTagName = "Hair";
    [SerializeField]
    private List<GameObject> hairs = null;

    [SerializeField]
    private string shirtTagName = "Shirt";
    [SerializeField]
    private List<GameObject> shirts = null;

    [SerializeField]
    private string pantsTagName = "Pants";
    [SerializeField]
    private List<GameObject> pants = null;

    [SerializeField]
    private string shoesTagName = "Shoes";
    [SerializeField]
    private List<GameObject> shoes = null;

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision) {
        /*//Check for a match with the specified name on any GameObject that collides with your GameObject
        if(collision.gameObject.name == "MyGameObjectName") {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
        }*/

        if(collision.gameObject.layer == clothingLayerNumber) {
            //Check for a match with the specific tag on any GameObject that collides with your GameObject
            if(collision.gameObject.tag == shirtTagName) {
                //If the GameObject has the same tag as specified, output this message in the console
                Debug.Log("Dit is een shirt");

                for(int i = 0; i < shirts.Count; i++) {
                    if(shirts[i].name == collision.gameObject.name) {
                        shirts[i].SetActive(true);
                    } else {
                        shirts[i].SetActive(false);
                    }
                }
            }
        }
    }
}