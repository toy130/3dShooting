using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
