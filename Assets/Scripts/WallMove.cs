using UnityEngine;

public class WallMove : MonoBehaviour
{
    private float speed = 1f;
    private bool MoveRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x > 4 && MoveRight)
        {
            MoveRight = false;
        }
        if(transform.position.x < -4 && !MoveRight)
        {
            MoveRight = true;
        }
    }
}
