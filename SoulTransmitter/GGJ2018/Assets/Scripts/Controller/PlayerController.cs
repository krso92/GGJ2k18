using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Player index for seperated input
    /// </summary>
    public int playerIndex;

    public int playerHealth;

    public float speed;

    public Transform shotIndicator;
    public Transform shotPosition;

    public enum PlayerType { RADIO, ANTENA };
    public PlayerType playerType = PlayerType.RADIO;

    public enum InputType { KEYBOARD, JOYSTICK };
    public InputType inputType = PlayerController.InputType.JOYSTICK;

    public CharacterAnimationHandler animationHandler;

    public ParticleSystem shootParticle;

    private float X = 0f;
    private float Y = 0f;
    private float RX = 0f;
    private float RY = 0f;

    private bool _flippedX;
    private bool _cooldown = true;
    private bool _jump = false;
    private bool _shoot = false;
    private bool _start = false;

    private bool _aiming = false;

    private Vector3 _aimDirection;
    private Vector2 _move;

    public Vector2 Move
    {
        get
        {
            return _move;
        }
    }

    public float _shotIndicatorDistance;
    // Use this for initialization
    void Start()
    {
        shootParticle.transform.localPosition = shotPosition.position;
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
            if (playerIndex == 2)
            {
                _shoot = Input.GetButtonDown("FireKeyboard" + playerIndex.ToString());
            }
            else
            {
                _shoot = Input.GetMouseButtonDown(0);

            }

            _start = Input.GetButtonDown("StartKeyboard" + playerIndex.ToString());
        }

        _jump = Input.GetButton("Jump" + playerIndex.ToString());
    }




    // Update is called once per frame
    void Update()
    {
        InputButtons();

        //print("PLayer " + playerIndex + "X is " + X + " Y is " + Y);

        if (playerType == PlayerType.ANTENA)
        {
            Aim();
        }
        Shoot();

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

        _move = new Vector2(X, Y);
        if (X < 0 && !_flippedX)
        {
            _flippedX = true;
            animationHandler.transform.Rotate(Vector3.up, 180f);
        }
        else if (X > 0 && _flippedX)
        {
            _flippedX = false;
            animationHandler.transform.Rotate(Vector3.up, 180f);
        }
        transform.Translate(_move * speed * Time.deltaTime);
        if (_move != Vector2.zero)
        {
            animationHandler.PlayWalkAnimation();
        }
        else
        {
            animationHandler.PlayIdleAnimation();
        }
    }

    void Aim()
    {
        if (inputType == InputType.JOYSTICK)
        {
            _aimDirection = new Vector3(RX, RY, 0);
        }
        else
        {
            _aimDirection = Input.mousePosition - transform.position;
        }
        shootParticle.transform.rotation = Quaternion.LookRotation(-transform.position + shotIndicator.transform.position);// = Quaternion.Euler(-transform.position + _aimDirection);
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
        if (_shoot && _aiming && _cooldown && !shootParticle.isPlaying)
        {
            _cooldown = false;
            StartCoroutine(WeaponCooldown(0.5f));
            shootParticle.transform.position = shotPosition.position;
            //GameObject g = Resources.Load("bullet");
            animationHandler.PlayShootAnimation();

            shootParticle.Emit(1);
            //GameObject g = Instantiate(shootParticle, shotPosition);
        }
        else
        {
            if (shootParticle.isPlaying)
            {
                shootParticle.Stop();
            }
            //shootParticle.Stop();
        }
    }

    public void DamageMeBaby(int dmg)
    {
        playerHealth -= dmg;
    }


    IEnumerator WeaponCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        _cooldown = true;
    }
}
