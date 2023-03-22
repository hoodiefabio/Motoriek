using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 30f;
    [SerializeField] GameObject myPrefab;
    [SerializeField] Canvas canvas;

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
            SpawnPrefab();
            timer = spawnTime;
        }
    }

    void SpawnPrefab()
    {
        Instantiate(myPrefab, canvas.transform);
        //myPrefab.transform.SetParent(this.transform);
    }
}
