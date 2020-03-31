using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    public void LoadLevel(int sceneIndex)
    {

        StartCoroutine(LoadAsynchronosly(sceneIndex));

    }

    IEnumerator LoadAsynchronosly(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {

            Debug.Log(operation.progress);

            yield return null;
        }

    }
}
