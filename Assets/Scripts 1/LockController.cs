using CASP.CameraManager;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LockController : MonoBehaviour
{
    private bool _isWinned = false;
    void Start()
    {

    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.black, 5);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5.0f))
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.gameObject.layer == 8)
            {
                Vector3 currentAngle = hit.transform.eulerAngles;
                if (Input.GetAxis("Mouse ScrollWheel") > 0f && ClickController._isScrolled)
                {
                    //hit.transform.DORotate(new Vector3(hit.transform.rotation.x, hit.transform.rotation.y, hit.transform.rotation.z - 36.0f), 0.5f);

                    currentAngle = new Vector3(
                        Mathf.LerpAngle(currentAngle.x, currentAngle.x, Time.deltaTime * 50),
                        Mathf.LerpAngle(currentAngle.y, currentAngle.y, Time.deltaTime * 50),
                        Mathf.LerpAngle(currentAngle.z, currentAngle.z - 12, Time.deltaTime * 50));
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0f && ClickController._isScrolled)
                {
                    //hit.transform.Rotate(new Vector3(hit.transform.rotation.x, hit.transform.rotation.y, hit.transform.rotation.z + 36.0f));

                    currentAngle = new Vector3(
                        Mathf.LerpAngle(currentAngle.x, currentAngle.x, Time.deltaTime * 50),
                        Mathf.LerpAngle(currentAngle.y, currentAngle.y, Time.deltaTime * 50),
                        Mathf.LerpAngle(currentAngle.z, currentAngle.z + 12, Time.deltaTime * 50));
                }

                //Debug.Log(currentAngle.z);

                hit.transform.eulerAngles = currentAngle;

            }
        }

        //252 288 72
        //3 2 9
        if (GameObject.FindWithTag("Left").transform.eulerAngles.z == 252 &&
            GameObject.FindWithTag("Middle").transform.eulerAngles.z == 288 &&
            GameObject.FindWithTag("Right").transform.eulerAngles.z == 36 && !_isWinned)
        {
            Invoke("OpenCase", 1);
            _isWinned = true;
        }

    }

    void OpenCase()
    {
        Debug.Log("Win");
        ClickController.instance.PlayerMode();
        //ClickController.isZoomIn = false;
        //CameraManager.instance.OpenCamera("PlayerCam", 1, CameraEaseStates.Linear);
        Invoke("RotateDoors", 1);
    }

    private void RotateDoors()
    {
        transform.parent.DOLocalRotate(new Vector3(0, -30, 0), 0.7f);
        transform.parent.parent.GetChild(0).DOLocalRotate(new Vector3(0, -210, 0), 0.7f);        
    }
}
