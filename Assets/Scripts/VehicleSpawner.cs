using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject vehicle;
    private float spawnRate;
    private float timer = 0;
    private string layer = "Default";
    public bool isSpawnToRight = true;
    
    void Start()
    {
        spawnRate = Random.Range(6, 10);
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
            spawnRate = Random.Range(5, 8);
            SpawnVehicle();
            timer = 0;
        } 
    }

    void SpawnVehicle()
    {
        GameObject obj = Instantiate(vehicle, transform.position, transform.rotation);
        obj.GetComponent<SpriteRenderer>().sortingLayerName = layer;

        VehicleMovement move = obj.GetComponent<VehicleMovement>();

        if (isSpawnToRight)
        {
            move.isSpawnToRight = true;
            move.transform.localScale = new Vector3(1f, 1f, 1f);   
        }
        else
        {
            move.isSpawnToRight = false;
            move.transform.localScale = new Vector3(-1f, 1f, 1f);   
        }
    }
}
