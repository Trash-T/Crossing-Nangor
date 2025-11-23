using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public List<GameObject> backgrounds;
    private GameObject background;
    public float spawnRate = 1.19f;
    private float timer = 0;
    
    void Start()
    {
        SpawnBackground();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnBackground();
            timer = 0;
        } 
    }

    void SpawnBackground()
    {
        background = backgrounds[Random.Range(0, 6)];
        Instantiate(background, transform.position, transform.rotation);
    }
}
