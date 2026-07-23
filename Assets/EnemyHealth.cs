using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
    [SerializeField] int maxHp = 3;
    int currentHp = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        Debug.Log(gameObject.name + " のHP: " + currentHp);

        if(currentHp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log(gameObject.name + "が倒された");
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
