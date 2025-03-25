using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    [Header("Settings")]
    public float health;
    public float speed;
    public float bulletSpeed;
    // public float scoreValue; No longer needed due to scraps on death
    public int scrapsOnDeath;
    public bool enemyBullets;

    public float exitDamage;



    [Header("Weapon")]
    public GameObject weapon;
    private float timeOfLastBullet;
    public MovementMode currentMovementMode;
    public float trackingSpeed;
    public GameObject trackingTarget;

    private gameHandler gameHandler;
    [Header("Health Slider")]
    public Slider healthSlider;


    public enum MovementMode
    {
        MoveForward,
        TrackYPriority,
    }

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameHandler>();
        transform.position = new Vector3(12, Random.Range(-3f, 3f), 0);
        timeOfLastBullet = Time.time;

        trackingTarget = GameObject.FindGameObjectWithTag("Player");

        if (healthSlider != null)
        {
            healthSlider.maxValue = health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon != null) // Means no weapon is required
            fireWeapon(weapon);

        moveMode();

        // Hurt Player and Delete Ship  
        if (transform.position.x < -10f){
            trackingTarget.GetComponent<SpaceShip>().playerHealthBar.decrementHealthBar(exitDamage);
            Debug.Log(19911);
            Destroy(gameObject);
        }


    }

    private void moveMode()
    {
        switch (currentMovementMode)
        {
            case MovementMode.MoveForward:
                moveForward();
                break;
            case MovementMode.TrackYPriority:
                trackPlayerPrioritizeY();
                break;
        }
    }

    private void trackPlayerPrioritizeY()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        float deltaY = trackingTarget.transform.position.y - transform.position.y;
        transform.position += new Vector3(0, deltaY * trackingSpeed * Time.deltaTime, 0);
    }

    private void moveForward()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


    public void fireWeapon(GameObject weapon)
    {
        WeaponBase weaponBase = weapon.GetComponent<WeaponBase>();

        if (Time.time > timeOfLastBullet + weaponBase.fireRate)
        {
            timeOfLastBullet = Time.time;
            GameObject newWeapon = Instantiate(weapon, transform.Find("EnemyBarrel").position, transform.Find("EnemyBarrel").rotation);
            newWeapon.GetComponent<WeaponBase>().movementSpeed = bulletSpeed;
            if (enemyBullets) newWeapon.tag = "Enemy";
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponBase collisonObject = collision.GetComponent<WeaponBase>();
        if (collisonObject != null && collisonObject.tag != "Enemy")
        {   
            Destroy(collision.gameObject);
            health -= collisonObject.damage;

            if (healthSlider != null)
            {
                healthSlider.value = health;
                if (healthSlider.value < healthSlider.maxValue)
                    healthSlider.gameObject.SetActive(true);
            }

            if (health <= 0)
            {
                gameHandler.shipScript.scraps += Mathf.RoundToInt(scrapsOnDeath * Random.Range(0.9f, 1.3f)); // give scraps
                Debug.Log("SCRAPS DEATH");
                Destroy(gameObject);
                //GameWorld.Instance.AddToScore(scoreValue);
            }
        }
    }

}
