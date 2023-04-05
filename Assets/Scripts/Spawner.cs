using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 5f;
    [SerializeField] public float moveSpeed = 1f;
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

        //Caps difficulty
        if (moveSpeed > 2.5f)
            moveSpeed = 2.5f;
        if (spawnTime < 1.7f)
            spawnTime = 1.7f;

        scoreText.text = "Score: " + score;
        liveText.text = lives.ToString();
    }

    void SpawnWave()
    {
        Instantiate(myPrefab, new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(8,11), canvas.transform.position.z), Quaternion.identity, canvas.transform);
        Instantiate(myPrefab, new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(8,11), canvas.transform.position.z), Quaternion.identity, canvas.transform);
        spawnTime -= (spawnTime / 60);
        moveSpeed += (moveSpeed / 60);

    }
}
