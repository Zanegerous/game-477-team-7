using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserShot : MonoBehaviour
{

    public float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);

        if (transform.position.x <= -10f)
            Destroy(gameObject);
    }
}
