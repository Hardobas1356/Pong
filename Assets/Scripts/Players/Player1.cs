using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player
{
    private void Update()
    {
        HandleMovement();
    }

    protected override void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W) && this.transform.position.y < boundary)
        {
            this.transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && this.transform.position.y > -boundary)
        {
            this.transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        }
    }
}
