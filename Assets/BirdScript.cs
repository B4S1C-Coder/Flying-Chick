using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // The script component in the editor will now have a field for a rigid body in which
    // we can place the rigid body we created in the editor for this bird.

    // Similarly we'll have the corresponding fields for whatever we create here.
    public Rigidbody2D birdRigidBody;
    public float flapStrength;
    public LogicScript logic;
    private bool birdIsAlive = true;
    public float deathBelow = -16;
    public Sprite wingUpSprite;
    public Sprite wingDownSprite;
    private SpriteRenderer wingSpriteRenderer;
    private Coroutine flapCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the child wing object
        Transform wingObj = transform.Find("Wing");
        if (wingObj != null) {
            // Get the sprite renderer of the wing object
            wingSpriteRenderer = wingObj.GetComponent<SpriteRenderer>();
            if (!wingSpriteRenderer) {
                Debug.LogWarning("Unable to get Sprite Renderer of the wing.");
            }
        }

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (transform.position.y <= deathBelow) {
            logic.GameOver();
            birdIsAlive = false;
        }

        if (Input.GetMouseButton(0) && birdIsAlive)
        {
            // Defining the direction in which bird should go
            birdRigidBody.linearVelocity = Vector2.up * flapStrength; // Essentially (0, 1) * flapStrength
            
            if (flapCoroutine != null) {
                StopCoroutine(flapCoroutine);
            }

            flapCoroutine = StartCoroutine(FlapWings());
        }
    }

    private IEnumerator FlapWings() {
        wingSpriteRenderer.sprite = wingUpSprite;
        yield return new WaitForSeconds(0.1f);
        wingSpriteRenderer.sprite = wingDownSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        logic.GameOver();
        birdIsAlive = false;
    }
}
