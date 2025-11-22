using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float speed;
    public float deadZone = -15f;
    public bool isSpawnToRight = true;

    // Update is called once per frame
    void Update()
    {
        if (isSpawnToRight == true)
        {
            transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
        }
        else if (isSpawnToRight == false)
        {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }

        if (Mathf.Abs(transform.position.y) > Mathf.Abs(deadZone))
        {
            Destroy(gameObject);
        }
    }
}
