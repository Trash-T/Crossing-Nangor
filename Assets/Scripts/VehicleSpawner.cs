using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public List<GameObject> vehicles;
    private GameObject vehicle;
    private float spawnRate;
    private float timer = 0;
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
        if (isSpawnToRight)
        {
            vehicle = vehicles[Random.Range(0, 9)];
            GameObject obj = Instantiate(vehicle, transform.position, transform.rotation);

            VehicleMovement move = obj.GetComponent<VehicleMovement>();

            move.isSpawnToRight = true;
            move.transform.localScale = new Vector3(1f, 1f, 1f);   
        }
        else
        {
            vehicle = vehicles[Random.Range(0, 6)];
            GameObject obj = Instantiate(vehicle, transform.position, transform.rotation);

            VehicleMovement move = obj.GetComponent<VehicleMovement>();

            move.isSpawnToRight = false;
            move.transform.localScale = new Vector3(-1f, 1f, 1f);   
        }
    }
}
