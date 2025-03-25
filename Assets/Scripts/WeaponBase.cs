using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [Header("Weapon Settings")]
    public float damage;
    public float movementSpeed;
    public float fireRate;
    public float spread;


    private Vector3 direction;

    [Header("Weapon Modifiers")]
    public MovementMode currentMovementMode;
    private GameObject trackingTarget;
    public float trackingSpeed;

    [Header("Assets")]
    public AudioSource fireSound;

    public enum MovementMode
    {
        MoveForward,
        ConstantTracking,
        None
    }


    private float startingXPos; // Track the initial position
    private float xOffset = 0f; // Movement over time
    private float yOffset = 0f;  // Optional: Adjust vertical position if needed

    // Start is called before the first frame update
    void Start()
    {
        startingXPos = transform.position.x;
        direction = GenerateAngle();
        trackingTarget = GameObject.FindGameObjectWithTag("Player");


        // if (isEnemy)
        //     movementSpeed = -movementSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        CheckPos();
    }

    public void movement()
    {
        switch (currentMovementMode)
        {
            case MovementMode.MoveForward:
                moveForward();
                break;
            case MovementMode.ConstantTracking:
                trackPlayerConstant();
                break;
            case MovementMode.None: // movement not handled here or not needed here
                break;
        }
    }

    private void trackPlayerPrioritizeY()
    {
        Vector3 directionToPlayer = new Vector3(movementSpeed * Time.deltaTime, trackingTarget.transform.position.y - transform.position.y, 0).normalized;
        transform.position += directionToPlayer * trackingSpeed * Time.deltaTime;
    }

    private void trackPlayerConstant()
    {

        Vector3 directionToPlayer = trackingTarget.transform.position - transform.position;
        transform.position += directionToPlayer.normalized * trackingSpeed * Time.deltaTime + new Vector3(movementSpeed * Time.deltaTime, 0, 0);
    }

    private void moveForward()
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    private Vector3 GenerateAngle()
    {
        float spreadOffset = UnityEngine.Random.Range(-spread, spread);
        float fireAngle = (transform.rotation.eulerAngles.z + spreadOffset) * Mathf.Deg2Rad;
        Vector3 result = new Vector3(
            Mathf.Cos(fireAngle),
            Mathf.Sin(fireAngle),
            0f
        );

        return result;
    }

    private void CheckPos()
    {
        if (Mathf.Abs(transform.position.x - startingXPos) > 20f) // if 20f units off left or right in your screen then delete
        {
            if (gameObject.name != "Asteroid")
            {
                Debug.Log("ABS VAL DELETE");
                Destroy(gameObject);
            }
        }
    }


}
