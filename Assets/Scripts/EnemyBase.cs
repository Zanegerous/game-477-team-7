using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Settings")]
    public float health;
    public float speed;
    public float scoreValue;


    [Header("Weapon")]
    public GameObject weapon;
    private float timeOfLastBullet;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(10f, 50f));
        Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
        transform.position = initPos;
        timeOfLastBullet = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        fireWeapon(weapon);

    }

    public void fireWeapon(GameObject weapon)
    {
        WeaponBase weaponBase = weapon.GetComponent<WeaponBase>();

        if (Time.time > timeOfLastBullet + weaponBase.fireRate)
        {
            timeOfLastBullet = Time.time;
            GameObject newWeapon = Instantiate(weapon, transform.Find("EnemyBarrel").position, transform.Find("EnemyBarrel").rotation);
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
