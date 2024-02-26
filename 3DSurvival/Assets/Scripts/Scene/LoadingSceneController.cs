using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using System.Collections;

public class LoadingSceneManager : MonoBehaviour
{
    public static void LoadScene(int sceneBuildIndex, AssetReference[] assetsToLoad)
    {
        LoadingSceneController.LoadScene(sceneBuildIndex, assetsToLoad);
    }
}

public class LoadingSceneController : MonoBehaviour
{
    [SerializeField] Image loadingBar;
    Coroutine loading;
    static int sceneBuildIndex;
    static AssetReference[] assetsToLoad;
    private void Start()
    {
        StartLoading();
    }
    public static void LoadScene(int _sceneBuildIndex, AssetReference[] _assetsToLoad) 
    {
        sceneBuildIndex = _sceneBuildIndex;
        assetsToLoad = _assetsToLoad;
        SceneManager.LoadScene("LoadingScene");
    }
    public void StartLoading()
    {
        if (loading != null)
        {
            StopCoroutine(loading);
            loading = null;
        }
        loading = StartCoroutine(LoadSceneAsync());
    }

    public IEnumerator LoadSceneAsync()
    {
        float totalProgress = 0f;

        if (assetsToLoad != null)
        {
            // 어드레서블 에셋 비동기 로드
            foreach (var assetRef in assetsToLoad)
            {
                AsyncOperationHandle handle = Addressables.LoadAssetAsync<GameObject>(assetRef);
                yield return handle.Task;

                if (handle.Result != null)
                {
                    totalProgress += 1f / assetsToLoad.Length;
                    loadingBar.fillAmount = totalProgress;
                }
            }
        }
        else
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneBuildIndex);

            while (!asyncLoad.isDone)
            {
                float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
                loadingBar.fillAmount = progress;

                yield return null;
            }
        }

        SceneManager.LoadScene(sceneBuildIndex);
    }
}