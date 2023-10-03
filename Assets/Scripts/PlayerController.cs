using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float jumpForce = 5f;
    private bool isGrounded = true;

    private Vector3 dir;
    private Rigidbody rb;
    private Transform cam;

    [Header("Shoot")]
    public GameObject bullet;
    public Transform firePoint;

    void Start(){
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    void Update(){
        MovePlayer();
        isGrounded = CheckGrounded();

        if(Input.GetButtonDown("Fire1")){
            Shot();
        }

        if(isGrounded && Input.GetButtonDown("Jump")){
            Jump();
        }
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
    }

    void MovePlayer(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(horizontal, 0f, vertical);
        dir = transform.TransformVector(moveInput.normalized);

        // Converter a rotação da câmera em uma direção de movimento
        Vector3 cameraForward = cam.forward;
        Vector3 cameraRight = cam.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        dir = (cameraForward * moveInput.z + cameraRight * moveInput.x).normalized;
    }

    void Jump(){
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void Shot(){
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void Hit(){
        FindObjectOfType<DamageScreen>().DamageEffect();
    }

    bool CheckGrounded(){
        if(rb.velocity.y == 0) return true;
        else return false;
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Bullet")){
            Hit();
        }
    }
} 