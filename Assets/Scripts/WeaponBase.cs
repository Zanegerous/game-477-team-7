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


    private float startingXPos; // Track the initial position
    private float xOffset = 0f; // Movement over time
    private float yOffset = 0f;  // Optional: Adjust vertical position if needed

    // Start is called before the first frame update
    void Start()
    {
        startingXPos = transform.position.x;
        direction = GenerateAngle();

        // if (isEnemy)
        //     movementSpeed = -movementSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
        CheckPos();
    }


    private Vector3 GenerateAngle(){
        float spreadOffset = Random.Range(-spread, spread);
        float fireAngle =  (transform.rotation.eulerAngles.z + spreadOffset) * Mathf.Deg2Rad;
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
            Destroy(gameObject);
        }
    }


}
