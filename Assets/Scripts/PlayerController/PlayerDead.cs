using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            SceneManager.LoadScene(1);
        }
        if (collision.gameObject.CompareTag("Gulle"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
