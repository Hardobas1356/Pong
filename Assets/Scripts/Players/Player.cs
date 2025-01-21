using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{

    protected float movementSpeed = 18f;
    protected float boundary = 9f;

    protected virtual void HandleMovement()
    {  }

}
