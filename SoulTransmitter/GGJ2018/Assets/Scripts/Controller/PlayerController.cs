﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Player index for seperated input
    /// </summary>
    public int playerIndex;
    public float speed;

    public Transform shotIndicator;

    public enum PlayerType { RADIO, ANTENA };
    public PlayerType playerType = PlayerType.RADIO;

    public enum InputType { KEYBOARD, JOYSTICK };
    public InputType inputType = PlayerController.InputType.JOYSTICK;

    private float X = 0f;
    private float Y = 0f;
    private float RX = 0f;
    private float RY = 0f;

    private bool _jump = false;
    private bool _shoot = false;
    private bool _start = false;

    private bool _aiming = false;

    private Vector3 _aimDirection;
    private Vector2 _move;
    public float _shotIndicatorDistance;
    // Use this for initialization
    void Start()
    {

    }

    void InputButtons()
    {
        if (inputType == InputType.JOYSTICK)
        {
            X = Input.GetAxis("Horizontal" + playerIndex.ToString());
            Y = Input.GetAxis("Vertical" + playerIndex.ToString());
            _shoot = Input.GetButtonDown("Fire" + playerIndex.ToString());
            _start = Input.GetButtonDown("Start" + playerIndex.ToString());
            RX = Input.GetAxis("RAxisX" + playerIndex.ToString());
            RY = Input.GetAxis("RAxisY" + playerIndex.ToString());
        }
        else
        {
            X = Input.GetAxis("HorizontalKeyboard" + playerIndex.ToString());
            Y = Input.GetAxis("VerticalKeyboard" + playerIndex.ToString());
            _shoot = Input.GetButtonDown("FireKeyboard" + playerIndex.ToString());
            _start = Input.GetButtonDown("StartKeyboard" + playerIndex.ToString());
        }

        _jump = Input.GetButton("Jump" + playerIndex.ToString());
    }




    // Update is called once per frame
    void Update()
    {
        InputButtons();

        print("PLayer " + playerIndex + "X is " + X + " Y is " + Y);
        //if (Input.GetButton("Jump" + playerIndex.ToString()))
        //{
        //    print("PLayer " + playerIndex + " jump is " + _jump);
        //}
        //if (_shoot)
        //{
        //    print("PLayer " + playerIndex + " shoot is " + _shoot);
        //}
        //if (_start)
        //{
        //    print("PLayer " + playerIndex + " start is " + _start);
        //}
        Aim();
        Shoot();

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

        _move = new Vector2(X, Y);
        transform.Translate(_move * speed * Time.deltaTime);
    }

    void Aim()
    {
        _aimDirection = new Vector3(RX, RY, 0);
        if (_aimDirection.magnitude > 0.9f)
        {
            if (!shotIndicator.gameObject.activeSelf)
            {
                shotIndicator.gameObject.SetActive(true);
            }
            _aiming = true;
            shotIndicator.localPosition = _aimDirection.normalized * _shotIndicatorDistance;
        }
        else if (shotIndicator.gameObject.activeSelf)
        {
            _aiming = false;
            shotIndicator.gameObject.SetActive(false);
        }


    }

    void Shoot()
    {

    }
}
