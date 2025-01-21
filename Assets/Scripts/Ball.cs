using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance { get; private set; }

    public event EventHandler<onGoalScoredEventArgs> onGoalScored;
    public event EventHandler onSolidHit;
    public class onGoalScoredEventArgs : EventArgs
    {
        public Collider2D collider;
    }

    [SerializeField] private Ball ball;
    private Rigidbody2D rigidbody2D;
    private float forceModifier = 18f;
    private float ballradius = 1f;
    private Vector2 direction = new Vector2(1f, 1f);

    private void Awake()
    {
        Instance = this;
        rigidbody2D = GetComponent<Rigidbody2D>();
        ResetPosition();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }


    private void HandleMovement()
    {
        if (rigidbody2D.velocity.magnitude < forceModifier)
        {
            rigidbody2D.velocity = direction.normalized * forceModifier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onGoalScored?.Invoke(this, new onGoalScoredEventArgs
        {
            collider = collision
        });
        ResetPosition();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onSolidHit?.Invoke(this,EventArgs.Empty);

        GameObject gameObject = collision.gameObject;

        if (gameObject.GetComponent<Player>())
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 playerPosition = gameObject.transform.position;
            float offset = contactPoint.y - playerPosition.y;
            direction.y = offset * 2; 

            ReverseDirection();
        }
        else
        {
            direction.y *= -1;
        }
    }


    public void ResetPosition()
    {
        ball.gameObject.transform.position = new Vector3(0, 0, 0);
        ResetBall();
    }

    private void ReverseDirection()
    {
        direction.x *= -1;
        direction.y = UnityEngine.Random.Range(-1f, 1f);
    }
    private void ResetBall()
    {
        rigidbody2D.velocity = direction.normalized * forceModifier;
    }
}
