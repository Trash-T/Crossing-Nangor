using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject vehicle;
    public float spawnRate = 1.19f;
    private float timer = 0;
    private string layer = "Default";
    
    void Start()
    {
        SpawnVehicle();
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
            SpawnVehicle();
            timer = 0;
        } 
    }

    void SpawnVehicle()
    {
        GameObject obj = Instantiate(vehicle, transform.position, transform.rotation);
        obj.GetComponent<SpriteRenderer>().sortingLayerName = layer;
    }
}
