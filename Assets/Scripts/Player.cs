using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Player player;

    private float movementSpeed = 18f;
    private float boundary = 10f;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {

        if (Input.GetKey(KeyCode.W) && player.transform.position.y < boundary)
        {
            player.transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && player.transform.position.y > -boundary)
        {
            player.transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        }

    }

}
