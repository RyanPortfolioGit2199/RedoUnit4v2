using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Getting access to the enemy character rigidbody at the start of the game
        enemyRb = GetComponent<Rigidbody>();
        // Finding a gameobject with the name Player at the start of the game
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = player.transform.position - transform.position;// Add force that pushes the enemy to the location of the player.
      
        enemyRb.AddForce((lookDirection).normalized * speed);// .normalized makes it so that the enemy will always move to towards the player at the same speed no matter the distance, ie: The farther away the player is from the player the faster the enemy with go to reach the player. The closer the enemy is to the player the slower the enemy will go to reach the player.

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }


    }
}
