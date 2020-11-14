using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FlickeringLight : MonoBehaviour
{
    private Light _lampLight;
    private void Start()
    {
        _lampLight = GetComponent<Light>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _lampLight.enabled = !_lampLight.enabled;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name != "Player") return;
        _lampLight.enabled = !_lampLight.enabled;
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name != "Player") return;
        if (_lampLight.enabled) return;
        _lampLight.enabled = true;
    }

}
