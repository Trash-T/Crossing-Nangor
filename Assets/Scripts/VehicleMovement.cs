using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    private float speed = 1f;
    public float deadZone = -20f;
    public bool isSpawnToRight = true;

 
    void Start()
    {
        AudioManager.instance.PlaySFX(5);
    }
    void Update()
    {
        float directionX = isSpawnToRight ? 1f : -1f;

        // combine movement
        Vector3 moveDir = new Vector3(directionX, -1f);

        // apply movement
        transform.position += moveDir * speed * Time.deltaTime;
        

        // destroy when out of bounds
        if (transform.position.y < deadZone && Mathf.Abs(transform.position.x) > deadZone)
        {
            Destroy(gameObject);
            AudioManager.instance.StopSFX(13);
        }
    }
}
