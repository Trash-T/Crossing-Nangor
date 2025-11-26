using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    private float speed = 1f;
    public float deadZone = -20f;
    public bool isSpawnToRight = true;

    // Update is called once per frame
    void Update()
    {
        float directionX = isSpawnToRight ? 1f : -1f;

        // combine movement
        Vector3 moveDir = new Vector3(directionX, -1f);

        // apply movement
        transform.position += moveDir * speed * Time.deltaTime;
        AudioManager.instance.PlaySFX(9);

        // destroy when out of bounds
        if (transform.position.y < deadZone && Mathf.Abs(transform.position.x) > deadZone)
        {
            Destroy(gameObject);
        }
    }
}
