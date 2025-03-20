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


    private float startingXPos; // Track the initial position
    private float xOffset = 0f; // Movement over time
    private float yOffset = 0f;  // Optional: Adjust vertical position if needed

    // Start is called before the first frame update
    void Start()
    {
        startingXPos = transform.position.x;

        // if (isEnemy)
        //     movementSpeed = -movementSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = new Vector3(Mathf.Cos(
            transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
            Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
            0f
        );

        transform.position += direction * movementSpeed * Time.deltaTime;

        CheckPos();
    }

    private void CheckPos()
    {
        if (Mathf.Abs(transform.position.x - startingXPos) > 20f) // if 20f units off left or right in your screen then delete
        {
            Destroy(gameObject);
        }
    }


}
