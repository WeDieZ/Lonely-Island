using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 2;
    private float jumpforce = 5.5f;
    private float gravity = 9.8f;
    private float _fallVelocity = 0;
    private int can_jump = 1;

    public Animator _animator;
    private CharacterController _characterController;
    private Vector3 _VectorMove;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        Fall();

        Move();
    }

    void Update()
    {
        Jump();

        Walk_Move();

        Run();
    }

    //decoding_

    private void Walk_Move()
    {
        _VectorMove = Vector3.zero;
        var run_direction = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _VectorMove += transform.forward * speed;
            run_direction = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _VectorMove -= transform.forward * speed;
            run_direction = 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _VectorMove += transform.right * speed;
            run_direction = 3;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _VectorMove -= transform.right * speed;
            run_direction = 4;
        }

        _animator.SetInteger("run_direction", run_direction);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && can_jump > 0)
        {
            can_jump -= 1;
            _fallVelocity = -jumpforce;
        }
    }

    private void Fall()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
            can_jump = 1;
        }
    }

    private void Move()
    {
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        _characterController.Move(_VectorMove * speed * Time.fixedDeltaTime);
    }

    private void Run()
    {
        var food = GetComponent<HP_Food_Script>().food;

        if (Input.GetKeyDown(KeyCode.LeftShift)  && food > 0)
        {
            speed *= 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || food <= 0)
        {
            speed = 2;
        }
    }

    //_decoding
}
