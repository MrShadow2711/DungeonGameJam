using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int layerMask;

    public float health { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Enemy.layerMask = 1 << LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Got Damage");
    }
}
