using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject SubCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MainCamera.SetActive(false);
            SubCamera.SetActive(true);
        }
        else
        {
            MainCamera.SetActive(true);
            SubCamera.SetActive(false);
        }
    }
}
