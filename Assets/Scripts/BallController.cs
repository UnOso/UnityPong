using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float inForce = 3.0f;
    public float forceOnBounce = 0.05f;
    public ParticleSystem ps;

    private SpriteRenderer rend;
    private Color baseColor;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        baseColor = rend.color;
        rb = GetComponent<Rigidbody2D>();
        inMove();
    }

    void inMove()
    {
        rb.AddRelativeForce(new Vector2(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f)).normalized * inForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pole"))
            bounce(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            restart();
            addScore();
        }
    }

    private void bounce(GameObject bouncedPole)
    {
        rb.velocity = rb.velocity * (1 + forceOnBounce);
        rend.color = bouncedPole.GetComponent<SpriteRenderer>().color;
        changePS(rend.color);
    }

    void addScore()
    {

    }

    void restart()
    {   
        transform.position = Vector2.zero;
        rb.velocity = Vector3.zero;
        rend.color = baseColor;
        changePS(rend.color);
        StartCoroutine(startTimer());
    }

    void changePS(Color color)
    {
        var mainPar = ps.main;
        mainPar.startColor = color;
    }



    IEnumerator startTimer()
    {
        yield return new WaitForSeconds(1);
        inMove();
    }
}
