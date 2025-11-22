using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject background;
    public float spawnRate = 1.19f;
    private float timer = 0;
    
    void Start()
    {
        SpawnPipe();
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
            SpawnPipe();
            timer = 0;
        } 
    }

    void SpawnPipe()
    {
        Instantiate(background, transform.position, transform.rotation);
    }
}
