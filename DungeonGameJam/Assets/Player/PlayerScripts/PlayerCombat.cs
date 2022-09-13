using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = new Sword();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButtonDown("Fire1")) return;

        weapon.Hit();
    }

    
}
