using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    void Start(){
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate(){
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other){
        Destroy(gameObject);
    }
}
