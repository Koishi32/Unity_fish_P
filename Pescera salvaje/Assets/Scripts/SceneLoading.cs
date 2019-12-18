using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public Image progressBar;
    // Start is called before the first frame update
    void Start()
    {
        progressBar.fillAmount = 0;
        StartCoroutine(loadAsyncOperation());
    }
    //Codigo para hilo de carga para no sobre saturar el hilo de ejecucion
    IEnumerator loadAsyncOperation()
    {
        AsyncOperation gabelevel = SceneManager.LoadSceneAsync("nv2");
        while (gabelevel.progress < 1) {
            progressBar.fillAmount = gabelevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
