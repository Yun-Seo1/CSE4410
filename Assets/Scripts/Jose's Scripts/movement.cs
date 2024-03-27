using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    [Header("Movement")]
    private float _MoveSpeed;
    public float WalkSpeed;
    public float SprintSpeed;

    private bool _Grounded = true;

    [Header("Keybinds")]
    public KeyCode SprintKey = KeyCode.LeftShift;

    public MovementState State;
    public enum MovementState
    {
        walking,
        sprinting,
        air
    }


    public float speed = 10f;
    public Rigidbody rb;
    public bool IsOnTheGround = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * _MoveSpeed;
		float verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * _MoveSpeed;

		transform.Translate(horizontalMovement, 0, verticalMovement);

        if(Input.GetButtonDown("Jump") && IsOnTheGround )
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            IsOnTheGround =  false;

        }
        StateHandler();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsOnTheGround = true;
        }
    }
    private void StateHandler()
    {
        //Sprinting
        if (_Grounded && Input.GetKey(SprintKey))
        {
            State = MovementState.sprinting;
            _MoveSpeed = SprintSpeed;
        }
        //Walking
        else if (_Grounded)
        {
            State = MovementState.walking;
            _MoveSpeed = WalkSpeed;
        }
        //Air
        else
        {
            State = MovementState.air;
        }
    }
}
