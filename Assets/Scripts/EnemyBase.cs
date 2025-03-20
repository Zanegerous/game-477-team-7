using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Settings")]
    public float health;
    public float speed;
    public float bulletSpeed;
    public float scoreValue;


    [Header("Weapon")]
    public GameObject weapon;
    private float timeOfLastBullet;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(12, Random.Range(-3f, 3f), 0);
        timeOfLastBullet = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        fireWeapon(weapon);
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Hurt Player and Delete Ship  
        if (transform.position.x < -10f)
            Destroy(gameObject);
        

    }

    public void fireWeapon(GameObject weapon)
    {
        WeaponBase weaponBase = weapon.GetComponent<WeaponBase>();

        if (Time.time > timeOfLastBullet + weaponBase.fireRate)
        {
            timeOfLastBullet = Time.time;
            GameObject newWeapon = Instantiate(weapon, transform.Find("EnemyBarrel").position, transform.Find("EnemyBarrel").rotation);
            newWeapon.GetComponent<WeaponBase>().movementSpeed = bulletSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponBase collisonObject = collision.GetComponent<WeaponBase>();
        if (collisonObject != null)
        {
            Destroy(collision.gameObject);
            health -= collisonObject.damage;
            if (health <= 0)
            {
                Destroy(gameObject);
                //GameWorld.Instance.AddToScore(scoreValue);
            }
        }
    }
}
