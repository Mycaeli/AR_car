using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float baseFriction = 0.5f;
    public float driftFrictionMultiplier = 0.2f; // Adjust for desired slipperiness
    public float driftForceMultiplier = 2.0f; // Adjust for desired driftiness
    public float driftAngleThreshold = 30.0f; // Adjust for drift initiation angle


    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");


        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        float steeringAngle = horizontalInput * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up * steeringAngle);

        bool isDrifting = Mathf.Abs(transform.eulerAngles.z) > driftAngleThreshold
                          && Mathf.Abs(horizontalInput) > 0.1f;

        float friction = isDrifting ? baseFriction * driftFrictionMultiplier : baseFriction;
        rb.drag = friction;

        if (isDrifting)
        {
            Vector2 driftForce = -transform.right * horizontalInput * driftForceMultiplier * speed * Time.deltaTime;
            rb.AddForce(driftForce);
        }
    }

}
