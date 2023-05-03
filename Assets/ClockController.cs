using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{

    public GameObject secondHand;
    public GameObject minuteHand;
    public GameObject hourHand;
    string oldSeconds;

    Vector3 _prevPos = Vector3.zero;
    Vector3 _posDelta = Vector3.zero;

    float mouseX, mouseY;
    float xRotation;
    float yRotation;
    //private void FixedUpdate()
    //{
    //    RaycastHit hit;
    //    Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.blue, 5);
    //    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5.0f))
    //    {
    //        if (Input.GetMouseButton(0) && ClickController._isHourHand)
    //        {
    //               // Debug.Log(Input.GetAxis("Mouse X"));
    //            //if (hit.transform.CompareTag("AnalogueClock"))
    //            //{

    //                //hourHand.transform.localRotation = Quaternion.Slerp(hourHand.transform.localRotation, Quaternion.LookRotation((Camera.main.transform.forward - hourHand.transform.position).normalized), Time.deltaTime * 50);

    //                //var lookPos = Camera.main.transform.position - hourHand.transform.position;
    //                //lookPos.y = 0;
    //                //var rotation = Quaternion.LookRotation(lookPos);
    //                //hourHand.transform.localRotation = Quaternion.Slerp(hourHand.transform.localRotation, rotation, Time.deltaTime * 50);
    //                // get mouse input
    //                mouseX = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 800;
    //                mouseY = Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * 800;

    //            if (hourHand.transform.localRotation.y > 20 && hourHand.transform.localRotation.y < 115)
    //            {
    //                yRotation -= mouseX;
    //                yRotation -= mouseY;
    //            }
    //            if (hourHand.transform.localRotation.y < 20 || hourHand.transform.localRotation.y > 290)
    //            {
    //                yRotation += mouseX;
    //                yRotation -= mouseY;
    //            }
    //            if (hourHand.transform.localRotation.y > 200 && hourHand.transform.localRotation.y < 290)
    //            {
    //                yRotation += mouseX;
    //                yRotation += mouseY;
    //            }
    //            if (hourHand.transform.localRotation.y > 115 && hourHand.transform.localRotation.y < 200)
    //            {
    //                yRotation -= mouseX;
    //                yRotation += mouseY;
    //            }
    //            hourHand.transform.localRotation = Quaternion.Euler(0, yRotation, 0);

    //                //hourHand.transform.Rotate(new Vector3(hourHand.transform.localRotation.x, (Camera.main.transform.position - hourHand.transform.position).y, hourHand.transform.localRotation.z), 0.5f);
    //                //Debug.Log(hit.transform.name);
    //                ////Debug.Log("blabla");
    //                //_posDelta = Input.mousePosition - _prevPos;

    //                ////if (Vector3.Dot(hourHand.transform.up, Vector3.up) >= 0)
    //                ////{
    //                //if (Input.GetAxis("Mouse X") > 0)
    //                //{
    //                //    //hourHand.transform.Rotate(hourHand.transform.up * Time.fixedDeltaTime * 50, -Vector3.Dot(_posDelta, Camera.main.transform.right), Space.World);
    //                //    hourHand.transform.Rotate(Vector3.up * Time.fixedDeltaTime * 50);
    //                //    Debug.Log("right");
    //                //}
    //                //else
    //                //{
    //                //    //hourHand.transform.Rotate(hourHand.transform.up * Time.fixedDeltaTime * 50, Vector3.Dot(_posDelta, Camera.main.transform.right), Space.World);
    //                //    hourHand.transform.Rotate(-Vector3.up * Time.fixedDeltaTime * 50);
    //                //    Debug.Log("left");
    //                //}

    //                //hourHand.transform.Rotate(Camera.main.transform.right, Vector3.Dot(_posDelta, Camera.main.transform.up), Space.World);




    //                //if (Input.GetAxis("Horizontal") > 0)
    //                //{
    //                //    hourHand.transform.Rotate(Vector3.up * Time.fixedDeltaTime * 50);
    //                //}

    //                //if (Input.GetAxis("Horizontal") < 0)
    //                //{
    //                //    hourHand.transform.Rotate(-Vector3.up * Time.fixedDeltaTime * 50);
    //                //}
    //            //}
    //            //_prevPos = Input.mousePosition;
    //        }
    //    }
    //}
    void Update()
    {

        transform.LookAt(Camera.main.transform.position);
        //string seconds = System.DateTime.UtcNow.ToString("ss");


        //if (seconds != oldSeconds)
        //{
        //    UpdateTimer();
        //}
        //oldSeconds = seconds;
    }

    //void UpdateTimer()
    //{

    //    int secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss"));
    //    int minutesInt = int.Parse(System.DateTime.UtcNow.ToString("mm"));
    //    int hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));
    //    print(hoursInt + " : " + minutesInt + " : " + secondsInt);

    //    secondHand.transform.DOLocalRotate(new Vector3(secondHand.transform.localRotation.x, secondsInt, secondHand.transform.localRotation.z), 1);
    //    //iTween.RotateTo(secondHand, iTween.Hash("y", secondsInt * 6 * -1, "time", 1, "easetype", "easeOutQuint"));
    //    iTween.RotateTo(minuteHand, iTween.Hash("y", minutesInt * 6 * -1, "time", 1, "easetype", "easeOutElastic"));
    //    float hourDistance = (float)(minutesInt) / 60f;
    //    iTween.RotateTo(hourHand, iTween.Hash("y", (hoursInt + hourDistance) * 360 / 12 * -1, "time", 1, "easetype", "easeOutQuint"));

    //}
}