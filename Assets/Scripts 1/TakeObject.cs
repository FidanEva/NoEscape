using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class TakeObject : MonoBehaviour
{
    [SerializeField] private Transform _holdTransform;
    private Collider[] _playerCollider;
    [SerializeField] private float _sphereRadius;
    [SerializeField] private LayerMask _playerLayer;
    void Start()
    {
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.6f, 0.0f, 0.0f, 0.6f);
        Gizmos.DrawSphere(transform.position, _sphereRadius);
    }
    void Update()
    {
        _playerCollider = Physics.OverlapSphere(transform.position, _sphereRadius, _playerLayer);
    }

    void OnMouseDown()
    {
        foreach (var item in _playerCollider)
        {
            if (item.CompareTag("Player"))
            {
                //Debug.Log(item.ToString());
                //Debug.Log("clicked");
                transform.parent = _holdTransform;
                //transform.localPosition = Vector3.zero;
                transform.DOLocalMove(Vector3.zero, 0.5f);
            }
        }
    }
}
