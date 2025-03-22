using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public float fullHealth;
    public float decrementAmount;
    public float incrementAmount;

    // Start is called before the first frame update
    void Start()
    {
        /*
        decrementAmount = 0.1f;
        fullHealth = 1f;
        Transform barSprite = transform.scale.GetComponent<x???>;
        barSprite = fullHealth;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decrementHealthBar() {
        // barsprite -= decrementAmount
    }

    public void incrementHealthBar() {
        // if barsprite + incrementAmount >= 100 
            // barsprite = fullHealth
        // else
            // barsprite += incrementAmount
    }
}
