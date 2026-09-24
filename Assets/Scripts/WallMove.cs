using UnityEngine;

public class WallMove : MonoBehaviour
{
    private bool MoveRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 5)
        {

        }
        transform.Translate(transform.right * Time.deltaTime);
    }
}
