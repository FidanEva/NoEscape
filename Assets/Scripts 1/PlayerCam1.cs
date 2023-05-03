using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam1 : MonoBehaviour
{
    public float sensX;
    public float sensY;

    float mouseX, mouseY;
    public Transform orientation;

    float xRotation;
    float yRotation;

    float CxRotation;
    float CyRotation;

    float LxRotation;
    float LyRotation;

    float ACxRotation;
    float ACyRotation;

    //[SerializeField] private Transform _chestController;

    //[SerializeField] private GameObject _chestCam;
    [SerializeField] private GameObject _lockCam;
    [SerializeField] private GameObject _analClockCam;

    private void Start()
    {
        ClickController.instance.OnClickLock += LockRotation;
        ClickController.instance.OnClickChest += ChestRotation;
        ClickController.instance.OnClickAnalogueClock += AnalogueClockRotation;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //_chestController = FindObjectOfType<ChestController>().transform;
        //_chestCam = GameObject.FindWithTag("ChestCam");
    }
    private void FixedUpdate()
    {
        // get mouse input
        mouseX = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * sensX;
        mouseY = Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        if (!ClickController.isZoomIn)
        {

            xRotation = Mathf.Clamp(xRotation, -45f, 45f);
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        else
        {
            //CyRotation += mouseX;
            //CxRotation -= mouseY;

            //CxRotation = Mathf.Clamp(CxRotation, 30f, 60f);
            //CyRotation = Mathf.Clamp(CyRotation, -5f, 5f);

            //_chestCam.transform.rotation = Quaternion.Euler(CxRotation, CyRotation, 0);
            //Debug.Log("else");
            ChestRotation();
            //_lockCam.transform.rotation = Quaternion.Euler(CxRotation, CyRotation + 90, 0);
            LockRotation();

            AnalogueClockRotation();
        }
    }

    private void AnalogueClockRotation()
    {
        ACyRotation += mouseX;
        ACxRotation -= mouseY;

        ACxRotation = Mathf.Clamp(ACxRotation, 10f, 25f);
        ACyRotation = Mathf.Clamp(ACyRotation, -5f, 15f);

        _analClockCam.transform.rotation = Quaternion.Euler(ACxRotation, ACyRotation, 0);
    }

    private void ChestRotation()
    {
        CyRotation += mouseX;
        CxRotation -= mouseY;

        CxRotation = Mathf.Clamp(CxRotation, 30f, 60f);
        CyRotation = Mathf.Clamp(CyRotation, -15f, 15f);

        //_chestCam.transform.rotation = Quaternion.Euler(CxRotation, CyRotation, 0);
    }

    private void LockRotation()
    {
        LyRotation += mouseX;
        LxRotation -= mouseY;

        LxRotation = Mathf.Clamp(LxRotation, 10f, 25f);
        LyRotation = Mathf.Clamp(LyRotation, -10f, 10f);

        _lockCam.transform.rotation = Quaternion.Euler(LxRotation, LyRotation - 90, 0);
    }

}