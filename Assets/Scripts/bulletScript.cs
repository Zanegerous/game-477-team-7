using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{   
    public float bulletSpeed = 10f;

    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);

        if (transform.position.x >= 10f)
            Destroy(gameObject);
    }
}
