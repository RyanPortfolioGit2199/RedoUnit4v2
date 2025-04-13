using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        // Spawns an enemy based on the enemy in the prefab folder at random x and z coordinates generated in the GenerateSpawnPosition method below
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        // get a random number between -9 and 9 for the x and z coordinates
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        // Since this isnt a void method(used for specific tasks that don't return a value), but a Vector3 method is a return type function because this method we are using to create a random Vector3 coordinates to spawn the objects in the level, and we need to send the value it generated to the Instanate we called in the Start function.
        return randomPos;
    }
}
