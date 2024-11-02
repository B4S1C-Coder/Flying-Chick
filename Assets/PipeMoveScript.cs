using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -32;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime ensures that our multiplication is not tied to frame rate.
        // Since Update() runs every frame, the pipe would move faster if frame rate is higher
        // so by adding deltaTime we ensure that multiplication only happens in stipulated time.

        // Time.deltaTime is the time since last frame was rendered.
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // Destroy the game object, if it moves outside the frame.
        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }
}
