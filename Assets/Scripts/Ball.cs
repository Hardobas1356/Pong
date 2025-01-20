using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Ball ball;
    private Rigidbody2D rigidbody2D;
    private float forceModifier = 13f;
    private float ballradius = 1f;
    private Vector2 direction = new Vector2(1f, 1f);

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        HandleMovement();
    }


    private void HandleMovement()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position, direction.normalized, ballradius);

        if (hit)
        {
            if (hit.collider.isTrigger)
            {
                ResetPosition();
            }
            else if (hit.collider.GetComponent<Player>() != null)
            {
                ReverseDirection();
            }

            direction.y *= -1;
        }

        Vector3 movement = direction.normalized * Time.deltaTime * forceModifier;
        ball.gameObject.transform.position += movement;
    }

    public void ResetPosition()
    {
        ReverseDirection();
        ball.gameObject.transform.position = new Vector3(0, 0, 0);
    }

    private void ReverseDirection()
    {
        direction.x *= -1;
        direction.y = Random.Range(0,4);
    }
}
