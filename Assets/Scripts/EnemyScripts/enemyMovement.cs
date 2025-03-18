using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [Header("Movement")]
    public float verticalSpeed = 1f;
    private float yOffset = 0f;
    private float yMovement = 1f;
    private float constraint = 4f;

    [Header("Attack")]
    public GameObject laser;
    public float bulletSpeed = 1;
    public float attackSpeed = 2;

    private float timeOfLastBullet;

    // Start is called before the first frame update
    void Start()
    {
        yOffset = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
        constrainEnemy();
        transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);

        if (Time.time > timeOfLastBullet + attackSpeed)
            shoot();
    }

    void enemyMovement()
    {
        yOffset += yMovement * verticalSpeed * Time.deltaTime;
        if (yOffset >= constraint || yOffset <= -constraint)
        {
            yMovement *= -1f;
        }
    }

    void constrainEnemy()
    {
        yOffset = Mathf.Clamp(yOffset, -constraint, constraint);
    }

    void shoot()
    {
        Transform enemyBarrel = transform.Find("enemyBarrel");

        GameObject newBullet = Instantiate(laser, enemyBarrel.position, enemyBarrel.rotation);
        newBullet.GetComponent<laserShot>().bulletSpeed = bulletSpeed;

        timeOfLastBullet = Time.time;
    }

}
