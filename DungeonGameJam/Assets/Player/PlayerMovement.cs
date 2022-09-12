using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 7;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = new()
        {
            x = Input.GetAxis("Horizontal") * Speed,
            y = Input.GetAxis("Vertical") * Speed
        };

        rb.velocity = v;
    }
}
