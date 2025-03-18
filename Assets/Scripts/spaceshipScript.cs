using UnityEngine;

public class spaceshipScript : MonoBehaviour
{      
    
    [Header("General")]
    public bool firing;
    public GameObject bullet;
    public int scraps;


    [Header("Movement Settings")]
    public bool canMove;
    public float verticalSpeed = 1f;
    public float horizontalSpeed = 0.2f;


    [Header("Attack Settings")]
    public float attackSpeed = 0.5f;
    public float bulletSpeed = 10f;
    public float damage = 1f;
    public int multiShot = 0;


    [Header("Defense Settings")]
    public float health = 100f;
    public float defense = 1f;

    [Header("Upgrades")]
    int currentAttackSpeedUpgradeCost = 100;



    public float timeOfLastBullet;
    private movePlayer moveScript;

    void Start()
    {
        moveScript = GetComponent<movePlayer>();
        timeOfLastBullet = Time.time;

    }

    void Update()
    {
        syncWithMovementScript();
        shootBullets();
    }

    void syncWithMovementScript(){
        moveScript.verticalSpeed = verticalSpeed;
        moveScript.horizontalSpeed = horizontalSpeed;
        firing = !Cursor.visible && (moveScript.shooting == 1);
        canMove = moveScript.canMove;
    }

    void shootBullets(){
        if (firing)
            if (Time.time > timeOfLastBullet + attackSpeed)
                shoot();
    }

    void shoot(){
        GameObject newBullet = Instantiate(bullet, transform.Find("Barrel").position, transform.Find("Barrel").rotation);
        newBullet.GetComponent<bulletScript>().bulletSpeed = bulletSpeed;

        timeOfLastBullet = Time.time;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public void upgradeAttackSpeed(){
        
        if (scraps >= currentAttackSpeedUpgradeCost)
        {
            scraps -= currentAttackSpeedUpgradeCost;
            attackSpeed /= 1.1f;
            // return attackSpeed.ToString("F2") + " -> " + (attackSpeed/1.1f).ToString("F2");
        }
    
        // return "Not Set Up";



    }
}
