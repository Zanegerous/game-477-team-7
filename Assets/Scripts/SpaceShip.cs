using UnityEngine;

public class SpaceShip : MonoBehaviour
{


    [Header("General")]
    public bool firing;
    public GameObject currentProjectile;
    public int scraps;


    [Header("Movement Settings")]
    public float speedMult = 1;
    public bool canMove;
    public float verticalSpeed = 1f; float initialVerticalSpeed;
    public float horizontalSpeed = 0.2f; float initialHorizontalSpeed;


    [Header("Attack Settings")]
    public float damageMult = 1;
    public float attackSpeed = 0.5f;
    public float bulletSpeed = 10f;
    public int multiShot = 0;


    [Header("Defense Settings")]
    public float health = 100f;
    public float defense = 1f;

    [Header("Upgrades")]
    public int currentAttackSpeedUpgradeCost = 100;
    public int currentShipSpeedUpgradeCost = 50;



    public float timeOfLastBullet;
    private movePlayer moveScript;
    private gameHandler gameHandler;
    public healthBar playerHealth;      // in progress

    void Start()
    {
        moveScript = GetComponent<movePlayer>();
        timeOfLastBullet = Time.time;
        initialVerticalSpeed = verticalSpeed;
        initialHorizontalSpeed = horizontalSpeed;
        attackSpeed = currentProjectile.GetComponent<WeaponBase>().fireRate;

        gameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameHandler>();

    }

    void Update()
    {
        syncWithMovementScript();
        shootBullets();
        checkForDamage();           // in progress
    }

    void syncWithMovementScript()
    {
        moveScript.verticalSpeed = verticalSpeed;
        moveScript.horizontalSpeed = horizontalSpeed;
        firing = (moveScript.shooting == 1);
        canMove = moveScript.canMove;
    }

    void shootBullets()
    {
        if (firing)
            if (Time.time > timeOfLastBullet + attackSpeed)
                shoot();
    }

    void shoot()
    {
        GameObject newBullet = Instantiate(currentProjectile, transform.Find("Barrel").position, transform.Find("Barrel").rotation);
        newBullet.GetComponent<WeaponBase>().movementSpeed = bulletSpeed;

        timeOfLastBullet = Time.time;
    }

    public void checkForDamage() {
        // if enemy.projectile.collider == player.collider
            // playerHealth.decrementHealthBar();
    }

    public void checkForHealthPotion() {
        // if potion.projectile.collider == player.collider
            // playerHealth.incrementHealthBar();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void upgradeAttackSpeed()
    {
        if (scraps >= currentAttackSpeedUpgradeCost)
        {
            scraps -= currentAttackSpeedUpgradeCost;
            currentAttackSpeedUpgradeCost += 50;
            attackSpeed /= 1.1f;
            gameHandler.updateAttackSpeedCost();
        }
    }

    public void upgradeShipSpeed()
    {

        if (scraps >= currentShipSpeedUpgradeCost)
        {
            scraps -= currentShipSpeedUpgradeCost;
            currentShipSpeedUpgradeCost += 50;
            speedMult += 0.1f;

            verticalSpeed = initialVerticalSpeed * speedMult;
            horizontalSpeed = initialHorizontalSpeed * speedMult;

            gameHandler.updateShipSpeedCost();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponBase collisonObject = collision.GetComponent<WeaponBase>();
        if (collisonObject != null)
        {
            health -= collisonObject.damage;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
                //GameWorld.Instance.AddToScore(scoreValue);
            }
        }
    }
}
