using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody rb;
    public bool IsOnTheGround = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.Translate(horizontalMovement, 0, verticalMovement);

        if(Input.GetButtonDown("Jump") && IsOnTheGround )
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            IsOnTheGround =  false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsOnTheGround = true;
        }
    }
}
