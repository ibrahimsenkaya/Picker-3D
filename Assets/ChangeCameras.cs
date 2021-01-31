using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ChangeCameras : MonoBehaviour
{
    [SerializeField] private GameObject maincam, SecondCam;

    public void ChangeCameraLevelEnd()
    {
        maincam.SetActive(false);

        SecondCam.SetActive(true);
    }

    public void ChangeCameraLevelStart()
    {
        maincam.SetActive(true);

        SecondCam.SetActive(false);
    }
}