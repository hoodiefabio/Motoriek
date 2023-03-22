using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    
    void Awake()
    {
        RandomSpawn();
    }

    
    // Update is called once per frame
    void Update()
    {
       FloatDown();
    }
    void RandomSpawn()
    {
        this.transform.position = new Vector3(Random.Range(-6, 6), 6);
    }

    void FloatDown()
    {
        transform.position -= new Vector3(0,moveSpeed * Time.deltaTime, 0);
    }

}
