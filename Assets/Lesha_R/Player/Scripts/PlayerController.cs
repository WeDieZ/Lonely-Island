﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 2;
    private float jumpforce = 5.5f;
    private float gravity = 9.8f;
    private float _fallVelocity = 0;
    private int can_jump = 1;

    public bool IsAbleToMove = true;

    public GameObject _player;

    public Animator _animator;
    private CharacterController _characterController;
    private Vector3 _VectorMove;
    public InventoryManager inventoryManager;
    public QuickslotInventory quickslotInventory;

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
        MeleeAttackAnim();

        Jump();

        Walk_Move();

        Run();
    }

    //decoding_

    public void Walk_Move()
    {
        _VectorMove = Vector3.zero;
        var run_direction = 0;

        if (IsAbleToMove == true)
        {
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
        }
        _animator.SetInteger("run_direction", run_direction);
    }

    public void Jump()
    {
        if (IsAbleToMove == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && can_jump > 0 && (IsAbleToMove = true))
            {
                can_jump -= 1;
                _fallVelocity = -jumpforce;
            }
        }
    }

    public void Fall()
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

    public void Run()
    {
        var food = _player.GetComponent<HP_Food_Script>().food;

        if (Input.GetKeyDown(KeyCode.LeftShift)  && food > 0)
        {
            speed *= 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || food <= 0)
        {
            speed = 2;
        }
    }

    public void MeleeAttackAnim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (quickslotInventory.activeSlot != null)
            {
                if (quickslotInventory.activeSlot.item != null)
                {
                    if (quickslotInventory.activeSlot.item.itemType == ItemType.Weapon)
                    {
                        if (inventoryManager.isOpened == false)
                        {
                            _animator.SetBool("Hit", true);
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("Hit", false);
        }    
    }
    //_decoding
}