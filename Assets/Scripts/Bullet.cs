using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletLifeTime = 3f;
    [SerializeField] int damage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(bulletSpeed);
        }
    }
    void Shoot(float speed)
    {
        GameObject Bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = Bullet.GetComponent<Rigidbody>();
        if(rb != null) rb.linearVelocity = -shootPoint.forward * speed;
        Destroy(Bullet, bulletLifeTime);
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy":
                Debug.Log("弾が敵に命中");
                EnemyHealth eh = other.GetComponent < EnemyHealth > ();
                if (eh != null)
                {
                    eh.TakeDamage(damage);
                }
                Destroy(gameObject);
                break;
            case "Wall":
                Debug.Log("壁に当たった");
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
