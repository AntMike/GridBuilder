using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class ModeSwitchController : MonoBehaviour
{
    private bool _isPersonView = false;

    [SerializeField] private CinemachineVirtualCamera buildCamera;
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private MouseHandler mouseHandler;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CameraTarget cameraTarget;

    [SerializeField] private TMP_Text text;

    public void Close()
    {
        Application.Quit();
    }

    public void SwitchMode()
    {
        if (_isPersonView)
        {
            SwitchToBuild();
        }
        else
        {
            SwitchToPerson();
        }
    }
    
    private void SwitchToPerson()
    {
        _isPersonView = true;
        text.text = "Pers";
        Cursor.lockState = CursorLockMode.Confined;
        GridBuildingSystem3D.Instance.SwitchToPerson();
        Mouse3D.Instance.canCalculate = false;
        cameraTarget.canMove = false;
        mouseHandler.canMove = true;
        playerController.canMove = true;
        playerCamera.Priority = 10;
        buildCamera.Priority = 1;
    }
    
    private void SwitchToBuild()
    {
        _isPersonView = false;
        text.text = "Build";
        Cursor.lockState = CursorLockMode.None;
        GridBuildingSystem3D.Instance.SwitchToBuild();
        Mouse3D.Instance.canCalculate = true;
        cameraTarget.canMove = true;
        mouseHandler.canMove = false;
        playerController.canMove = false;
        playerCamera.Priority = 1;
        buildCamera.Priority = 10;
    }
}
