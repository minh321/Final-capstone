using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum InputButtons
{
    Forward = 0,
    Backward =1,
    Left =2,
    Right =3,
}

public struct NetworkInputData : INetworkInput
{
    public Vector2 movementInput;
    public float rotationInput;
    public NetworkBool isJumpPressed;
    //public NetworkBool isAttacked;
}
