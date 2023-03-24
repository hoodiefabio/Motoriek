using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 30f;
    [SerializeField] GameObject myPrefab;
    [SerializeField] GameObject winScreen;
    [SerializeField] Text scoreText;
    [SerializeField] Text liveText;
    [SerializeField] Canvas canvas;
    public int score = 0;
    public int lives = 3;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; 

        if(timer <= 0 && lives > 0)
        {
            SpawnWave();
            timer = spawnTime;
        }

        if(lives == 0)
        {
            winScreen.SetActive(true);
        }

        scoreText.text = "Score: " + score;
        liveText.text = lives.ToString();
    }

    void SpawnWave()
    {
        Instantiate(myPrefab, new Vector3(Random.Range(-7, 7), Random.Range(7,10), canvas.transform.position.z), Quaternion.identity, canvas.transform);
        Instantiate(myPrefab, new Vector3(Random.Range(-7, 7), Random.Range(7,10), canvas.transform.position.z), Quaternion.identity, canvas.transform);
    }
}
