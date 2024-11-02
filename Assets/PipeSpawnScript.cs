using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        // We don't want to spawn pipes every frame, we only want to spawn them per unit of time
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Rendered pipes will have same x coordinate as pipe spawner game object,
        // Random y coordinate and 0 z coordinate
        Vector3 position = new Vector3(
            transform.position.x,
            Random.Range(lowestPoint, highestPoint),
            0
        );

        Instantiate(pipe, position, transform.rotation);
    }
}