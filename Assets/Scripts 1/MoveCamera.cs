using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    //private Rigidbody _rb;

    //[SerializeField] private float _angVel;
    private void Start()
    {
        //PlayerMovement.instance.OnMovement += NullParent;
        //PlayerMovement.instance.OnStopped += ChangeParent;
        ////Debug.Log("onenable");

        //_rb = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody>();
    }

    //private void NullParent()
    //{
    //    if (_rb.angularVelocity.magnitude > _angVel)
    //    {
    //        transform.parent = null;
    //        Debug.Log("nullParent");
    //    }
    //}

    //private void ChangeParent()
    //{
    //    if (_rb.angularVelocity.magnitude <= _angVel)
    //    {
    //        transform.parent = cameraPosition.parent;
    //        Debug.Log("changeParent");
    //    }
    //}

    private void Update()
    {
        transform.position = cameraPosition.position;

        //if (_rb.angularVelocity.magnitude > _angVel)
        //{
        //    NullParent();
        //}
        //else
        //{
        //    ChangeParent();
        //}
    }
}
