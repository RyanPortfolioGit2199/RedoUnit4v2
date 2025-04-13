using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    private float speed = 2.0f;
    private GameObject focalpoint;

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
    }
}
