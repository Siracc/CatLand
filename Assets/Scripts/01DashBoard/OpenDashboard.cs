using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDashboard : MonoBehaviour
{
    [SerializeField] GameObject _infoImage;

    public void InfoOpenOnClick()
    {
        _infoImage.SetActive(true);
    }

    public void InfoCloseOnClick()
    {
        _infoImage.SetActive(false);
    }
}
