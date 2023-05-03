using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSensor : MonoBehaviour
{
    public static DoorSensor instamce;
    private void Awake()
    {
        if (instamce == null)
        {
            instamce = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //OpenDoors();
                    transform.parent.GetChild(0).DOLocalMoveY(-2f, 0.5f);
        transform.parent.GetChild(1).DOLocalMoveY(-5.5f, 0.5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseDoors();
        }
    }

    public void OpenDoors()
    {
        transform.parent.GetChild(0).DOLocalMoveY(-2f, 0.5f);
        transform.parent.GetChild(1).DOLocalMoveY(-5.5f, 0.5f);

        Invoke("CloseDoors", 5);
    }

    private void CloseDoors()
    {
        transform.parent.GetChild(0).DOLocalMoveY(-3.523749f, 0.5f);
        transform.parent.GetChild(1).DOLocalMoveY(-3.523749f, 0.5f);
    }
}
