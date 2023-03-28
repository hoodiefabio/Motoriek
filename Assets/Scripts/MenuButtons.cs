using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    

    public void LoadScenes(int scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    IEnumerator LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        yield return null;
    }

}
