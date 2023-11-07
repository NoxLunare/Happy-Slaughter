using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField] float damage;

    private void Awake(){
        rigidbody.velocity=transform.forward*velocity;
        Destroy(gameObject, 5f);
    }
}
