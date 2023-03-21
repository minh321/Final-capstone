using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class CharacterInputHandler : MonoBehaviour
{
    //[SerializeField] private GameObject bulletPrefab;
    Vector2 movementInputVector= Vector2.zero;
    Vector2 viewInputVector = Vector2.zero;
    bool isJumpButtonPressed = false;
    bool isAttackdButtonPressed = false;
    CharacterMovementHandler characterMovementHandler;

    private void Awake()
    {
        characterMovementHandler= GetComponent<CharacterMovementHandler>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementInputVector.x = Input.GetAxis("Horizontal");
        movementInputVector.y = Input.GetAxis("Vertical");

        characterMovementHandler.SetViewInputVector(viewInputVector);

        viewInputVector.x = Input.GetAxis("Mouse X");
        viewInputVector.y = Input.GetAxis("Mouse Y") * -1;

        isJumpButtonPressed = Input.GetButtonDown("Jump");

        /*isAttackdButtonPressed = Input.GetKey("Fire1");

        if(isAttackdButtonPressed)
        {
            LeanPool.Spawn(bulletPrefab);
        }*/
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.rotationInput = viewInputVector.x;
        networkInputData.isJumpPressed= isJumpButtonPressed;
        networkInputData.movementInput=movementInputVector;
        //networkInputData.isAttacked= isAttackdButtonPressed;
        return networkInputData;
    }
}
