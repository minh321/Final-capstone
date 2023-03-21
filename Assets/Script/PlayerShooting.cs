using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class PlayerShooting : MonoBehaviour
{
    public float fireRate = 0.5f;
    public float maxWeaponRange = 500f;
    public float raycastIncrement = 10f;
    public Transform gunEnd;
    public Transform crosshair;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Spawn a bullet
            //GameObject bullet = Instantiate(bulletPrefab, gunEnd.position, Quaternion.identity);
            var bullet = LeanPool.Spawn(bulletPrefab, gunEnd.position, Quaternion.identity);
            bullet.transform.forward = Camera.main.transform.forward;
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward;

  
            return;

        }
    }
}