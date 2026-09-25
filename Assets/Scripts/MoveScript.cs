using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletLifeTime = 3f;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float jumpPower = 1.0f;
    [SerializeField] int damage = 1;
    [SerializeField] MainHealth mainHealth;

    private bool isGrounded = true;
    private int justJumpTime = 0;
    private bool startJump = false;
    private bool justJump = false;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(bulletSpeed);
        }
        if (startJump)
        {
            justJumpTime++;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (!justJump)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * 2);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                if(0 <= justJumpTime && justJumpTime <= 40)
                {
                    justJump = true;
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy":
                mainHealth.currentHp = 0;
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("着地");
        isGrounded = true;
        startJump = true;
        justJump = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        startJump = false;
        justJumpTime = 0;
    }
    void Shoot(float speed)
    {
        GameObject Bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = Bullet.GetComponent<Rigidbody>();
        if (rb != null) rb.linearVelocity = -shootPoint.forward * speed;
        Destroy(Bullet, bulletLifeTime);
    }
}
