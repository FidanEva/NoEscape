using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    [SerializeField] private Transform _holdTransform;
    [SerializeField] private GameObject _takeObj;
    private Renderer _rend;

    [SerializeField] private Collider[] _playerCollider;
    [SerializeField] private float _sphereRadius;
    [SerializeField] private LayerMask _playerLayer;

    //private Collider _player;
    void Start()
    {
        //_takeObj = GameObject.FindWithTag("Takable");
        _rend = GetComponent<Renderer>();
    }

    void Update()
    {
        _playerCollider = Physics.OverlapSphere(transform.position, _sphereRadius, _playerLayer);

            if (_playerCollider.Length == 0)
            {
                _rend.enabled = false;
            }
        
    }
    private void OnMouseOver()
    {
        foreach (var item in _playerCollider)
        {
            if (item.CompareTag("Player") && _takeObj.transform.parent == _holdTransform)
            {
                _rend.enabled = true;
            }
        }
    }
    private void OnMouseExit()
    {
        foreach (var item in _playerCollider)
        {
            if (item.CompareTag("Player") && _takeObj.transform.parent == _holdTransform)
            {
                _rend.enabled = false;
            }
        }
    }
    private void OnMouseDown()
    {
        foreach (var item in _playerCollider)
        {
            if (item.CompareTag("Player") && _takeObj.transform.parent == _holdTransform)
            {
                _rend.enabled = false;
                _takeObj.transform.parent = null;
                var seq = DOTween.Sequence();
                seq.Append(_takeObj.transform.DOMove(transform.position, 0.5f)).OnComplete(() =>
                {
                    DoorSensor.instamce.OpenDoors();
                    _takeObj.transform.parent = _holdTransform;
                    _takeObj.transform.DOLocalMove(Vector3.zero, 0.5f);
                });
            }
        }
    }
}
