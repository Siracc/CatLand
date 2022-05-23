using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundCheck : MonoBehaviour
{
    MoveController _moverController;

    [SerializeField] Transform[] _translates;
    [SerializeField] Rigidbody2D _playerRigidbody2D;
    [SerializeField] Animator _animator;
    [SerializeField] bool _isOnGround = false;
    [SerializeField] bool  _isJumpActive;
    [SerializeField] float _maxDistance, _jumpForce;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] bool _isSpaceControl;
    public bool IsOnGround => _isOnGround;

    private void Awake()
    {
        _moverController = new MoveController();
    }


    void Update()
    {
        if (_isOnGround & Input.GetButtonDown("Jump"))
        {
            _isSpaceControl = true;
        }

        foreach (Transform footTransform in _translates)
        {
            CheckFoodOnGround(footTransform);
            if (_isOnGround) break;
        }
    }

    private void FixedUpdate()
    {
        jump();
 
    }

    void jump()
    {
        if (_isSpaceControl)
        {
            _moverController.Jump(_playerRigidbody2D, _jumpForce, _isJumpActive);
            _animator.SetBool("__jump", true);
            
        }
        _isSpaceControl = false;

        if (!_isOnGround) 
        { 
           _animator.SetBool("__jump", false); 
        }
    }

    void CheckFoodOnGround(Transform _footTransfom)
    {
        RaycastHit2D hit = Physics2D.Raycast(_footTransfom.position, _footTransfom.forward, _maxDistance, _layerMask);
        Debug.DrawRay(_footTransfom.position, _footTransfom.forward * _maxDistance, Color.blue);

        if (hit.collider != null)
        {
            _isOnGround = true;
 
        }
        else
        { 
            _isOnGround = false;           
        }
    }
}
