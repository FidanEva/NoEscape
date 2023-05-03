using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControler : MonoBehaviour
{
    [SerializeField] private Transform _playerCam;
    private Light _revealedLight;
    private Light _light;
    
    [SerializeField] private Light _revealedLightDirect;
    [SerializeField] private Light _lightDirect;

    void Start()
    {
        _playerCam= GameObject.FindObjectOfType<PlayerCam1>().transform;
        _light = transform.GetChild(1).GetComponent<Light>();
        _light.enabled = false;
        _revealedLight = transform.GetChild(0).GetComponent<Light>();
        _revealedLight.enabled = false;

        _revealedLightDirect = _revealedLightDirect.GetComponent<Light>();
        _revealedLightDirect.enabled = false;
        _lightDirect = _lightDirect.GetComponent<Light>();
        _lightDirect.enabled = true;

    }

    void Update()
    {
        transform.rotation = _playerCam.rotation;

        if (Input.GetKeyDown(KeyCode.L))
        {
            _light.enabled = !_light.enabled;
            _revealedLight.enabled = false;

            _lightDirect.enabled = !_lightDirect.enabled;
            _revealedLightDirect.enabled = false;

        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            _revealedLight.enabled = !_revealedLight.enabled;
            _light.enabled = !false;

            _lightDirect.enabled = false;
            _revealedLightDirect.enabled =!_revealedLightDirect.enabled;
        }

        if (!_revealedLightDirect.enabled)
        {
            _lightDirect.enabled = true;
        }
    }
}
