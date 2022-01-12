using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleMoveController : MonoBehaviour
{
    public float speed = 6.0f;
    public bool player2 = false;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3.0f, 3.0f));

        float v;
        if (!player2)
        {
            v = Input.GetAxisRaw("Vertical");
        }
        else
        {
            v = Input.GetAxisRaw("Vertical2");
        }


        rb.velocity = new Vector2(rb.velocity.x, v * speed);
    }
}
