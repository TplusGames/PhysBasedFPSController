using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform camHolder;
    [SerializeField] private Transform orientation;
    [SerializeField] private float sensitivity;
    [SerializeField] private float smoothSpeed;

    private Vector3 _targetRot;
    private float _lookX;
    private float _lookY;

    private void Update()
    {
        if (GameManager.Instance.CurrentGameState != EGameState.Standard) return;
        GetInput();
        RotateCamera();
    }

    private void GetInput()
    {
        var inputDir = InputManager.Instance.GetLookVector() * (sensitivity * Time.deltaTime);
        _lookX -= inputDir.y;
        _lookY += inputDir.x;

        _lookX = Mathf.Clamp(_lookX, -90, 90);
        
        _targetRot = new Vector3(_lookX, _lookY);
    }

    private void RotateCamera()
    {
        var newBodyRot = Quaternion.Euler(0, _targetRot.y, 0);
        orientation.rotation = Quaternion.Slerp(orientation.rotation, newBodyRot, smoothSpeed * Time.deltaTime);
        var newCameraRot = Quaternion.Euler(_lookX, _lookY, 0);
        camHolder.rotation = Quaternion.Slerp(camHolder.rotation, newCameraRot, smoothSpeed * Time.deltaTime);
    }

    public void SetTargetRot(Vector3 rot)
    {
        _targetRot = rot;
    }
}
