using UnityEngine;

public class HelloTest : MonoBehaviour
{
    [SerializeField] private int a = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello,Unity!");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }
}
