using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{
    private void Update()
    {
        HandleMovement();
    }

    protected override void HandleMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) && this.transform.position.y < boundary)
        {
            this.transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && this.transform.position.y > -boundary)
        {
            this.transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        }
    }
}
