using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave();
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length; //Find objects all objects in the scene with the Enemy Script, SortMode has the amount of enemies stored in an array, the .None mean we dont need to sort them. But since the amount of enemies is stored in an array, the .Length is used to covert the array of enemies into a integer.
        if (enemyCount == 0)
        {
            waveNumber++; //Increases the amount of the integer varable waveNumber everytime enemyCount equals 0.
            SpawnEnemyWave(); // if the enemy count equals 0 run the SpawnEnemyWave method to spawn the amount of enemies based on the integer variable waveNumber.
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // when the enemyCount equals 0 spawn a powerup at coordinates reusing GenerateSpawnPosition method.
        }
    }

    void SpawnEnemyWave()
    {
        for (int i = 0; i < this.waveNumber; i++) // this for loops spawns a certain number of enemies based on the integer variable enemiesToSpawn, it starts at 0, every time an enemy is spawned i increases until i equals the integer variable enemiesToSpawn.
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); // Spawns an enemy based on the enemy in the prefab folder at random x and z coordinates generated in the GenerateSpawnPosition method below
        }
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
