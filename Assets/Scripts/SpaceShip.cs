using UnityEngine;

public class SpaceShip : MonoBehaviour
{


    [Header("General")]
    public bool firing;
    public GameObject bullet;
    public int scraps;


    [Header("Movement Settings")]
    public float speedMult = 1;
    public bool canMove;
    public float verticalSpeed = 1f; float initialVerticalSpeed;
    public float horizontalSpeed = 0.2f; float initialHorizontalSpeed;


    [Header("Attack Settings")]
    public float attackSpeed = 0.5f;
    public float bulletSpeed = 10f;
    public float damage = 1f;
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

    void Start()
    {
        moveScript = GetComponent<movePlayer>();
        timeOfLastBullet = Time.time;
        initialVerticalSpeed = verticalSpeed;
        initialHorizontalSpeed = horizontalSpeed;

        gameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameHandler>();

    }

    void Update()
    {
        syncWithMovementScript();
        shootBullets();
    }

    void syncWithMovementScript()
    {
        moveScript.verticalSpeed = verticalSpeed;
        moveScript.horizontalSpeed = horizontalSpeed;
        firing = !Cursor.visible && (moveScript.shooting == 1);
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
        GameObject newBullet = Instantiate(bullet, transform.Find("Barrel").position, transform.Find("Barrel").rotation);
        newBullet.GetComponent<bulletScript>().bulletSpeed = bulletSpeed;

        timeOfLastBullet = Time.time;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public void upgradeAttackSpeed()
    {

        if (scraps >= currentAttackSpeedUpgradeCost)
        {
            scraps -= currentAttackSpeedUpgradeCost;
            currentAttackSpeedUpgradeCost += 100;
            attackSpeed /= 1.1f;
            gameHandler.updateAttackSpeedCost();
        }
    }

    public void upgradeShipSpeed()
    {

        if (scraps >= currentShipSpeedUpgradeCost)
        {
            scraps -= currentShipSpeedUpgradeCost;
            currentShipSpeedUpgradeCost += 25;
            speedMult += 0.1f;

            verticalSpeed = initialVerticalSpeed * speedMult;
            horizontalSpeed = initialHorizontalSpeed * speedMult;

            gameHandler.updateShipSpeedCost();
        }
    }

    public void DamagePlayer(float damage)
    {

    }
}
