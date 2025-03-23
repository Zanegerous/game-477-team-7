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
        incrementAmount = 0.1f;
        barspriteTransform = transform;
    }

    public void incrementHealthBar() {
        fullHealth = Mathf.Min(fullHealth + incrementAmount, 1f);
        barspriteTransform.localScale = new Vector3(fullHealth, barspriteTransform.localScale.y, barspriteTransform.localScale.z);
    }

    public void decrementHealthBar() {
        fullHealth = Mathf.Max(fullHealth - incrementAmount, 0f);
        barspriteTransform.localScale = new Vector3(fullHealth, barspriteTransform.localScale.y, barspriteTransform.localScale.z);
    }
}
