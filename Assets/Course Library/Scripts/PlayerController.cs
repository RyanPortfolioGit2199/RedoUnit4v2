using UnityEngine;
using System.Collections; // need this in order to use the IEnumerator namespcae.

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    private float speed = 2.0f;
    private GameObject focalpoint;
    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("FocusPoint");
    }

    // Update is called once per frame
    void Update()
    {
        // Applies force on the player object that pushes it based on the W & S keys pressed and what the focal point forward direction is facing.
        float forwardInput = Input.GetAxis("Vertical");
        PlayerRb.AddForce(focalpoint.transform.forward * forwardInput *  speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); // Makes the Powerup Indicator appear around the player
    }

    private void OnTriggerEnter(Collider other)     // use this metheod for coding what to do when using triggers when objects collide
    {
        // If the player collides with an object with the tag Power up, then destroy the powerup gameobject, and makes the hasPowerup bool varible equal true
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true); // makes the powerup indicator visable when picking up the powerup
            // Runs the 7 second countdown to lose the powerup
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    // An IEnumerator is known as a interface, tutorial didnt go into what this is or what specifically used for but is helpful when trying to do a countdown timer outside of the Update() loop.
    IEnumerator PowerupCountdownRoutine()
    {
        // Uses a Coroutine (dont know what it is tutorial didnt say what it is) that will run with a function called WaitForSeconds
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false); // After the ability countdown ends make the powerup indicator turn invisable.
    }
    // The IEnumerator is going to create a new thread outside of the update loop, and it will use the WaitForSeconds method to wait for 7 seconds before setting hasPower back to false (Simple terms makes the players powerup disappear after 7 seconds)

    private void OnCollisionEnter(Collision collision) // use this metheod for coding what to when using physics when objects collide.
    {
        // If the player collides with an object with the tag Enemy and has Powerup set to true, do, (Print Debug), and send the enemy flying away from the player.
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {

            // Gets enemyRidgidbody component to use it later.
            Rigidbody enemyRidgidbody = collision.gameObject.GetComponent<Rigidbody>();
            // Declares a variable to get the direction away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " +  collision.gameObject.name + " with powerup set to " + hasPowerup);
            // Applies a impulse force,(applies force to the enemy object instantly) to the enemy using the powerupStrength variable
            enemyRidgidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
