using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class AssetLoader : MonoBehaviour
{
    public void LoadScene(string sceneAddress)
    {
        StartCoroutine(LoadSceneAsync(sceneAddress));
    }

    private IEnumerator LoadSceneAsync(string sceneAddress)
    {
        AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(sceneAddress, LoadSceneMode.Single);
        yield return handle;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log($"Scene '{sceneAddress}' loaded successfully.");
        }
        else
        {
            Debug.LogError($"Failed to load scene '{sceneAddress}'.");
        }
    }

    public void UnloadScene(string sceneAddress)
    {
        StartCoroutine(UnloadSceneAsync(sceneAddress));
    }

    private IEnumerator UnloadSceneAsync(string sceneAddress)
    {
        AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(sceneAddress, LoadSceneMode.Additive);
        yield return handle;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(handle.Result.Scene);
            yield return unloadOperation;

            if (unloadOperation.isDone)
            {
                Addressables.Release(handle);
                Debug.Log($"Scene '{sceneAddress}' unloaded successfully.");
            }
            else
            {
                Debug.LogError($"Failed to unload scene '{sceneAddress}'.");
            }
        }
        else
        {
            Debug.LogError($"Failed to load scene '{sceneAddress}' for unloading.");
        }
    }
}
