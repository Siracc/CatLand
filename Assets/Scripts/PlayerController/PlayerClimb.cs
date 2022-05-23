using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{

    MoveController _moverController;

    [SerializeField] Transform _PlayerTransform;
    [SerializeField] float  _climSpeed;
    [SerializeField] bool  _isVerticalActive = false;

    private void Awake()
    {
        _moverController = new MoveController();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stairs"))
        {
            _isVerticalActive = true;
            _moverController.Vertical(_PlayerTransform, _climSpeed, _isVerticalActive);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stairs"))
        {
            _isVerticalActive = false;

        }
    }

}
