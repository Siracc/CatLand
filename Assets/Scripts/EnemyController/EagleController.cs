using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _scale1, _scale2;
    bool MoveRight;

    private void FixedUpdate()
    {

        if (MoveRight)
        {

            transform.Translate(1 * Time.deltaTime * _speed, 0, 0);
            transform.localScale = new Vector2(_scale1, 1);


        }
        else
        {

            transform.Translate(-1 * Time.deltaTime * _speed, 0, 0);
            transform.localScale = new Vector2(_scale2, 1);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (MoveRight)
            {
                MoveRight = false;


            }
            else
            {
                MoveRight = true;

            }
        }
    }
}
