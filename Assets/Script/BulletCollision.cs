using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] public Rigidbody bulletBody;
    [SerializeField] private float thrust;
   
    private void Start()
    {
        bulletBody = GetComponent<Rigidbody>();
        StartCoroutine(DestroyBullet());
    }
    private void Update()
    {
        bulletBody.AddForce(transform.forward * thrust *Time.deltaTime,ForceMode.Impulse);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        LeanPool.Despawn(this);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        LeanPool.Despawn(this);
    }
}
