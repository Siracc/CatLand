using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MoveController _moverController;


    [SerializeField] Transform _PlayerTransform;
    [SerializeField] float _playerSpeed, _jumpForce;
    [SerializeField] bool _isHorizontalActive, _isJumpActive, _isFlipActive;
    [SerializeField] Rigidbody2D _playerRigidbody2D;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _animator;
    private void Awake()
    {
        _moverController = new MoveController();
    }
    private void FixedUpdate()
    {
        Walk();
        Flip();

    }
    void Walk()
    {            
        _moverController.Horizontal(_PlayerTransform, _playerSpeed, _isHorizontalActive);           
        _animator.SetFloat("__walk", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    void Flip()
    {
        _moverController.Flip(_spriteRenderer, _isFlipActive);
    }

 
}
