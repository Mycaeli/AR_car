using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CarControllerN : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        // Adjust these values based on your car's physics and desired handling
        engineForce = 1000.0f;
        maxTurnAngle = 15.0f;
        steeringSpeed = 50.0f;
    }

    [SerializeField] private Rigidbody carRigidbody;  // Reference car's Rigidbody component
    private float engineForce;                          // Force applied for acceleration
    private float maxTurnAngle;                         // Maximum steering angle in degrees
    private float steeringSpeed;                         // Rate of change for steering angle

    // Update is called once per frame
    void Update()
    {
        float throttle = CrossPlatformInputManager.GetAxis("Vertical");
        float steering = CrossPlatformInputManager.GetAxis("Horizontal");

        // Optimized movement for realistic car physics:
        // - Use Rigidbody forces for more natural acceleration and deceleration
        // - Apply steering rotation to front wheel colliders
        // - Optionally add drag (optional)

        // Apply forward/backward force based on throttle input
        carRigidbody.AddForce(transform.forward * throttle * engineForce);

        // Calculate steering angle based on input and steering speed
        float targetTurnAngle = steering * maxTurnAngle;
        float turnAngle = Mathf.Lerp(carRigidbody.rotation.eulerAngles.y, targetTurnAngle, steeringSpeed * Time.deltaTime);

        // Optionally add drag for a more realistic feel
        carRigidbody.drag = Mathf.Abs(throttle) * 0.1f;  // Adjust drag coefficient

        // Rotate the car based on the calculated steering angle
        carRigidbody.rotation = Quaternion.Euler(0f, turnAngle, 0f);
    }
}













