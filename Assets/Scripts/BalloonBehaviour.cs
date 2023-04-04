using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonBehaviour : MonoBehaviour
{
    [SerializeField] int layers = 1;
    [SerializeField] Animator animator;
    private Image buttonImage;
    private Spawner spawner;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        spawner = FindObjectOfType<Spawner>();
    }
    void Awake()
    {
        RandomSpawn();
    }

    
    // Update is called once per frame
    void Update()
    {
        FloatDown();
        if(layers == 3)
            buttonImage.color = Color.green;
        else if(layers == 2)
            buttonImage.color = Color.yellow;
        else if(layers == 1)
            buttonImage.color = Color.red;

        if (transform.position.y < -6)
        {
            spawner.lives--;
            Destroy(gameObject);
        }
    }
    void RandomSpawn()
    {
        int randomID = Random.Range(1, 20);

        if (randomID > 16)
            layers = 3;
        else if (randomID < 16 && randomID > 10)
            layers = 2;
        else if (randomID < 10)
            layers = 1;

    }

    void FloatDown()
    {
        transform.position -= new Vector3(0,spawner.moveSpeed * Time.deltaTime, 0);
    }

    public void PopBalloon()
    {
        spawner.score += 1;
        StartCoroutine(PopAnimation());
       
    }

    private IEnumerator PopAnimation()
    {
        animator.Play("PoppingAnimation");
        yield return new WaitForSecondsRealtime(0.1f);
        if (layers == 1)
        {
            Destroy(gameObject);
        }
        else
        {
            layers--;
        }
    }
}
