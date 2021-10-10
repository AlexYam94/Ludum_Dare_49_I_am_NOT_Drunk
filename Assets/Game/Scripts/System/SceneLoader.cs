using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    int nextSceneIndexToLoad = 2;

    [SerializeField]
    private string gameOverIndex;

    [SerializeField]
    private string endingIndex;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nextSceneIndexToLoad);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadEnding()
    {
        SceneManager.LoadScene(endingIndex);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(gameOverIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
