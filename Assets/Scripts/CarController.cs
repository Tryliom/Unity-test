using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _rotationSpeed = 180f;
    
    [SerializeField] private GameObject _wheelBackLeft;
    [SerializeField] private GameObject _wheelBackRight;
    [SerializeField] private GameObject _wheelFrontLeft;
    [SerializeField] private GameObject _wheelFrontRight;
    
    private Rigidbody _rigidbody;
    
    private Vector3 _direction;
    private Vector3 _rotation;
    private bool _hasWin = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = Vector3.zero;
        _rotation = Vector3.zero;
        
        if (_hasWin)
        {
            return;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            _rotation = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rotation = Vector3.up;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            _direction = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _direction = Vector3.back;
            _rotation *= -1;
        }
    }

    private void FixedUpdate()
    {
        var speedPerSecond = _speed * Time.deltaTime;
        var rotationPerSecond = _rotationSpeed * Time.deltaTime;
        
        _rigidbody.velocity += transform.TransformDirection(_direction * speedPerSecond);
        
        if (_direction != Vector3.zero)
        {
            _rigidbody.rotation = Quaternion.Euler(_rigidbody.rotation.eulerAngles + _rotation * rotationPerSecond);
        }
        
        // Rotate wheels corresponding to the direction of the rotation
        /*if (_rotation == Vector3.down)
        {
            _wheelBackLeft.transform.Rotate(Vector3.forward * 45f);
            _wheelBackRight.transform.Rotate(Vector3.forward * 45f);
        }
        else if (_rotation == Vector3.up)
        {
            _wheelFrontLeft.transform.Rotate(Vector3.forward * 45f);
            _wheelFrontRight.transform.Rotate(Vector3.forward * 45f);
        }*/
    }

    public void Win()
    {
        _hasWin = true;
        
        Debug.Log("You win!");
    }
}
