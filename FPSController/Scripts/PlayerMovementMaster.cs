using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementMaster : MonoBehaviour
{
    private Rigidbody _rb;
    private float _currentSpeed;
    private PlayerLocomotion _playerLocomotion;
    
    [SerializeField] private Transform orientation;
    [SerializeField] private float runSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundDrag;
    [SerializeField] private float airDrag;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        var info = new PlayerMovementInfo(runSpeed, sprintSpeed, jumpForce, groundDrag, airDrag, orientation, _rb);
        _playerLocomotion = new PlayerLocomotion(null, info);
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.CurrentGameState != EGameState.Standard) return;
        _playerLocomotion?.StateUpdate();
    }
}
