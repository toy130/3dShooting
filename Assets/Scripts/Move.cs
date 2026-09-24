using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 1;

    [SerializeField]
    private float rotateSpeed = 1;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
     
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left* Time.deltaTime* moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -90 * rotateSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 90 * rotateSpeed * Time.deltaTime, 0));
        }
    }
}
