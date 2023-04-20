using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    [SerializeField] Text winScore;
    [SerializeField] Text highScore;
    [SerializeField] GameObject confetti;
    [SerializeField] AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
       bgm.mute = false;
    }

    // Update is called once per frame
    void Update()
    {
        winScore.text = "Score: " + spawner.score;
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
        if(spawner.gameOver)
            bgm.mute = true;
        if (spawner.newHighscore)
            confetti.SetActive(true);
    }

    public void Restart()
    {
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }
}
