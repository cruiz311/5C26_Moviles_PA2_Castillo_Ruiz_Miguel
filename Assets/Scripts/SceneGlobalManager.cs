using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlobalManager:MonoBehaviour
{
    private static SceneGlobalManager instance;

    public static SceneGlobalManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneGlobalManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("SceneGlobalManager");
                    instance = container.AddComponent<SceneGlobalManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LoadSceneAsync(string sceneName, LoadSceneMode mode)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName, mode));
    }

    private IEnumerator LoadSceneAsyncCoroutine(string sceneName, LoadSceneMode mode)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);
        while (!asyncOperation.isDone)
        {
            // Puedes mostrar una barra de carga o hacer otras cosas aquí
            yield return null;
        }
    }
}
