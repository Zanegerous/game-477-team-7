using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundController : MonoBehaviour
{
    public GameObject layer1;
    public GameObject layer2;
    public GameObject layer3;
    public float layer1Speed;
    public float layer2Speed;
    public float layer3Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (layer1)
            layer1.transform.Translate(Vector2.left * layer1Speed * Time.deltaTime);
        
        if (layer2)
            layer2.transform.Translate(Vector2.left * layer2Speed * Time.deltaTime);
        
        if (layer3)
            layer3.transform.Translate(Vector2.left * layer3Speed * Time.deltaTime);
    }
}
