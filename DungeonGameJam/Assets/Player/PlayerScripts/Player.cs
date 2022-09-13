using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject Instance;

    public static bool freezed = false;

    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this.gameObject;
            return;
        }

        Destroy(gameObject);
        return;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
