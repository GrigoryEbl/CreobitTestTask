using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneAddress)
    {
        Addressables.LoadSceneAsync(sceneAddress, LoadSceneMode.Additive);
    }

    public void ReturnToMainScene(string mainSceneAddress)
    {
        foreach (var scene in SceneManager.GetAllScenes())
        {
            if (scene.name != mainSceneAddress)
            {
                SceneManager.UnloadSceneAsync(scene.name);
            }
        }

        Addressables.LoadSceneAsync(mainSceneAddress, LoadSceneMode.Single);
    }
}
