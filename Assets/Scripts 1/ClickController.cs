using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using CASP.CameraManager;
using Cinemachine;
using UnityEditor.PackageManager;

public class ClickController : MonoBehaviour
{
    public static ClickController instance;
    public event Action OnClickChest;
    public event Action OnClickLock;
    public event Action OnClickAnalogueClock;
    //[SerializeField] private Collider[] _playerCollider;
    //[SerializeField] private float _sphereRadius;
    //[SerializeField] private LayerMask _playerLayer;
    //private Transform _playerCam;

    public static bool isZoomIn = false;
    private bool _isDown = true;

    [SerializeField] private Transform _holdTransform;
    [SerializeField] private GameObject _bossDoorLeft, _bossDoorRight;
    //Ray ray;
    //RaycastHit hit;

    //[SerializeField] private CinemachineVirtualCamera _cam;

    public static bool _isScrolled = false;

    public static bool _isHourHand = false;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //_playerCam = FindObjectOfType<PlayerCam1>().transform;
        //_cam = FindObjectOfType<CinemachineVirtualCamera>();
    }
    void FixedUpdate()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward, Color.black, 5);
        if (Input.GetMouseButtonDown(0))
        {
            //if (Physics.Raycast(ray, out hit, 2f))
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3.0f))
            {
                if (hit.transform.CompareTag("Chest") && !isZoomIn)
                {
                    OnClickChest.Invoke();
                    transform.DOMove(hit.transform.position, 0.5f);

                    ZoomIn("ChestCam");

                }
                if (hit.transform.CompareTag("Lock") && !isZoomIn)
                {
                    ZoomIn("LockCam");
                    OnClickLock.Invoke();
                    _isScrolled = true;
                    //if (Input.GetMouseButtonDown(0))
                    //{
                    //    if (hit.transform.CompareTag("Numbers"))
                    //    {
                    //        Debug.Log("numbers");
                    //    }
                    //}
                }

                if (hit.transform.CompareTag("SheetPart"))
                {
                    Debug.Log(hit.transform.GetChild(0).transform.localRotation.eulerAngles.z);
                    //Debug.Log(hit.transform.GetChild(0).transform.localRotation.z);
                    //if (hit.transform.GetChild(0).transform.localRotation.eulerAngles.z == 0)
                    //{
                    if(_isDown)
                    { 
                        Debug.Log("0");
                        Invoke("DownBool", 0.5f);
                        //_isDown= false;
                        //hit.transform.GetChild(0).tag= "SheetOn";
                        hit.transform.GetChild(0).gameObject.layer = 9;
                        hit.transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 0, 270), 0.5f);
                    }
                    //if (hit.transform.GetChild(0).transform.localRotation.eulerAngles.z == 270)
                    //{
                    if(!_isDown)
                    { 
                        Debug.Log("-90");
                        Invoke("DownBool", 0.5f);
                        //hit.transform.GetChild(0).tag = "SheetOff";
                        hit.transform.GetChild(0).gameObject.layer = 10;

                        //_isDown= true;
                        hit.transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
                    }
                }

                if (hit.transform.CompareTag("GateOneKey"))
                {
                    BossGate.instance.OpenDoor();
                }

                if (hit.transform.CompareTag("AnalogueClock"))
                {
                    ZoomIn("AnalogueClockCam");
                    //CameraManager.instance.OpenCamera("AnalogueClockCam", 0.5f, CameraEaseStates.EaseInOut);
                    OnClickAnalogueClock.Invoke();
                    _isHourHand= true;
                }

                if (hit.transform.CompareTag("Takable") && _isDown)
                {
                    //Debug.Log("takable");
                    hit.transform.parent = _holdTransform;
                    //_isParent= true;
                    Invoke("DownBool", 0.5f);

                    //if(hit.transform.GetComponent<Rigidbody>())
                    //{
                    //    Debug.Log("rigidody");
                    //    hit.transform.GetComponent<Rigidbody>().detectCollisions = false;
                    //}
                }
                if (GameObject.FindWithTag("Takable").transform.parent == _holdTransform && !_isDown)
                {
                    //Debug.Log("round");
                    GameObject.FindWithTag("Takable").transform.parent = null;
                    //_isParent= false;
                    Invoke("DownBool", 0.5f);

                    //GameObject.FindWithTag("Takable").transform.GetComponent<Rigidbody>().detectCollisions = true;
                }
            }
        }
    }
    //IEnumerator TakedObjectPosition(Transform hit)
    //{
    //    Debug.Log("ienumer");
    //    yield return new WaitForSeconds(0.5f);
    //    hit.localPosition = Vector3.zero;
    //}
    private void DownBool()
    {
        _isDown = !_isDown;
    }
    void ZoomIn(string camName)
    {
        isZoomIn = true;
        CameraManager.instance.OpenCamera(camName, 1, CameraEaseStates.EaseInOut);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerMode();
            _isScrolled = false;
            _isHourHand= false;
        }
    }

    public void PlayerMode()
    {
        isZoomIn = false;
        CameraManager.instance.OpenCamera("PlayerCam", 1, CameraEaseStates.Linear);
    }
}
