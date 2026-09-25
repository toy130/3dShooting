using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject SubCamera;
    [SerializeField] private MainHealth mainHealth;
    [SerializeField] private GameObject DeathCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeathCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(mainHealth.currentHp <= 0)
        {
            MainCamera.SetActive(false);
            SubCamera.SetActive(false);
            DeathCamera.SetActive(true);
        }
        else
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
}
