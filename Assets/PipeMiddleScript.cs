using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // We add a tag "Logic" to the Logic manager game object. You can't drag and drop it in the editor
        // hence we do it here via code.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        // Increment the score only if it was the bird that passed thorugh. Bird is in layer 3 named "Brid"
        if (collision.gameObject.layer == 3) {
            logic.AddScore(1);
        }
    }
}
