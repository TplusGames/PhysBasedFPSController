using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    private Transform _cam;

    private void Start()
    {
        _cam = Camera.main.transform;
    }

    private void Update()
    {
        if (_cam == null) return;
        _cam.position = transform.position;
        _cam.rotation = transform.rotation;
    }
}
