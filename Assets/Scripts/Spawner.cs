using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 30f;
    [SerializeField] GameObject myPrefab;
    [SerializeField] Text scoreText;
    [SerializeField] Canvas canvas;
    public int score = 0;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; 

        if(timer <= 0)
        {
            SpawnWave();
            timer = spawnTime;
        }

        scoreText.text = "Score: " + score;
    }

    void SpawnWave()
    {
        Instantiate(myPrefab, new Vector3(Random.Range(-7, 7), Random.Range(7,10), canvas.transform.position.z), Quaternion.identity, canvas.transform);
        Instantiate(myPrefab, new Vector3(Random.Range(-7, 7), Random.Range(7,10), canvas.transform.position.z), Quaternion.identity, canvas.transform);
    }
}
