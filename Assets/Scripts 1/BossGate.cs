using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossGate : MonoBehaviour
{
    public static BossGate instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void OpenDoor()
    {
        transform.GetChild(0).DOLocalMoveZ(2, 0.5f);
        transform.GetChild(1).DOLocalMoveZ(-1.9f, 0.5f);
        Invoke("CloseDoor", 8.5F);
    }

    private void CloseDoor()
    {
        transform.GetChild(0).DOLocalMoveZ(0.6542773f, 0.5f);
        transform.GetChild(1).DOLocalMoveZ(-0.4665541f, 0.5f);
    }
}
