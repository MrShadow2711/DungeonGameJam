using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject Instance;
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
