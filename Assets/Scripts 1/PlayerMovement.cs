using System;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public event Action OnMovement;
    public event Action OnStopped;

    [Header("Movement")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    private float _horizontalInput, _verticalInput;
    private Vector3 _moveDirection;

    private Rigidbody _rb;

    [Header("Ground Check")]
    [SerializeField] private LayerMask _ground;
    private bool _isGrounded;
    [SerializeField] private float _playerHeight;
    [SerializeField] private float _groundDrag;


    [Header("States")]
    //public static bool _isWalking;
    public static bool _isRunning;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    private bool _readyToJump = true;
    [SerializeField] private float _fallMultiplier;


    [SerializeField] private Transform _orientation;

    [SerializeField] private Animator _anim;

    //private void OnEnable()
    //{
    //    EventManager.instance.OnChestZoomIn += StopMovement;
    //}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;

        //_chestCam = GameObject.FindWithTag("ChestCam");

        _anim = transform.GetChild(0).transform.GetChild(1).GetComponent<Animator>();
    }

    private void Update()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector3.up * Physics.gravity.y * _fallMultiplier * Time.deltaTime;
        }

        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _ground);

        if (_isGrounded)
        {
            _rb.drag = _groundDrag;
        }
        else
        {
            _rb.drag = 0;
        }

        if (_isRunning)
        {
            SpeedControl(_runSpeed);
            //Debug.Log("SpeedControl(_runSpeed);");
        }
        else
        {
            SpeedControl(_walkSpeed);
            //Debug.Log("SpeedControl(_walkSpeed);");
        }
    }

    private void FixedUpdate()
    {
        if (!ClickController.isZoomIn)
        {
            MyInput();
        }
    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //_isWalking = false;
            _isRunning = true;
            MovePlayer(_runSpeed);
        }
        else
        {
            //_isWalking = true;
            _isRunning = false;
            MovePlayer(_walkSpeed);
        }

        if (Input.GetKey(KeyCode.Space) && _isGrounded && _readyToJump)
        {
            _readyToJump = false;
            Jump();
            Invoke("ResetJump", 0.5f);
        }
    }
    //private void StopMovement()
    //{
    //    _horizontalInput = 0;
    //    _verticalInput = 0;
    //    _jumpForce = 0;
    //}

    private void MovePlayer(float moveSpeed)
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;
        _rb.AddForce(_moveDirection.normalized * moveSpeed, ForceMode.Force);

        _anim.SetFloat("Walk", _moveDirection.magnitude);
        //if (_moveDirection.magnitude > 0.1)
        //{
        //    Debug.Log("MovePlayer");
        //    OnMovement.Invoke();
        //}
        //else
        //{
        //    Debug.Log("stop");
        //    OnStopped.Invoke();
        //}
    }

    private void SpeedControl(float moveSpeed)
    {
        Vector3 flatVel = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel * moveSpeed;
            _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        _rb.AddForce(transform.up * _jumpForce, ForceMode.VelocityChange);
    }

    private void ResetJump()
    {
        _readyToJump = true;
    }
}