using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(horizontal, 0, vertical);

        if(Input.GetButtonDown("Jump"))
        {
        rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        Debug.Log("Jump pressed");

        }
    }
}
