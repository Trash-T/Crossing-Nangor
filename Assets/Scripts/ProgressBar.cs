using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Image bar;
    public float maxTime = 300f;
    float time;
    public GameObject winScene;
    public GameObject darkMode;
    
    public GameObject playerObject; 
    public float finalMoveSpeed = 8f; 
    
    private Rigidbody2D playerRb;
    private Collider2D playerCol; 
    private bool rbDisabled = false;
    
    private float topBoundaryY;
    private bool timeIsUp = false; 
    
    private void DisablePhysicsForMovement()
    {
        if (playerRb != null && !rbDisabled)
        {
            playerRb.linearVelocity = Vector2.zero;
            playerRb.bodyType = RigidbodyType2D.Kinematic; 
            if (playerCol != null) 
            {
                playerCol.enabled = false;
            }

            rbDisabled = true;
            Debug.Log("Fisika Player dinonaktifkan.");
        }
    }

    private void EnablePhysicsAfterMovement()
    {
        if (playerRb != null && rbDisabled)
        {
            playerRb.bodyType = RigidbodyType2D.Dynamic; 
            
            if (playerCol != null) 
            {
                playerCol.enabled = true;
            }

            rbDisabled = false;
            Debug.Log("Fisika Player diaktifkan kembali.");
        }
    }

    void Start()
    {
        winScene.SetActive(false);
        bar = GetComponent<Image> ();
        time = 0;
        
        if (playerObject != null)
        {
            playerRb = playerObject.GetComponent<Rigidbody2D>(); 
            playerCol = playerObject.GetComponent<Collider2D>();
            
            Camera mainCamera = Camera.main;
            Vector3 topEdgeWorld = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0));
            topBoundaryY = topEdgeWorld.y;

            SpriteRenderer sr = playerObject.GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        if (time <= maxTime)
        {
            time += Time.deltaTime;
            bar.fillAmount = time / maxTime;
            
            if(time >= 180 && time <= 240)
            {
                darkMode.SetActive(true);
            }
            else
            {
                darkMode.SetActive(false);
            }
        }
        else
        {
            if (timeIsUp == false)
            {
                timeIsUp = true;
                DisablePhysicsForMovement();
            }
            
            if (timeIsUp)
            {
                MovePlayerToTopEdge();
            }

            if (playerObject != null && playerObject.transform.position.y >= topBoundaryY)
            {
                winScene.SetActive(true);
                EnablePhysicsAfterMovement();
            }
        }
    }
    
    private void MovePlayerToTopEdge()
    {
        if (playerObject == null) return; 

        float targetY = topBoundaryY;
        
        if (playerObject.transform.position.y < targetY)
        {
            playerObject.transform.Translate(Vector3.up * finalMoveSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 finalPos = playerObject.transform.position;
            finalPos.y = targetY;
            playerObject.transform.position = finalPos;
            
            timeIsUp = false; 
        }
    }
}