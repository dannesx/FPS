using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;
    public Transform weapon;

    [Header("Shooting")]
    public float cadence = 2f;
    public GameObject bullet;
    public Transform[] firePoints;
    private float timer = 0f;

    [Header("Stats")]
    public int hp = 5;
    private Bar hpBar;

    void Start(){
        player = FindObjectOfType<PlayerController>().transform;
        weapon = GameObject.Find("turretWeapon").transform;
        hpBar = FindObjectOfType<Bar>();
        hpBar.maxValue = hp;
    }

    void FixedUpdate(){ 
        weapon.LookAt(player, Vector3.up);

        if(timer > cadence){
            Shoot();
            timer = 0f;
        } else {
            timer += Time.deltaTime;
        }

        weapon.Rotate(0, 180, 0);
    }

    void Shoot(){
        foreach(Transform point in firePoints){
            Instantiate(bullet, point.transform.position, weapon.transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Bullet")) {
            hp--;
            hpBar.SetValue(hp);

            if(hp < 1) Destroy(this.gameObject);
        }
    }
}