using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    [SerializeField]
    SceneLoader sceneLoader = null;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader.LoadMenu();
    }

}
