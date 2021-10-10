using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    [SerializeField]
    SceneLoader sceneLoader;

    [SerializeField]
    int nextScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sceneLoader.LoadScene(nextScene);
        }
    }
}
