using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public float fullHealth;
    private float incrementAmount;
    private Transform barspriteTransform;

    // Start is called before the first frame update
    void Start()
    {
        fullHealth = 1f;
        incrementAmount = 0.01f;
        barspriteTransform = transform;
    }

    public void incrementHealthBar(float value)
    {
        fullHealth = Mathf.Min(fullHealth + (incrementAmount * value), 1f);
        barspriteTransform.localScale = new Vector3(fullHealth, barspriteTransform.localScale.y, barspriteTransform.localScale.z);
    }

    public void decrementHealthBar(float damage)
    {
        fullHealth = Mathf.Max(fullHealth - (incrementAmount * damage), 0f);
        barspriteTransform.localScale = new Vector3(fullHealth, barspriteTransform.localScale.y, barspriteTransform.localScale.z);
    }
}
