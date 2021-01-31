using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TouchController : MonoBehaviour
{
    [FormerlySerializedAs("DifX")] public float difX;
    
    private float _startPosX,_endposX;
    private float _dividedVal;
    private void Start()
    {
        _dividedVal = Screen.width / 18f;
    }

    private void Update()
    {
        OnTouch();
    }

    private void OnTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _endposX = Input.mousePosition.x;
            
            difX = (_startPosX - _endposX)/_dividedVal;
            _startPosX = _endposX;
        }
        if(Input.GetMouseButtonUp(0))
        {
            //startPosX = endposX = DifX = 0;
        }
    }
}