using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingBarHolder;
    [SerializeField]
    private Image loadingBarProgress;
    public float progressValue = 0.1f;
    public float progressMultiple = 0.1f;
    public float levelTime = 3f;

    private void Start()
    {
        StartCoroutine(LoadingSomeLevel());
    }

    private void Update()
    {
        ShowLoadingScreen();
    }

    public void LoadLevel(string levelName)
    {
        loadingBarHolder.SetActive(true);
        SceneManager.LoadScene(levelName);
    }

    private void ShowLoadingScreen()
    {
        if (progressValue < 1)
        {
            progressValue += progressMultiple * Time.deltaTime;
            loadingBarProgress.fillAmount = progressValue;

        }
    }

    private IEnumerator LoadingSomeLevel()
    {
        yield return new WaitForSeconds(levelTime);
        LoadLevel("StartTest");
    }

    public void LoadLevelAsync(string levelName)
    {
        StartCoroutine(LoadLevelAsyncCoroutine(levelName));
    }

    private IEnumerator LoadLevelAsyncCoroutine(string levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
        loadingBarHolder.SetActive(true);

        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingBarProgress.fillAmount = progress;

            yield return null;
        }

        loadingBarHolder.SetActive(false);
    }
}
