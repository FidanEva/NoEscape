using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetPuzzleController : MonoBehaviour
{
    [SerializeField] private List<Transform> On;
    [SerializeField] private List<Transform> Off;
    [SerializeField] private List<Transform> All;
    [SerializeField] private int _correctCount;
    [SerializeField] private LayerMask _on;
    void Start()
    {
        foreach (var item in All)
        {

        }
       
        //foreach (var on in On)
        //{
        //    foreach (var off in Off)
        //    {
        //        //Debug.Log(off);
        //        if (on.gameObject.layer == 9 && off.gameObject.layer == 10)
        //        {
        //            Debug.Log("yes");
        //        }
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
    }
}
