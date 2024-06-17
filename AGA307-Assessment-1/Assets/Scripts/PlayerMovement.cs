using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("--- Movement ---")]
    public CharacterController controller;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    public float speed = 5;
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    Rigidbody RB;
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    [Header("--- Projectile Settings ---")]
    public float Velocity = 1000;
    public Transform projectileSpawner;
    public GameObject projectilePrefab;
    public float projectileLifeTime = 5;



    void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        IsRunning = canRun && Input.GetKey(runningKey);

        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        RB.velocity = transform.rotation * new Vector3(targetVelocity.x, RB.velocity.y, targetVelocity.y);
    }

    //Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void Shoot()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, projectileSpawner.position, projectileSpawner.rotation);
        projectileInstance.GetComponent<Rigidbody>().AddForce(projectileSpawner.transform.forward * Velocity);
        Destroy(projectileInstance, projectileLifeTime);
    }
}
