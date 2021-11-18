using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public void GoToScene()
    {
        SceneManager.LoadScene("GrabClothing");
    }
}
