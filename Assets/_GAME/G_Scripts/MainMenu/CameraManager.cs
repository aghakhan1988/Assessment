using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject StartCamera;
    public GameObject SecondCamera;
    void Start()
    {
        SecondCamera.gameObject.SetActive(true);
        StartCamera.gameObject.SetActive(true);
    }
}
